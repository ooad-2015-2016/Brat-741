using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ProjekatSpijunskaAgencija.Models
{
    public class Meta
    {
        public int idBroj { get; set; }
        public BasicGeoposition lokacija { get; set; }
        public Tim radnaGrupa { get; set; }
    }
}
