// j2sc#2203b.cs: ToDictionary() ile yegane anahtarla kayýtlara eriþim örneði.

using System;
using System.Linq; //GetMethods() ve group by için
using System.Collections.Generic; //Dictionary<> için
using System.Collections; //ArrayList iiçin
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
    class ToDictionary {
        static void Main() {
            Console.Write ("ToDictionary dönüþüm sözlük anahtarlarýna 'ICollection sözlük.Keys' ile eriþilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm arþiv int ve string metotlarýnýn ayný adlý grup listeleri:");
            var sorgu1 = from mt in typeof (int).GetMethods()
                group mt by mt.Name into grup
                select grup;
            Dictionary<string, int> sözlük1 = sorgu1.ToDictionary (k => k.Key, k => k.Count());
            Console.WriteLine ("-->{0} adet 'typeof(int).GetMethods()' farklý tamsayý metot ad ve sayýlarý:", sözlük1.Count());
            foreach(var s in sözlük1) Console.WriteLine (s);
            var sorgu2 = (from m in typeof (string).GetMethods() group m by m.Name into gr select gr).ToDictionary (k => k.Key, k=>k.Count());
            Console.WriteLine ("-->{0} adet 'typeof(string).GetMethods()' dizgesel metotlarý:", sorgu2.Count());
            foreach(var m in sorgu2) Console.WriteLine (m);

            Console.WriteLine ("\nArrayList-->Ýþçi[] dizi-->Dictionary(k=>k.alan) dönüþümleri:");
            Ýþçi[] iþçiDizi = Ýþçi.ÝþçiDizisiniAl();
            Console.WriteLine ("-->{0} adet iþçi dizisi:", iþçiDizi.Length);
            foreach(var iþ in iþçiDizi) Console.WriteLine ("{0} {1}, {2}", iþ.ad, iþ.soyad, iþ.yýl);
            Dictionary<int, string> sözlük2a = Ýþçi.ÝþçiDizisiniAl().ToDictionary (anh => anh.yýl, isim => string.Format ("{0} {1}", isim.ad, isim.soyad));
            ICollection<int> ik1 = sözlük2a.Keys;
            Console.WriteLine ("-->{0} adet yýl anahtarlý iþçi sözlüðü:", ik1.Count());
            foreach(int yýl in ik1) Console.WriteLine ("Yýl: {0},\tÝsim: {1}", yýl, sözlük2a [yýl]);
            Console.WriteLine ("Ýþçi(Yýl==1957: {0}", sözlük2a [1957]);
            try {Console.WriteLine ("Ýþçi(Yýl==1958: {0}", sözlük2a [1958]);} catch {Console.WriteLine ("Ýþçi(Yýl==1958): Sözlükte NAMEVCUT");}
            Dictionary<int, Ýþçi> sözlük2b = Ýþçi.ÝþçiDizisiniAl().ToDictionary (anh => anh.yýl);
            Console.WriteLine ("Ýþçi(Yýl==1891: {0} {1}", sözlük2b [1891].ad, sözlük2b [1891].soyad);
            Dictionary<string, int> sözlük2c = Ýþçi.ÝþçiDizisiniAl().ToDictionary (a => a.soyad+" "+a.ad, y=>y.yýl);
            ICollection<string> ik2 = sözlük2c.Keys;
            Console.WriteLine ("-->{0} adet soyad+ad anahtarlý iþçi sözlüðü:", ik2.Count());
            foreach(string ism in ik2) Console.WriteLine ("Ýsim: {0},\tDyýl: {1}", ism, sözlük2c [ism]);
            Console.WriteLine ("Ýþçi(Ýsim==Yavaþ Sevim: {0}", sözlük2c ["Yavaþ Sevim"]);
            try {Console.WriteLine ("Ýþçi(Ýsim==Yavaþ Sevil: {0}", sözlük2c ["Yavaþ Sevil"]);} catch {Console.WriteLine ("Ýþçi('Yavaþ Sevil'): Sözlükte NAMEVCUT");}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}