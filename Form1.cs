using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public int ile_zestawów;
        public int ktury_zestaw=1;
        StreamReader sr = new StreamReader("plik.txt");
        public Form1()
        {
            InitializeComponent();    
            ile_zestawów = int.Parse(sr.ReadLine());
            obliczenia();
        }

        private void obliczenia()
        {
            double w;
            układ  uk = new układ();
            rysuj_układ ry = new rysuj_układ();
            uk.wczytaj(sr);
            ry.Rysuj(uk, pictureBox1);
            w = uk.wysokość(int.Parse(sr.ReadLine()));
            if (w == -1)
            {
              wynik.Text="OVERFLOW";
            }
            else
            {
               wynik.Text=w.ToString("0.00");
            }
         }

        private void button1_Click(object sender, EventArgs e)
        {
            obliczenia();
            ktury_zestaw++;
            if (ktury_zestaw == ile_zestawów)
            {
                next.Enabled = false;
            }    
        }
    }
}
