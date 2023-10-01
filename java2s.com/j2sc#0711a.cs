// j2sc#0711a.cs: Parametriz ilkdeðerli ve aþýrýyüklü parametli kurucular örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        public int x;
        public Sýnýf1() {x = 20230919;} //Parametresiz kurucuyla içsel ilkdeðerleme
        public Sýnýf1 (int i) {x = i;} //Tek parametreli kurucuyla dýþsal ilkdeðerleme
    }
    public class Sýnýf2 {
        public int x;
        public int y;
        public Sýnýf2 (int x, int y) {//Çift parametreli kurucu
            this.x = x;
            this.y = y;
        }
    }
    class Sýnýf3 { 
        public static int a;
        public int b;
        static Sýnýf3() {a = 19092023; Console.WriteLine ("Statik kurucu içindeyim.");}
        public Sýnýf3() {b = 20230919; Console.WriteLine ("Tipleme kurucu içindeyim.");}
        public Sýnýf3 (int b) {a=0; this.b=b; Console.WriteLine ("Tek parametreli kurucu içindeyim.");}
        public Sýnýf3 (int aa, int b) {a=aa; this.b=b; Console.WriteLine ("Çift parametreli kurucu içindeyim.");}
    }
    class Sýnýf4 {
        public int[] dizi;
        public int x;
        public int sayaç = 0;
        public Sýnýf4() {
            dizi=new int[]{1938, 11, 10, 9, 5, 45};
            x=20230919;
        }
        public Sýnýf4 (int x, params int[] d) {
            this.x=x;
            dizi=new int[6]{d[0],d[1],d[2],d[3],d[4],d[5]};
        }
    }
    public class BankaHesabý {
        static int hesapNo2 = 1000;
        int hesapNo1;
        double bakiye;
        public BankaHesabý(): this (0, 0){}
        public BankaHesabý (double tutar): this (0, tutar){}
        public BankaHesabý (int ilkNo, double tutar) {
            if (ilkNo <= 0) {ilkNo = ++hesapNo2;}
            hesapNo1 = ilkNo;
            bakiye = tutar;
            if (bakiye < 0) bakiye = 0;
        }
        public void YatanÇekilen (double tutar) {bakiye +=tutar; if (bakiye < 0) bakiye = 0;}
        public string HesapDurumu() {return String.Format ("#{0} = {1:#,0.00} TL", hesapNo1, bakiye);}
    }
    class Kurucu1 {
        static void Main() {
            Console.Write ("Sýnýfýyla ayný adlý olan metot benzeri return'süz kurucu tiplediði nesneyi parametre yada içsel atamayla ilkdeðerler. Statik alan için this kullanýlmaz, tiplemeyle deðil sýnýf adýyla eriþilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf tiplemesini kuruculu içsel veya parametrik ilkdeðerleme:");
            var r=new Random(); int ts1, ts2, i;
            Sýnýf1 t1 = new Sýnýf1(); Console.WriteLine ("t1.x = {0}", t1.x);
            ts1=r.Next (-1000, 1000); t1 = new Sýnýf1(); t1.x=ts1; Console.WriteLine ("t1.x = {0}", t1.x);
            ts1=r.Next (-1000, 1000); var t2 = new Sýnýf1 (ts1); Console.WriteLine ("t2.x = {0}", t2.x);
            ts1=r.Next (-1000, 1000); t2 = new Sýnýf1 (ts1); Console.WriteLine ("t2.x = {0}", t2.x);

            Console.WriteLine ("\nParametresiz kurucusu yoksa parametresiz tiplenemez:");
            //Sýnýf2 s2 = new Sýnýf2(); //Derleme hatasý verir
            Sýnýf2 s2;
            for (i=0; i<5; i++) {
                ts1=r.Next (-1000, 1000);
                ts2=r.Next (-1000, 1000);
                s2 = new Sýnýf2 (ts1, ts2);
                Console.WriteLine ("Sýnýf2 (x, y) = ({0}, {1})", s2.x, s2.y);
            }

            Console.WriteLine ("\nStatik, tiplemeli, parametresiz, tek/çift-parametreli kurucular:");
            Sýnýf3 s3 = new Sýnýf3(); Console.WriteLine ("Sýnýf3 (a, b) = ({0}, {1})", Sýnýf3.a, s3.b);
            ts1=r.Next (-1000, 1000); s3 = new Sýnýf3 (ts1); Console.WriteLine ("Sýnýf3 (a, b) = ({0}, {1})", Sýnýf3.a, s3.b);
            ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000); s3 = new Sýnýf3 (ts1, ts2); Console.WriteLine ("Sýnýf3 (a, b) = ({0}, {1})", Sýnýf3.a, s3.b);

            Console.WriteLine ("\nParametresiz ve parametreli kurucularla dizisel alaný ilkdeðerleme:");
            Sýnýf4 s4 = new Sýnýf4(); s4.sayaç++; s4.sayaç +=10; Console.WriteLine ("Sýnýf4 (sayaç, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.sayaç, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);
            s4 = new Sýnýf4 (19381110, 2023, 9, 19, 22, 53, 34); s4.sayaç++; s4.sayaç +=100; Console.WriteLine ("Sýnýf4 (sayaç, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.sayaç, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);
            s4 = new Sýnýf4 (19550807, 1955, 8, 7, 14, 32, 51); s4.sayaç++; s4.sayaç +=1000; Console.WriteLine ("Sýnýf4 (sayaç, x, dizi) = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", s4.sayaç, s4.x, s4.dizi[0], s4.dizi[1], s4.dizi[2], s4.dizi[3], s4.dizi[4], s4.dizi[5]);

            Console.WriteLine ("\nBanka hesabýna yatan, çekilen ve bakiye bilgileri:");
            double ds1=r.Next (-10000, 10000)+r.Next (0, 10000)/10000D;
            BankaHesabý bh = new BankaHesabý(); Console.Write ("Hesap açýlýþý\t"); Console.Write (bh.HesapDurumu() );
            bh = new BankaHesabý (ds1); Console.Write ("\nYatan/Çekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            bh = new BankaHesabý (-2023, ds1); Console.Write ("Yatan/Çekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            for (i=0; i<5; i++) {
                ds1=r.Next (-10000, 10000)+r.Next (0, 10000)/10000D;
                bh.YatanÇekilen (ds1);
                Console.Write ("Yatan/Çekilen: {0:#,0.00} TL\tBakiye: ", ds1); Console.WriteLine (bh.HesapDurumu());
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}