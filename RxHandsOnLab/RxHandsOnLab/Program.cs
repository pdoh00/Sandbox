using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace RxHandsOnLab
{
    class Program
    {
        private const int KeyPressThresholdMilliSec = 200;
        static void Main(string[] args)
        {
            //var txt = new TextBox();

            var frm = new System.Windows.Forms.Form()
            {
                //Controls = { txt }
            };

            var disposables = new List<IDisposable>();

            var t = TimeSpan.FromMilliseconds(KeyPressThresholdMilliSec);
            //Hook up fast forward
            var upRightArrow = Observable.FromEventPattern<KeyEventArgs>(frm, "KeyUp")
                .Where(x => x.EventArgs.KeyCode == Keys.Right);

            upRightArrow.Subscribe(x =>
            {
                Console.WriteLine("FastForward STOP");
            });

            var downRightArrow = Observable.FromEventPattern<KeyEventArgs>(frm, "KeyDown")
                .Where(x => x.EventArgs.KeyCode == Keys.Right)
                .Take(1)
                .Concat(upRightArrow.Take(1).IgnoreElements())
                .Repeat();

            //hook up frame increment
            var tapFastForward = downRightArrow.SelectMany(x =>
                Observable.Amb(
                    Observable.Empty<EventPattern<KeyEventArgs>>().Delay(t),
                    upRightArrow.Take(1)
                ))
                .Publish()
                .RefCount();

            tapFastForward.Subscribe(x =>
            {
                Console.WriteLine("Increment Frame");
            });

            var longPressFastForward = downRightArrow.SelectMany(x =>
                Observable.Return(x).Delay(t).TakeUntil(tapFastForward)
                ).Subscribe(x =>
                {
                    Console.WriteLine("FastForward GO");
                });

            using (new CompositeDisposable(disposables))
            {
                Application.Run(frm);
            }
        }
    }
}
