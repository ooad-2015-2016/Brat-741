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
            DataContext = new UposlenikViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
            DataContext = (UposlenikViewModel)e.Parameter;
            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
