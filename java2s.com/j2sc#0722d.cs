// j2sc#0722d.cs: Sadeceokunabilir/readonly de�i�kene ilkde�er-li/siz veri atama �rne�i.

using System;
namespace S�n�flar {
    class Renk {
        public int k�rm�z�, ye�il, mavi;
        public Renk (int k�rm�z�, int ye�il, int mavi) {this.k�rm�z� = k�rm�z�; this.ye�il = ye�il; this.mavi = mavi;} //Kurucu
        public static readonly Renk K�rm�z�, Ye�il, Mavi, Sar�, Beyaz, Siyah; //Sabit renk nesneleri
        static Renk() {//Sabit readonly renkleri de�i�mez ilkde�erle yaratma
            K�rm�z� = new Renk (255, 0, 0);
            Ye�il = new Renk (0, 255, 0);
            Mavi = new Renk (0, 0, 255);
            Sar� = new Renk (255, 255, 0);
            Siyah = new Renk (0, 0, 0);
            Beyaz = new Renk (255, 255, 255);
        }
    }
    public class Bisiklet {
        public readonly string marka;
        public static readonly int vitesSay�s� = 3 * 7;
        public Bisiklet (string marka) {Console.WriteLine ("{0} markal� bisiklet nesnesi yarat�l�yor.", marka); this.marka = marka;} //Kurucu
    }
    public class Kordinat3B {
        public readonly int x = 1881; //�lkde�erliyse ba�kaca de�er alamaz
        public readonly int y; //�lkde�ersizse �okkez de�er atamas� yap�labilir
        public const int z = 1938; //Sabit ilkde�erle yarat�lmal�d�r
        public Kordinat3B(int y) {this.y = 1919; this.y = 1921; De�erAta (ref this.y); this.y=y;} //Kurucuyla ilkde�ersiz readonly y'ye �oklu de�er atama
        private void De�erAta (ref int de�er) {de�er = 1923;}
    }
    public class Readonly�zellik {
        readonly int ya�;
        readonly double maa�;
        public int Ya� {get {return ya�;}}
        public double Maa� {get {return maa�;}}
        public Readonly�zellik (int ya�, double maa�) {this.ya�=ya�; this.maa�=maa�;}
    }
    class �e�itli4 {
        public static readonly int EBAT = 50;
        static void Main() {
             Console.Write ("Sadeceokunabilir/readonly de�i�kene ilkde�er atanabilir, ama sonradan de�i�tirilemez. �lkde�ersizse sadece her yeni nesne kurucusuyla dahilen/parametreyle de�er atanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

             Console.WriteLine ("'readonly' EBAT'l� dizi elemanlar�na de�er atama ve okuma:");
             var r=new Random(); int ts1, ts2, ts3, i;
             int[] say�lar = new int [�e�itli4.EBAT];
             for(i=0;i<�e�itli4.EBAT;i++) say�lar [i]=r.Next(-100,100);
             for(i=0;i<�e�itli4.EBAT;i++) Console.Write ("{0}={1}, ", i, say�lar [i]);
             //�e�itli4.EBAT=100; //De�i�tirilemez derleme hatas�

             Console.WriteLine ("\n\nSabit readonly renkler ve karma geli�ig�zel renk de�erleri:");
             Renk rnk = Renk.K�rm�z�; Console.WriteLine ("Renk.K�rm�z� (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             rnk = Renk.Sar�; Console.WriteLine ("Renk.Sar� (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             rnk = Renk.Mavi; Console.WriteLine ("Renk.Mavi (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             rnk = Renk.Ye�il; Console.WriteLine ("Renk.Ye�il (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             rnk = Renk.Siyah; Console.WriteLine ("Renk.Siyah (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             rnk = Renk.Beyaz; Console.WriteLine ("Renk.Beyaz (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
             for(i=0;i<5;i++) {
                ts1=r.Next(0,256); ts2=r.Next(0,256); ts3=r.Next(0,256);
                rnk=new Renk (ts1,ts2,ts3);
                Console.WriteLine ("\tRenk.Karma (k,y,m) = ({0}, {1}, {2})", rnk.k�rm�z�, rnk.ye�il, rnk.mavi);
            }

            Console.WriteLine ("\nHer yeni Bisikler nesnesine readonly marka atanabilir:");
            Console.WriteLine ("Bisiklet.vitesSay�s� = " + Bisiklet.vitesSay�s�);
            Bisiklet bis = new Bisiklet ("JET"); Console.WriteLine ("\tbis.marka = " + bis.marka);
            bis = new Bisiklet ("��TA"); Console.WriteLine ("\tbis.marka = " + bis.marka);
            bis = new Bisiklet ("TAZI"); Console.WriteLine ("\tbis.marka = " + bis.marka);

            Console.WriteLine ("\n�lkde�erli 'const z' ve ilkde�erli/de�ersiz 'readonly x/y':");
            Kordinat3B k3b;
            for(i=0;i<5;i++) {ts1=r.Next(1923,1938); k3b = new Kordinat3B(ts1); Console.WriteLine ("(x,y,z) = ({0}, {1}, {2})", k3b.x, k3b.y, Kordinat3B.z);}

            Console.WriteLine ("\n'readonly ya�, maa�'�n her yeni kurulu�la atan�p �zellik'le okunmas�:");
            Readonly�zellik ym;
            double ds1;
            for(i=0;i<5;i++) {
                ts1=r.Next(18,66);
                ds1=r.Next(7865,100000)+r.Next(10,100)/100D;
                ym = new Readonly�zellik (ts1, ds1);
                Console.WriteLine ("(ya�,maa�) = ({0}, {1,9:#,0.00})", ym.Ya�, ym.Maa�);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}