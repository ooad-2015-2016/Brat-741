using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ProjekatSpijunskaAgencija.Models
{
    public class Izvjestaj
    {
        public DateTime datumKreiranja { get; set; }
        public float stanjeBudzeta { get; set; }
        public string opis { get; set; }
        public BasicGeoposition pozicija { set; get; }

        public override string ToString()
        {
            return "Datum Kreiranja: " + datumKreiranja.ToString() + ", StanjeBudzeta: " + stanjeBudzeta + ", Opis: " + opis + ", Pozicija: " + pozicija;
        }
    }
}
