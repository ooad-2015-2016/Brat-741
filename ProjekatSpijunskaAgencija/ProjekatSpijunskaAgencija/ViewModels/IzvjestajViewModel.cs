using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class IzvjestajViewModel : INotifyPropertyChanged
    {
        public Izvjestaj izvjestaj { get; set; }
        public Geolocator pozicija { get; set; }
        private double _longitude;
        private double _latitude;
        public double Longitude { get { return _longitude; } set { this._longitude = value; NotifyPropertyChanged("Longitude"); } }
        public double Latitude { get { return _latitude; } set { this._latitude = value; NotifyPropertyChanged("Latitude"); } }

        public ICommand Lokacija { get; set; }
        public INavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public IzvjestajViewModel()
        {
            NavigationService = new NavigationService();
            Lokacija = new RelayCommand<object>(lokacija, mozeLiSeLocirati);
            izvjestaj = new Izvjestaj();
        }
        public bool mozeLiSeLocirati(object parameter)
        {
            return true;
        }
        public async void lokacija(object sender)
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            MessageDialog dialog = new MessageDialog("Dobavljam Lokaciju");
            dialog.Commands.Add(new UICommand("Ok"));
            dialog.DefaultCommandIndex = 0;
            dialog.ShowAsync();

            // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
            Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };

            // Subscribe to the StatusChanged event to get updates of location status changes.
            //  geolocator.StatusChanged += OnStatusChanged;

            // Carry out the operation.
            Geoposition pos = await geolocator.GetGeopositionAsync();

            UpdateLocationData(pos);
        }
        private async void UpdateLocationData(Geoposition pos)
        {
            MessageDialog dialog = new MessageDialog(String.Format("Latitude: {0} Longitude: {1}",
                pos.Coordinate.Latitude, pos.Coordinate.Longitude));

            Longitude = pos.Coordinate.Longitude;
            Latitude = pos.Coordinate.Latitude;

            dialog.Commands.Add(new UICommand("Ok"));
            dialog.DefaultCommandIndex = 0;
            await dialog.ShowAsync();
        }
    }
}
