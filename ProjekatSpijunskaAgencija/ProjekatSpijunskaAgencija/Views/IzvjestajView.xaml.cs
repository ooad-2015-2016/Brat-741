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
        #region NE DIRAJ
        public IzvjestajView()
        {
            this.InitializeComponent();
            DataContext = new IzvjestajViewModel(mapa);
        }
        #endregion
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
            DataContext = (IzvjestajViewModel)e.Parameter;
            NavigationCacheMode = NavigationCacheMode.Required;
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
