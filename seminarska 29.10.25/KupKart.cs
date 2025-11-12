using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seminarska_29._10._25
{
    public class KupKart
    {
        public Queue<Karta> Karte { get; private set; }

        public KupKart()
        {
            Karte = new Queue<Karta>();
            UstvariKup();
            Premesaj();
        }

        private void UstvariKup()
        {
            var barve = new[] { "Srce", "Karo", "Pik", "Križ" };
            for (var vrednost = 2; vrednost <= 14; vrednost++)
            {
                foreach (var barva in barve)
                {
                    Karte.Enqueue(new Karta(barva, vrednost));
                }
            }
        }

        private void Premesaj()
        {
            var rnd = new Random();
            Karte = new Queue<Karta>(Karte.OrderBy(k => rnd.Next()));
        }

        public Karta VzemiKarto() => Karte.Count > 0 ? Karte.Dequeue() : null;










    }
}
