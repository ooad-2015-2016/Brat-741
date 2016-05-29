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

        #region Konstruktori, ukljucujuci i metodu Setup kako bi se izbjeglo suvisno ponavljanje
        public void Setup()
        {
            NavigationService = new NavigationService();
            DodajUposlenika = new RelayCommand<object>(dodajUposlenika, mozeLiSeDodatiUposlenik);
        }
        public UposlenikViewModel()
        {
            uposlenik = new Uposlenik();
            Setup();
        }
        public UposlenikViewModel(Uposlenik parameter) 
        {
            uposlenik = parameter;
            Setup();
        }
        #endregion

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
