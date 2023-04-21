using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace WindowsFormsApp4
{
    abstract  class cysterna
    {
        

        public abstract double[][] wymiary();
        public abstract void wczytaj(TextReader tr);
        public abstract int poziom();
        public abstract int wysokość();
        public abstract int szerokość();
        public abstract double objętość(double p);

    }

    class cysterna_sześcian:cysterna
        {
            protected int b, h, w, d;

        public override double[][] wymiary()
        {
            double[][] wymiary = new double [4][];
            for(int i=0; i < 4 ; i++)
            {
                wymiary[i] = new double[2];
            }
            wymiary[0][0] = 0;
            wymiary[0][1] = b;
            wymiary[1][0] = 0;
            wymiary[1][1] = b + h;
            wymiary[3][0] = w ;
            wymiary[3][1] = b;
            wymiary[2][0] = w ;
            wymiary[2][1] = b + h;  
         return wymiary;
        }


        public override void wczytaj(TextReader tr)
            {
                string[] części = tr.ReadLine().Split();
                b = int.Parse(części[0]);
                h = int.Parse(części[1]);
                w = int.Parse(części[2]);
                d = int.Parse(części[3]);
            }
            public override int poziom()
            {
                return b;
            }
            public override int wysokość()
            {
                return h;
            }

        public override int szerokość()
        {
            return w;
        }
        public override double objętość(double p)
            {
                double wynik = 0.0;
                if (p > b)
                {
                    p = p - b;
                    if (p > h)
                        p = h;
                    wynik = p * w * d;
                }
                return wynik;
            }

        }

        class walce_cysterna : cysterna
        {
        protected int b, h, w;

        public override int poziom()
        {
            return b;
        }
        public override int szerokość()
        {
            return 2*w;
        }
        public override int wysokość()
        {
            return h;
        }

        public override double[][] wymiary()
        {
            double[][] wymiary = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                wymiary[i] = new double[2];
            }
            wymiary[0][0] = 0;
            wymiary[0][1] = b;
            wymiary[1][0] = 0;
            wymiary[1][1] = b + h;
            wymiary[3][0] = 2*w;
            wymiary[3][1] = b;
            wymiary[2][0] = 2*w;
            wymiary[2][1] = b + h;
            return wymiary;
        }

        public override void wczytaj(TextReader tr)
            {
                string[] części = tr.ReadLine().Split();
                b = int.Parse(części[0]);
                h = int.Parse(części[1]);
                w = int.Parse(części[2]);
            }
        
        public override double objętość(double p)
            {
                double wynik = 0.0;
                if (p > b)
                {
                    p = p - b;
                    if (p > h)
                        p = h;
                    wynik = p * 3.14 * w * w;
                }
                return wynik;
            }

        }
        class stożek_cysterna : walce_cysterna
        {
        public override double[][] wymiary()
        {
            double[][] wymiary = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                wymiary[i] = new double[2];
            }
            wymiary[0][0] = 0;
            wymiary[0][1] = b;
            wymiary[1][0] = 2*w;
            wymiary[1][1] = b + h;
            wymiary[2][0] = w;
            wymiary[2][1] = b+h;
            return wymiary;
        }
        public override double objętość(double p)
            {
                double wynik = 0.0;
                if (p > b)
                {
                    p = p - b;
                    if (p > h)
                        p = h;
                    wynik = (1.0 / 3.0) * (p * 3.14 * w * w);
                }
                return wynik;
            }

        }

}


