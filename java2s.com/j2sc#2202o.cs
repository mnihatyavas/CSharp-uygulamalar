// j2sc#2202o.cs: Single ile tek sonu�, Reverse ile ters dizi �rne�i.

using System;
using System.Linq; //Single() i�in
using System.Collections.Generic; //List<> i�in
namespace LinqMetot {
    public class ���i {
        public int y�l;
        public string ad;
        public string soyad;
        public static List<���i> ���iListesiniAl() {
            List<���i> liste = new List<���i>();
            liste.Add (new ���i {y�l = 1891, ad = "Fatma", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1899, ad = "Bekir", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1931, ad = "Han�m", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1934, ad = "Memet", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1951, ad = "Hatice", soyad = "Ka�ar"});
            liste.Add (new ���i {y�l = 1953, ad = "S�heyla", soyad = "�zbay"});
            liste.Add (new ���i {y�l = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new ���i {y�l = 1957, ad = "M.Nihat", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1959, ad = "Song�l", soyad = "G�kyi�it"});
            liste.Add (new ���i {y�l = 1961, ad = "M.Nedim", soyad = "Yava�"});
            liste.Add (new ���i {y�l = 1963, ad = "Sevim", soyad = "Yava�"});
            return (liste);
        }
    }
    class Single_Reverse {
        static void Main() {
            Console.Write ("'dizi.Single(�art)' �art� sa�layan tek eleman� d�nd�r�r, �oklu elemanda hata verir, �art sa�lanmazsa '-OrDefault' 0 d�nd�r�r. 'dizi.Reverse()' s�ral�/s�ras�z diziyi tersten dizer.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("50 adet rasgele y�llar, �art� sa�layan tek eleman:");
            int i, ts; var r=new Random();
            int[] y�llar = new int[50];
            for(i=0;i<y�llar.Length;i++) {ts=r.Next(1881,1939); y�llar [i] = ts;}
            Console.Write ("-->T�m rasgele {0} adet y�llar: ", y�llar.Length);
            foreach (int y�l in y�llar) Console.Write (y�l+" "); Console.WriteLine();
            ts=r.Next(0,y�llar.Length); Console.WriteLine (ts+", "+y�llar[ts]);
            var sorgu1 = (from y in y�llar orderby y descending select y).Distinct();
            Console.Write ("-->Yegane azalan {0} adet y�llar: ", sorgu1.Count());
            foreach (int y�l in sorgu1) Console.Write (y�l+" "); Console.WriteLine();
            Console.WriteLine ("-->Yegane y�llarda {0}'a e�it tek y�l: {1}", y�llar [y�llar.Length/2], sorgu1.Single (y=>y==y�llar [y�llar.Length/2]));
            try {Console.Write ("-->�oklu y�llarda {0}'a e�it tek y�l: ", y�llar [y�llar.Length/2]); Console.Write (y�llar.Single (y=>y==y�llar [y�llar.Length/2]));}catch (Exception ht) {Console.Write ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("\n-->{1} >= {0}\t\t{3} <= {2}", 1938, sorgu1.SingleOrDefault (y=>y>=1938), 1881, sorgu1.SingleOrDefault (y=>y<=1881));
            Console.WriteLine ("\n-->sorgu1'de sondan 2 �ncekinden sonraki: {0}", sorgu1.Single (y=>y < sorgu1.ElementAt (sorgu1.Count()-2)));

            Console.WriteLine ("\nList<���i> d�k�m� ve �artl� Single'lar:");
            List<���i> i��iler = ���i.���iListesiniAl();
            Console.WriteLine ("-->T�m {0} adet i��iler: ", i��iler.Count());
            foreach (var i� in i��iler) Console.WriteLine ("(isim, dy�l) = ({0} {1}, {2})", i�.ad, i�.soyad, i�.y�l);
            var sorgu2 = i��iler.Where (i� => i�.y�l == 1957).Single(); Console.WriteLine ("-->{0} do�umlu i��i = {1} {2}", 1957, sorgu2.ad, sorgu2.soyad);
            sorgu2 = i��iler.Where (i� => i�.y�l > 1961).Single(); Console.WriteLine ("-->{0}'den b�y�k i��i = {1} {2}", 1961, sorgu2.ad, sorgu2.soyad);
            sorgu2 = i��iler.Where (i� => i�.y�l < 1899).Single(); Console.WriteLine ("-->{0}'dan k���k i��i = {1} {2}", 1899, sorgu2.ad, sorgu2.soyad);
            sorgu2 = i��iler.Where (i� => i�.y�l == 1959).SingleOrDefault(); Console.WriteLine ("-->1959'lu i��i = " + (sorgu2 == null?"NAMEVCUT":string.Format ("{0} {1}", sorgu2.ad, sorgu2.soyad)));
            sorgu2 = i��iler.Where (i� => i�.y�l == 1958).SingleOrDefault(); Console.WriteLine ("-->1958'li i��i = " + (sorgu2 == null?"NAMEVCUT":string.Format ("{0} {1}", sorgu2.ad, sorgu2.soyad)));

            Console.WriteLine ("\nOrderBy-Descending'le artan/azalan s�ralama, Reverse'le ters dizme:");
            IEnumerable<int> sorgu3a = y�llar.OrderBy (y=>y).Distinct().Reverse();
            Console.Write ("-->Yegane artan-->azalan {0} adet y�llar: ", sorgu3a.Count());
            foreach (int y�l in sorgu3a) Console.Write (y�l+" "); Console.WriteLine();
            IEnumerable<���i> sorgu3b = i��iler.OrderBy/*Descending*/ (i�=>i�.y�l).Reverse();
            Console.WriteLine ("-->ArtanY�l-->azalanY�l {0} adet i��iler: ", sorgu3b.Count());
            foreach (���i i� in sorgu3b) Console.WriteLine ("(y�l, isim) = ({0}, {1} {2})", i�.y�l, i�.ad, i�.soyad);
            string[] peygamberler = {"Nuh", "�brahim", "Musa", "Davut", "S�leyman", "�sa", "Muhammed", "Buda", "Konfi�yus", "Zerd��t"};
            IEnumerable<string> sorgu3c = peygamberler.OrderByDescending (p=>p).Reverse();
            Console.Write ("-->Azalan-ZA-->artan-AZ {0} adet peygamberler: ", sorgu3c.Count());
            foreach (string pey in sorgu3c) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<String> sorgu3d = peygamberler.OrderBy (p=>p.Length).Reverse();
            Console.Write ("-->Uzunluk�a artan-09-->azalan-90 {0} adet peygamberler: ", sorgu3d.Count());
            foreach (string pey in sorgu3d) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<int> sorgu3e = y�llar.Reverse();
            Console.Write ("-->T�m rasgele {0} adet y�llar� ters dizme: ", sorgu3e.Count());
            foreach (int y�l in sorgu3e) Console.Write (y�l+" "); Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}