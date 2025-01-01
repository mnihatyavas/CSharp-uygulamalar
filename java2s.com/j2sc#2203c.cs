// j2sc#2203c.cs: Soysal ToList<>() ve çoklu anahtarlý ToLookup() örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; //ToList() için
using System.Collections; //ArrayList için
namespace To_Dönüþümler {
    public class Ýþçi {
        public int yýl;
        public string ad;
        public string soyad;
        public static ArrayList ÝþçiListesiniAl() {
            ArrayList liste = new ArrayList();
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
        public static Ýþçi[] ÝþçiDizisiniAl() {return ((Ýþçi[])ÝþçiListesiniAl().ToArray (typeof (Ýþçi)));} //Liste<Ýþçi>, Ýþçi[] dizi'ye çevrilip alýnmakta
    }
    class ToList_Lookup {
        static void Main() {
            Console.Write ("ArtayList soysal olmadýðýndan Cast<Ýþçi>() ile dönüþmekte, Ýþçi[] dizi doðrudan soysal ToList<Ýþçi>()'ye dönüþmektedir. ToDictionary() sadece yegane anahtarlarý sorgularken, ToLookup() çoklu benzer anahtarlý kayýtlarý da sorgular.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'string[] peygamberler.ToList()' dönüþümü:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            List<string> liste1 = peygamberler.ToList();
            Console.Write ("-->Tüm {0} adet peygamberler: ", liste1.Count());
            foreach (string ad in liste1) Console.Write (ad+" "); Console.WriteLine();

            Console.WriteLine ("\n'List<> liste'den liste.ToList() Linq sorguya dönüþüm:");
            var yýllar = new List<int>();
            int i;
            for(i=1881;i<=1938;i++) yýllar.Add (i);
            Console.Write ("-->Tüm {0} adet yýllar: ", yýllar.Count());
            foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            List<int> liste2 = yýllar.Select (n => 2024 - n).ToList();
            yýllar.Clear(); Console.WriteLine ("Yýllar listesi {0} adet.", yýllar.Count);
            Console.Write ("-->Tüm {0} adet liste2: ", liste2.Count());
            foreach (int yýl in liste2) Console.Write (yýl+":"+(2024 - yýl)+" "); Console.WriteLine();

            Console.WriteLine ("\nArrayList-->Cast<Ýþçi> ve Ýþçi[]-->ToList<Ýþçi> dönüþümleri:");
            ArrayList iþçiler = Ýþçi.ÝþçiListesiniAl();
            Console.WriteLine ("iþçiler.GetType(): " + iþçiler.GetType());
            var sýra = iþçiler.Cast<Ýþçi>();
            Console.WriteLine ("sýra.GetType(): " + sýra.GetType());
            var sorgu1 = sýra.OrderByDescending (iþ => iþ.yýl);
            Console.WriteLine ("-->{0} adet 9->0 azalan-yýl sýralý sorgu:", sorgu1.Count());
            foreach (Ýþçi iþ in sorgu1) Console.WriteLine ("{0} {1}, {2}", iþ.ad, iþ.soyad, iþ.yýl);
            var sýra2 = Ýþçi.ÝþçiDizisiniAl().ToList<Ýþçi>();
            var sorgu2 = from iþ in sýra2
                where iþ.soyad.Length > 5
                select new {Ýsim = iþ.soyad + " " + iþ.ad, Yýl = iþ.yýl};
            Console.WriteLine ("-->{0} adet soyad.Length>5 iþçiler:", sorgu2.Count());
            foreach (var iþ in sorgu2) Console.WriteLine (iþ);

            Console.WriteLine ("\nÇoklu benzer anahtar kayýtlarýný araþtýran ToLookup():");
            string[] soyadlar = {"Gökyiðit", "Özbay", "Kaçar", "Candan", "Yavaþ"};
            ILookup<string, Ýþçi> gözat1 = Ýþçi.ÝþçiDizisiniAl().ToLookup (anh => anh.soyad);
            IEnumerable<Ýþçi> sorgu3 = gözat1 ["Yavaþ"];
            Console.WriteLine ("==>Tek sorgu3'le {0} (adet soyad=='Yavaþ') iþçiler: ", sorgu3.Count());
            foreach (var iþ in sorgu3) Console.WriteLine ("{0} {1}, {2}", iþ.ad, iþ.soyad, iþ.yýl);
            Console.WriteLine ("==>Tüm {0} adet soyadlar'la iþçiler: ", soyadlar.Length);
            foreach(string sad in soyadlar) {
                sorgu3 = gözat1 [sad];
                Console.WriteLine ("-->{0} (adet soyad=='{1}') iþçiler: ", sorgu3.Count(), sad);
                foreach (var iþ in sorgu3) Console.WriteLine ("{0} {1}, {2}", iþ.ad, iþ.soyad, iþ.yýl);
            }
            var soy = (from iþ in sýra select iþ.soyad).Distinct();
            Console.WriteLine ("==>Tüm {0} adet soy'la iþçiler: ", soy.Count());
            foreach(string sad in soy) {
                sorgu3 = gözat1 [sad];
                Console.WriteLine ("-->{0} (adet soyad=='{1}') iþçiler: ", sorgu3.Count(), sad);
                foreach (var iþ in sorgu3) Console.WriteLine ("{0} {1}, {2}", iþ.ad, iþ.soyad, iþ.yýl);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}