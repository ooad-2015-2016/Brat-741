using KompShopMVVM.KompShop.Helper;
using ProjekatSpijunskaAgencija.DataSource;
using ProjekatSpijunskaAgencija.Models;
using ProjekatSpijunskaAgencija.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace ProjekatSpijunskaAgencija.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool dialogOn { get; set; }
        private string username;
        private string password;

        public string Username { get { return username; } set { username = value; NotifyPropertyChanged("Username"); } }
        public string Password { get { return password; } set { password = value; NotifyPropertyChanged("Password"); } }
        public ICommand LoginClick { get; set; }
        public ICommand RegisterClick { get; set; }

        private SplitViewModel splitView;
        public SplitViewModel SplitView { get { return splitView; } set { splitView = value; NotifyPropertyChanged("SplitView"); } }
        public NavigationService NavigationService { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        public LoginViewModel()
        {
            NavigationService = new NavigationService();
            NavigationService.SetCanGoBack(false);
            splitView = new SplitViewModel(NavigationService);
            LoginClick = new RelayCommand<object>(login_Click);
            RegisterClick = new RelayCommand<object>(register_Click);
            username = "";
            password = "";
            DataSourceSA.ucitajPodatke();
        }

        public async void login_Click(object sender)
        {
            //uklanja enter iz teksta, koji je smetao kada se pritisne enter za login
            username = Regex.Replace(username, @"\t|\n|\r", "");
            password = Regex.Replace(password, @"\t|\n|\r", "");

            if (DataSourceSA.dajBrojUposlenika() == 0)
            {
                MessageDialog mdialog = new MessageDialog("Vi ste prvi korisnik programa, te mozete kreirati novu Spijunsku Agenciju.");
                await mdialog.ShowAsync();
                Direktor direktor = new Direktor()
                {
                    username = this.username,
                    sifra = this.password
                };
                NavigationService.Navigate(typeof(DirektorView), new DirektorViewModel(direktor));
            }

            Uposlenik uposlenik = DataSourceSA.dajUposlenika(username, password);
            if (uposlenik != null)
            {
                if (!dialogOn)
                {
                    MessageDialog dialog = new MessageDialog("Zdravo uposlenik broj " + uposlenik.idBroj);
                    dialogOn = true;
                    await dialog.ShowAsync();
                    dialogOn = false;
                    NavigationService.Navigate(typeof(UposlenikView), new UposlenikViewModel(uposlenik));
                }
            }
            else
            {
                if (!dialogOn)
                {
                    MessageDialog dialog = new MessageDialog(String.Format("Pogresni podaci, probajte ponovo ili se registrujte d{0}d{1}d",username, this.password));

                    //Treba napraviti mogucnost da u samom dijalogu odabere mogucnost za registraciju.
                    dialog.Commands.Add(new UICommand("Try again"));
                    //dialog.Commands.Add(new UICommand("Close"));
                    dialog.DefaultCommandIndex = 0;
                    //dialog.CancelCommandIndex = 1;
                    dialogOn = true;
                    await dialog.ShowAsync();
                    dialogOn = false;
                }
            }
        }
        private void register_Click(object sender)
        {
            this.username = Regex.Replace(this.username, @"\t|\n|\r", "");
            this.password = Regex.Replace(this.password, @"\t|\n|\r", "");
            Uposlenik uposlenik = new Uposlenik()
            {
                username = this.username,
                sifra = this.password
            };
            NavigationService.Navigate(typeof(UposlenikView), new UposlenikViewModel(uposlenik));
        }

    }
}
