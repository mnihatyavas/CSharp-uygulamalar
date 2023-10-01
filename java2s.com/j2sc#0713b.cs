// j2sc#0713b.cs: Tüm alan eriþimlerinin karþýlaþtýrýlmalarý örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {  
        private int a; //aþikar private belirteçli
        int b; //varsayýlý private belirteçli
        public int gama; //public eriþim
        public void alfaKoy (int a) {this.a = a;}
        public int alfaAl() {return a;}
        public void betaKoy (int a) {b = a;}
        public int betaAl() {return b;}
    }
    class Sýnýf2 {
        int sayaç;
        public Sýnýf2() {sayaç = 1881;} //Kurucuyla ilkdeðerleme
        public int Sayaç {get {return sayaç;} set {sayaç = value;} }
        public void sayacýBirartýr() {Sayaç++;}
    }
    class Nokta2B {public int x, y;}
    class Nokta3B : Nokta2B {public int z;}
    class TemelSýnýf {
        protected int i, j; //Miraslayan eriþir
        public void Koy1 (int a, int b) {i = a; j = b;}
        public void Göster1() {Console.Write ("{0} * {1} = ", i, j);}
    }
    class TürediSýnýf : TemelSýnýf {
        int k; // private 
        public void Koy2() {k = i * j;} 
        public void Göster2() {Console.WriteLine (k);}
    }
    class InternalSýnýf {
        internal int x; //Ayný uygulama içinde eriþilir
        protected internal int y; //Hem ayný uygulamada, hem de diðer uygulamalarýn miraslayanlarýnda eriþilir
    }
    public class BileþenGrubu {
        internal Bileþen[] nesneler;
        protected internal int nesneSayýsý;
        public BileþenGrubu() {//Ýlkdeðerlemeli kurucu
            nesneler = new Bileþen [5];
            nesneSayýsý = 0;
        }
        public void NesneEkle (Bileþen nesne) {
            if (nesneSayýsý < 5) {
                nesneler [nesneSayýsý] = nesne;
                nesneSayýsý++;
            }
        }
        public void Sunuþ() {for (int i = 0; i < nesneSayýsý; i++) Console.WriteLine (nesneler [i]);}
    }
    public class Bileþen {/* internal void Sunuþ(){} */ }//Ýçerik olsa da olmasa da farketmez
    class EriþimDeðiþtireci2 {
        static void Main() {
            Console.Write ("'public' alana sýnýfý tiplemeli doðrudan eriþilirken, 'private' alana 'public' metoduyla eriþilir. Parametresiz 'get-set'in set'inde 'value' atanýr. 'internal'a sadece ayný uygulamada tiplemeyle; 'protected internal'a internal gibi, ayrýca haricen miraslamayla eriþilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("private'ye public metotla, public'e doðrudan eriþim:");
            var r=new Random(); int ts1, ts2, ts3, i;
            Sýnýf1 s1 = new Sýnýf1();
            for(i=0;i<5;i++) {
                ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100);
                s1.alfaKoy (ts1); s1.betaKoy (ts2); s1.gama=ts3;
                Console.WriteLine ("(alfa, beta, gama)= ({0}, {1}, {2})", s1.alfaAl(), s1.betaAl(), s1.gama);
            }

            Console.WriteLine ("\nprivate'ye metot()'suz public set-get'le de eriþilebilir;");
            Sýnýf2 s2 = new Sýnýf2(); Console.WriteLine ("s2.Sayaç'ýn kuruluþ ilkdeðeri: {0} ", s2.Sayaç);
            for(i=1882;i<=1938;i++) {
                s2.sayacýBirartýr();
                Console.Write (s2.Sayaç + " ");
            } Console.WriteLine();

            Console.WriteLine ("\n2 boyutlu'yu miraslayan 3 boyutlu public alanlý noktalar:");
            Nokta3B n3b = new Nokta3B();
            for(i=0;i<5;i++) {
                n3b.x=r.Next (-100, 100); n3b.y=r.Next (-100, 100); n3b.z=r.Next (-100, 100);
                Console.WriteLine ("Nokta3B (x, y, z)= ({0}, {1}, {2})", n3b.x, n3b.y, n3b.z);
            }

            Console.WriteLine ("\n'protected' altsýnýflarý ve miraslayanlarý dýþýnda private'dir:");
            TürediSýnýf ts = new TürediSýnýf();
            for(i=0;i<5;i++) {
                ts1=r.Next (-100, 100); ts2=r.Next (-100, 100);
                ts.Koy1 (ts1, ts2); ts.Koy2();
                ts.Göster1(); ts.Göster2();
            }

            Console.WriteLine ("\n'internal' ve 'protected intenal' ayný uygulamada public'tir:");
            InternalSýnýf is1 = new InternalSýnýf();
            for(i=0;i<5;i++) {
                is1.x=r.Next (-100, 100); is1.y=r.Next (-100, 100);
                Console.WriteLine ("{0} * {1} = {2}", is1.x, is1.y, is1.x*is1.y);   
            }

            Console.WriteLine ("\nAzami 5 bileþen eklemeli nesne grubu:");
            BileþenGrubu grup = new BileþenGrubu();
            for(i=0;i<1000;i++) grup.NesneEkle (new Bileþen());
            grup.Sunuþ();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}