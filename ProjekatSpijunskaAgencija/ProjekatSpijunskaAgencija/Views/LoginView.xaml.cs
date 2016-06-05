using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows.Input;
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
    public sealed partial class LoginView : Page
    {
        public LoginViewModel dcontext = new LoginViewModel();
        public LoginView()
        {
            this.InitializeComponent();
            
            
            DataContext = dcontext;
        }
        
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Loaded += delegate { Focus(FocusState.Programmatic); };
            if(e.Parameter!="")DataContext = (LoginViewModel)e.Parameter;
            NavigationCacheMode = NavigationCacheMode.Required;
            #if DEBUG
            //this.Frame.BackStack.Remove(this.Frame.BackStack.LastOrDefault());
            #endif
        }

        private void txtPassword_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) dcontext.login_Click(sender);
        }

        private void otvoriConnection_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ConnectionPage));
        }

        private async void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog md = new MessageDialog("Username and Password: U ova polja unosite ime vašeg korisničkog naloga i šifru koju ste napravili."
                +"\nŠifra mora sadržavati minimalno sedam karaktera. Ako ste novi radnik(tj.niste registrovani u bazu) klikom na Login dugme bit ćete prebačeni na formu za registraciju gdje"
                +"će te morati popuniti osnovne podatke o sebi. Novi klijent Ovu opciju možete izabrati ako želite naručiti novu misiju.Klikom na dugme "
                +"Novi klijent bivate prebačeni na novu formu za naručivanje misije gdje popunjavate pojedinosti o meti i način izvršavanja misije.");
            await md.ShowAsync();
        }
    }
}
