using ProjekatSpijunskaAgencija.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatSpijunskaAgencija.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IzvjestajView : Page
    {
        public IzvjestajView()
        {
            this.InitializeComponent();
            DataContext = new IzvjestajViewModel();
        }

        private void budzet_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void button_Click(object sender, RoutedEventArgs e)
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

            longitudeBox.Text = String.Format("{0}", pos.Coordinate.Longitude);
            latitudeBox.Text = String.Format("{0}", pos.Coordinate.Latitude);

            dialog.Commands.Add(new UICommand("Ok"));
            dialog.DefaultCommandIndex = 0;
            await dialog.ShowAsync();
        }

        private void textBlock1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            longitudeBox.Visibility = Visibility.Visible;
            latitudeBox.Visibility = Visibility.Visible;
            textBlock.Visibility = Visibility.Visible;
            textBlock_Copy.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Visible;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            longitudeBox.Visibility = Visibility.Collapsed;
            latitudeBox.Visibility = Visibility.Collapsed;
            textBlock.Visibility = Visibility.Collapsed;
            textBlock_Copy.Visibility = Visibility.Collapsed;
            button.Visibility = Visibility.Collapsed;
        }
    }
}
