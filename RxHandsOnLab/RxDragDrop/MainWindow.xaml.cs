using System;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

namespace RxDragDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(MainWindowViewModel viewModel):this()
        {

            viewModel.Photos.CollectionChanged += Photos_CollectionChanged;



            WireUIElementForDragAndDrop(this.image1, p => { return IsInBounds(p); });
            WireUIElementForDragAndDrop(this.image2, p => { return IsInBounds(p); });

            output.TextChanged += output_TextChanged;
        }


        private bool IsInBounds(Rect r)
        {
            var bounds = new Rect(0,0, this.mainCanvas.ActualWidth, this.mainCanvas.ActualHeight);
            return bounds.Contains(r);
        }

        private void Photos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                WireUIElementForDragAndDrop((FrameworkElement)item, p => { return IsInBounds(p); });
            }
        }

        private void WireUIElementForDragAndDrop(FrameworkElement target, Func<Rect, bool> isInBounds)
        {
            Point origin = default(Point);

            var mouseDown = Observable.FromEventPattern<MouseButtonEventArgs>(target, "MouseDown");
            mouseDown.Subscribe(p => 
            {
                target.CaptureMouse();
                origin = p.EventArgs.GetPosition(target); 
            });

            var mouseUp = Observable.FromEventPattern<MouseButtonEventArgs>(target, "MouseUp")
                .Publish();

            var mouseLeave = Observable.FromEventPattern<MouseEventArgs>(target, "MouseLeave")
                .Publish();

            //hot observables
            mouseUp.Connect();
            mouseLeave.Connect();


            var mouseMove = Observable.FromEventPattern<MouseEventArgs>(target, "MouseMove");
            //var mouseHitTest = Observable.Create(mouseMove =>
            //    {
            //        return Task.Factory.StartNew<Action>(p => { return true; });
            //    });

            var mouseUpOrLeave = Observable.CombineLatest(mouseUp, mouseLeave, (a, b) => { return true; });
            mouseUpOrLeave
                .Do(_ => Console.WriteLine("MouseUpOrLeave fired {0}", Guid.NewGuid()))
                .Subscribe(p => { target.ReleaseMouseCapture(); });

            mouseMove
                .Select(x => x.EventArgs.GetPosition(target))
                .SkipUntil(mouseDown).Repeat()
                .TakeUntil(mouseUpOrLeave).Repeat()
                .Subscribe(p=> {
                    var dX = p.X - origin.X;
                    var dY = p.Y - origin.Y;
                    var moveTo = new Point(Canvas.GetLeft(target)+ dX, Canvas.GetTop(target)+ dY);
                    if (isInBounds(new Rect(moveTo, new Point(moveTo.X + target.ActualWidth, moveTo.Y + target.ActualHeight))))
                    {
                        Canvas.SetTop(target, moveTo.Y);
                        Canvas.SetLeft(target, moveTo.X);
                    }
                }); 
        }

        private void output_TextChanged(object sender, TextChangedEventArgs e)
        {
            output.ScrollToEnd();
        }
    }
}
