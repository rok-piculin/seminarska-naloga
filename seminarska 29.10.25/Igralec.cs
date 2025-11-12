
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminarska_29._10._25
{
    // Razred Igralec – predstavlja enega igralca v igri
    internal class Igralec
    {
        public string Ime { get; set; }
        public List<Karta> Roka { get; set; }
        public List<Karta> Vojna { get; set; }
        public List<Karta> ZadnjeKarteVojna { get; set; }

        public Igralec(string ime)
        {
            Ime = ime;
            Roka = new List<Karta>();
            Vojna = new List<Karta>();
            ZadnjeKarteVojna = new List<Karta>();
        }

    

        public void DodajKarte(Karta[] karte)
        {
            foreach (var karta in karte)
            {
                Roka.Add(karta);
            }
        }

    }
}
