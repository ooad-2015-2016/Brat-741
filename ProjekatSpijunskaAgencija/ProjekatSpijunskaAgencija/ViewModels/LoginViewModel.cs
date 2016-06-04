using KompShopMVVM.KompShop.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }
        public NavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        public LoginViewModel()
        {
            NavigationService = new NavigationService();
            NavigationService.SetCanGoBack(false);
            splitView = new SplitViewModel(NavigationService);
        }
    }
}
