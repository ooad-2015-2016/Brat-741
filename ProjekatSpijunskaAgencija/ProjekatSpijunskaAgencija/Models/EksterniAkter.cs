using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    class EksterniAkter : Contact
    {
        public String dostupniResursi { get; set; }

        public void pozoviUPomoc(String razlog)
        {

        }

        //public void promijeniResurse(String noviResursi)          Zato sto vec imamo implementirano kroz get set metode nad atributom dostupniResursi
        //{
        //    this.dostupniResursi = noviResursi;
        //}
    }
}
