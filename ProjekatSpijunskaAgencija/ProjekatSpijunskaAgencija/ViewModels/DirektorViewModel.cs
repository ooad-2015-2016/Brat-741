using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class DirektorViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }

        private string nazivAgencije;
        private Direktor direktor;

        public Direktor Direktor { get { return direktor; } set { direktor = value; NotifyPropertyChanged("Direktor"); } }
        public string NazivAgencije { get { return nazivAgencije; } set { nazivAgencije = value; NotifyPropertyChanged("NazivAgencije"); } }

        private ObservableCollection<object> trenutnaLista;
        public ObservableCollection<object> TrenutnaLista { get { return trenutnaLista; } set { trenutnaLista = value; NotifyPropertyChanged("TrenutnaLista"); } }


        public ICommand KontaktInfo { get; set; }
        public ICommand PrikaziUposlenike { get; set; }
        public ICommand PrikaziIzvjestaje { get; set; }
        public ICommand PrikaziMisije { get; set; }


        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void kontaktInfo(object parameter)
        {
            NavigationService.Navigate(typeof(KontaktView), new KontaktViewModel(direktor.kontaktInfo));
        }
        private void prikaziUposlenike(object parameter)
        {
            //TrenutnaLista = new ObservableCollection<object>(DataSourceSA.dajSveUposlenike());
            TrenutnaLista = new ObservableCollection<object>(new List<Uposlenik>() {
                new Uposlenik() { username = "Ibro", idBroj=1, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"} },
                new Uposlenik() { username = "Mijo", idBroj=2, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"}},
                new Uposlenik() { username = "Safet", idBroj=3, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"}},
                new Uposlenik() { username = "Dimko", idBroj=4, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"}},
                new Uposlenik() { username = "Talicnitom", idBroj=5, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"}},
                new Uposlenik() { username = "MawaSwatka95", idBroj=6, sifra="1234", kontaktInfo = new Contact(){ ime = "Dirka", prezime = "Ibro"}}
            });
        }
        private void prikaziMisije(object parameter)
        {
            TrenutnaLista = new ObservableCollection<object>(new List<Misija>() {
                new Misija()
                {
                    budzet=4541,
                    izvjestaji=direktor.izvjestaji,
                    mete=null,
                    hashID="154515dada54",
                    radnaGrupa=null
                },
                new Misija()
                {
                    budzet=4510,
                    izvjestaji=direktor.izvjestaji,
                    mete=null,
                    hashID="154515dada54",
                    radnaGrupa=null
                },
                new Misija()
                {
                    budzet=4514,
                    izvjestaji=direktor.izvjestaji,
                    mete=null,
                    hashID="154515dada54",
                    radnaGrupa=null
                }
        });
        }
        private void prikaziIzvjestaje(object parameter)
        {
            TrenutnaLista = new ObservableCollection<object>(direktor.izvjestaji);
        }

        private void Setup()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
            KontaktInfo = new RelayCommand<object>(kontaktInfo);
            PrikaziUposlenike = new RelayCommand<object>(prikaziUposlenike);
            PrikaziIzvjestaje = new RelayCommand<object>(prikaziIzvjestaje);
            PrikaziMisije = new RelayCommand<object>(prikaziMisije);
        }
        public DirektorViewModel(Direktor direktor)
        {
            this.direktor = direktor;
            Setup();
        }
        public DirektorViewModel()
        {
            Setup();
        }
    }
}
