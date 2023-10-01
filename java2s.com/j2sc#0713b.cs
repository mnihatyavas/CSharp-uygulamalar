// j2sc#0713b.cs: T�m alan eri�imlerinin kar��la�t�r�lmalar� �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {  
        private int a; //a�ikar private belirte�li
        int b; //varsay�l� private belirte�li
        public int gama; //public eri�im
        public void alfaKoy (int a) {this.a = a;}
        public int alfaAl() {return a;}
        public void betaKoy (int a) {b = a;}
        public int betaAl() {return b;}
    }
    class S�n�f2 {
        int saya�;
        public S�n�f2() {saya� = 1881;} //Kurucuyla ilkde�erleme
        public int Saya� {get {return saya�;} set {saya� = value;} }
        public void sayac�Birart�r() {Saya�++;}
    }
    class Nokta2B {public int x, y;}
    class Nokta3B : Nokta2B {public int z;}
    class TemelS�n�f {
        protected int i, j; //Miraslayan eri�ir
        public void Koy1 (int a, int b) {i = a; j = b;}
        public void G�ster1() {Console.Write ("{0} * {1} = ", i, j);}
    }
    class T�rediS�n�f : TemelS�n�f {
        int k; // private 
        public void Koy2() {k = i * j;} 
        public void G�ster2() {Console.WriteLine (k);}
    }
    class InternalS�n�f {
        internal int x; //Ayn� uygulama i�inde eri�ilir
        protected internal int y; //Hem ayn� uygulamada, hem de di�er uygulamalar�n miraslayanlar�nda eri�ilir
    }
    public class Bile�enGrubu {
        internal Bile�en[] nesneler;
        protected internal int nesneSay�s�;
        public Bile�enGrubu() {//�lkde�erlemeli kurucu
            nesneler = new Bile�en [5];
            nesneSay�s� = 0;
        }
        public void NesneEkle (Bile�en nesne) {
            if (nesneSay�s� < 5) {
                nesneler [nesneSay�s�] = nesne;
                nesneSay�s�++;
            }
        }
        public void Sunu�() {for (int i = 0; i < nesneSay�s�; i++) Console.WriteLine (nesneler [i]);}
    }
    public class Bile�en {/* internal void Sunu�(){} */ }//��erik olsa da olmasa da farketmez
    class Eri�imDe�i�tireci2 {
        static void Main() {
            Console.Write ("'public' alana s�n�f� tiplemeli do�rudan eri�ilirken, 'private' alana 'public' metoduyla eri�ilir. Parametresiz 'get-set'in set'inde 'value' atan�r. 'internal'a sadece ayn� uygulamada tiplemeyle; 'protected internal'a internal gibi, ayr�ca haricen miraslamayla eri�ilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("private'ye public metotla, public'e do�rudan eri�im:");
            var r=new Random(); int ts1, ts2, ts3, i;
            S�n�f1 s1 = new S�n�f1();
            for(i=0;i<5;i++) {
                ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100);
                s1.alfaKoy (ts1); s1.betaKoy (ts2); s1.gama=ts3;
                Console.WriteLine ("(alfa, beta, gama)= ({0}, {1}, {2})", s1.alfaAl(), s1.betaAl(), s1.gama);
            }

            Console.WriteLine ("\nprivate'ye metot()'suz public set-get'le de eri�ilebilir;");
            S�n�f2 s2 = new S�n�f2(); Console.WriteLine ("s2.Saya�'�n kurulu� ilkde�eri: {0} ", s2.Saya�);
            for(i=1882;i<=1938;i++) {
                s2.sayac�Birart�r();
                Console.Write (s2.Saya� + " ");
            } Console.WriteLine();

            Console.WriteLine ("\n2 boyutlu'yu miraslayan 3 boyutlu public alanl� noktalar:");
            Nokta3B n3b = new Nokta3B();
            for(i=0;i<5;i++) {
                n3b.x=r.Next (-100, 100); n3b.y=r.Next (-100, 100); n3b.z=r.Next (-100, 100);
                Console.WriteLine ("Nokta3B (x, y, z)= ({0}, {1}, {2})", n3b.x, n3b.y, n3b.z);
            }

            Console.WriteLine ("\n'protected' alts�n�flar� ve miraslayanlar� d���nda private'dir:");
            T�rediS�n�f ts = new T�rediS�n�f();
            for(i=0;i<5;i++) {
                ts1=r.Next (-100, 100); ts2=r.Next (-100, 100);
                ts.Koy1 (ts1, ts2); ts.Koy2();
                ts.G�ster1(); ts.G�ster2();
            }

            Console.WriteLine ("\n'internal' ve 'protected intenal' ayn� uygulamada public'tir:");
            InternalS�n�f is1 = new InternalS�n�f();
            for(i=0;i<5;i++) {
                is1.x=r.Next (-100, 100); is1.y=r.Next (-100, 100);
                Console.WriteLine ("{0} * {1} = {2}", is1.x, is1.y, is1.x*is1.y);   
            }

            Console.WriteLine ("\nAzami 5 bile�en eklemeli nesne grubu:");
            Bile�enGrubu grup = new Bile�enGrubu();
            for(i=0;i<1000;i++) grup.NesneEkle (new Bile�en());
            grup.Sunu�();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}