using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class Login : Page
    {
        public object NotifyType { get; private set; }

        public Login()
        {
            this.InitializeComponent();
            var data = new DataSourceSA();
        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            //uklanja enter iz teksta, koji je smetao kada se pritisne enter za login
            var username = Regex.Replace(txtUsername.Text, @"\t|\n|\r", "");
            var password = Regex.Replace(txtPassword.Password, @"\t|\n|\r", "");
            Uposlenik uposlenik = DataSourceSA.dajUposlenika(username, password);
            if (uposlenik != null)
            {
                MessageDialog dialog = new MessageDialog("Zdravo uposlenik broj " + uposlenik.idBroj);
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(UposlenikView), new UposlenikViewModel(uposlenik));
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Pogresni podaci, probajte ponovo ili se registrujte");

                //Treba napraviti mogucnost da u samom dijalogu odabere mogucnost za registraciju.
                //dialog.Commands.Add(new UICommand("Try again", new UICommandInvokedHandler(this.CommandInvokedHandler)));
                //dialog.Commands.Add(new UICommand("Close",new UICommandInvokedHandler(this.CommandInvokedHandler)));
                //dialog.DefaultCommandIndex = 0;
                //dialog.CancelCommandIndex = 1;

                await dialog.ShowAsync();
            }
        }
        private void register_Click(object sender, RoutedEventArgs e)
        {
            var username = Regex.Replace(txtUsername.Text, @"\t|\n|\r", "");
            var password = Regex.Replace(txtPassword.Password, @"\t|\n|\r", "");
            var uposlenik = new Uposlenik()
            {
                username = username,
                sifra = password
            };
            this.Frame.Navigate(typeof(UposlenikRegisterView), new UposlenikViewModel(uposlenik));
        }

        private void KeyDownPress(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter) login_Click(sender, e);
        }
    }
}
