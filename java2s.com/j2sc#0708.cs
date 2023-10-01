// j2sc#0708.cs: Say�sal parametrelerde, �oklu kurucularda ve miraslayanda a��r�y�kleme �rne�i.

using System;
namespace S�n�flar {
    class A��r�y�kleme1 {
        public void a�y�kMetot() {Console.WriteLine ("Parametresiz");}
        public void a�y�kMetot (int a) {Console.WriteLine ("Gerid�n��s�z tek int parametreli: " + a);}
        //public int a�y�kMetot (int a) {Console.WriteLine ("int gerid�n��l� tek int parametreli: " + a); return a*2;} //Bir�stteki y�z�nden derleme hatas� verir
        public int a�y�kMetot (int a, int b) {Console.Write ("int gerid�n��l� �ift int parametreli: " + a + " + " + b + " = "); return a + b;}
        public double a�y�kMetot (double a, double b) {Console.Write ("double gerid�n��l� �ift double parametreli: " + a + " + "+ b + " = "); return a + b;}
        public double a�y�kMetot (double a, int b) {Console.Write ("int gerid�n��l� �ift double+int parametreli: " + a + " + "+ b + " = "); return a + b;}
    }
    public class Araba {
        private string marka;
        private string model;
        private string renk;
        private int imalY�l�;
        public Araba() {//Parametresiz kurucu
            this.marka = "Ford";
            this.model = "Mustang";
            this.renk = "k�rm�z�";
            this.imalY�l� = 1970;
        }
        public Araba (string marka) {//Tek parametreli kurucu a��r�y�kleme
            this.marka = marka;
            this.model = "Corvette";
            this.renk = "g�m��";
            this.imalY�l� = 1969;
        }
        public Araba (string marka, string model, string renk, int imalY�l�) {//4 parametreli kurucu a��r�y�kleme
            this.marka = marka;
            this.model = model;
            this.renk = renk;
            this.imalY�l� = imalY�l�;
        }
        public void G�ster() {Console.WriteLine ("(" + marka + ", " + model + ", " + renk + ", " + imalY�l� + ")");}
    }
    public class ��rak��g�ren {
        private int ya�;
        public ��rak��g�ren() {ya� = 15;} //Parametresiz ilkde�er atamal� kurucu
        public virtual void ya�Koy (int y�) {ya� = y�;}
        public virtual int ya�Al() {return ya�;}
    }
    public class Re�it��g�ren : ��rak��g�ren {
        public Re�it��g�ren() {} //Parametresiz ilkde�er atamas�z kurucu
        override public void ya�Koy (int y�) {if (y� > 18) base.ya�Koy (y�); else base.ya�Koy (18);} //A��r�y�kleme metot
    }
    class A��r�y�kleme2 {
        public void a�y�kMetot (int x) {Console.WriteLine ("a�y�kMetot(int) i�inde: " + x);} //int olmazsa long farzedilir
        public void a�y�kMetot (long x) {Console.WriteLine ("a�y�kMetot(long) i�inde: " + x);}
        public void a�y�kMetot (double x) {Console.WriteLine ("a�y�kMetot(double) i�inde: " + x);}
    }
    class MetotA��r�Y�kleme {
        static void Main() {
            Console.Write ("Ayn� adl� a��r�y�klenen metotlar�n sadece gerid�n�� tip farkl�l��� yetersiz olup, parametre tip ve say�lar�n�n farkl�l��� esast�r. Parametre tiplerinden 'byte, short' bir�st� 'int' yada mevcutsa 'long', 'float' ise 'double' olarak alg�lan�r. Miraslayanda ayn� adl� (esas) ge�erli 'override' metodlar a��r�y�klemelerdir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayn� adl� farkl� parametre ve gerid�n��l� 5 metot:");
            var r=new Random(); int ts1=r.Next(1000, 10000), ts2=r.Next(1000, 10000); double ds1=r.Next(1000, 10000)+r.Next(1000, 10000)/10000D, ds2=r.Next(1000, 10000)+r.Next(1000, 10000)/10000D;
            A��r�y�kleme1 ay1 = new A��r�y�kleme1();
            ay1.a�y�kMetot();
            ay1.a�y�kMetot (ts1);
            Console.WriteLine (ay1.a�y�kMetot (ts1, ts2) );
            Console.WriteLine (ay1.a�y�kMetot (ds1, ds2) );
            Console.WriteLine (ay1.a�y�kMetot (ds1, ts1) );
            Console.WriteLine (ay1.a�y�kMetot (ts2, ds2) ); //Parametreleri double+double farzeder

            Console.WriteLine ("\nAst yoksa tamsay� �st 'long', k�s�ratl� �st 'double'd�r:");
            A��r�y�kleme2 ay2 = new A��r�y�kleme2();
            ts1=r.Next (1000, 10000);
            ds1=Math.PI;
            long ls1=long.MaxValue;
            byte b = 200;
            short s = 2023;
            float f = (float)Math.E; 
            ay2.a�y�kMetot (ls1);
            ay2.a�y�kMetot (ts1);
            ay2.a�y�kMetot (b);
            ay2.a�y�kMetot (s);
            ay2.a�y�kMetot (ds1);
            ay2.a�y�kMetot (f);

            Console.WriteLine ("\nA��r�y�klemeli kurucularla araba (marka, model, renk, imalY�l�):");
            Araba arabam = new Araba ("Toyota", "MR2", "siyah", 1995); arabam.G�ster();
            arabam = new Araba(); arabam.G�ster();
            arabam = new Araba ("Chevrolet"); arabam.G�ster();

            Console.WriteLine ("\n��rak temelli de olsa re�it ya�� 18 ve �st� yans�r:");
            ��rak��g�ren �i = new ��rak��g�ren(); �i.ya�Koy (13); Console.WriteLine ("��rak��g�ren ya�: {0}", �i.ya�Al());
            Re�it��g�ren ri = new Re�it��g�ren(); ri.ya�Koy (15); Console.WriteLine ("Re�it��g�ren ya�: {0}", ri.ya�Al());
            ri = new Re�it��g�ren(); ri.ya�Koy (19); Console.WriteLine ("Re�it��g�ren ya�: {0}", ri.ya�Al());
            ts1=r.Next (10, 65); ri = new Re�it��g�ren(); ri.ya�Koy (ts1); Console.WriteLine ("Re�it��g�ren ya�: {0}", ri.ya�Al());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}