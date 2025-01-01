// j2sc#2202l.cs: Min()/Max() ile dizi elemanlarýnýn enküçüðü/enbüyüðü örneði.

using System;
using System.Linq; //Min() ve Max için
using System.Collections; //ArrayList için
using System.Collections.Generic; //List<> için
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
    class Bayii {
        public string No {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro;
    }
    class Maaþ {
        int _no, _yýl;
        double _maaþ;
        public int No {get {return _no;} set {_no = value;}}
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public double Maaþý {get {return _maaþ;} set {_maaþ = value;}}
    }
    class Ýþçi2 {
        int _no, _branþ;
        string _soyad, _ad;
        public int No {get {return _no;} set {_no = value;}}
        public int Branþý {get {return _branþ;} set {_branþ = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    class Max_Min {
        static void Main() {
            Console.Write ("'dizi.Min()/Max()' dizinin enküçük/enbüyük, 'diziMin(e=>e.Length)' dizgesel dizinin enkýsa uzunluktaki elemanýný, 'liste.Max(a=>a.Maaþ)' liste kaydý maaþ alanýnýn enbüyüðünü döndürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sayýsal ve dizgesel dizilerin enküçük/enbüyük elemanlarý:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[10];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("-->Tüm rasgele [1881,1938] yýllar: ");
            foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("Yýl(enküçük,enbüyük) = ({0}, {1})", yýllar.Min(), yýllar.Max());
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.Write ("-->Tüm peygamberler: ");
            foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.WriteLine ("Peygamber(enküçük,enbüyük)[A->Z] = ({0}, {1})", peygamberler.Min(), peygamberler.Max());
            Console.WriteLine ("Peygamber(enküçük,enbüyük)[Length] = ({0}, {1})", peygamberler.Min (x=>x.Length), peygamberler.Max (x=>x.Length));

            Console.WriteLine ("\nÝþçi listesi Ýþçi[] diziye çevrilip 3 alanýnýn enküçük/enbüyük tespiti:");
            Ýþçi[] iþçiler = Ýþçi.ListeyiAl();
            Console.WriteLine ("Ýþçi-Yaþ(enküçük,enbüyük) = ({0}, {1})", iþçiler.Min (a => a.yýl), iþçiler.Max (a => a.yýl));
            Console.WriteLine ("Ýþçi-Ad(enküçük,enbüyük) = ({0}, {1})", iþçiler.Min (a => a.ad), iþçiler.Max (a => a.ad));
            Console.WriteLine ("Ýþçi-Soyad(enküçük,enbüyük) = ({0}, {1})", iþçiler.Min (a => a.soyad), iþçiler.Max (a => a.soyad));

            Console.WriteLine ("\nDünyadaki bayilerinin enküçük/enbüyük ciro, kýta, ülke ve þehirleri:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", Þehir="Tahran", Ülke="Ýran", Kýta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("Bayi-Ciro(enküçük, enbüyük) = (${0:#,0.00}, ${1:#,0.00})", bayiler.Min (a=>a.Ciro), bayiler.Max (a=>a.Ciro));
            Console.WriteLine ("Bayi-Kýta(enküçük, enbüyük) = ({0}, {1})", bayiler.Min (a=>a.Kýta), bayiler.Max (a=>a.Kýta));
            Console.WriteLine ("Bayi-Ülke(enküçük, enbüyük) = ({0}, {1})", bayiler.Min (a=>a.Ülke), bayiler.Max (a=>a.Ülke));
            Console.WriteLine ("Bayi-Þehir(enküçük, enbüyük) = ({0}, {1})", bayiler.Min (a=>a.Þehir), bayiler.Max (a=>a.Þehir));

            Console.WriteLine ("\nBirleþik iþçi ve maaþ liste eleman alanlarýnýn enküçük/enbüyüðü:");
            List<Ýþçi2> iþçiler2 = new List<Ýþçi2> {//Branþý=1: Yönetim; 2: Muhasebe; 3: Vardiya
                new Ýþçi2 {No = 1951, Branþý = 1, Soyad = "Kaçar", Ad = "Hatice"},
                new Ýþçi2 {No = 1953, Branþý = 3, Soyad = "Özbay", Ad = "Süheyla"},
                new Ýþçi2 {No = 1955, Branþý = 2, Soyad = "Candan", Ad = "Zeliha"},
                new Ýþçi2 {No = 1957, Branþý = 3, Soyad = "Yavaþ", Ad = "M.Nihat"},
                new Ýþçi2 {No = 1959, Branþý = 3, Soyad = "Gökyiðit", Ad = "Songül"},
                new Ýþçi2 {No = 1961, Branþý = 2, Soyad = "Yavaþ", Ad = "M.Nedim"},
                new Ýþçi2 {No = 1963, Branþý = 1, Soyad = "Yavaþ", Ad = "Sevim"}
            };
            List<Maaþ> maaþlar = new List<Maaþ> {
                new Maaþ {No = 1951, Yýl = 2024, Maaþý = 120675.87},
                new Maaþ {No = 1953, Yýl = 2024, Maaþý = 105302.15},
                new Maaþ {No = 1955, Yýl = 2024, Maaþý = 118765.54},
                new Maaþ {No = 1957, Yýl = 2024, Maaþý = 165674.43},
                new Maaþ {No = 1959, Yýl = 2024, Maaþý = 218765.43},
                new Maaþ {No = 1961, Yýl = 2024, Maaþý = 146734.17},
                new Maaþ {No = 1963, Yýl = 2024, Maaþý = 215458.98}
            };
            var sorgu1 = from iþ in iþçiler2
                join m in maaþlar on iþ.No equals m.No
                select new {no=iþ.No, ad=iþ.Ad, soyad=iþ.Soyad, maaþ=m.Maaþý, dyýl=iþ.No};
            Console.WriteLine ("Ýþçi-Maaþ(enküçük,enbüyük) = ({0:#,0.00}TL, {1:#,0.00}TL)", sorgu1.Min (a=>a.maaþ), sorgu1.Max (a=>a.maaþ));
            Console.WriteLine ("Ýþçi-Ad(enküçük,enbüyük) = ({0}, {1})", sorgu1.Min (a=>a.ad), sorgu1.Max (a=>a.ad));
            Console.WriteLine ("Ýþçi-Soyad(enküçük,enbüyük) = ({0}, {1})", sorgu1.Min (a=>a.soyad), sorgu1.Max (a=>a.soyad));
            Console.WriteLine ("Ýþçi-DYýl(enküçük,enbüyük) = ({0}, {1})", sorgu1.Min (a=>a.dyýl), sorgu1.Max (a=>a.dyýl));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}