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
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Maps;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    class IzvjestajViewModel : INotifyPropertyChanged
    {
        public Izvjestaj izvjestaj { get; set; }
        public Geopoint trenutnaLokacija { get; set; }
        public Geopoint TrenutnaLokacija { get { return trenutnaLokacija; } set { this.trenutnaLokacija = value; NotifyPropertyChanged("TrenutnaLokacija"); } }
        private double _longitude;
        private double _latitude;
        public double Longitude { get { return _longitude; } set { this._longitude = value; NotifyPropertyChanged("Longitude"); } }
        public double Latitude { get { return _latitude; } set { this._latitude = value; NotifyPropertyChanged("Latitude"); } }
        MapControl Mapa;

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }

        public ICommand Lokacija { get; set; }
        public NavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        public IzvjestajViewModel(Izvjestaj izvjestaj)
        {
            NavigationService = new NavigationService();
            Lokacija = new RelayCommand<object>(lokacija, mozeLiSeLocirati);
            this.izvjestaj = izvjestaj;
            splitView = new SplitViewModel(NavigationService);
            Mapa = new MapControl();
        }
        public IzvjestajViewModel(MapControl mapa)
        {
            NavigationService = new NavigationService();
            Lokacija = new RelayCommand<object>(lokacija, mozeLiSeLocirati);
            izvjestaj = new Izvjestaj();
            splitView = new SplitViewModel(NavigationService);
            Mapa = mapa;
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
            await dialog.ShowAsync();
            // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
            Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };

            // Subscribe to the StatusChanged event to get updates of location status changes.
            //  geolocator.StatusChanged += OnStatusChanged;

            // Carry out the operation.
            Geoposition pos = await geolocator.GetGeopositionAsync();


            UpdateLocationData(pos);
        }
        private void DisplayIcon(double x, double y, MapControl MapControl1)
        {
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = x, Longitude = y };
            Geopoint snPoint = new Geopoint(snPosition);

            // Create a MapIcon.
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapIcon1.Title = "Pin";
            mapIcon1.ZIndex = 0;
            
            // Add the MapIcon to the map.
            MapControl1.MapElements.Add(mapIcon1);
            // MapControl1.MapElements.Add(new MapIcon() { Location = new Geopoint(new BasicGeoposition() { Latitude = x - 5, Longitude = y } ), NormalizedAnchorPoint = new Point(0.5, 1.0), Title = "Pin", ZIndex=0 });
            
            // Center the map over the POI.
            MapControl1.Center = snPoint;
            MapControl1.ZoomLevel = 14;
        }
        private void UpdateLocationData(Geoposition pos)
        {
            //MessageDialog dialog = new MessageDialog(String.Format("Latitude: {0} Longitude: {1}",
               // pos.Coordinate.Latitude, pos.Coordinate.Longitude));

            Longitude = pos.Coordinate.Longitude;
            Latitude = pos.Coordinate.Latitude;
            DisplayIcon(Latitude, Longitude, Mapa);
            //dialog.Commands.Add(new UICommand("Ok"));
            //dialog.DefaultCommandIndex = 0;
            //await dialog.ShowAsync();
        }
    }
}
