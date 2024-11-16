// j2sc#2201d.cs: Func, delegeli ve lambda'lý fonksiyonlar örneði.

using System;
using System.Collections.Generic; // Soysal IEnumerable<> için
using System.Linq; //Select için
using System.Linq.Expressions; //Expression için
using System.Collections; //ArrayList için
namespace Anonimler {
    delegate int YýlDelegesi();
    delegate double KarekökDelegesi (int i);
    class Ürün {
        public string ad {get; private set;}
        public int adet {get; private set;}
        public decimal fiyat {get; private set;}
        public Ürün (string a, int adt, decimal f) {ad = a; adet=adt; fiyat = f;} //Kurucu-parametreli
        Ürün(){}  //Kurucu-parametresiz
        public static List<Ürün> ürünleriAl() {
            return new List<Ürün> {
                new Ürün {ad="Cetvel", adet=1265, fiyat = 57.35m},
                new Ürün {ad="Kalem", adet=8261, fiyat=45.87m},
                new Ürün {ad="Defter", adet=879, fiyat=1165.75m},
                new Ürün {ad="Silgi", adet=12653, fiyat=35.72m},
                new Ürün {ad="Çanta", adet=657, fiyat=587.93m}
            };
        }
        public override string ToString() {return string.Format ("Ad: {0}\tFiyat: {1,8:#,0.00} TL\tAdet: {2:#,0}", ad, fiyat, adet);}
    }
    class Lambda {
        static YýlDelegesi YýlSayacý() {
            int yýl = 1881;
            return () => yýl++;
        }
        public delegate Boolean þehirKontrolu (String dizge);
        public static String[] ÞehirSeçimi (String[] þehirler, þehirKontrolu seç) {
            ArrayList seçiliListe = new ArrayList();
            foreach(String þehir in þehirler) if (seç (þehir)) seçiliListe.Add (þehir);
            return (String[])seçiliListe.ToArray (typeof (String));
        }
        static void Main() {
            Console.Write ("Func<int,bool> anonim fonksiyonda parametre <int>, dönen <bool> olmalýdýr; delegeli '=delegate(int x){return (x&1)==1}' yerine lambda 'x=>(x&1)==1' kullanýlmýþtýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("[1881,1938] arasý rasgele tek/çift yýllar:");
            var r=new Random(); int i, ts1, ts2;
            Func<int, bool> tekMi = x => (x & 1) == 1; //bool &'le sonu 1 yada 0?
            for(i = 0; i < 10; i++) {
               ts1=r.Next(1881,1938);
               if (tekMi (ts1)) Console.WriteLine (ts1 + " tek yýl'dýr");
               else Console.WriteLine (ts1 + " çift yýl'dýr");
            }
            Console.WriteLine ("-->Func lambda örneðin Expression derlenmiþ sürümü:");
            Expression <Func<int, bool>> TekMi = n => (n & 1) == 1;
            Func<int, bool> tekMiDerle = TekMi.Compile();
            for (i = 0; i < 10; i++) {
               ts1=r.Next(1881,1938);
               if (tekMiDerle (ts1)) Console.WriteLine (ts1 + " tek yýl'dýr");
               else Console.WriteLine (ts1 + " çift yýl'dýr");
            }

            Console.WriteLine ("\nyyyyaagg yýllar ve yyyy-aa-gg seçili sorgu sunumlarý:");
            int[] yýllar = new int[1939-1881];
            for(i=0;i<=(1938-1881);i++) {
                ts1=r.Next(1,13); ts2=r.Next(1,32);
                yýllar [i] = ((i+1881)*100+ts1)*100+ts2;
            }
            IEnumerable<int> yýlAyGün = yýllar.Select (yýl => yýl);
            foreach(var yýl in yýllar) Console.Write (yýl + " "); Console.WriteLine();
            foreach(var yýl in yýlAyGün) Console.Write ("{0}-{1}-{2} ", yýl/10000, (yýl-(yýl/10000)*10000)/100, Int32.Parse ((yýl.ToString()).Substring (6,2)) ); Console.WriteLine();

            Console.WriteLine ("\nDelegeli lambda dönüþlü [1881,1938]:57 döngülü sayaç çaðrýsý:");
            YýlDelegesi ysayaç = YýlSayacý();
            for(i=0;i<=(1938-1881);i++) Console.Write (ysayaç()+" "); Console.WriteLine();
            Console.WriteLine ("-->Delegeli lambda dönüþlü [1881,1938]:57 döngülü ifade çaðrýsý:");
            ts1 = 1881;
            YýlDelegesi ydlg = () => ts1++;
            for(i=0;i<=(1938-1881);i++) Console.Write (ydlg()+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 10 tamsanýn karesi (Func) ve karekökü (delege):");
            Func<int, int> kare = x => x * x;
            KarekökDelegesi karekök = x => Math.Sqrt (x);
            for(i=0;i<10;i++) {
                ts1=r.Next(1881,2024);
                Console.WriteLine ("Tamsayý: {0}\tKaresi: {1:#,0}\tKarekökü: {2:0.0000}", ts1, kare (ts1), karekök (ts1));
            }

            Console.WriteLine ("\nHer üç alan için Sort'la lambda artan/azalan sýralamalý dökümler:");
            List<Ürün> ürünler = Ürün.ürünleriAl();
            double ds=0;
            ürünler.Sort ((ilk, ikinci) => ilk.ad.CompareTo (ikinci.ad));
            Console.WriteLine ("-->Ad'la A-->Z artan sýralý:");
            foreach (Ürün ürün in ürünler) Console.WriteLine (ürün);
            ürünler.Sort ((ilk, ikinci) => ikinci.fiyat.CompareTo (ilk.fiyat));
            Console.WriteLine ("-->Fiyat'la 9-->0 azalan sýralý:");
            foreach (Ürün ürün in ürünler) Console.WriteLine (ürün);
            ürünler.Sort ((ilk, ikinci) => ilk.adet.CompareTo (ikinci.adet));
            Console.WriteLine ("-->Adet'le 0--9 artan sýralý:");
            foreach (Ürün ürün in ürünler) {Console.WriteLine (ürün); ds+=(double)(ürün.fiyat * ürün.adet);}
            Console.WriteLine ("Tüm ürünlerin envanter deðeri: {0:#,0.00} TL", ds);

            Console.WriteLine ("\n10 þehrin uzunluk ve ilkharf kýstaslý delegeli lambda seçilimleri:");
            string[] þehirler = {"ÞanlýUrfa", "Mersin", "Bursa", "Malatya", "Van", "Ýstanbul", "Ankara", "Ýzmir", "KahramanMaraþ", "Bolu"};
            String[] seçiliÞehirler = ÞehirSeçimi (þehirler, þehir => þehir.Length > 6);
            Console.Write ("'þehir.Length > 6' süzgeci: ");
            foreach (String þehir in seçiliÞehirler) Console.Write (þehir+" "); Console.WriteLine();
            seçiliÞehirler = ÞehirSeçimi (þehirler, þehir => þehir.Length <= 6);
            Console.Write ("'þehir.Length <= 6' süzgeci: ");
            foreach (String þehir in seçiliÞehirler) Console.Write (þehir+" "); Console.WriteLine();
            seçiliÞehirler = ÞehirSeçimi (þehirler, þehir => þehir [0] == 'M' | þehir [0] == 'Ý');
            Console.Write ("'M ve Ý' süzgeci: ");
            foreach (String þehir in seçiliÞehirler) Console.Write (þehir+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}