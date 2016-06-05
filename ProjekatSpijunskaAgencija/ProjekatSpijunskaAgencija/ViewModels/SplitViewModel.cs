using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    public class SplitViewModel : INotifyPropertyChanged
    {
        private bool isPaneOpen;
        public bool IsPaneOpen { get { return isPaneOpen; } set { isPaneOpen = value; NotifyPropertyChanged("IsPaneOpen"); NotifyPropertyChanged("SplitViewModel"); } }
        public INavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void back(object sender)
        {
            var frame = (Frame)Window.Current.Content;
            if (NavigationService.CanGoBack() == true)
            {
                NavigationService.GoBack();
            }
        }

        private void hamburger(object sender)
        {

            IsPaneOpen = !IsPaneOpen;
        }

        private void home(object sender)
        {
            if (NavigationService.GetType() != typeof(LoginView))
            {
                NavigationService.Navigate(typeof(LoginView));
            }
        }

        private void friends(object sender)
        {
            if (NavigationService.GetType() != typeof(UposlenikView))
            {
                NavigationService.Navigate(typeof(UposlenikView));
            }
        }

        public ICommand Back { get; set; }
        public ICommand Hamburger { get; set; }
        public ICommand Home { get; set; }
        public ICommand Friends { get; set; }
        private void Setup()
        {
            Back = new RelayCommand<object>(back);
            Hamburger = new RelayCommand<object>(hamburger);
            Home = new RelayCommand<object>(home);
            Friends = new RelayCommand<object>(friends);
        }
        public SplitViewModel()
        {
            NavigationService = new NavigationService();
            this.Setup();
        }
        public SplitViewModel(NavigationService navService)
        {
            this.Setup();
            NavigationService = navService;
        }
    }
}
