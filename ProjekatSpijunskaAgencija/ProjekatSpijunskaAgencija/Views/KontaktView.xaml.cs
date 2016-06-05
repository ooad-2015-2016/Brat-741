using ProjekatSpijunskaAgencija.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class KontaktView : Page
    {
        public KontaktView()
        {
            this.InitializeComponent();
            DataContext = new KontaktViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
            DataContext = (KontaktViewModel)e.Parameter;
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Forma za Kontakt\nIme i prezime U ova polja unosite vaše ime i prezime.\ne - mail Ovo polje je predviđeno za unos e - maila.\nBroj telefona Polje gdje upisujete vaš broj telefona.");
            await md.ShowAsync();
        }
    }
}
