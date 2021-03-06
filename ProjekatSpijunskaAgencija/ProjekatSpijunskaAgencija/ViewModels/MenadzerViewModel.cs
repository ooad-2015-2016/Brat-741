﻿using KompShopMVVM.KompShop.Helper;
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
    class MenadzerViewModel : INotifyPropertyChanged
    {
        public NavigationService NavigationService { get; set; }
        private Menadzer menadzer;
        public Menadzer Menadzer { get { return menadzer; } set { menadzer = value; NotifyPropertyChanged("Menadzer"); } }
        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MenadzerViewModel()
        {
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }

        public MenadzerViewModel(Menadzer menadzer)
        {
            this.menadzer = menadzer;
            NavigationService = new NavigationService();
            splitView = new SplitViewModel(NavigationService);
        }
    }
}
