using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class UposlenikViewModel : INotifyPropertyChanged
    {
        //UposlenikViewModel ima brigu i o generalisanom Uposlenik view-u i o view-ima koji se ticu registracije novih uposlenika
        private Uposlenik uposlenik;
        public ICommand DodajUposlenika { get; set; }
        public ICommand AnalizirajIzvjestaj { get; set; }
        public ICommand Trzni { get; set; }
        public ICommand Register { get; set; }

        public Uposlenik Uposlenik { get { return uposlenik; } set { uposlenik = value; NotifyPropertyChanged("Uposlenik"); } }

        public INavigationService NavigationService { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        #region Konstruktori, ukljucujuci i metodu Setup kako bi se izbjeglo suvisno ponavljanje
        public void Setup()
        {
            NavigationService = new NavigationService();
            DodajUposlenika = new RelayCommand<object>(dodajUposlenika, mozeLiSeDodatiUposlenik);
            AnalizirajIzvjestaj = new RelayCommand<object>(analizirajIzvjestaj, mozeLiSeAnaliziratiIzvjestaj);
            Trzni = new RelayCommand<object>(trzni);
            Register = new RelayCommand<object>(register);
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
        public void register(object parameter)
        {
            DataSourceSA.dodajUposlenika(uposlenik);
        }
        public void trzni(object parameter)
        {
            Uposlenik = new Uposlenik()
            {
                idBroj = 45,
                kontaktInfo = new Contact()
                {
                    ime = "Test",
                    prezime = "Pls Work",
                    email = "@Cigra.kralj",
                    brojTel = "3456"
                }
            };
        }
        public void analizirajIzvjestaj(object parameter)
        {
            NavigationService.Navigate(typeof(IzvjestajView), uposlenik);
        }
        public void dodajUposlenika(object parameter)
        {
            NavigationService.Navigate(typeof(UposlenikView), uposlenik);
        }

        #region moze li ovo, moze li ono. Ma sve moze, wuhuuu :D
        public bool mozeLiSeAnaliziratiIzvjestaj(object parameter)
        {
            return true;
        }
        public bool mozeLiSeDodatiUposlenik(object parameter)
        {
            return true;
        }
        #endregion
    }
}
