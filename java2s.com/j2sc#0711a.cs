// j2sc#0711a.cs: Parametriz ilkde�erli ve a��r�y�kl� parametli kurucular �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        public int x;
        public S�n�f1() {x = 20230919;} //Parametresiz kurucuyla i�sel ilkde�erleme
        public S�n�f1 (int i) {x = i;} //Tek parametreli kurucuyla d��sal ilkde�erleme
    }
    public class S�n�f2 {
        public int x;
        public int y;
        public S�n�f2 (int x, int y) {//�ift parametreli kurucu
            this.x = x;
            this.y = y;
        }
    }
    class S�n�f3 { 
        public static int a;
        public int b;
        static S�n�f3() {a = 19092023; Console.WriteLine ("Statik kurucu i�indeyim.");}
        public S�n�f3() {b = 20230919; Console.WriteLine ("Tipleme kurucu i�indeyim.");}
        public S�n�f3 (int b) {a=0; this.b=b; Console.WriteLine ("Tek parametreli kurucu i�indeyim.");}
        public S�n�f3 (int aa, int b) {a=aa; this.b=b; Console.WriteLine ("�ift parametreli kurucu i�indeyim.");}
    }
    class S�n�f4 {
        public int[] dizi;
        public int x;
        public int saya� = 0;
        public S�n�f4() {
            dizi=new int[]{1938, 11, 10, 9, 5, 45};
            x=20230919;
        }
        public S�n�f4 (int x, params int[] d) {
            this.x=x;
            dizi=new int[6]{d[0],d[1],d[2],d[3],d[4],d[5]};
        }
    }
    public class BankaHesab� {
        static int hesapNo2 = 1000;
        int hesapNo1;
        double bakiye;
        public BankaHesab�(): this (0, 0){}
        public BankaHesab� (double tutar): this (0, tutar){}
        public BankaHesab� (int ilkNo, double tutar) {
            if (ilkNo <= 0) {ilkNo = ++hesapNo2;}
            hesapNo1 = ilkNo;
            bakiye = tutar;
            if (bakiye < 0) bakiye = 0;
        }
        public void Yatan�ekilen (double tutar) {bakiye +=tutar; if (bakiye < 0) bakiye = 0;}
        public string HesapDurumu() {return String.Format ("#{0} = {1:#,0.00} TL", hesapNo1, bakiye);}
    }
    class Kurucu1 {
        static void Main() {
            Console.Write ("S�n�f�yla ayn� adl� olan metot benzeri return's�z kurucu tipledi�i nesneyi parametre yada i�sel atamayla ilkde�erler. Statik alan i�in this kullan�lmaz, tiplemeyle de�il s�n�f ad�yla eri�ilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f tiplemesini kuruculu i�sel veya parametrik ilkde�erleme:");
            var r=new Random(); int ts1, ts2, i;
            S�n�f1 t1 = new S�n�f1(); Console.WriteLine ("t1.x = {0}", t1.x);
            ts1=r.Next (-1000, 1000); t1 = new S�n�f1(); t1.x=ts1; Console.WriteLine ("t1.x = {0}", t1.x);
            ts1=r.Next (-1000, 1000); var t2 = new S�n�f1 (ts1); Console.WriteLine ("t2.x = {0}", t2.x);
            ts1=r.Next (-1000, 1000); t2 = new S�n�f1 (ts1); Console.WriteLine ("t2.x = {0}", t2.x);

            Console.WriteLine ("\nParametresiz kurucusu yoksa parametresiz tiplenemez:");
            //S�n�f2 s2 = new S�n�f2(); //Derleme hatas� verir
            S�n�f2 s2;
            for (i=0; i<5; i++) {
                ts1=r.Next (-1000, 1000);
                ts2=r.Next (-1000, 1000);
                s2 = new S�n�f2 (ts1, ts2);
                Console.WriteLine ("S�n�f2 (x, y) = ({0}, {1})", s2.x, s2.y);
            }

            Console.WriteLine ("\nStatik, tiplemeli, parametresiz, tek/�ift-parametreli kurucular:");
            S�n�f3 s3 = new S�n�f3(); Console.WriteLine ("S�n�f3 (a, b) = ({0}, {1})", S�n�f3.a, s3.b);
            ts1=r.Next (-1000, 1000); s3 = new S�n�f3 (ts1); Console.WriteLine ("S�n�f3 (a, b) = ({0}, {1})", S�n�f3.a, s3.b);
            ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000); s3 = new S�n�f3 (ts1, ts2); Console.WriteLine ("S�n�f3 (a, b) = ({0}, {1})", S�n�f3.a, s3.b);

            Console.WriteLine ("\nParametresiz ve parametreli kurucularla dizisel alan� ilkde�erleme:");
            S�n�f4 s4 = new S�n�f4(); s4.saya�++; s4.saya� +=10; Console.WriteLine ("S�n�f4 (saya�, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.saya�, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);
            s4 = new S�n�f4 (19381110, 2023, 9, 19, 22, 53, 34); s4.saya�++; s4.saya� +=100; Console.WriteLine ("S�n�f4 (saya�, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.saya�, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);
            s4 = new S�n�f4 (19550807, 1955, 8, 7, 14, 32, 51); s4.saya�++; s4.saya� +=1000; Console.WriteLine ("S�n�f4 (saya�, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.saya�, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);

            Console.WriteLine ("\nBanka hesab�na yatan, �ekilen ve bakiye bilgileri:");
            double ds1=r.Next (-10000, 10000)+r.Next (0, 10000)/10000D;
            BankaHesab� bh = new BankaHesab�(); Console.Write ("Hesap a��l���\t"); Console.Write (bh.HesapDurumu() );
            bh = new BankaHesab� (ds1); Console.Write ("\nYatan/�ekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            bh = new BankaHesab� (-2023, ds1); Console.Write ("Yatan/�ekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            for (i=0; i<5; i++) {
                ds1=r.Next (-10000, 10000)+r.Next (0, 10000)/10000D;
                bh.Yatan�ekilen (ds1);
                Console.Write ("Yatan/�ekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}