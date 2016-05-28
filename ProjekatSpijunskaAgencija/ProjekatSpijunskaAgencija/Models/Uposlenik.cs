using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum NivoPristupa { zelena, zuta, plava, crvena, zlatna }
    public class Uposlenik
    {
        public int idBroj { get; set; }
        public string sifra { get; set; }
        public Contact kontaktInfo { get; set; }
        //public Contact kontakt { get; set; }
        public NivoPristupa nivoPristupa { get; set; }
        public int plata { get; set; }
        public DateTime danZaposljenja { get; set; }
        public Izvjestaj analizirajIzvjestaj(Izvjestaj izvjestaj)
        {
            return izvjestaj;
        }
    }
}
