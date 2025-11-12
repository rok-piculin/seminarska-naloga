using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Enum Barve – definira 4 barve kart
namespace seminarska_29._10._25
{
    public enum Barve
    {
        Srce,
        Karo,
        Pik,
        Križ
    }

    public enum Vrednosti
    {
        Dva = 2,
        Tri = 3,
        Štiri = 4,
        Pet = 5,
        Šest = 6,
        Sedem = 7,
        Osem = 8,
        Devet = 9,
        Deset = 10,
        Fant = 11,
        Kraljica = 12,
        Kralj = 13,
        As = 14
    }

    internal class Karta
    {
        public Barve Barva { get; set; }
        public Vrednosti Vrednost { get; set; }

        public Karta(Barve barva, Vrednosti vrednost)
        {
            Barva = barva;
            Vrednost = vrednost;
        }


        public string Ime
        {
            get { return Vrednost.ToString() + " " + Barva.ToString(); }
        }

     
    }
}




