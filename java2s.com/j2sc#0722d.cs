// j2sc#0722d.cs: Sadeceokunabilir/readonly deðiþkene ilkdeðer-li/siz veri atama örneði.

using System;
namespace Sýnýflar {
    class Renk {
        public int kýrmýzý, yeþil, mavi;
        public Renk (int kýrmýzý, int yeþil, int mavi) {this.kýrmýzý = kýrmýzý; this.yeþil = yeþil; this.mavi = mavi;} //Kurucu
        public static readonly Renk Kýrmýzý, Yeþil, Mavi, Sarý, Beyaz, Siyah; //Sabit renk nesneleri
        static Renk() {//Sabit readonly renkleri deðiþmez ilkdeðerle yaratma
            Kýrmýzý = new Renk (255, 0, 0);
            Yeþil = new Renk (0, 255, 0);
            Mavi = new Renk (0, 0, 255);
            Sarý = new Renk (255, 255, 0);
            Siyah = new Renk (0, 0, 0);
            Beyaz = new Renk (255, 255, 255);
        }
    }
    public class Bisiklet {
        public readonly string marka;
        public static readonly int vitesSayýsý = 3 * 7;
        public Bisiklet (string marka) {Console.WriteLine ("{0} markalý bisiklet nesnesi yaratýlýyor.", marka); this.marka = marka;} //Kurucu
    }
    public class Kordinat3B {
        public readonly int x = 1881; //Ýlkdeðerliyse baþkaca deðer alamaz
        public readonly int y; //Ýlkdeðersizse çokkez deðer atamasý yapýlabilir
        public const int z = 1938; //Sabit ilkdeðerle yaratýlmalýdýr
        public Kordinat3B(int y) {this.y = 1919; this.y = 1921; DeðerAta (ref this.y); this.y=y;} //Kurucuyla ilkdeðersiz readonly y'ye çoklu deðer atama
        private void DeðerAta (ref int deðer) {deðer = 1923;}
    }
    public class ReadonlyÖzellik {
        readonly int yaþ;
        readonly double maaþ;
        public int Yaþ {get {return yaþ;}}
        public double Maaþ {get {return maaþ;}}
        public ReadonlyÖzellik (int yaþ, double maaþ) {this.yaþ=yaþ; this.maaþ=maaþ;}
    }
    class Çeþitli4 {
        public static readonly int EBAT = 50;
        static void Main() {
             Console.Write ("Sadeceokunabilir/readonly deðiþkene ilkdeðer atanabilir, ama sonradan deðiþtirilemez. Ýlkdeðersizse sadece her yeni nesne kurucusuyla dahilen/parametreyle deðer atanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

             Console.WriteLine ("'readonly' EBAT'lý dizi elemanlarýna deðer atama ve okuma:");
             var r=new Random(); int ts1, ts2, ts3, i;
             int[] sayýlar = new int [Çeþitli4.EBAT];
             for(i=0;i<Çeþitli4.EBAT;i++) sayýlar [i]=r.Next(-100,100);
             for(i=0;i<Çeþitli4.EBAT;i++) Console.Write ("{0}={1}, ", i, sayýlar [i]);
             //Çeþitli4.EBAT=100; //Deðiþtirilemez derleme hatasý

             Console.WriteLine ("\n\nSabit readonly renkler ve karma geliþigüzel renk deðerleri:");
             Renk rnk = Renk.Kýrmýzý; Console.WriteLine ("Renk.Kýrmýzý (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             rnk = Renk.Sarý; Console.WriteLine ("Renk.Sarý (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             rnk = Renk.Mavi; Console.WriteLine ("Renk.Mavi (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             rnk = Renk.Yeþil; Console.WriteLine ("Renk.Yeþil (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             rnk = Renk.Siyah; Console.WriteLine ("Renk.Siyah (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             rnk = Renk.Beyaz; Console.WriteLine ("Renk.Beyaz (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
             for(i=0;i<5;i++) {
                ts1=r.Next(0,256); ts2=r.Next(0,256); ts3=r.Next(0,256);
                rnk=new Renk (ts1,ts2,ts3);
                Console.WriteLine ("\tRenk.Karma (k,y,m) = ({0}, {1}, {2})", rnk.kýrmýzý, rnk.yeþil, rnk.mavi);
            }

            Console.WriteLine ("\nHer yeni Bisikler nesnesine readonly marka atanabilir:");
            Console.WriteLine ("Bisiklet.vitesSayýsý = " + Bisiklet.vitesSayýsý);
            Bisiklet bis = new Bisiklet ("JET"); Console.WriteLine ("\tbis.marka = " + bis.marka);
            bis = new Bisiklet ("ÇÝTA"); Console.WriteLine ("\tbis.marka = " + bis.marka);
            bis = new Bisiklet ("TAZI"); Console.WriteLine ("\tbis.marka = " + bis.marka);

            Console.WriteLine ("\nÝlkdeðerli 'const z' ve ilkdeðerli/deðersiz 'readonly x/y':");
            Kordinat3B k3b;
            for(i=0;i<5;i++) {ts1=r.Next(1923,1938); k3b = new Kordinat3B(ts1); Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", k3b.x, k3b.y, Kordinat3B.z);}

            Console.WriteLine ("\n'readonly yaþ, maaþ'ýn her yeni kuruluþla atanýp özellik'le okunmasý:");
            ReadonlyÖzellik ym;
            double ds1;
            for(i=0;i<5;i++) {
                ts1=r.Next(18,66);
                ds1=r.Next(7865,100000)+r.Next(10,100)/100D;
                ym = new ReadonlyÖzellik (ts1, ds1);
                Console.WriteLine ("(yaþ,maaþ) = ({0}, {1,9:#,0.00})", ym.Yaþ, ym.Maaþ);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}