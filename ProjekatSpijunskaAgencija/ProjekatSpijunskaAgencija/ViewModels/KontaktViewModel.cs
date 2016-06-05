using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    public class KontaktViewModel : INotifyPropertyChanged
    {
        private Contact kontakt;
        public Contact Kontakt { get { return kontakt; } set { kontakt = value; NotifyPropertyChanged("Kontakt"); } }
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }
        public NavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private void Setup()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }

        public KontaktViewModel()
        {
            Setup();
            kontakt = new Contact();
        }
        public KontaktViewModel(Contact kontakt)
        {
            Setup();
            this.kontakt = kontakt;
        }
    }
}
