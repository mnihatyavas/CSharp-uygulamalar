// j2sc#2204b.cs: Ýçiçe sorgular, nesnel sorgu alanlarý, Split.First/Last örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; //Where için
namespace Query_Sorgu {
    public class Hanehalký {
        public int _yýl;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
    }
    class Rol {
        int _meslekNo;
        string meslek;
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Meslek {get {return meslek;} set {meslek = value;}}
    }
    public class Kitap {
        public String Yazar {get; set;}
        public String Ad {get; set;}
        public override String ToString() {return Yazar+": "+Ad;}
    }
    class Sorgu2 {
        static void Main() {
            Console.Write ("enum.Split().First() boþluklu ismin ilk adýný, enum.Split().Last() sonuncu soyadýný alýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Hanehalký-->meslekno ile roller-->meslek iliþkili içiçe sorgu:");
            List<Hanehalký> hanehalký = new List<Hanehalký> {
                new Hanehalký {Yýl = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1931, MeslekNo = 1, Ad = "Haným", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Kaçar"},
                new Hanehalký {Yýl = 1953, MeslekNo = 2, Ad = "Süheyla", Soyad = "Özbay"},
                new Hanehalký {Yýl = 1955, MeslekNo = 2, Ad = "Zeliha", Soyad = "Candan"},
                new Hanehalký {Yýl = 1957, MeslekNo = 2, Ad = "M.Nihat", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1959, MeslekNo = 2, Ad = "Songül", Soyad = "Gökyiðit"},
                new Hanehalký {Yýl = 1961, MeslekNo = 2, Ad = "M.Nedim", Soyad = "Yavaþ"},
                new Hanehalký {Yýl = 1963, MeslekNo = 2, Ad = "Sevim", Soyad = "Yavaþ"}
            };
            List<Rol> roller = new List<Rol> {
                new Rol {MeslekNo = 1, Meslek = "Yönetici"},
                new Rol {MeslekNo = 2, Meslek = "Ýþgören"}
            };
            var sorgu1a = hanehalký
                .Where (hh => hh.MeslekNo == 1)
                .SelectMany (hh => roller
                    .Where (r => r.MeslekNo == hh.MeslekNo)
                    .Select (r => new {r.Meslek, hh.Ad, hh.Soyad, hh.Yýl}));
            Console.WriteLine ("-->{0} adet {1} listesi:", sorgu1a.Count(), "Yönetici");
            foreach (var h in sorgu1a) Console.WriteLine (h);
            var sorgu1b = hanehalký
                .Where (hh => hh.MeslekNo == 2)
                .SelectMany (hh => roller
                    .Where (r => r.MeslekNo == hh.MeslekNo)
                    .Select (r => new {r.Meslek, hh.Ad, hh.Soyad, hh.Yýl}));
            Console.WriteLine ("-->{0} adet {1} listesi:", sorgu1b.Count(), "Ýþgören");
            foreach (var h in sorgu1b) Console.WriteLine (h);
            var sorgu1c = from h in hanehalký select h; //Console.WriteLine (h) object/nesnedir, ya "h.Alan" yada "new {h.Alan}" gerekir
            Console.Write ("-->Tüm {0} adet hanehalký adlarý: ", sorgu1c.Count());
            foreach (var h in sorgu1c) Console.Write (h.Ad+" "); Console.WriteLine();
            var sorgu1d = from h in hanehalký
                where h.Soyad == "Yavaþ"
                select h;
            Console.Write ("-->{0} adet soyad='Yavaþ' hanehalký adlarý: ", sorgu1d.Count());
            foreach (var h in sorgu1d) Console.Write (h.Ad+" "); Console.WriteLine();
            var sorgu1e = hanehalký
                .Where (h => h.MeslekNo == 1)
                .Select (h => new {h.Ad, h.Soyad});
            Console.WriteLine ("-->{0} adet meslek='Yönetici' hanehalký isimleri:", sorgu1e.Count());
            foreach (var h in sorgu1e) Console.WriteLine (h);

            Console.WriteLine ("\nPeygamberler dizisini çeþitli içiçe IEnumerable<> sorgularla seçme:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> sorgu2a = Enumerable.Select (
                Enumerable.OrderBy (
                    Enumerable.Where (peygamberler, p => p.Contains ("a")
                ), p => p.Length
            ), p => p.ToUpper());
            Console.Write ("-->{0} adet {1} harfi-içeren ve artan-uzunlukla sýralý, büyükharfli nebiler: ", sorgu2a.Count(), "a");
            foreach (var p in sorgu2a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu2b = Enumerable.Select (
                Enumerable.OrderByDescending (
                    Enumerable.Where (peygamberler, p => p.Contains("u")||p.Contains("ü")
                ), p => p.Length
            ), p => p.ToLower());
            Console.Write ("-->{0} adet {1} harfi-içeren ve azalan-uzunlukla sýralý, küçükharfli nebiler: ", sorgu2b.Count(), "a|ü");
            foreach (var p in sorgu2b) Console.Write (p+" "); Console.WriteLine();
            for(int i=0;i<peygamberler.Length;i++) peygamberler [i] = "Hazreti " + peygamberler [i];
            IEnumerable<string> sorgu2c = peygamberler.OrderBy (p => p.Split().First());
            Console.Write ("-->{0} adet ilk ünvanla sýralý nebiler: ", sorgu2c.Count());
            foreach (var p in sorgu2c) Console.Write (p.Split().Last()+" "); Console.WriteLine();
            IEnumerable<string> sorgu2d = peygamberler.OrderByDescending (p => p.Split().Last());
            Console.Write ("-->{0} adet son adla azalan sýralý nebiler: ", sorgu2d.Count());
            foreach (var p in sorgu2d) Console.Write ("\"{0}\" ", p); Console.WriteLine();

            Console.WriteLine ("\nKitap sorgu dökümünü 'new{}' veya 'override String ToString(){}' ile yapma:");
            Kitap[] kitaplar = {
                new Kitap {Yazar="Atatürk", Ad="Nutuk"},
                new Kitap {Yazar="F.R.Atay", Ad="Çankaya"},
                new Kitap {Yazar="A.M.Ýnan", Ad="Atatürk'ün Not Defterler"},
                new Kitap {Yazar="Lord Kinross", Ad="Atatürk, Bir Milletin Doðuþu"}
            };
            var sorgu3a = kitaplar
                .Where (k => k.Ad.Contains("a")&&k.Ad.Contains("ü"))
                .Select (k => new {k.Yazar, k.Ad});
            Console.WriteLine ("-->{0} adet kitapadý({1}) kitap listesi:", sorgu3a.Count(), "a&ü");
            foreach (var k in sorgu3a) Console.WriteLine (k);
            var sorgu3b = kitaplar
                .Where (k => k.Ad.Equals ("Çankaya"))
                .Select (k => k);
            Console.WriteLine ("-->{0} adet kitapadý({1}) kitap listesi:", sorgu3b.Count(), "Çankaya");
            foreach (var k in sorgu3b) Console.WriteLine (k);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}