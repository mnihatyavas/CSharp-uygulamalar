// j2sc#2202i.cs: ElementAt, ElementAtOrDefault, Equals, SequenceEqual örneði.

using System;
using System.Linq; //ElementAt() için
using System.Collections; //ArrayList için
using System.Collections.Generic; //IEqualityComparer<> için
namespace LinqMetot {
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
        public static Ýþçi[] ListeyiAl() {return ((Ýþçi[])ÝþçiListesiniAl().ToArray (typeof(Ýþçi)));}
    }
    public class SýnýfA : IEqualityComparer<string> {
        public bool Equals (string x, string y) {return (Int32.Parse (x) == Int32.Parse (y));}
        public int GetHashCode (string nesne) {return Int32.Parse (nesne).ToString().GetHashCode();}
    }
    class ElementAt_Equals {
        static void Main() {
            Console.Write ("'dizi.ElementAt(4)' 4.endeks elemanýný seçer. 'dizi.ElementAtOrDefault(14)' endeks mevcutsa elemaný, kapsam dýþýysa hata deðil 0/null döndürür. Equals eþitliði referans adresle, SequenceEqual ise içerik eleman deðerleriyle kýyaslar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Rasgele [1881,1938] yýllarda ElementAt(endeks) yýlý:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[10];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("Tüm yýllar: "); foreach(var y in yýllar) Console.Write (y+" "); Console.WriteLine();
            ts=r.Next(0,yýllar.Length);
            Console.WriteLine ("yýllar.ElementAt({0}) = {1}", ts, yýllar.ElementAt (ts));
            Console.WriteLine ("yýllar.First() = {0}", yýllar.First());
            Console.WriteLine ("yýllar.Last() = {0}", yýllar.Last());
            Console.WriteLine ("Küçük yýl = {0}", yýllar.OrderBy (y=>y).First());
            Console.WriteLine ("Büyük yýl = {0}", yýllar.OrderBy (y=>y).Last());
            Console.WriteLine ("Ortanca yýl = {0}", yýllar.OrderBy (y=>y).ElementAt (yýllar.Length/2));
            int yýl1 = (
                from y in yýllar
                where y > (1881+1939)/2
                select y).ElementAt (1);
            Console.WriteLine ("yýllar(y>1910)[1] = {0}", yýl1);

            Console.WriteLine ("\nÝþçi[] liste dizisinin ElementAt() ile tersten dökümü:");
            Ýþçi[] iþçiler = Ýþçi.ListeyiAl();
            for(i=iþçiler.Length-1;i>0;i--) Console.WriteLine ("Ýsim: {0} {1}\tD.yýlý: {2}", iþçiler.ElementAt (i).ad, iþçiler.ElementAt (i).soyad, iþçiler.ElementAt (i).yýl);
            Console.WriteLine ("Ýlk iþçi: {0} {1}", iþçiler.First().ad, iþçiler.First().soyad);
            Console.WriteLine ("Son iþçi: {0} {1}", iþçiler.Last().ad, iþçiler.Last().soyad);
            Console.WriteLine ("Ortanca iþçi: {0} {1}", iþçiler.ElementAt (iþçiler.Length/2).ad, iþçiler.ElementAt (iþçiler.Length/2).soyad);

            Console.WriteLine ("\nElementAt için endeks taþma hatasýný ElementAtOrDefault önler:");
            Console.WriteLine ("yýllar.ElementAtOrDefault(2024) = {0}\tyýllar.ElementAtOrDefault (2) = {1}", yýllar.ElementAtOrDefault (2024), yýllar.ElementAtOrDefault (2));
            try {Console.WriteLine ("yýllar.ElementAt(2024) = {0}\tyýllar.ElementAt(2) = {1}", yýllar.ElementAt (2024), yýllar.ElementAt (2));} catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Ýþçi iþçi = Ýþçi.ListeyiAl().ElementAtOrDefault (3);
            Console.WriteLine ("Ýþçi[{0}]'nin ismi: {1}", 3, iþçi == null ? "NULL" : string.Format (iþçi.ad + " " + iþçi.soyad));
            iþçi = Ýþçi.ListeyiAl().ElementAtOrDefault (iþçiler.Length+1);
            Console.WriteLine ("Ýþçi[{0}]'nin ismi: {1}", iþçiler.Length+1, iþçi == null ? "NULL" : string.Format (iþçi.ad + " " + iþçi.soyad));

            Console.WriteLine ("\nAtanan nesneler eþit, fakat yeniden yaratýlan ayný nesneler eþit deðildir:");
            Ýþçi[] iþçiler1 = Ýþçi.ListeyiAl();
            Ýþçi[] iþçiler2 = Ýþçi.ListeyiAl();
            Ýþçi[] iþçiler3 = iþçiler1;
            Console.WriteLine ("iþçiler1.Equals(iþçiler2)? {0}", iþçiler1.Equals (iþçiler2));
            Console.WriteLine ("iþçiler1.Equals(iþçiler1)? {0}", iþçiler1.Equals (iþçiler1));
            Console.WriteLine ("iþçiler1.Equals(iþçiler3)? {0}", iþçiler1.Equals (iþçiler3));
            Console.WriteLine ("iþçiler2.Equals(iþçiler3)? {0}", iþçiler2.Equals (iþçiler3));

            Console.WriteLine ("\nYeni yaratýlan ayný elemanlý 2 nesne Equals=false fakat SequenceEqual=true:");
            string[] peygamberler1 = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            string[] peygamberler2 = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.WriteLine ("peygamberler1.Equals(peygamberler2? {0}", peygamberler1.Equals (peygamberler2));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler2)? {0}", peygamberler1.SequenceEqual (peygamberler2));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler1.Take(peygamberler1.Count()))? {0}", peygamberler1.SequenceEqual (peygamberler1.Take (peygamberler1.Count())));
            Console.WriteLine ("peygamberler1.SequenceEqual(peygamberler1.Take(5).Concat(peygamberler1.Skip(5)))? {0}", peygamberler1.SequenceEqual (peygamberler1.Take (5).Concat (peygamberler1.Skip (5))));
            string[] yýllar1 = new string [yýllar.Length]; for(i=0;i<yýllar1.Length;i++) yýllar1 [i]=yýllar [i].ToString();
            string[] yýllar2 = yýllar1;
            Console.WriteLine ("yýllar1.SequenceEqual(yýllar2,new SýnýfA())? {0}", yýllar1.SequenceEqual (yýllar2, new SýnýfA()));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}