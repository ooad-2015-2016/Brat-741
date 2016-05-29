using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum statusAgenta { zauzet, slobodan }

    public class Agent : Uposlenik
    {
        public statusAgenta status { get; set; }
        public List<Oprema> oprema { get; set; }
    }
}
