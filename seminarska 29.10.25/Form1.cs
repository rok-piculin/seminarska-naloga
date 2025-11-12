using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using seminarska_29._10._25;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace seminarska_29._10._25
{
    public partial class Form1 : Form
    {
        private Igra igra;
        private string vnesenoIme;

        public Form1()
        {
            InitializeComponent();
            btnPoteza.Enabled = false;
            btnSePredam.Enabled = false;
            txtKartaJaz.Enabled = false;
            txtKartaRač.Enabled = false;
            textŠtKartJaz4.Enabled = false;
            textŠtKartRač4.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ime.Text))
            {
                MessageBox.Show("Vnesi svoje ime");
                return;
            }
            vnesenoIme = ime.Text.Trim();
            lblPozdrav.Text = vnesenoIme;

            var igralec1 = new Igralec(vnesenoIme);
            var igralec2 = new Igralec("Računalnik");
            igra = new Igra(igralec1, igralec2);

            textŠtKartJaz4.Text = igra.Igralec1.Roka.Count.ToString();
            textŠtKartRač4.Text = igra.Igralec2.Roka.Count.ToString();

            btnPoteza.Enabled = true;
            btnSePredam.Enabled = true;
            textŠtKartRač4.Enabled = true;
            textŠtKartJaz4.Enabled = true;
            textZmagovalec.Enabled = true;
            txtKartaRač.Enabled = true;
            txtKartaJaz.Enabled = true;


            textZmagovalec.Text = string.Empty;

            IzpisiKup(igra.Igralec1.Roka, listBox2);
            IzpisiKup(igra.Igralec2.Roka, listBox1);

        }

        private void IzpisiKup(List<Karta> kup, ListBox listBox)
        {
            listBox.Items.Clear(); // počistimo obstoječe vnose
            foreach (var karta in kup)
            {
                listBox.Items.Add(karta.Ime); // dodamo ime karte v seznam
            }
        }

        private void btnPoteza_Click(object sender, EventArgs e)
        {
            if (igra == null || igra.JeKonec())
            {
                MessageBox.Show("Konec igre!");
                return;
            }

            string rezultat = igra.OdigrajRundo();
            KdoJeZmagalRundo.Text = rezultat;

            if (igra.statusVojne != StatusVojne.NiVojne)
            {
                if (igra.statusVojne == StatusVojne.Zacetek)
                {
                    txtKartaRač.Text = "";
                    txtKartaJaz.Text = "";
                }
                else
                {
                    if (igra.ZadnjaKartaIgralca1 != null)
                        txtKartaJaz.Text = igra.ZadnjaKartaIgralca1.Ime;
                    if (igra.ZadnjaKartaIgralca2 != null)
                        txtKartaRač.Text = igra.ZadnjaKartaIgralca2.Ime;
                }

                textŠtKartJaz4.Text = igra.Igralec1.Vojna.Count.ToString();
                textŠtKartRač4.Text = igra.Igralec2.Vojna.Count.ToString();
            }
            else
            {
                if (igra.ZadnjaKartaIgralca1 != null)
                    txtKartaJaz.Text = igra.ZadnjaKartaIgralca1.Ime;
                if (igra.ZadnjaKartaIgralca2 != null)
                    txtKartaRač.Text = igra.ZadnjaKartaIgralca2.Ime;

                textŠtKartJaz4.Text = igra.Igralec1.Roka.Count.ToString();
                textŠtKartRač4.Text = igra.Igralec2.Roka.Count.ToString();
            }

            btnSePredam.Enabled = true;

            if (igra.JeKonec())
            {
                string zmagovalec;
                if (igra.Igralec2.Roka.Count < igra.Igralec1.Roka.Count)
                    zmagovalec = vnesenoIme;
                else
                    zmagovalec = "Računalnik!";

                textZmagovalec.Text = zmagovalec;
            }
            IzpisiKup(igra.Igralec1.Roka, listBox1);
            IzpisiKup(igra.Igralec2.Roka, listBox2);
        }

        private void btnPredaja_Click(object sender, EventArgs e)
        {
            textZmagovalec.Text = "Računalnik";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Visible = false;
            listBox2.Visible = false;
        }

      
    }
}




