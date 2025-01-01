// j2sc#2202r.cs: Sorgularda endeks, çýkarým, ilkörnek ve sýnýrlama örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; //Select için
namespace LinqMetot {
    class Kiþi {
        int _dyýl;
        string _soyad;
        string _ad;
        public int Dyýl {get {return _dyýl;} set {_dyýl = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
    public class Kitap {
        public String Yazar {get; set;}
        public String Ad {get; set;}
        public override String ToString() {return Yazar+": "+Ad;}
    }
    class Bayii {
        public string No {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro;
        public override string ToString() {return "No: " + No + " Þehir: " + Þehir + " Ülke: " + Ülke + " Kýta: " + Kýta + " Ciro: " + Ciro;}
    }
    class Endeks {
        static public Kitap[] Kitaplar = {
            new Kitap {Yazar="Atatürk", Ad="Nutuk"},
            new Kitap {Yazar="F.R.Atay", Ad="Çankaya"},
            new Kitap {Yazar="A.M.Ýnan", Ad="Atatürk'ün Not Defterler"},
            new Kitap {Yazar="Lord Kinross", Ad="Atatürk, Bir Milletin Doðuþu"}
        };
        static void Main() {
            Console.Write ("Sorgu lambda'nýn '(k,endeks)=>' 2.ci parametresi otomatikmen tarananýn endeksidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sorgu lambda'nýn 2.ci parametresi otomatikmen tarananýn endeksidir:");
            List<Kiþi> kiþiler = new List<Kiþi> {
                new Kiþi {Dyýl = 1891, Ad = "Fatma", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1899, Ad = "Bekir", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1931, Ad = "Haným", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1934, Ad = "Memet", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1951, Ad = "Hatice", Soyad = "Kaçar"},
                new Kiþi {Dyýl = 1953, Ad = "Süheyla", Soyad = "Özbay"},
                new Kiþi {Dyýl = 1955, Ad = "Zeliha", Soyad = "Candan"},
                new Kiþi {Dyýl = 1957, Ad = "M.Nihat", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1959, Ad = "Songül", Soyad = "Gökyiðit"},
                new Kiþi {Dyýl = 1961, Ad = "M.Nedim", Soyad = "Yavaþ"},
                new Kiþi {Dyýl = 1963, Ad = "Sevim", Soyad = "Yavaþ"}
            };
            var sorgu1 = kiþiler.Select ((k, endeks) => new {Konum = endeks, k.Ad, k.Soyad, k.Dyýl});
            Console.WriteLine ("-->{0} adet kiþiler: ", sorgu1.Count());
            foreach (var k in sorgu1) Console.WriteLine (k);

            Console.WriteLine ("\nPeygamberlerden 'p.Length <= e' þartýný saðlayanlarý seçme:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.Write ("-->{0} adet tüm peygamberler (uzn, end): ", peygamberler.Length);
            int i; for(i=0;i<peygamberler.Length;i++) Console.Write ("{0}({1},{2}) ", peygamberler [i], peygamberler [i].Length, i); Console.WriteLine();
            Console.WriteLine ("-->'p.Length <= e' þartlý peygamber:");
            //var sorgu2 = peygamberler.Where ((p, e) => p.Length <= e).Select ((p, e) => new {Peygamber = p, Uzunluk = p.Length, Endeks = e});
            for(i=0;i<peygamberler.Length;i++) if(peygamberler [i].Length <= i) Console.WriteLine ("Peygamber={0,-10}\tUzunluk={1}\tEndeks={2}", peygamberler [i], peygamberler [i].Length, i);

            Console.WriteLine ("\nKitaplarý konum-no'lu ve A->Z ad-sýralý sunma:");
            var kitaplar = Kitaplar
                .Select ((kitap, end) => new {end, kitap.Yazar, kitap.Ad})
                .OrderBy (k => k.Ad);
            Console.WriteLine ("-->{0} adet orijinal endeksli ve ad-sýralý kitaplar: ", kitaplar.Count());
            foreach (var k in kitaplar) Console.WriteLine (k);

            Console.WriteLine ("\nEldeki mevcut yýllardan sorguyla yeni yýllar çýkarýmlama:");
            var yýllar = Enumerable.Range (2025-58, 58);
            Console.Write ("-->Tüm {0} adet yýllar: ", yýllar.Count());
            foreach (var y in yýllar) Console.Write (y+" "); Console.WriteLine();
            var sorgu3 =
                from yýl in yýllar
                select yýl-86;
            Console.Write ("-->Yýllar - 86: ");
            foreach (var yýl in sorgu3) Console.Write (yýl+" "); Console.WriteLine();

            Console.WriteLine ("\nYukardaki kiþiler listesini HAYATTA/MÜTEVEFFA þeklinde çýkarýmlama:");
            var sorgu4 = kiþiler.ConvertAll (delegate (Kiþi k) {return new {k.Ad, k.Soyad, k.Dyýl, YaþýyorMu = (k.Dyýl >= 1950)};});
            foreach (var k in sorgu4) Console.WriteLine ("{0}: {1}", k.YaþýyorMu?"HAYATTA":"MÜTEVEFFA", k);

            Console.WriteLine ("\nTüm kýta bayilerinden Asya'dakilerin çýkarýmlanmasý:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", Þehir="Tahran", Ülke="Ýran", Kýta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m}
            };
            Console.WriteLine ("-->Tüm kýtalardaki {0} adet bayiler: ", bayiler.Count());
            foreach (var b in bayiler) Console.WriteLine (b);
            var sorgu5 =
                from b in bayiler
                where b.Kýta == "Asya"
                select new {b.Þehir, b.Ülke, b.Ciro};
            Console.WriteLine ("-->Sadece {0} kýtasýndaki {1} adet bayiler: ", "Asya", sorgu5.Count());
            foreach (var b in sorgu5) Console.WriteLine (b);

            Console.WriteLine ("\nPeygamber ad, uzunluk ve endeksleriyle sorgular:");
            IEnumerable<string> sorgu6 = peygamberler.Where ((p, e) => (e % 2) == 0);
            Console.Write ("-->Çift endeksli {0} adet peygamberler: ", sorgu6.Count());
            foreach (string pey in sorgu6) Console.Write ("{0} ", pey); Console.WriteLine();
            IEnumerable<string> sorgu7 = peygamberler.Where ((p, e) => (e & 1) == 1);
            Console.Write ("-->Tek endeksli {0} adet peygamberler: ", sorgu7.Count());
            foreach (string pey in sorgu7) Console.Write ("{0} ", pey); Console.WriteLine();
            var sorgu8 = peygamberler.Select ((p,e) => new {p, p.Length, e});
            Console.WriteLine ("-->Tüm {0} adet peygamberler, ad-uzunluklarý ve endeksleri: ", sorgu8.Count());
            foreach (var p in sorgu8) Console.WriteLine (p);
            var sorgu9 = peygamberler.Select ((p,e) => new {Ad=p, Uzunluk=p.Length, Konum=e});
            Console.WriteLine ("-->Tüm {0} adet açýklamalý peygamberler: ", sorgu9.Count());
            foreach (var p in sorgu9) Console.WriteLine ("Konum={0,2}\tUzunluk={1}\tAd={2}", p.Konum+1, p.Uzunluk, p.Ad);
            var sorgu10 = from p in peygamberler where p.Length <= 5 select p;
            Console.Write ("-->Ad.Length<=5 ile sýnýrlý {0} adet peygamberler: ", sorgu10.Count());
            foreach (var p in sorgu10) Console.Write (p+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}