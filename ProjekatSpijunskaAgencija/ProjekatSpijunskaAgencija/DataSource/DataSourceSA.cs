using Newtonsoft.Json;
using ProjekatSpijunskaAgencija.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;

namespace ProjekatSpijunskaAgencija.DataSource
{
    public partial class DataSourceSA
    {
        private static List<Oprema> _resursi = new List<Oprema>();
        private static List<Misija> _misije = new List<Misija>();
        private static List<Tim> _timovi = new List<Tim>();

        private static List<Uposlenik> _uposlenici = new List<Uposlenik>();
        //{
        //    
        //    //new Direktor()
        //    //{
        //    //    username = "Direktor",
        //    //    sifra = "1234",
        //    //    kontaktInfo = new Contact()
        //    //    {
        //    //        ime = "M",
        //    //        prezime = "I6",
        //    //        email = "mi61@etf.unsa.ba",
        //    //        brojTel = "0038733007116"
        //    //    },
        //    //    idBroj = 1,
        //    //    nivoPristupa = NivoPristupa.zlatna,
        //    //    plata = 15000,
        //    //    danZaposljenja=new DateTime(2016,6,1),
        //    //    izvjestaji=new List<Izvjestaj>()
        //    //    {
        //    //        new Izvjestaj()
        //    //        {
        //    //            opis="sada",
        //    //            stanjeBudzeta= 1,
        //    //            datumKreiranja=new DateTime(2016,6,1),
        //    //            pozicija = new Windows.Devices.Geolocation.BasicGeoposition()
        //    //            {
        //    //                Latitude=45,
        //    //                Longitude=21
        //    //            }
        //    //        } 
        //    //    }
        //    //},
        //    //new Uposlenik()
        //    //{
        //    //    username = "Menadzer",
        //    //    sifra = "0000",
        //    //    kontaktInfo = new Contact()
        //    //    {
        //    //        ime = "Saldo",
        //    //        prezime = "Menadzeric",
        //    //        email = "mmenadzeric1@etf.unsa.ba",
        //    //        brojTel = "0038733007115"
        //    //    },
        //    //    idBroj=2,
        //    //    nivoPristupa = NivoPristupa.crvena,
        //    //    plata = 15000, //kasnije napraviti da bude suma svih plata
        //    //    danZaposljenja=new DateTime(2016,6,1)
        //    //}
        //};

        public static Uposlenik dajUposlenika(string username, string password)
        {
            Uposlenik rez = null;
            foreach (var k in _uposlenici)
            {
                if (k.sifra == password && k.username == username) rez = new Uposlenik(k);
            }
            return rez;
        }
        public async static void dodajUposlenika(Uposlenik uposlenik)
        {
            MessageDialog sar= new MessageDialog("Sarajevo");
            await sar.ShowAsync();
            _uposlenici.Add(uposlenik);
        }
     

        public async static void ucitajPodatke()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile uposlenici = await storageFolder.CreateFileAsync("uposlenici.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            string json = await Windows.Storage.FileIO.ReadTextAsync(uposlenici);
            _uposlenici = JsonConvert.DeserializeObject<List<Uposlenik>>(json);
            var nd = new MessageDialog(json);
            await nd.ShowAsync();
        }
        public async static void zapisiPodatke()
        {
            string json = JsonConvert.SerializeObject(_uposlenici);
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            MessageDialog md = new MessageDialog(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
            await md.ShowAsync();
            //Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile uposlenici = await storageFolder.CreateFileAsync("uposlenici.json", Windows.Storage.CreationCollisionOption.OpenIfExists);
            await Windows.Storage.FileIO.WriteTextAsync(uposlenici, json);
        }
    }
}
