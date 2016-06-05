using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public class Contact
    {
        private string _ime,_prezime,_email,_brojTel;
        public string ime
        {
            get { return _ime; }
            set
            {
                if (Helpers.Validacija.ImePrezime(value))
                    _ime = value;
                else
                    _ime = "";
            }
        }
        public string prezime
        {
            get { return _prezime; }
            set
            {
                if (Helpers.Validacija.ImePrezime(value))
                    _prezime = value;
                else
                    _prezime = "";
            }
        }
        public string email
        {
            get { return _email; }
            set
            {
                if (Helpers.Validacija.Email(value))
                    _email = value;
                else
                    _email = "";
            }
        }
        public string brojTel
        {
            get { return _brojTel; }
            set
            {
                if (Helpers.Validacija.Broj(value))
                    _brojTel = value;
                else
                    _brojTel = "";
            }
        }

        public void kontaktiraj()
        {
            //nismo jos nabavili telefon niti mail servis...
        }
    }
}
