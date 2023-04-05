// j2sc#0116.cs: Deðiþebilir adet metot argümanlarýnýn 'params' ile idaresi örneði.

using System;
namespace DilTemelleri {
    class EnKüçükBüyük {
        public int enküçükBüyük (out int enbüyük, params int[] sayýlar) {
            //if (sayýlar.Length == 0) {Console.WriteLine ("HATA: Argüman YOK."); return 0;}
            int enküçük = enbüyük = sayýlar [0];
            for (int i=1; i < sayýlar.Length; i++) {
                if (sayýlar [i] < enküçük) enküçük = sayýlar [i];
                if (sayýlar [i] > enbüyük) enbüyük = sayýlar [i];
            }
            return enküçük;
        }
    }
    class ArgümanlarýGöster {
        public void argümanlarýGöster (string mesaj, params int[] sayýlar) {
            int n=0; Console.Write ("\n" + mesaj + ": ");
            foreach (int i in sayýlar) {++n; Console.Write (i + " ");} Console.WriteLine ("\n ==>Argüman sayýsý: " + n);
        }
    }
    class Þahýs {
        public string isim;
        public int yaþ;
        public Þahýs (string i, int y) {isim = i; yaþ = y;}
        public void Göster() {Console.WriteLine ("{0} adlý þahýs {1} yaþýndadýr.", isim, yaþ);}
    }
    class Params {
        public static void NesnelerDizisi (params object[] dizi) {
            for (int i = 0 ; i < dizi.Length ; i++ ) {   
                if (dizi [i] is Þahýs) {((Þahýs)dizi [i]).Göster();
                }else Console.WriteLine (dizi [i]);
            }
        }
        static void Main() {
            Console.Write ("Her veri tipli deðiþebilir sayýdaki metot argümanlarý 'params tip[] dizi' ile yönetilebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var nesne1 = new EnKüçükBüyük(); int büyük; var r=new Random();
            var dizi = new int[] {2023, 1951}; Console.WriteLine ("{0} elemanlý tamsayý dizinin enküçük ve enbüyük elemanlarý: ({1}, {2})", dizi.Length, nesne1.enküçükBüyük (out büyük, dizi), büyük);
            dizi = new int[] {2023, 1951, 1938, 1881}; Console.WriteLine ("{0} elemanlý tamsayý dizinin enküçük ve enbüyük elemanlarý: ({1}, {2})", dizi.Length, nesne1.enküçükBüyük (out büyük, dizi), büyük);
            dizi = new int[] {2023, 1951, 1938, 1881, -450, 0}; Console.WriteLine ("{0} elemanlý tamsayý dizinin enküçük ve enbüyük elemanlarý: ({1}, {2})", dizi.Length, nesne1.enküçükBüyük (out büyük, dizi), büyük);
            int n=r.Next (2, 100);
            dizi=new int [n]; for (int i=0; i < n; i++) dizi [i]=r.Next (-10000, 10000);
            Console.WriteLine ("{0} elemanlý tamsayý dizinin enküçük ve enbüyük elemanlarý: ({1}, {2})", n, nesne1.enküçükBüyük (out büyük, dizi), büyük);

            var nesne2 = new ArgümanlarýGöster(); 
            nesne2.argümanlarýGöster ("Ýþte birkaç tamsayý", 1, 2, 3, 4, 5);
            nesne2.argümanlarýGöster ("Ýþte birkaç yýl", 1881, 1938, 1951, 2023);
            nesne2.argümanlarýGöster ("Al sana ekstra MÖ ve MS yýllar", dizi);

            var þ1 = new Þahýs ("M.Nihat Yavaþ", 2023-1957);
            var þ2 = new Þahýs ("Sevim Yavaþ", 2023-1963);
            var þ3 = new Þahýs ("Zafer N.Candan", 2023-1977);
            Console.WriteLine(); NesnelerDizisi (true, þ1, 1938-1881, þ2, "System.String", þ3, "Merhabalar!..", (1==0));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}