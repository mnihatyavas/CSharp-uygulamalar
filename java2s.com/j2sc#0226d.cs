// j2sc#0226d.cs: Hi�lenebilir say�larla k�yas ve kontrollu g�sterim �rne�i.

using System;
using System.Collections.Generic;
namespace VeriTipleri {
    public static class Kar��la�t�r�c� {
        public static int? Compare<T> (T ilk, T ikinci) {
            return Compare (Comparer<T>. Default, ilk, ikinci);
        }
        public static int? Compare<T> (IComparer<T> comparer, T ilk,T ikinci) {
            int cevap = comparer.Compare (ilk, ikinci);
            if (cevap == 0) {return null;}
            return cevap;
        }
    }
    class Hi�lenebilir4 {
        static void G�ster (Nullable<double> x, int? i) {
            Console.WriteLine ("\n{0}): HasValue? {1}", (i+1), x.HasValue);
            if (x.HasValue) {
                Console.WriteLine ("De�er: {0}", x.Value);
                Console.WriteLine ("Aleni �evrim: {0}", (double)x);
                Console.WriteLine ("�mal� �evrim: {0}", x);
            }
            Console.WriteLine ("GetValueOrDefault (2023.0607): {0}", x.GetValueOrDefault (2023.0607));            
        }
        static void Main() {
            Console.Write ("Her Tip iki de�eri kar��la�t�ran Compare/IComparer 'using System.Collections.Generic' gerektirir. Kontrollu say�/null kontrolu 'say�.HasValue' ve 'say�.GetValueOrDefault (2023.0607)' ile de yap�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kar��la�t�rma (1: ilk>ikinci, -1: ilk<ikinci, 0=null: ilk==ikinci):");
            var r=new Random();
            double ds1=(double)r.Next (1000, 10000) + r.Next (10, 100) / 100D;
            double ds2=(double)r.Next (1000, 10000) + r.Next (10, 100) / 100.0;
            int? ts1 = Kar��la�t�r�c�.Compare (ds1, ds2);
            Console.WriteLine ("Kar��la�t�r ({0}, {1}) = \"{2}\"", ds1, ds2, ts1);
            ts1 = Kar��la�t�r�c�.Compare (ds2, ds1);
            Console.WriteLine ("Kar��la�t�r ({0}, {1}) = \"{2}\"", ds2, ds1, ts1);
            ds2=ds1; ts1 = Kar��la�t�r�c�.Compare (ds1, ds2);
            Console.WriteLine ("Kar��la�t�r ({0}, {1}) = \"{2}\"", ds1, ds2, ts1);

            Console.WriteLine ("\nTesad�fi 10 double say�dan yar�s� -:null olabilir:");
            Nullable<double> ds3;
            int? saya� = null; ts1=0;
            do {
                ds3 = (double)r.Next (-100, 100) + r.Next (10, 100) / 100.0;
                if (ds3 < 0) ds3 = null;
                G�ster (ds3, ts1);
                if (++ts1 == 10) saya� = 2023;
            }while (saya� == null);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}