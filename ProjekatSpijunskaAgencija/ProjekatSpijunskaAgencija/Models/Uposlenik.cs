using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum NivoPristupa { zelena, zuta, crvena }

    public class Uposlenik
    {
        #region Atributi koje popunjava sam uposlenik
        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                if (Helpers.Validacija.ImePrezime(value))
                    _username = value;
                else
                    _username = "";
            }
        }
        private string _sifra;
        public string sifra
        {
            get { return _sifra; }
            set
            {
                if (Helpers.Validacija.Password(value))
                    _sifra = value;
                else
                    _sifra = "";
            }
        }
        public Contact kontaktInfo { get; set; }
        #endregion

        #region Atributi koje popunjava direktor/menadzer i sistem
        public int idBroj { get; set; }

        public NivoPristupa nivoPristupa { get; set; }
        private int _plata;
        public int plata
        {
            get { return _plata; }
            set
            {
                if (Helpers.Validacija.Password(value.ToString()))
                    _plata = value;
                else
                    _plata = 0;
            }
        }
        public DateTime danZaposljenja { get; set; }
        #endregion
        public Uposlenik() { idBroj = -1; }
        public Uposlenik(Uposlenik k)
        {
            username = k.username;
            sifra = k.sifra;
            kontaktInfo = k.kontaktInfo;
            idBroj = k.idBroj;
            nivoPristupa = k.nivoPristupa;
            plata = k.plata;
            danZaposljenja = k.danZaposljenja;
        }

        public Izvjestaj analizirajIzvjestaj(Izvjestaj izvjestaj)
        {
            return izvjestaj;
        }
    }
}
