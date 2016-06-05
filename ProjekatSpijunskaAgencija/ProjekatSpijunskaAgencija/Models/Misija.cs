using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public class Misija
    {
        public List<Meta> mete;
        public float budzet { get; set; }
        public List<Izvjestaj> izvjestaji { get; set; }
        public Tim radnaGrupa { get; set; }
        public string hashID { get; set; }
        //public promijeniBudzet()
        public void abortMisije(String razlog)
        {

        }
        public override string ToString()
        {
            return "Prva meta: " + mete.First<Meta>() + ", budzet: " + budzet + ", zadnji izvjestaj: " + izvjestaji.Last<Izvjestaj>() + ", Radna Grupa: " + radnaGrupa.ToString() + ", Hash ID: " + hashID;
        }
        public Misija()
        {

        }
    }
}
