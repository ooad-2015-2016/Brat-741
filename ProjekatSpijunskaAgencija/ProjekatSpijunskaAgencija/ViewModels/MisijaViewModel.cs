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
    class MisijaViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }
        private Misija misija;
        public Misija Misija { get { return misija; }set { misija = value; NotifyPropertyChanged("Misija"); } }
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MisijaViewModel()
        {
            misija = new Misija();
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
        public MisijaViewModel(Misija misija)
        {
            this.misija = misija;
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
    }
}
