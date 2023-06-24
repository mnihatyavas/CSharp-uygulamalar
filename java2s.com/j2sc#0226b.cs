// j2sc#0226b.cs: Hiçlenebilir sayýnýn kontrollu gösterimleri örneði.

using System;
namespace VeriTipleri {
    class Þahýs {
        public string isim;
        public DateTime dTarih;
        public DateTime? öTarih;
        public Þahýs (string isim, DateTime dTarih, DateTime? öTarih) {
            this.isim = isim;
            this.dTarih = dTarih;
            this.öTarih = öTarih;
        }
        public TimeSpan yaþ {
            get {if (öTarih == null) {return DateTime.Now - dTarih;
                 }else {return öTarih.Value - dTarih;}
            }
        }
    }
    class Hiçlenebilir2 {
        static void Göster (Nullable<int> x) {
            Console.WriteLine ("Deðerli mi: {0}", x.HasValue);
            if (x.HasValue) {
                Console.WriteLine ("Deðer: {0}", x.Value);
                Console.WriteLine ("Aleni çevrim: {0}", (int) x);
                Console.WriteLine ("Doðrudan gösterim: {0}", x);
            }else {
                Console.WriteLine ("Null: {0}", x);
                Console.WriteLine ("Kontrollu gösterim: {0}", x ?? -1);
                Console.WriteLine ("x == null? {0}", (x == null));
            }

            Console.WriteLine ("ToString() çevrim: \"{0}\"", x.ToString());
        }
        static void Main() {
            Console.Write ("Hiçlenebilir deðiþken 'int? sayý', 'new int?()' veya 'Nullable<int> sayý', 'new Nullable<int>()' ile kontrolu ise 'sayý == null' veya 'sayý.HasValue' ile yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hiçlenebilir sayýnýn kutulanmasý/kutusuzlanmasý ve hiç'lik kontrolu:");
            int? ts1 = 5;
            object ns1 = ts1;
            Console.WriteLine ("Nesneye kutulanan hiçlenebilir ts1: ({0}, {1}) = ns1: ({2}, {3})", ts1, ts1.GetType(), ns1, ns1.GetType() );
            int ts2 = (int) ns1;
            Console.WriteLine ("Kutusuzlanan ts2 = ({0}, {1})", ts2, ts2.GetTypeCode() );
            ts1 = (int?) ns1;
            Console.WriteLine ("Kutusuzlanan hiçlenebilir ts1 = ({0}, {1})", ts1, ts1.GetType() );
            ts1 = new int?();
            ns1 = ts1;
            Console.WriteLine ("ts1({0})'den kutulanan ns1({1}) hiç mi? {2}", ts1, ns1, (ns1 == null) );
            ts1 = (int?) ns1;
            Console.WriteLine ("ns1({0})'den kutusuzlanan ts1({1})'in deðeri var mý? {2}", ns1, ts1, ts1.HasValue);

            Console.WriteLine ("\nHiçlenebilirliði 'int?' yerine 'Nullable<int>' ile yapma:");
            Nullable<int> ts3 = 8;
            object ns2 = ts3;
            Console.WriteLine ("Nesneye kutulanan hiçlenebilir ts3: ({0}) = ns2: ({1})", ts3, ns2);
            ts3 = (Nullable<int>) ns2;
            Console.WriteLine ("Kutusuzlanan hiçlenebilir ts3 = ({0})", ts3);
            ts3 = new Nullable<int>();
            ns2 = ts3;
            Console.WriteLine ("ts3({0})'den kutulanan ns2({1}) hiç mi? {2}", ts3, ns2, (ns2 == null) );
            ts3 = (Nullable<int>) ns2;
            Console.WriteLine ("ns2({0})'den kutusuzlanan ts3({1})'in deðeri var mý? {2}", ns2, ts3, ts3.HasValue);

            Console.WriteLine ("\nYaþayan/müteveffa kiþi (isim, doðum, ölüm, yaþ:saat/365) bilgileri:");
            Þahýs þahýs1 = new Þahýs ("Memet Yavaþ", new DateTime (1934, 1, 1), new DateTime (2018, 1, 1));
            Console.WriteLine ("==>{0}'ýn doð.tarih, öl.tarih ve yaþý = ({1}, {2}, {3})", þahýs1.isim, þahýs1.dTarih, (þahýs1.öTarih ?? new DateTime (1, 1, 1)), þahýs1.yaþ);
            Þahýs þahýs2 = new Þahýs ("Sevim Yavaþ", new DateTime (1963, 1, 1), null);
            Console.WriteLine ("==>{0}'ýn doð.tarih, öl.tarih ve yaþý = ({1}, {2}, {3})", þahýs2.isim, þahýs2.dTarih, (þahýs2.öTarih ?? new DateTime (1, 1, 1)), þahýs2.yaþ);
            Þahýs þahýs3 = new Þahýs ("Fatma Yavaþ", new DateTime (1895, 1, 1), new DateTime (1969, 1, 1));
            Console.WriteLine ("==>{0}'ýn doð.tarih, öl.tarih ve yaþý = ({1}, {2}, {3})", þahýs3.isim, þahýs3.dTarih, (þahýs3.öTarih ?? new DateTime (1, 1, 1)), þahýs3.yaþ);
            Þahýs þahýs4 = new Þahýs ("Hatice Yavaþ Kaçar", new DateTime (1951, 1, 1), null);
            Console.WriteLine ("==>{0}'ýn doð.tarih, öl.tarih ve yaþý = ({1}, {2}, {3})", þahýs4.isim, þahýs4.dTarih, (þahýs4.öTarih ?? new DateTime (1, 1, 1)), þahýs4.yaþ);

            Console.WriteLine ("\nHiçlenebilir tamsayý deðiþkenin kontrollu gösterimi:");
            Nullable<int> x = 20230602; /* veya */ x = new Nullable<int> (20230602);
            Console.WriteLine ("==>Deðer tiplemeli gösterim:"); Göster (x);
            x = new Nullable<int>();
            Console.WriteLine ("==>Hiç tiplemeli gösterim:"); Göster (x);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}