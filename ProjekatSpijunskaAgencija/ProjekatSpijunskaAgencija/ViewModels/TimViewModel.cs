using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class TimViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }
        private Tim tim;
        public Tim Tim { get { return tim; } set { tim = value; NotifyPropertyChanged("Tim"); } }
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public TimViewModel()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
            tim = new Tim();
        }

        public TimViewModel(Tim tim)
        {
            this.tim = tim;
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
    }
}
