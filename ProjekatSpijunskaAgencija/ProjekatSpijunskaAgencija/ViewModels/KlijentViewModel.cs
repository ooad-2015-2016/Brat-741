using KompShopMVVM.KompShop.Helper;
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
    class KlijentViewModel : INotifyPropertyChanged
    {
        private Klijent klijent;
        public Klijent Klijent { get { return klijent; } set { klijent = value; NotifyPropertyChanged("Klijent"); } }
        public NavigationService NavigationService { get; set; }
        public ICommand KreirajMisiju { get; set; }
        public ICommand StatusMisije { get; set; }
        public ObservableCollection<Misija> lista;
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        public KlijentViewModel(Klijent klijent)
        {
            this.klijent = klijent;
            lista = new ObservableCollection<Misija>(new List<Misija>() { klijent.misija });
            KreirajMisiju = new RelayCommand<object>(kreirajMisiju);
            StatusMisije = new RelayCommand<object>(statusMisije);
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
        public KlijentViewModel()
        {
            KreirajMisiju = new RelayCommand<object>(kreirajMisiju);
            StatusMisije = new RelayCommand<object>(statusMisije);
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
        private void kreirajMisiju(object sender)
        {
            NavigationService.Navigate(typeof(MisijaView), new MisijaViewModel(klijent.misija));
        }
        private void statusMisije(object sender)
        {

        }
    }
}
