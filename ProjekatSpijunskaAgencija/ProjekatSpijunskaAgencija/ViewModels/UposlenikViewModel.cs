using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class UposlenikViewModel
    {
        public Uposlenik uposlenik { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand DodajUposlenika { get; set; }

        public UposlenikViewModel()
        {
            uposlenik = new Uposlenik();
            NavigationService = new NavigationService();
            DodajUposlenika = new RelayCommand<object>(dodajUposlenika, mozeLiSeDodatiUposlenik);
        }
        public bool mozeLiSeDodatiUposlenik(object parameter)
        {
            return true;
        }
        public void dodajUposlenika(object parameter)
        {
            NavigationService.Navigate(typeof(UposlenikRegisterView), new Uposlenik());
        }
    }
}
