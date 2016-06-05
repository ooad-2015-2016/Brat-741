using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Helpers
{
    static public class Validacija
    {
        public static bool ImePrezime(string ime)
        {
            foreach(var x in ime)
                if (!Char.IsLetter(x)) return false;
            return true;
        }
        public static bool Broj(string ime)
        {
            foreach (var x in ime)
                if (!Char.IsDigit(x)) return false;
            return true;
        }
        public static bool Email(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        public static bool Password(string pass)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            Match match = regex.Match(pass);
#if DEBUG
            return true;
#endif
#pragma warning disable CS0162 // Unreachable code detected
            return match.Success;
#pragma warning restore CS0162 // Unreachable code detected
        }
    }
}
