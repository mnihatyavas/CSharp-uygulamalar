// j2sc#0226d.cs: Hiçlenebilir sayýlarla kýyas ve kontrollu gösterim örneði.

using System;
using System.Collections.Generic;
namespace VeriTipleri {
    public static class Karþýlaþtýrýcý {
        public static int? Compare<T> (T ilk, T ikinci) {
            return Compare (Comparer<T>. Default, ilk, ikinci);
        }
        public static int? Compare<T> (IComparer<T> comparer, T ilk,T ikinci) {
            int cevap = comparer.Compare (ilk, ikinci);
            if (cevap == 0) {return null;}
            return cevap;
        }
    }
    class Hiçlenebilir4 {
        static void Göster (Nullable<double> x, int? i) {
            Console.WriteLine ("\n{0}): HasValue? {1}", (i+1), x.HasValue);
            if (x.HasValue) {
                Console.WriteLine ("Deðer: {0}", x.Value);
                Console.WriteLine ("Aleni çevrim: {0}", (double)x);
                Console.WriteLine ("Ýmalý çevrim: {0}", x);
            }
            Console.WriteLine ("GetValueOrDefault (2023.0607): {0}", x.GetValueOrDefault (2023.0607));            
        }
        static void Main() {
            Console.Write ("Her Tip iki deðeri karþýlaþtýran Compare/IComparer 'using System.Collections.Generic' gerektirir. Kontrollu sayý/null kontrolu 'sayý.HasValue' ve 'sayý.GetValueOrDefault (2023.0607)' ile de yapýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Karþýlaþtýrma (1: ilk>ikinci, -1: ilk<ikinci, 0=null: ilk==ikinci):");
            var r=new Random();
            double ds1=(double)r.Next (1000, 10000) + r.Next (10, 100) / 100D;
            double ds2=(double)r.Next (1000, 10000) + r.Next (10, 100) / 100.0;
            int? ts1 = Karþýlaþtýrýcý.Compare (ds1, ds2);
            Console.WriteLine ("Karþýlaþtýr ({0}, {1}) = \"{2}\"", ds1, ds2, ts1);
            ts1 = Karþýlaþtýrýcý.Compare (ds2, ds1);
            Console.WriteLine ("Karþýlaþtýr ({0}, {1}) = \"{2}\"", ds2, ds1, ts1);
            ds2=ds1; ts1 = Karþýlaþtýrýcý.Compare (ds1, ds2);
            Console.WriteLine ("Karþýlaþtýr ({0}, {1}) = \"{2}\"", ds1, ds2, ts1);

            Console.WriteLine ("\nTesadüfi 10 double sayýdan yarýsý -:null olabilir:");
            Nullable<double> ds3;
            int? sayaç = null; ts1=0;
            do {
                ds3 = (double)r.Next (-100, 100) + r.Next (10, 100) / 100.0;
                if (ds3 < 0) ds3 = null;
                Göster (ds3, ts1);
                if (++ts1 == 10) sayaç = 2023;
            }while (sayaç == null);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}