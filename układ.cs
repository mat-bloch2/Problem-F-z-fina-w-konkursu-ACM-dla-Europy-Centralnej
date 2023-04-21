using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace WindowsFormsApp4
{
    class układ
    {
        public cysterna[] cysterny;
        
        public void wczytaj(TextReader tr)
        {
           int  ile_cystern = int.Parse(tr.ReadLine());
            cysterny = new cysterna[ile_cystern];
            for (int i = 0; i < ile_cystern; i++)
            {
                switch (tr.ReadLine())
                {
                    case "w":
                        cysterny[i] = new walce_cysterna();
                        break;
                    case "s":
                        cysterny[i] = new stożek_cysterna();
                        break;                   
                    default:
                        cysterny[i] = new cysterna_sześcian();
                        break;
                }
                cysterny[i].wczytaj(tr);
            }

        }
        public double objętość(double p)
        {
            double wynik = 0;
            for (int i = 0; i < cysterny.Length; i++)
            {
                wynik += cysterny[i].objętość(p);
            }
            return wynik;
        }

        public int MAX_P()
        {
            int MAX_poziom = 0;
            for (int i = 0; i < cysterny.Length; i++)
                if (MAX_poziom < cysterny[i].poziom() + cysterny[i].wysokość())
                {
                    MAX_poziom = cysterny[i].poziom() + cysterny[i].wysokość();
                }

            return MAX_poziom;
        }
        public int MAX_R()
        {
            int szerokość=0;
            for (int i = 0; i < cysterny.Length; i++)
            {
                szerokość+= cysterny[i].szerokość();
            }
            return szerokość;
        }
        public double wysokość(int V)
        {
            double l = 0, sr, p = MAX_P();

            if (objętość(p) < V)
                return -1;
            while (true)
            {
                sr = (p + l) / 2;
                if (p - l < 0.001)
                    return sr;
                if (objętość(sr) >= V)
                    p = sr;
                else
                    l = sr;
            }
        }

        public int ile_cystern()
        {
            return cysterny.Length;
        }

        public double[][][] wymiary_cystern()
        {
            double[][][] wymiary= new double[ile_cystern()][][];
            for (int i = 0; i < ile_cystern(); i++)
            {
                wymiary[i] = cysterny[i].wymiary();
            }
            return wymiary;
        }
    }
}
