﻿using Newtonsoft.Json;
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
        #region Uposlenici
        public static int dajBrojUposlenika() { return _uposlenici.Count; }
        public static Uposlenik dajUposlenika(string username, string password)
        {
            Uposlenik rez = null;
            foreach (var k in _uposlenici)
            {
                if (k.sifra == password && k.username == username) rez = new Uposlenik(k);
            }
            return rez;
        }
        public static List<Uposlenik> dajSveUposlenike()
        {
            return _uposlenici;
        }
        public async static void dodajUposlenika(Uposlenik uposlenik)
        {
            if (_uposlenici.Count<Uposlenik>(k => k.kontaktInfo.prezime == uposlenik.kontaktInfo.prezime && k.kontaktInfo.ime==uposlenik.kontaktInfo.ime) == 0)
            {
                _uposlenici.Add(uposlenik);
            }
            else
            {
                MessageDialog md = new MessageDialog("Uposlenik vec postoji");
                await md.ShowAsync();
            }
        }
        #endregion
        #region Timovi
        public static int dajBrojTimova() { return _uposlenici.Count; }
        public static Tim dajTim(int index)
        {
            //Tim rez = null;
            //foreach (var k in _timovi)
            //{
            //    if (k.index00x == index) rez = new Tim();
            //    throw Exception;
            //}
            return null;
        }
        public static List<Tim> dajSveTimove()
        {
            return _timovi;
        }
        public async static void dodajTim(Tim tim)
        {
            if (_timovi.Count<Tim>(k => k.index00x == tim.index00x) == 0)
            {
                _timovi.Add(tim);
            }
            else
            {
                MessageDialog md = new MessageDialog("Uposlenik vec postoji");
                await md.ShowAsync();
            }
        }
        #endregion
        #region Misije
        public static int dajBrojMisija() { return _uposlenici.Count; }
        public static Misija dajMisiju(int index)
        {
            //Tim rez = null;
            //foreach (var k in _timovi)
            //{
            //    if (k.index00x == index) rez = new Tim();
            //    throw Exception;
            //}
            return null;
        }
        public static List<Misija> dajSveMisije()
        {
            return _misije;
        }
        public async static void dodajMisiju(Misija misija)
        {
            if (_misije.Count<Misija>(k => k.radnaGrupa.index00x == misija.radnaGrupa.index00x) == 0)
            {
                _misije.Add(misija);
            }
            else
            {
                MessageDialog md = new MessageDialog("Uposlenik vec postoji");
                await md.ShowAsync();
            }
        }
        #endregion
        public async static void ucitajPodatke()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile uposlenici = await storageFolder.CreateFileAsync("uposlenici.json", Windows.Storage.CreationCollisionOption.OpenIfExists);

            string json = await Windows.Storage.FileIO.ReadTextAsync(uposlenici);
            _uposlenici = JsonConvert.DeserializeObject<List<Uposlenik>>(json);
            MessageDialog md = new MessageDialog(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
            await md.ShowAsync();
            //var nd = new MessageDialog(json);
            //await nd.ShowAsync();
        }
        public async static void zapisiPodatke()
        {
            string json = JsonConvert.SerializeObject(_uposlenici);
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            MessageDialog md = new MessageDialog(Windows.Storage.ApplicationData.Current.LocalFolder.Path);
            await md.ShowAsync();
            Windows.Storage.StorageFile uposlenici = await storageFolder.CreateFileAsync("uposlenici.json", Windows.Storage.CreationCollisionOption.OpenIfExists);

            await Windows.Storage.FileIO.WriteTextAsync(uposlenici, json);
        }
    }
}
