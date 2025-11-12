using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminarska_29._10._25
{
    internal class IgraVojna
    {
        public Igralec Igralec1 { get; private set; }
        public Igralec Igralec2 { get; private set; }

        public IgraVojna(Igralec igralec1, Igralec igralec2)
        {
            Igralec1 = igralec1;
            Igralec2 = igralec2;

            var kup = new KupKart();
            while (kup.Karte.Count > 0)
            {
                Igralec1.Roka.Enqueue(kup.VzemiKarto());
                Igralec2.Roka.Enqueue(kup.VzemiKarto());
            }
        }

        public string OdigrajRundo()
        {
            var karta1 = Igralec1.OdigrajKarto();
            var karta2 = Igralec2.OdigrajKarto();

            if (karta1 == null || karta2 == null)
                return "Konec igre.";

            var rezultat = $"Ti igra {karta1}, Računalnik igra {karta2}.\r\n";

            if (karta1.Vrednost > karta2.Vrednost)
            {
                Igralec1.DodajKarte(new[] { karta1, karta2 });
                rezultat += "Ti zmaga rundo.";
            }
            else if (karta2.Vrednost > karta1.Vrednost)
            {
                Igralec2.DodajKarte(new[] { karta1, karta2 });
                rezultat += "Računalnik zmaga rundo.";
            }
            else
            {
                rezultat += "Vojna! (neodločeno)";
            }

            return rezultat;
        }

        public bool JeKonec() => Igralec1.Roka.Count == 0 || Igralec2.Roka.Count == 0;
    }
}
