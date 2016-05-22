using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    class Menadzer : Uposlenik
    {
        public int brojIzvjestaja = 0;
        public Izvjestaj[] izvjestaji { get; set; }

        public void kreirajMisiju() { }
        public Izvjestaj podnesiIzvjestaj()
        {
            return this.izvjestaji[brojIzvjestaja];
        }
    }
}
