using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using seminarska_29._10._25;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace seminarska_29._10._25
{

    // Enum StatusVojne – opisuje različna stanja vojne
    public enum StatusVojne
    {
        NiVojne = 0,
        Zacetek = 1,
        VojnaSeOdvija = 2,
        PonovnoVojna = 3
    }

    internal class Igra
    {
        public Karta ZadnjaKartaIgralca1 { get;  set; }
        public Karta ZadnjaKartaIgralca2 { get;  set; }
        public StatusVojne statusVojne { get; set; } = StatusVojne.NiVojne;
        public Igralec Igralec1 { get;  set; }
        public Igralec Igralec2 { get;  set; }

        public Igra(Igralec igralec1, Igralec igralec2)
        {
            Igralec1 = igralec1;
            Igralec2 = igralec2;
            var kup = new Kup();

            //razeli karte
            while (kup.Karte.Count > 0)
            {
                Igralec1.Roka.Add(kup.VzemiKarto());
                Igralec2.Roka.Add(kup.VzemiKarto());
            }
        }

        public string OdigrajRundo()
        {
            Karta Mojakarta;
            Karta RacKarta;


            if (statusVojne == StatusVojne.VojnaSeOdvija)
            {
                return Vojna();
            }

            Mojakarta = VzemiKarto(Igralec1.Roka);
            RacKarta = VzemiKarto(Igralec2.Roka);

            ZadnjaKartaIgralca1 = Mojakarta;
            ZadnjaKartaIgralca2 = RacKarta;

            if (Mojakarta == null || RacKarta == null)
                return "Konec igre!";

            var rezultat = "";

            if (Mojakarta.Vrednost > RacKarta.Vrednost)
            {
                Igralec1.DodajKarte(new Karta[] { Mojakarta, RacKarta });
                rezultat = "Si zmagal rundo";
            }
            else if (Mojakarta.Vrednost < RacKarta.Vrednost)
            {
                Igralec2.DodajKarte(new Karta[] { Mojakarta, RacKarta });
                rezultat = "Računalnik zmaga rundo";
            }
            else
            {
                Igralec1.ZadnjeKarteVojna.Add(ZadnjaKartaIgralca1);
                Igralec2.ZadnjeKarteVojna.Add(ZadnjaKartaIgralca2);

                statusVojne = StatusVojne.Zacetek;

                Razdeli4KarteVojna();

                rezultat = "Vojna";
            }

            return rezultat;
        }

        public string Vojna()
        {
            Karta MojaKartaVojna = VzemiKarto(Igralec1.Vojna);
            Karta RacKartaVojna = VzemiKarto(Igralec2.Vojna);

            ZadnjaKartaIgralca1 = MojaKartaVojna;
            ZadnjaKartaIgralca2 = RacKartaVojna;

            Igralec1.ZadnjeKarteVojna.Add(MojaKartaVojna);
            Igralec2.ZadnjeKarteVojna.Add(RacKartaVojna);

            if (MojaKartaVojna == null || RacKartaVojna == null)
                return "Konec igre.";

            var rezultat = "";

            if (RacKartaVojna.Vrednost > MojaKartaVojna.Vrednost)
            {
                Igralec2.DodajKarte(Igralec1.ZadnjeKarteVojna.ToArray());
                Igralec2.DodajKarte(Igralec2.ZadnjeKarteVojna.ToArray());
                Igralec1.ZadnjeKarteVojna.Clear();
                Igralec2.ZadnjeKarteVojna.Clear();
                Igralec2.DodajKarte(Igralec1.Vojna.ToArray());
                Igralec2.DodajKarte(Igralec2.Vojna.ToArray());
                statusVojne = StatusVojne.NiVojne;
                rezultat = "Računalnik zmaga vojno.";
            }
            else if (MojaKartaVojna.Vrednost > RacKartaVojna.Vrednost)
            {
                Igralec1.DodajKarte(Igralec1.ZadnjeKarteVojna.ToArray());
                Igralec1.DodajKarte(Igralec2.ZadnjeKarteVojna.ToArray());
                Igralec1.ZadnjeKarteVojna.Clear();
                Igralec2.ZadnjeKarteVojna.Clear();
                Igralec1.DodajKarte(Igralec1.Vojna.ToArray());
                Igralec1.DodajKarte(Igralec2.Vojna.ToArray());
                statusVojne = StatusVojne.NiVojne;
                rezultat = "Igralec zmaga vojno.";
            }
            else
            {
                statusVojne = StatusVojne.PonovnoVojna;
                
                Razdeli4KarteVojna();

                rezultat = "Ponovna vojna ...";
            }

            return rezultat;
        }

        public void Razdeli4KarteVojna()
        {
            if (statusVojne == StatusVojne.Zacetek || statusVojne == StatusVojne.PonovnoVojna)
            {
                if (statusVojne == StatusVojne.Zacetek)
                {
                    Igralec1.Vojna.Clear();
                    Igralec2.Vojna.Clear();
                }

                for (int i = 1; i <= 4; i++)
                {
                    Igralec1.Vojna.Add(VzemiKarto(Igralec1.Roka));
                    Igralec2.Vojna.Add(VzemiKarto(Igralec2.Roka));
                }
                statusVojne = StatusVojne.VojnaSeOdvija;
            }
        }

        public Karta VzemiKarto(List<Karta> karteIgralec)
        {
            if (karteIgralec.Count > 0)
            {
                Karta karta = karteIgralec[0];
                karteIgralec.RemoveAt(0);
                return karta;
            }
            return null;
        }

        public bool JeKonec() => Igralec1.Roka.Count == 0 || Igralec2.Roka.Count == 0;
    }
}

    












 






