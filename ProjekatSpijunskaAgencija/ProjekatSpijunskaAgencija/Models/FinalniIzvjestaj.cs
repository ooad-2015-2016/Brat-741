﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    enum uspjehEnum { }
    class FinalniIzvjestaj : Izvjestaj
    {
        public DateTime pocetakMisije { get; set; }
        public DateTime krajMisije { get; set; }
        public uspjehEnum uspjeh { get; set; }
    }
}
