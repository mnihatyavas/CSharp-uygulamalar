// j2sc#2202o.cs: Single ile tek sonuç, Reverse ile ters dizi örneði.

using System;
using System.Linq; //Single() için
using System.Collections.Generic; //List<> için
namespace LinqMetot {
    public class Ýþçi {
        public int yýl;
        public string ad;
        public string soyad;
        public static List<Ýþçi> ÝþçiListesiniAl() {
            List<Ýþçi> liste = new List<Ýþçi>();
            liste.Add (new Ýþçi {yýl = 1891, ad = "Fatma", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1899, ad = "Bekir", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1931, ad = "Haným", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1934, ad = "Memet", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1951, ad = "Hatice", soyad = "Kaçar"});
            liste.Add (new Ýþçi {yýl = 1953, ad = "Süheyla", soyad = "Özbay"});
            liste.Add (new Ýþçi {yýl = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new Ýþçi {yýl = 1957, ad = "M.Nihat", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1959, ad = "Songül", soyad = "Gökyiðit"});
            liste.Add (new Ýþçi {yýl = 1961, ad = "M.Nedim", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1963, ad = "Sevim", soyad = "Yavaþ"});
            return (liste);
        }
    }
    class Single_Reverse {
        static void Main() {
            Console.Write ("'dizi.Single(þart)' þartý saðlayan tek elemaný döndürür, çoklu elemanda hata verir, þart saðlanmazsa '-OrDefault' 0 döndürür. 'dizi.Reverse()' sýralý/sýrasýz diziyi tersten dizer.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("50 adet rasgele yýllar, þartý saðlayan tek eleman:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[50];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("-->Tüm rasgele {0} adet yýllar: ", yýllar.Length);
            foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            ts=r.Next(0,yýllar.Length); Console.WriteLine (ts+", "+yýllar[ts]);
            var sorgu1 = (from y in yýllar orderby y descending select y).Distinct();
            Console.Write ("-->Yegane azalan {0} adet yýllar: ", sorgu1.Count());
            foreach (int yýl in sorgu1) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("-->Yegane yýllarda {0}'a eþit tek yýl: {1}", yýllar [yýllar.Length/2], sorgu1.Single (y=>y==yýllar [yýllar.Length/2]));
            try {Console.Write ("-->Çoklu yýllarda {0}'a eþit tek yýl: ", yýllar [yýllar.Length/2]); Console.Write (yýllar.Single (y=>y==yýllar [yýllar.Length/2]));}catch (Exception ht) {Console.Write ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("\n-->{1} >= {0}\t\t{3} <= {2}", 1938, sorgu1.SingleOrDefault (y=>y>=1938), 1881, sorgu1.SingleOrDefault (y=>y<=1881));
            Console.WriteLine ("\n-->sorgu1'de sondan 2 öncekinden sonraki: {0}", sorgu1.Single (y=>y < sorgu1.ElementAt (sorgu1.Count()-2)));

            Console.WriteLine ("\nList<Ýþçi> dökümü ve þartlý Single'lar:");
            List<Ýþçi> iþçiler = Ýþçi.ÝþçiListesiniAl();
            Console.WriteLine ("-->Tüm {0} adet iþçiler: ", iþçiler.Count());
            foreach (var iþ in iþçiler) Console.WriteLine ("(isim, dyýl) = ({0} {1}, {2})", iþ.ad, iþ.soyad, iþ.yýl);
            var sorgu2 = iþçiler.Where (iþ => iþ.yýl == 1957).Single(); Console.WriteLine ("-->{0} doðumlu iþçi = {1} {2}", 1957, sorgu2.ad, sorgu2.soyad);
            sorgu2 = iþçiler.Where (iþ => iþ.yýl > 1961).Single(); Console.WriteLine ("-->{0}'den büyük iþçi = {1} {2}", 1961, sorgu2.ad, sorgu2.soyad);
            sorgu2 = iþçiler.Where (iþ => iþ.yýl < 1899).Single(); Console.WriteLine ("-->{0}'dan küçük iþçi = {1} {2}", 1899, sorgu2.ad, sorgu2.soyad);
            sorgu2 = iþçiler.Where (iþ => iþ.yýl == 1959).SingleOrDefault(); Console.WriteLine ("-->1959'lu iþçi = " + (sorgu2 == null?"NAMEVCUT":string.Format ("{0} {1}", sorgu2.ad, sorgu2.soyad)));
            sorgu2 = iþçiler.Where (iþ => iþ.yýl == 1958).SingleOrDefault(); Console.WriteLine ("-->1958'li iþçi = " + (sorgu2 == null?"NAMEVCUT":string.Format ("{0} {1}", sorgu2.ad, sorgu2.soyad)));

            Console.WriteLine ("\nOrderBy-Descending'le artan/azalan sýralama, Reverse'le ters dizme:");
            IEnumerable<int> sorgu3a = yýllar.OrderBy (y=>y).Distinct().Reverse();
            Console.Write ("-->Yegane artan-->azalan {0} adet yýllar: ", sorgu3a.Count());
            foreach (int yýl in sorgu3a) Console.Write (yýl+" "); Console.WriteLine();
            IEnumerable<Ýþçi> sorgu3b = iþçiler.OrderBy/*Descending*/ (iþ=>iþ.yýl).Reverse();
            Console.WriteLine ("-->ArtanYýl-->azalanYýl {0} adet iþçiler: ", sorgu3b.Count());
            foreach (Ýþçi iþ in sorgu3b) Console.WriteLine ("(yýl, isim) = ({0}, {1} {2})", iþ.yýl, iþ.ad, iþ.soyad);
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> sorgu3c = peygamberler.OrderByDescending (p=>p).Reverse();
            Console.Write ("-->Azalan-ZA-->artan-AZ {0} adet peygamberler: ", sorgu3c.Count());
            foreach (string pey in sorgu3c) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<String> sorgu3d = peygamberler.OrderBy (p=>p.Length).Reverse();
            Console.Write ("-->Uzunlukça artan-09-->azalan-90 {0} adet peygamberler: ", sorgu3d.Count());
            foreach (string pey in sorgu3d) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<int> sorgu3e = yýllar.Reverse();
            Console.Write ("-->Tüm rasgele {0} adet yýllarý ters dizme: ", sorgu3e.Count());
            foreach (int yýl in sorgu3e) Console.Write (yýl+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}