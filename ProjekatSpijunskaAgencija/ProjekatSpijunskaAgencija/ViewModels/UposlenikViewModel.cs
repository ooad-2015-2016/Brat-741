﻿using KompShopMVVM.KompShop.Helper;
using Microsoft.Maker.RemoteWiring;
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

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public ICommand DodajUposlenika { get; set; }
        public ICommand AnalizirajIzvjestaj { get; set; }
        public ICommand Trzni { get; set; }
        public ICommand Register { get; set; }
        public Uposlenik Uposlenik { get { return uposlenik; } set { uposlenik = value; NotifyPropertyChanged("Uposlenik"); NotifyPropertyChanged("kontaktInfo"); } }

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
            splitView = new SplitViewModel();
            DodajUposlenika = new RelayCommand<object>(dodajUposlenika, mozeLiSeDodatiUposlenik);
            AnalizirajIzvjestaj = new RelayCommand<object>(analizirajIzvjestaj, mozeLiSeAnaliziratiIzvjestaj);
            Trzni = new RelayCommand<object>(trzni);
            Register = new RelayCommand<object>(register);
        }
        public UposlenikViewModel()
        {
            Uposlenik = new Uposlenik();
            externi();
            Setup();
        }
        public UposlenikViewModel(Uposlenik parameter) 
        {
            Uposlenik = new Uposlenik()
            {
                idBroj = parameter.idBroj,
                username = parameter.username,
                sifra = parameter.sifra,
                kontaktInfo = parameter.kontaktInfo,
                nivoPristupa = parameter.nivoPristupa,
                plata = parameter.plata
            };
           
            Uposlenik = parameter;
            Setup();
            externi();
        }
        #endregion
        public void register(object parameter)
        {
            DataSourceSA.dodajUposlenika(uposlenik);
            DataSourceSA.zapisiPodatke();
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
                    email = "Amar@Cigra.kralj",
                    brojTel = "3456"
                }
            };
        }
        public void externi()
        {
            if (App.Arduino != null)
            {
                App.Arduino.digitalWrite(3, (((int)(uposlenik.nivoPristupa)) >= 0) ? PinState.HIGH : PinState.LOW);
                App.Arduino.digitalWrite(4, (((int)(uposlenik.nivoPristupa)) >= 1) ? PinState.HIGH : PinState.LOW);
                App.Arduino.digitalWrite(5, (((int)(uposlenik.nivoPristupa)) >= 2) ? PinState.HIGH : PinState.LOW);
            }
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
