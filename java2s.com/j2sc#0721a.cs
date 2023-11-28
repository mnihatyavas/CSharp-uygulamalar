// j2sc#0721a.cs: Statik s�n�f metotlar�n�n tiplemesiz uzant�l� y�r�t�lmesi �rne�i.

using System;
namespace S�n�flar {
    static class StatikS�n�f1 {  
        static public double bireB�l�m� (double n) {return 1/n;}
        static public double k�s�rat� (double n) {return n - (int)n;}
        static public bool �iftMi (double n) {return ((int)n % 2) == 0 ? true : false;}
        static public bool tekMi(double n) {return !�iftMi (n);}
    }
    public static class StatikS�n�f2 {
        public static int Saya� = 0;
        public static void ��Yap() {++Saya�; Console.Write ("StatikS�n�f2.��Yap()");}
        public class ��S�n�f {public ��S�n�f() {Console.Write ("\t��S�n�f.��S�n�f() kuruculu tipleme");}}
    }
    class D��S�n�f<A> {
        public class Normal��S�n�f<B, C> {
            static int Saya� = 0;
            public static void StatikMetot1() {Console.WriteLine ("D��S�n�f<{0}>.Normal��S�n�f<{1},{2}>.StatikMetot1()\tSaya� = {3}", typeof (A).Name, typeof (B).Name, typeof (C).Name, ++Saya�);}
            public static void StatikMetot2() {Console.WriteLine ("\tD��S�n�f<A>.Normal��S�n�f<B,C>.StatikMetot2()\tSaya� = {0}", ++Saya�);}
        }
    }
    class S�n�fA {
        public static int N=20231102;
        static S�n�fA() {Console.WriteLine ("S�n�fA'n�n statik kurucusu: {0}", N);}
    }
    class S�n�fB {
        private static Random RasgeleTS;
        static S�n�fB() {RasgeleTS = new Random(); Console.WriteLine ("S�n�fB'nin statik kurucusu 'new Random()' atad�.");}
        public int De�eriAl() {return RasgeleTS.Next();}
    }
    class Statik1 {
        static void Main() {
            Console.Write ("Statik s�n�f tiplenmeden metotlar� do�rudan s�n�f ad� uzant�l� kullan�lmal�d�r. Tiplennmesi derleme hatas� verir. Ancak statik s�n�f i�indeki normal s�n�f-lar tiplenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili say�lar�n (bireB�l�m�, k�s�rat�, �iftMi, tekMi) sonu�lar�:");
            var r=new Random(); int ts1, i; double ds1;
            for(i=0;i<5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("{0:0.00} say�s� = ({1:0.0000}, {2:0.00}, {3}, {4})", ds1, StatikS�n�f1.bireB�l�m� (ds1), StatikS�n�f1.k�s�rat� (ds1), StatikS�n�f1.�iftMi (ds1), StatikS�n�f1.tekMi (ds1));
            }
            //StatikS�n�f1 ss1 = new StatikS�n�f1(); Console.WriteLine (ss1.bireB�l�m� (ds1)); //Derleme hatas� 

            Console.WriteLine ("\nStatik ve i�erdi�i normal s�n�f'la her �a�r�da artan saya�:");
            StatikS�n�f2.��S�n�f i�;
            for(i=0;i<5;i++) {
                StatikS�n�f2.��Yap(); i�=new StatikS�n�f2.��S�n�f();
                Console.Write("\tSaya� = {0}\n", StatikS�n�f2.Saya�);
            }

            Console.WriteLine ("\n��i�e normal s�n�ftaki statik metotlar�n �a�r�lmas�:");
            for(i=0;i<5;i++) {
                D��S�n�f<int>.Normal��S�n�f<string, DateTime>.StatikMetot1();
                D��S�n�f<int>.Normal��S�n�f<string, DateTime>.StatikMetot2();
            }

            Console.WriteLine ("\n�oklu d�ng�de sadece tek kere y�r�t�len statik kurucu:");
            for(i=0;i<5;i++) {ts1=r.Next(1000,10000); S�n�fA.N = ts1; Console.WriteLine (S�n�fA.N);}

            Console.WriteLine ("\nStatik kurucunun tek kerelik rasgele tipleme yapmas�:");
            S�n�fB sb = new S�n�fB();
            for(i=0;i<5;i++) {sb=new S�n�fB(); Console.WriteLine ("{0:#,0}", sb.De�eriAl());}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}