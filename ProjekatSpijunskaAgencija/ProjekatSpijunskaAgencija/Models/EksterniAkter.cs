using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public class EksterniAkter
    {
        public string dostupniResursi { get; set; }
        public Contact kontaktInfo { get; set; }

        public void pozoviUPomoc(string razlog)
        {

        }

        //public void promijeniResurse(String noviResursi)          Zato sto vec imamo implementirano kroz get set metode nad atributom dostupniResursi
        //{
        //    this.dostupniResursi = noviResursi;
        //}
    }
}
