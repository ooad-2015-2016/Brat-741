using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum nivoPristupa { zelena, zuta, plava, crvena, zlatna }
    class Uposlenik : Contact
    {
        public int idBroj { get; set; }
        //public Contact kontakt { get; set; }
        public nivoPristupa nivoPristupa { get; set; }
        public int plata { get; set; }
        public DateTime danZaposljenja { get; set; }
    }
}
