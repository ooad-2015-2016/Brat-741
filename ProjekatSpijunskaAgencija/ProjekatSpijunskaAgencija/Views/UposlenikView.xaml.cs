using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class UposlenikView : Page
    {
        public UposlenikView()
        {
            this.InitializeComponent();
            DataContext = new DataSourceSA();
            NavigationCacheMode = NavigationCacheMode.Required;
            
            //var currentView = SystemNavigationManager.GetForCurrentView();
            //currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            //SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
            DataContext = (UposlenikViewModel)e.Parameter;
            if (((UposlenikViewModel)e.Parameter).Uposlenik.idBroj==-1)
            {
                registriraj.Visibility = Visibility.Visible;
            }
            else registriraj.Visibility = Visibility.Collapsed;
        }

        //private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        //{
        //    if (Frame.CanGoBack)
        //    {
        //        Frame.GoBack();
        //        e.Handled = true;
        //    }
        //}

        protected override void OnKeyUp(KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) this.Frame.GoBack();
        }
    }
}
