// j2sc#0112.cs: Metodun 'out' parametrik �oklu gerid�n�� sa�lamas� �rne�i.

using System;
namespace DilTemelleri {
    class Nokta {
        int x, y;
        public Nokta (int x, int y) {this.x = x; this.y = y;}
        public void Noktay�Al1 (out int x, out int y) {x = this.x; y = this.y;}
        public void Noktay�Al2 (ref int x, ref int y) {x = this.x; y = this.y;}
    }
    class Ayr��t�r {
        public int par�ala (double say�, out double k�s�rat) { 
            int tamsay� = (int)say�; 
            k�s�rat = say� - tamsay�; //'out' ile gerid�n��
            return tamsay�; // 'return' ile gerid�n��
        }
    }
    class OrtakB�len {
        public bool ortakB�lenVarm� (int x, int y, out string d) {
            d="";
            int kere; if (x > y) kere=y; else kere=x;
            for (int i=2; i <= (int)kere/2; i++) {if ((double)x%i==0d & (double)y%i==0d) d+=i+" ";}
            if (d=="") return false; else return true;
        }
    }
    class Out {
        public static void Topla (int x,int y, out int toplam) {toplam = x + y;}
        static void Main() {
            Console.Write ("'out' arg�mana ilkde�er atamas� gerekmez, ancak atansa dahi 'out' parametresi atanmam�� addeder. Ama metod gerid�n��� �ncesi t�m 'out' parametreleri de�er y�kl� ister. Yani 'ref' �ift tarafl� de�er aktar�m� sa�larken, 'out' sadece metoddan gerid�n�� sa�lar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r = new Random();int cevap, r1=r.Next (1, 1000), r2=r.Next (1, 1000);
            Topla (r1, r2, out cevap);
            Console.WriteLine ("Toplam: {0} + {1} = {2}", r1, r2, cevap);
            r1=r.Next (1, 1000); r2=r.Next (1, 1000); Topla (r1, r2, out cevap);
            Console.WriteLine ("Toplam: {0} + {1} = {2}", r1, r2, cevap);

            int x, y; // 'out' ilkde�er atanmas� istemez
            var noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.Noktay�Al1 (out x, out y); Console.WriteLine ("\n'out' ile Nokta ({0}, {1})", x, y);
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.Noktay�Al1 (out x, out y); Console.WriteLine ("'out' ile Nokta ({0}, {1})", x, y);

            int a=0, b=0; // 'ref' ilkde�er atanmas� ister
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.Noktay�Al2 (ref a, ref b); Console.WriteLine ("\n'ref' ile Nokta ({0}, {1})", a, b);
            noktam = new Nokta (r.Next (1, 100), r.Next (1, 100)); noktam.Noktay�Al2 (ref a, ref b); Console.WriteLine ("'ref' ile Nokta ({0}, {1})", a, b);

            var ayr��t�r = new Ayr��t�r();
            int ts; double sy, ksr;
            ts = ayr��t�r.par�ala (sy = r.Next (1, 1000000) / 10000d, out ksr); Console.WriteLine ("\nAyr��t�rma: {0} = {1} + {2:0.0###}", sy, ts, ksr);
            ts = ayr��t�r.par�ala (sy = r.Next (1, 1000000) / 10000d, out ksr); Console.WriteLine ("Ayr��t�rma: {0} = {1} + {2:0.0###}", sy, ts, ksr);

            var ob = new OrtakB�len();
            x = r.Next (1, 1000); y = r.Next (1, 1000); string sonu�; //x=24, y=768 veya 216 ve 168 dene
            if (ob.ortakB�lenVarm� (x, y, out sonu�) ) Console.WriteLine ("\n{0} ve {1} say�lar�n�n ortak b�lenleri: {2}", x, y, sonu�);
            else Console.WriteLine ("\n{0} ve {1} say�lar�n�n ortak b�lenleri: YOK", x, y);
            x = r.Next (1, 1000); y = r.Next (1, 1000);
            if (ob.ortakB�lenVarm� (x, y, out sonu�) ) Console.WriteLine ("{0} ve {1} say�lar�n�n ortak b�lenleri: {2}", x, y, sonu�);
            else Console.WriteLine ("{0} ve {1} say�lar�n�n ortak b�lenleri: YOK", x, y);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}