using ProjekatSpijunskaAgencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.DataSource
{
    public partial class DataSourceSA
    {
        private static List<Uposlenik> _uposlenici = new List<Uposlenik>()
        {
            new Uposlenik()
            {
                sifra = "1234",
                idBroj = 1,
                nivoPristupa = NivoPristupa.zlatna
            },
            new Uposlenik()
            {
                sifra = "0000",
                idBroj=2,
                nivoPristupa = NivoPristupa.crvena
            }
        };
        public static Uposlenik dajUposlenika(string username, string password)
        {
            Uposlenik rez = new Uposlenik();
            foreach (var k in _uposlenici)
            {
                if (k.sifra == password && k.kontaktInfo.ime == username) rez = k;
            }
            return rez;
        }

    }
}
