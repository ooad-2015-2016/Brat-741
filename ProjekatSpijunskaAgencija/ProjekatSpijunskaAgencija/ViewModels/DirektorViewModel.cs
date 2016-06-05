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

        public ObservableCollection<object> TrenutnaLista;


        public ICommand KontaktInfo;
        public ICommand PrikaziUposlenike;

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void kontaktInfo(object parameter)
        {
            NavigationService.Navigate(typeof(KontaktView), direktor.kontaktInfo);
        }
        private void prikaziUposlenike(object parameter)
        {
            TrenutnaLista = new ObservableCollection<object>(DataSourceSA.dajSveUposlenike());
        }


        private void Setup()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
            KontaktInfo = new RelayCommand<object>(kontaktInfo);
            PrikaziUposlenike = new RelayCommand<object>(prikaziUposlenike);
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
