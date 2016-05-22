using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    class Agent00x : Agent //buduci da nisam znao kako drugacije isao sam sa visestrukim nasljedjivanjem
    {
        public int x { get; set; }
        private Izvjestaj izvjestaj { get; set; }
        public Izvjestaj analizirajIzvjestaj()
        {
            //OVDJE TREBA IMPLEMENTIRATI OBRADU IZVJESTAJA
            return this.izvjestaj;
        }
    }
}
