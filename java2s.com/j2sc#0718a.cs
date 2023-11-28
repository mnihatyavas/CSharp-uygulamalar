// j2sc#0718a.cs: S�n�f alan de�erinin set-get'li �zellikle konulmas�-al�nmas� �rne�i.

using System;
namespace S�n�flar {
    class �zellik {
        int �zlk;
        public �zellik() {�zlk = 0;} //�lkde�erleyen kurucu
        public int �zlk {get {return �zlk;} set {�zlk = value;}}
    }
    class S�n�f {
        public double A = 0, B = 0;
        public double Topla {get {return (A + B);}}
        public double ��kar {get {return (A - B);}}
        public double �arp {get {return (A * B);}}
        public double B�l {get {return (A / B);}}
        public double Kalan {get {return (Math.Abs(A) > Math.Abs(B)? Math.Abs(A)%Math.Abs(B) : Math.Abs(B)%Math.Abs(A));}}
    }
    class Adres {
        protected string �ehir;
        public string �ehir {get {return �ehir;}}
        protected string pk;
        public string PK {get {return pk;} set {pk = value; �ehir = "Mersin";}}
    }
    class �ekil {
        double en, boy; //private  
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
    }
    class ��gen : �ekil {
        string t�r; //��genin t�r�
        public string T�r {get {return t�r;} set {t�r = value;}}
        public double alan() {return En * Boy / 2;} 
    }
    class Dizim { 
        float[] a;
        int uz;
        public bool hatal�M�;
        public Dizim (int ebat) {a = new float [ebat]; uz = ebat;} //Tek parametreli kurucu
        public int Uz {get {return uz;}}
        public float this [int endeks] {
            get {if (endeksKontrol (endeks)) {hatal�M� = false; return a [endeks];}
                else {hatal�M� = true; return 0;}
            }
            set {if (endeksKontrol (endeks)) {a [endeks] = value; hatal�M� = false;}
                else hatal�M� = true;
            }
        }
        private bool endeksKontrol (int endeks) {
            if (endeks >= 0 & endeks < Uz) return true;
            return false;
        }
    }
    class Atam {
        private int y�l = 1881;
        public int Y�l {set {y�l = value;} get {return y�l;}}
    }
    public class A {
        private int n;
        public int N {
           set {Console.Write ("De�er konuluyor..."); n = value;}
           get {Console.Write ("\tKonulan de�er al�n�yor: " ); return n;}
        }
    }
    class �zellik1 {
        static void Main() {
            Console.Write ("�zellik, bir ad ve i�i de�er al-koy/get-set'li bir {} g�vdeden olu�ur. Metot parametresiyken ref veya out olamaz. �zelli�in a��r�y�klenimi/overload olmaz. Ait oldu�u alan de�i�kenin tipini de�i�tiremez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�zelli�e set-get'li de�er/value atama ve okuma:");
            var r=new Random(); int ts1, i;
            �zellik �z = new �zellik(); Console.WriteLine ("�z.�zlk'in ilk kurulum de�eri = " + �z.�zlk);
            for(i=1;i<=5;i++) {
                ts1=r.Next(-1000, 1000);
                �z=new �zellik();
                �z.�zlk = ts1;
                Console.WriteLine ("{0})inci �z.�zlk de�eri = {1}", i, �z.�zlk);
            }

            Console.WriteLine ("\nA ve B ile �zellikler (topla, ��kar, �arp, b�l, abs(kalan)):");
            double ds1, ds2;
            S�n�f s;
            for(i=1;i<=5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(1000,10000)/10000D; ds2=r.Next(-1000,1000)+r.Next(1000,10000)/10000D;
                s=new S�n�f();
                s.A = ds1; s.B = ds2;
                Console.WriteLine ("{0}) A={1} ve B={2} ise: ({3:0.00}, {4:0.00}, {5:0.00}, {6:.00}, {7:0.00})", i, s.A, s.B, s.Topla, s.��kar, s.�arp, s.B�l, s.Kalan);
            }

            Console.WriteLine ("\nMetsin'in �ehir ve PK �zellikleri:");
            Adres adr;
            for(i=1;i<=5;i++) {
                ts1=r.Next(100,1000);
                adr=new Adres();
                adr.PK="33"+ts1;
                Console.WriteLine ("{0}.inci (�ehir, PK) = ({1}, {2})", i, adr.�ehir, adr.PK);
            }

            Console.WriteLine ("\n��gen'in T�r, En, Boy �zelliklerini koy-al ve alan()'�n� hesapla:");
            string[] t�r=new string[] {"dik", "ikizkenar", "e�kenar", "farkl�kenar", "e�rikenar"};
            ��gen ��g;
            for(i=0;i<5;i++) {
                ��g=new ��gen();
                ��g.En=r.Next(1,20)+r.Next(1000,10000)/10000D; ��g.Boy=r.Next(1,20)+r.Next(1000,10000)/10000D;
                ��g.T�r=t�r [i];
                Console.WriteLine ("{0}.inci {1} ��genin (en, boy, alan) = ({2}, {3}, {4:0.0000})", (i+1), ��g.T�r, ��g.En, ��g.Boy, ��g.alan());
            }

            Console.WriteLine ("\n�artl� get-set'le dizinin eksi ve ta�an endekslerinin tespiti:"); //Tespit edilenen de�eri 0.00 d�nd�r�r.
            Dizim dizim = new Dizim (10);
            float x;
            for (i=0; i < dizim.Uz; i++)  dizim [i] = r.Next(-100,100)+r.Next(1000,10000)/10000F;
            for (i=-2; i < dizim.Uz+2; i++) {
                x = dizim [i];
                Console.Write ("dizim[{0}]={1:0.00##}, ", i, x);
            } Console.WriteLine();

            Console.WriteLine ("\n'private' alana 'public' set-get �zellikle eri�im:");
            Atam ata = new Atam();
            Console.Write  ("�lk Y�l: {0},\t", ata.Y�l);
            for(i=1882;i<1938;i++) {
                ata.Y�l=i;
                Console.Write (ata.Y�l + ", ");
            } Console.Write  ("\tSon Y�l: {0}\n", ++ata.Y�l);

            Console.WriteLine ("\n�zellik vas�tas�yla de�er konulmas� ve al�nmas�:");
            A nes = new A();
            for(i=1;i<=5;i++) {
                nes.N=r.Next(-10000,10000);
                Console.Write (nes.N + "\n");
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}