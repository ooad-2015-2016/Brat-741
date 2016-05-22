using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    class Tim
    {
        private int brojClanova = 0;
        private Agent[] clanovi;
        public int index00x { get; set; }
        public Oprema[] resursi { get; set; }

        public void dodajAgenta(Agent noviAgent)
        {
            if (this.clanovi.Contains(noviAgent))
            {
                //URADI NESTO AKO AGENT VEC POSTOJI
            }
            else
            {
                this.clanovi[brojClanova++] = noviAgent;
            }
        }

        public void izbaciAgenta(int idAgenta)
        {
            this.clanovi = this.clanovi.Where(w => w.idBroj != idAgenta).ToArray();
            //pravi novi niz clanovi, koji je takav da ne sadrzi agente kojima se idBroj poklapa sa zadanim idAgenta
        }
    }
}
