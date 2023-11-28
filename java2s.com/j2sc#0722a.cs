// j2sc#0722a.cs: Ebeveyn base, ayn� adl� new alan/metot ve i�i�e s�n�flar �rne�i.

using System;
namespace S�n�flar {
    class TemelS�n�f {public int n1 = 0;}
    class T�rediS�n�f : TemelS�n�f {
        public T�rediS�n�f (int a, int b) {n1=a; base.n1=b;}
        new public int n1 = 0;
        public void G�ster() {Console.WriteLine ("Temel.n1={0},\tT�redi.n1={1}", base.n1, n1);}
    }
    public class Temel {
        public int n1;
        public Temel() { n1=0; Console.WriteLine ("\tParametresiz Temel kurucusu: {0}", n1);}
        public Temel (int i) {Console.WriteLine ("\tTek parametreli Temel kurucusu: {0}", i); n1=i;}
    }
    public class T�redi : Temel {
        new public int n1;
        public T�redi() {n1=0; base.n1=0; Console.WriteLine ("Parametresiz T�redi kurucusu: ({0}, {1})", n1, base.n1);}
        public T�redi (int i1, int i2) : base (i1) {n1=i2; Console.WriteLine ("�ift parametreli T�redi kurucusu: ({0}, {1})", n1, base.n1);}
    }
    class Temel2 { 
        public int n = 0;
        public void g�ster() {Console.WriteLine ("\tTemel n = {0}", n);}
    }
    class T�redi2 : Temel2 {
        new int n; //Bu n, Temel n'i gizler
        public T�redi2 (int a, int b) {base.n = a; n = b;}
        new public void g�ster() {base.g�ster(); Console.WriteLine ("T�redi n = {0}", n);}
    }
    internal class D��1 {
        internal class D��2 {
            public static int saya�;
            internal class �� {public void Birart�r() {saya�++;}}
        }
    }
    class S�n�fA {
        class Sayac�m {public int Say = 0;}
        private Sayac�m saya�;
        public S�n�fA() {saya� = new Sayac�m();} //Kurucu
        public int Birart�r() {return saya�.Say++;}
        public int De�eriAl() {return saya�.Say;}
    }
    class �e�itli1 {
        static void Main() {
            Console.Write ("'base' t�redi s�n�fta temel kasd�yla kullan�l�r. T�redinin tiplenmesi �ncelikle miraslanan temel kurucuyu otomatikmen �a��r�r. T�redinin temelle ayn� new adl� alan� temelinkini gizler, ancak base.alan onu if�a eder. Temel'le ayn� adl� t�redi alan ve metot adlar� �n�nde new olmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Temel'in n1'ini T�redi'ninkinden ay�ran 'base' anahtarkelimesi:");
            var r=new Random(); int ts1, ts2, i;
            T�rediS�n�f t1;
            for(i=0;i<5;i++) {
                ts1=r.Next(); ts2=r.Next();
                t1=new T�rediS�n�f (ts1, ts2);
                t1.G�ster();
            }

            Console.WriteLine ("\nTek/�ift parametreli kurucularla t�redi/temel alanlara de�er atama:");
            T�redi trd1 = new T�redi();
            T�redi trd2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                trd2=new T�redi (ts1, ts2);
            }

            Console.WriteLine ("\nTemelin kurucusuz alan de�erinin base.metot()'la g�sterilmesi:");
            T�redi2 tr2;
            for(i=0;i<5;i++) {
                ts1=r.Next(-1000,1000); ts2=r.Next(-1000,1000);
                tr2=new T�redi2 (ts1, ts2);
                tr2.g�ster();
            }

            Console.WriteLine ("\nStatik sayac�n i�i�e 3 s�n�fl� tiplemeli metotla art�r�lmas�:");
            D��1.D��2.�� di=new D��1.D��2.��();
            for(i=0;i<100;i++) {di.Birart�r(); Console.Write ("{0} ", D��1.D��2.saya�);}

            Console.WriteLine ("\n\nAyn� i�lemin statik olmayan i�i�e 2 s�n�f alan ve metoduyla yap�lmas�:");
            S�n�fA sa = new S�n�fA();
            for(i=0;i<100;i++) {sa.Birart�r(); Console.Write ("{0} ", sa.De�eriAl());}

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}