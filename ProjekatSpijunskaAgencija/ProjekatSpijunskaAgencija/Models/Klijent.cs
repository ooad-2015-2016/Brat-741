using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public enum Fizikalnost { fizickoLice, pravnoLice }
    public class Klijent
    {
        private string _pristupniKod;
        public string pristupniKod
        {
            get { return _pristupniKod; }
            set
            {
                if (Helpers.Validacija.Broj(value))
                    _pristupniKod = value;
                else
                    _pristupniKod = "";
            }
        }
        public Misija misija { get; set; }
        public Fizikalnost fizikalnost { get; set; }
        public FinalniIzvjestaj izvjestaj { get; set; }
        public Contact kontaktInfo { get; set; }

        public void ispisiStatus() { }
        public Misija kreirajMisiju()
        {
            return this.misija;
        }
        public bool potvrdiKod()
        {
            return true;
        }
    }
}
