using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RxDragDrop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWinViewModel = new MainWindowViewModel();
            var mainWid = new MainWindow(mainWinViewModel);

            //var img = new Image()
            //{
            //    Source = new BitmapImage(new Uri(@"C:\Users\phil.SONOCINE\Pictures\image001.png"))
            //};
            //mainWinViewModel.Photos.Add(img);

            mainWid.Show();
        }
    }
}
