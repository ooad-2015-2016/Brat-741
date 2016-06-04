using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class TesterViewModel : INotifyPropertyChanged
    {
        private SplitViewModel split = new SplitViewModel();
        public SplitViewModel Split { get { return split; } set { split = value; NotifyPropertyChanged("Split"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
