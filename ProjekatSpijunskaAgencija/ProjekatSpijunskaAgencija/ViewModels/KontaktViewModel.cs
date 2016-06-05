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

        public NavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
