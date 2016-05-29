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
                kontaktInfo = new Contact()
                {
                    ime = "M",
                    prezime = "16"
                },
                username = "Direktor",
                sifra = "1234",
                idBroj = 1,
                nivoPristupa = NivoPristupa.zlatna
            },
            new Uposlenik()
            {
                username = "Menadzer",
                sifra = "0000",
                idBroj=2,
                nivoPristupa = NivoPristupa.crvena
            }
        };

        public static Uposlenik dajUposlenika(string username, string password)
        {
            Uposlenik rez = null;
            foreach (var k in _uposlenici)
            {
                if (k.sifra == password && k.username == username) rez = new Uposlenik(k);
            }
            return rez;
        }

    }
}
