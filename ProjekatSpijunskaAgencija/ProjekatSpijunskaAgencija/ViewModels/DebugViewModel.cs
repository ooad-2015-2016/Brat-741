using KompShopMVVM.KompShop.Helper;
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
    class DebugViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public ICommand DirektorView { get; set; }
        public ICommand IzvjestajView { get; set; }
        public ICommand KlijentView { get; set; }
        public ICommand KontaktView { get; set; }
        public ICommand LoginView { get; set; }
        public ICommand MenadzerView { get; set; }
        public ICommand MisijaView { get; set; }
        public ICommand TimView { get; set; }
        public ICommand UposlenikView { get; set; }

        private void direktorView(object sender)  { NavigationService.Navigate(typeof(DirektorView),  new DirektorViewModel(direktor)); }
        private void izvjestajView(object sender) { NavigationService.Navigate(typeof(IzvjestajView), new IzvjestajViewModel(izvjestaj)); }
        private void klijentView(object sender)   { NavigationService.Navigate(typeof(KlijentView),   new KlijentViewModel(klijent)); }
        private void kontaktView(object sender)   { NavigationService.Navigate(typeof(KontaktView),   new KontaktViewModel(kontakt)); }
        private void loginView(object sender)     { NavigationService.Navigate(typeof(LoginView)); }
        private void menadzerView(object sender)  { NavigationService.Navigate(typeof(MenadzerView),  new MenadzerViewModel(menadzer)); }
        private void misijaView(object sender)    { NavigationService.Navigate(typeof(MisijaView),    new MisijaViewModel(misija)); }
        private void timView(object sender)       { NavigationService.Navigate(typeof(TimView),       new TimViewModel(tim)); }
        private void uposlenikView(object sender) { NavigationService.Navigate(typeof(UposlenikView), new UposlenikViewModel(uposlenik)); }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public DebugViewModel()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);

            DirektorView = new RelayCommand<object>(direktorView);
            IzvjestajView = new RelayCommand<object>(izvjestajView);
            KlijentView = new RelayCommand<object>(klijentView);
            KontaktView = new RelayCommand<object>(kontaktView);
            LoginView = new RelayCommand<object>(loginView);
            MenadzerView = new RelayCommand<object>(menadzerView);
            MisijaView = new RelayCommand<object>(misijaView);
            TimView = new RelayCommand<object>(timView);
            UposlenikView = new RelayCommand<object>(uposlenikView);
        }

        #region HARD ROCK CODE ZA VLASTITO DOBRO NE OTVARATI
        private Contact kontakt = new Contact()
        {
            ime = "Safete",
            prezime = "Ne sam",
            brojTel = "033545388",
            email = "snesam1@etf.unsa.ba"
        };

        private Uposlenik uposlenik = new Uposlenik()
        {
            kontaktInfo = new Contact
            {
                ime = "Safete",
                prezime = "Ne sam",
                brojTel = "033545388",
                email = "snesam1@etf.unsa.ba"
            },
            idBroj = 1,
            danZaposljenja = new DateTime(2016, 6, 5),
            nivoPristupa = NivoPristupa.zelena,
            plata=4510,
            sifra="1234",
            username="Uposlenik"
        };

        private Direktor direktor = new Direktor()
        {
            #region direktor
            kontaktInfo = new Contact
            {
                ime = "Safete",
                prezime = "Ne sam",
                brojTel = "033545388",
                email = "snesam1@etf.unsa.ba"
            },
            idBroj = 1,
            danZaposljenja = new DateTime(2016, 6, 5),
            nivoPristupa = NivoPristupa.zelena,
            plata = 4510,
            sifra = "1234",
            username = "Direktor",
            izvjestaji=new List<Izvjestaj>()
            {
                new Izvjestaj()
                {
                    datumKreiranja=new DateTime(2016, 6, 3),
                    opis="Cilj je unistiti logisticki lanac kojim se sverca cisti kajmak preko ibarskih planina",
                    pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45, Longitude=22 },
                    stanjeBudzeta=4522
                },
                new Izvjestaj()
                {
                    datumKreiranja=new DateTime(2016, 6, 4),
                    opis="Naisli smo na mali otpor prilikom susreta sa kajmak bandom",
                    pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22 },
                    stanjeBudzeta=522
                },
                new Izvjestaj()
                {
                    datumKreiranja=new DateTime(2016, 6, 5),
                    opis="Kajmak banda je uspjesno odstranjena, sav materijal je zaplijenjen",
                    pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22.004 },
                    stanjeBudzeta=12422
                }
            }
            #endregion
        };

        private Izvjestaj izvjestaj = new Izvjestaj()
        {
            datumKreiranja=new DateTime(2016, 6, 5),
            opis="Kajmak banda je uspjesno odstranjena, sav materijal je zaplijenjen",
            pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22.004 },
            stanjeBudzeta=12422
        };
        
        private Klijent klijent = new Klijent()
        {
            #region Klijent
            fizikalnost = Fizikalnost.fizickoLice,
            izvjestaj = new FinalniIzvjestaj()
            {
                datumKreiranja = new DateTime(2016, 6, 5),
                opis = "Kajmak banda je uspjesno odstranjena, sav materijal je zaplijenjen",
                pozicija = new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 45.0154, Longitude = 22.004 },
                stanjeBudzeta = 12422,
                krajMisije = new DateTime(2016, 6, 5),
                pocetakMisije = new DateTime(2016, 6, 3),
                uspjeh = uspjehEnum.uspjesna
            },
            kontaktInfo = new Contact
            {
                ime = "Safete",
                prezime = "Ne sam",
                brojTel = "033545388",
                email = "snesam1@etf.unsa.ba"
            },
            misija=new Misija
            {
                budzet=1200,
                izvjestaji=new List<Izvjestaj>()
                {
                        new Izvjestaj()
                    {
                        datumKreiranja=new DateTime(2016, 6, 4),
                        opis="Naisli smo na mali otpor prilikom susreta sa kajmak bandom",
                        pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22 },
                        stanjeBudzeta=522
                    },
                    new Izvjestaj()
                    {
                        datumKreiranja=new DateTime(2016, 6, 5),
                        opis="Kajmak banda je uspjesno odstranjena, sav materijal je zaplijenjen",
                        pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22.004 },
                        stanjeBudzeta=12422
                    }
                },
                mete=new List<Meta>()
                {
                    new Meta
                    {
                        idBroj=1,
                        lokacija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22.004 },
                        radnaGrupa=new Tim
                        {
                            index00x=1,
                            resursi=new List<Oprema>()
                            {
                                new Oprema
                                {
                                    cijena=1400,
                                    idBroj=1,
                                    nazivOpreme="Safetalije",
                                    status=statusOpreme.ispravna,
                                    ostecenost=0,
                                    proizvodjac="Kajmak inc"
                                }
                            }
                        }
                    }
                },
                radnaGrupa= new Tim
                {
                    index00x = 1,
                    resursi = new List<Oprema>()
                    {
                        new Oprema
                        {
                            cijena=1400,
                            idBroj=1,
                            nazivOpreme="Safetalije",
                            status=statusOpreme.ispravna,
                            ostecenost=0,
                            proizvodjac="Kajmak inc"
                        }
                    }
                }
            }
            #endregion
        };
        private Menadzer menadzer = new Menadzer()
        {
            danZaposljenja = new DateTime(2016, 4, 5),
            idBroj = 1,
            izvjestaji = new List<Izvjestaj>
            {
                new Izvjestaj()
                {
                    datumKreiranja=new DateTime(2016, 6, 5),
                    opis="Kajmak banda je uspjesno odstranjena, sav materijal je zaplijenjen",
                    pozicija=new Windows.Devices.Geolocation.BasicGeoposition() {Latitude=45.0154, Longitude=22.004 },
                    stanjeBudzeta=12422
                    }
            },
            kontaktInfo = new Contact
            {
                ime = "Safete",
                prezime = "Ne sam",
                brojTel = "033545388",
                email = "snesam1@etf.unsa.ba"
            },
            nivoPristupa = NivoPristupa.crvena,
            plata = 4515,
            sifra="1234",
            username="Safet"
        };

        private Misija misija = new Misija()
        {
            budzet=451,
            izvjestaji=null,
            mete=null,
            hashID="154515dada54",
            radnaGrupa=null
        };
        private Tim tim = new Tim()
        {
            index00x = 7,
            resursi = new List<Oprema>()
            {
                new Oprema
                {
                    cijena=1400,
                    idBroj=1,
                    nazivOpreme="Safetalije",
                    status=statusOpreme.ispravna,
                    ostecenost=0,
                    proizvodjac="Kajmak inc"
                }
            }
        };
        #endregion
    }
}
