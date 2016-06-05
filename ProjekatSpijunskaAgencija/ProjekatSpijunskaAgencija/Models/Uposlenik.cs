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
        public string username { get; set; }
        public string sifra { get; set; }
        public Contact kontaktInfo { get; set; }
        #endregion

        #region Atributi koje popunjava direktor/menadzer i sistem
        public int idBroj { get; set; }

        public NivoPristupa nivoPristupa { get; set; }
        public int plata { get; set; }
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
