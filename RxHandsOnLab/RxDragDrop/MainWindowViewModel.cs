using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RxDragDrop
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Photos = new ObservableCollection<Image>();
            
        }
        public ObservableCollection<Image> Photos { get; set; }
    }
}
