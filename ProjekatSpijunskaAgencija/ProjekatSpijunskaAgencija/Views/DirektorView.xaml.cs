using ProjekatSpijunskaAgencija.Models;
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
    public sealed partial class DirektorView : Page
    {
        public DirektorView()
        {
            this.InitializeComponent();
            DataContext = new DirektorViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            Loaded += delegate { Focus(FocusState.Programmatic); };
            DataContext = (DirektorViewModel)e.Parameter;
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Uposlenici Klikom na ovo dugme možete da pratite aktivnosti svih uposlenika agencije. \nIzvještaji Ova opcija vam pruža uvid u izvještaje koje Vam je Menadžer poslao.Pristupate bazi podataka sa izvještajima sa svih misija.\nMisijeIzabirom ove opcije pristupate bazi podataka svih misija gdje možete pratiti stanje tekućih misija i po potrebi neke terminirati.Također možete pristupiti podacima već završenih i arhiviranih misija.");
            await md.ShowAsync();
        }
    }
}
