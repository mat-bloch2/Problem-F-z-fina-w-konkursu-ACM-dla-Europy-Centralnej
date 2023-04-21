using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    class rysuj_układ : układ
    {
        public void Rysuj(układ uk, PictureBox pictureBox1)
        {
            Point[][] wymiary = wymiary_układu(pictureBox1.Size.Width, pictureBox1.Size.Height, uk);
            Bitmap plansza = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            Graphics powieszchnia = Graphics.FromImage(plansza);
            for (int i = 0; i < wymiary.Length; i++)
            {  
                powieszchnia.FillPolygon(Brushes.Red, wymiary[i]);
            }
            pictureBox1.Image = plansza;
        }

        private double szukanie_skali(int W, int H, int r, int p)
        {
            if ((W / r) > (H / p))
                return H / p;
            else
                return W / r;
        }

        private Point[][] wymiary_układu(int W, int H, układ uk)
        {
            Point[][] wymiary = new Point[uk.ile_cystern()][];
            int miejsce = 0;
            double skala = szukanie_skali(W, H, uk.MAX_R(), uk.MAX_P());
            double[][][] wymiary_cystern = uk.wymiary_cystern();
            for (int i = 0; i < uk.ile_cystern(); i++)
            {
                wymiary[i] = new Point[wymiary_cystern[i].Length];
               
                for (int j=0; j< wymiary_cystern[i].Length; j++)
                {
                    wymiary[i][j] = new Point((int)(wymiary_cystern[i][j][0]* skala)+ miejsce,  (int)(H-(wymiary_cystern[i][j][1]* skala)));
                }                
                miejsce += (int)(uk.cysterny[i].szerokość() * skala) + 2;
            }
            return wymiary;


        }

       

    }

}