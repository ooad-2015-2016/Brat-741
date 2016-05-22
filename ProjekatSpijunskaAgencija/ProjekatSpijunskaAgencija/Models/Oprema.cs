using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum statusOpreme { ispravna, slobodna, zauzeta, naPopravci}
    class Oprema
    {
        public int idBroj { get; set; }
        public String nazivOpreme { get; set; }
        public String proizvodjac { get; set; }
        public statusOpreme status { get; set; }
        public float ostecenost { get; set; }
        public float cijena { get; set; }

        //public void promijeniStatus(statusOpreme noviStatus) { }
        //public void promijeniOstecenost(flaot novaOstecenost) { }
    }
}
