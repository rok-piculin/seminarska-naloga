using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace seminarska_29._10._25
{
    // Razred Kup – predstavlja celoten komplet kart (deck)
    internal class Kup
    {
        public List<Karta> Karte { get; private set; }

        public Kup()
        {
            PripraviKup();
            NaključKarte();
            NaključKarte();
        }

        public void PripraviKup()
        {
            Karte = new List<Karta>();
            for (int barva = 0; barva < 4; barva++)
            {
                for (int vrednost = 2; vrednost <= 14; vrednost++)
                {
                    Karte.Add(new Karta((Barve)barva, (Vrednosti)vrednost));
                }
            }
        }

        public void NaključKarte()
        {   // Algoritem Fisher–Yates 
            Random rnd = new Random();
            for (int i = Karte.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                Karta temp = Karte[i];
                Karte[i] = Karte[j];
                Karte[j] = temp;
            }
        }

       

        public Karta VzemiKarto()
        {
            if (Karte.Count > 0)
            {
                Karta karta = Karte[0];
                Karte.RemoveAt(0);
                return karta;
            }
            return null;
        }
    }

}


