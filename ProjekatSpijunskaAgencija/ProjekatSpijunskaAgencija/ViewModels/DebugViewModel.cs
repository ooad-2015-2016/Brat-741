using KompShopMVVM.KompShop.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class DebugViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public DebugViewModel()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
    }
}
