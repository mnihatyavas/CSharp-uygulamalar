// j2sc#0113.cs: S�n�f nesnesi de�i�kenlerine metod parametresiyle de�er aktarma �rne�i.

using System;
namespace DilTemelleri {
    class S�n�fA {
        private int a, b;
        public S�n�fA (int i, int j) {a = i; b = j;}
        public bool ayn�M� (S�n�fA nesne) {
            if ((nesne.a == this.a) & (nesne.b == this.b)) return true;
            else return false;
        }
        public void kopyala (S�n�fA nesne) {this.a = nesne.a; this.b  = nesne.b;}
        public void g�ster() {Console.WriteLine ("a: {0}, b: {1}", this.a, this.b);}
    }
    class S�n�fB {
        public int a, b;
        public S�n�fB (int i, int j) {a = i; b = j;}
        public void de�i�tir (S�n�fB nesne) {nesne.a = nesne.a - nesne.b; nesne.b = 2023 - nesne.b;}
    }
    class S�n�fC {
        public void daire (ref double y�, ref double �v, ref double al, ref double kal, ref double khc) {
            double pi=Math.PI; �v=2*pi*y�; al=pi*y�*y�; kal=4*al; khc=4/3*pi*y�*y�*y�; y�=0;
        }
    }
    class ParametreReferans� {
        static void Metod (ref string d) {d = "Han�m Yava�";}
        static void Main() {
            Console.Write ("S�n�f tiplemeli nesne �yesi de�i�kenlerine �e�itli metod parametresi y�ntemiyle de�er aktar�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new S�n�fA (2023, 1951);
            var nesne2 = new S�n�fA (1938, 1881);
            Console.Write ("nesne1: "); nesne1.g�ster();
            Console.Write ("nesne2: "); nesne2.g�ster();
            if (nesne1.ayn�M�(nesne2)) Console.WriteLine ("==>nesne1 ve nesne2'nin de�erleri AYNIDIR.");
            else Console.WriteLine ("==>nesne1 ve nesne2'nin de�erleri FARKLIDIR.");
            nesne1.kopyala (nesne2);
            Console.Write ("\nnesne2 nesne1'e kopyaland�ktan sonra: "); nesne1.g�ster();
            if (nesne1.ayn�M�(nesne2)) Console.WriteLine ("==>nesne1 ve nesne2'nin de�erleri AYNIDIR.");
            else Console.WriteLine ("==>nesne1 ve nesne2'nin de�erleri FARKLIDIR.");

            var nesne3 = new S�n�fB (1938, 1881);
            Console.WriteLine ("\n�a�r�lmadan �NCE nesne3.a ve nesne3.b: " + nesne3.a + " " + nesne3.b);
            nesne3.de�i�tir (nesne3);
            Console.WriteLine ("�a�r�ld�ktan SONRA nesne3.a ve nesne3.b: " + nesne3.a + " " + nesne3.b);

            var nesne4 = new S�n�fC();
            var r=new Random(); double yar��ap=r.Next (0, 1000000) / 100000d, �evre=0, alan=0, k�reAlan=0, k�reHacim=0;
            Console.WriteLine ("\n�a�r�lmadan �NCE (yar��ap, �evre, daireAlan, k�reAlan, k�reHacim)\n = ({0:0.0###}, {1:0.0###}, {2:0.0###}, {3:0.0###}, {4:0.0###})", yar��ap, �evre, alan, k�reAlan, k�reHacim);
            nesne4.daire (ref yar��ap, ref �evre, ref alan, ref k�reAlan, ref k�reHacim);
            Console.WriteLine ("�a�r�ld�ktan SONRA (yar��ap, �evre, daireAlan, k�reAlan, k�reHacim)\n = ({0:0.0###}, {1:0.0###}, {2:0.0###}, {3:0.0###}, {4:0.0###})", yar��ap, �evre, alan, k�reAlan, k�reHacim);

            string ad = "Han�m Emanet";
            Console.WriteLine ("\nEvlenmeden �NCE isim: " + ad);
            Metod (ref ad);
            Console.WriteLine ("Evlendikten SONRA isim: " + ad);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}