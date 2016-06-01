using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatSpijunskaAgencija.Models
{
    public class Tim
    {
        public int index00x { get; set; }

        private List<Agent> clanovi { get; set; }
        public List<Oprema> resursi { get; set; }

        #region Dodavanja i uklanjanje oprema i agenata, dodajOpremu/Agenta, ukloniOpremu/Agenta
        public void dodajAgenta(Agent noviAgent)
        {
            if (!clanovi.Exists(k => k.idBroj == noviAgent.idBroj)) clanovi.Add(noviAgent);
        }

        public void dodajOpremu(Oprema novaOprema)
        {
            if (!resursi.Exists(k => k.idBroj == novaOprema.idBroj)) resursi.Add(novaOprema);
        }

        public void ukloniOpremu(int idOpreme)
        {
            resursi.RemoveAt(resursi.FindIndex(k => k.idBroj == idOpreme));
        }

        public void ukloniAgenta(int idAgenta)
        {
            clanovi.RemoveAt(clanovi.FindIndex(k => k.idBroj == idAgenta));
        }
        #endregion

        public Tim()
        {
        }

        public Tim(Agent00x agent)
        {
            index00x = agent.x;
            clanovi.Add(agent);
            resursi.AddRange(agent.oprema);
            //agent.status = statusAgenta.zauzet; o ovome se brine konstruktor Misije
        }
    }
}
