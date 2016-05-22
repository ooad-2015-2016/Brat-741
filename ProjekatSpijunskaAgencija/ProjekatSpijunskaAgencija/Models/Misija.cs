using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    class Misija
    {
        private int brojMeta=0;
        private Meta[] mete;
        public float budzet { get; set; }
        public Izvjestaj[] izvjestaji { get; set; }
        public Tim radnaGrupa { get; set; }

        //public promijeniBudzet()
        public void abortMisije(String razlog)
        {

        }

        public void dodajMetu(Meta novaMeta)
        {
            this.mete[brojMeta++] = novaMeta;
        }
    }
}
