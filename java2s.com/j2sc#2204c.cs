// j2sc#2204c.cs: Linq.Where()/where sorgu filitresi örneði.

using System;
using System.Collections.Generic; //IEnumerable<> için
using System.Linq; //Where için
namespace Query_Sorgu {
    static class ÖzelWhere {
        public static IEnumerable<TipKaynak> Where<TipKaynak>(this IEnumerable<TipKaynak> kaynak) {
          int Ebat = kaynak.Count<TipKaynak>();
          TipKaynak[] Birimler = new TipKaynak [Ebat];
          Birimler.Initialize();
          int endeks = 0;
          foreach (TipKaynak birim in kaynak) {
             if (birim.ToString().Length > 4) {
                Birimler [endeks] = birim;
                endeks++;
             }
          }
          return Birimler;
       }
    }
    public class Ýþçi {
        public int _yýl;
        public int _meslekNo;
        public string _ad;
        public string _soyad;
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public int MeslekNo {get {return _meslekNo;} set {_meslekNo = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
    }
    class Maaþ {
        int _no;
        int _yýl;
        double _maaþ;
        public int MeslekNo {get {return _no;} set {_no = value;}}
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public double Maaþý {get {return _maaþ;} set {_maaþ = value;}}
    }
    class Ürün : IComparable<Ürün> {
        public int ÜrünNo {get; set;}
        public string ÜrünAdý {get; set;}
        public string Katagori {get; set;}
        public int BirimFiyat {get; set;}
        public int StoktaKalan {get; set;}
        public DateTime SipariþTarihi {get; set;}
        public override string ToString() {return String.Format ("Ürün no: {0}, Ürün adý: {1} , Katagori: {3}", this.ÜrünNo, this.ÜrünAdý, this.Katagori);}
        int IComparable<Ürün>.CompareTo (Ürün þu) {
            if (þu == null) return 1;
            if (this.ÜrünNo > þu.ÜrünNo) return 1;
            if (this.ÜrünNo < þu.ÜrünNo) return -1;
            return 0;
        }
    }
    class Where {
        static List<Ürün> ÜrünListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünNo = 1881, ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, StoktaKalan = 1500, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1914, ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, StoktaKalan = 130, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1919, ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, StoktaKalan = 8, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1920, ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, StoktaKalan = 10, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1923, ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, StoktaKalan = 1600, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1930, ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, StoktaKalan = 0, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1938, ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, StoktaKalan = 285, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return ürünListesi;
        }
        static void Main() {
            Console.Write ("Sorguda 'where/.Where()' seçilmek istenenlerin kýstas filitresidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\nPeygamberler dizisini where sorgularla seçme:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Brahman", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> sorgu1a = peygamberler.Where (p => p.StartsWith ("B"));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1a.Count(), "B");
            foreach (string p in sorgu1a) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1b = peygamberler
                .Where (p => p.Length < 6)
                .Select (p => p);
            Console.Write ("-->{0} adet 'uzn < 6' nebiler: ", sorgu1b.Count());
            foreach (string p in sorgu1b) Console.Write ("{0} ", p); Console.WriteLine();
            IEnumerable<string> sorgu1c = from p in peygamberler
                where p.Length >= 6
                select p;
            Console.Write ("-->{0} adet 'uzn >= 6' nebiler: ", sorgu1c.Count());
            foreach (string p in sorgu1c) Console.Write ("{0} ", p); Console.WriteLine();
            string pey = peygamberler.Where (p => p.StartsWith ("M")).Last();
            Console.Write ("-->{0} adet {1} ilkharfli son nebi: ", 1, "M");
            Console.Write (pey); Console.WriteLine();
            var sorgu1d = peygamberler.Where (p => p.StartsWith ("M")).First();
            Console.Write ("-->{0} adet {1} ilkharfli ilk nebi: ", 1, "M");
            foreach (var p in sorgu1d) Console.Write (p); Console.WriteLine();
            peygamberler [1]="nuh"; peygamberler [peygamberler.Length-1]="zerdüþt";
            IEnumerable<string> sorgu1e = peygamberler.Where (p => Char.IsLower (p [0]));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1e.Count(), "küçük");
            foreach (var p in sorgu1e) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<string> sorgu1f = peygamberler.Where (p => Char.IsUpper (p [0]));
            Console.Write ("-->{0} adet {1} ilkharfli nebiler: ", sorgu1f.Count(), "büyük");
            foreach (var p in sorgu1f) Console.Write (p+" "); Console.WriteLine();
            var sorgu1g = from p in peygamberler
                where p.EndsWith ("a")
                select p;
            Console.Write ("-->{0} adet {1} sonharfli nebiler: ", sorgu1g.Count(), "a");
            foreach (var p in sorgu1g) Console.Write (p+" "); Console.WriteLine();
            var sorgu1h = (from p in peygamberler
                where p [1] == 'u'
                select p).Reverse();
            Console.Write ("-->{0} adet {1} 2.harfli nebiler (ters): ", sorgu1h.Count(), "u");
            foreach (var p in sorgu1h) Console.Write (p+" "); Console.WriteLine();
            IEnumerable<char> sesliler = "aeýioöuü"; char sesli;
            IEnumerator<char> tarayýcý = sesliler.GetEnumerator();
            IEnumerable<char> sorgu1i = String.Join (" ", peygamberler);
            while (tarayýcý.MoveNext()) {
                sesli = tarayýcý.Current;
                sorgu1i = sorgu1i.Where (k => k != sesli);
                Console.Write ("-->{0} harfi silinen nebiler: ", sesli);
                foreach (var p in sorgu1i) Console.Write (p); Console.WriteLine();
            }
            foreach (char ses in "AaeýÝioöuü") {
                char aracý = ses;
                sorgu1i = sorgu1i.Where (k => k != aracý);
            }
            Console.Write ("-->Tüm {0} harfleri silinen nebiler: ", "sesli");
            foreach (var p in sorgu1i) Console.Write (p); Console.WriteLine();
            IEnumerable<char> sorgu1j = from k in string.Join ("", peygamberler) where Char.IsUpper (k) select k;
            Console.Write ("-->Sadece büyükharfleri alýnan nebiler: ");
            foreach (var k in sorgu1j) Console.Write (k+" "); Console.WriteLine();
            var sorgu1k = from p in peygamberler
                let endeks = p.Substring (0, 1)
                where Convert.ToChar (endeks) >= 'A'
                orderby endeks
                select new {p, endeks};
            Console.WriteLine ("-->Ýlk endeks harfle sýralý {0} adet tüm nebiler: ", sorgu1k.Count());
            foreach (var p in sorgu1k) Console.WriteLine (p);
            var sorgu1l = from p in peygamberler
                where p.Length >= 3
                select p;
            Console.Write ("-->{0} adet 'Uzn>=3' nebiler: ", sorgu1l.Count());
            foreach (var p in sorgu1l) Console.Write (p+" "); Console.WriteLine();
            var sorgu1m = ÖzelWhere.Where (peygamberler);
            Console.Write ("-->{0} adet 'Uzn > 4' özel nebiler: ", sorgu1m.Count());
            foreach (var p in sorgu1m) Console.Write (p+" "); Console.WriteLine();

            Console.WriteLine ("\nÝþçi-Maaþ kayýtlarýna dair sorgular:");
            List<Ýþçi> iþçiler = new List<Ýþçi> {
                new Ýþçi {Yýl = 1891, MeslekNo = 1, Ad = "Fatma", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1899, MeslekNo = 2, Ad = "Bekir", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1931, MeslekNo = 1, Ad = "Haným", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1934, MeslekNo = 2, Ad = "Memet", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1951, MeslekNo = 1, Ad = "Hatice", Soyad = "Kaçar"},
                new Ýþçi {Yýl = 1953, MeslekNo = 2, Ad = "Süheyla", Soyad = "Özbay"},
                new Ýþçi {Yýl = 1955, MeslekNo = 2, Ad = "Zeliha", Soyad = "Candan"},
                new Ýþçi {Yýl = 1957, MeslekNo = 2, Ad = "M.Nihat", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1959, MeslekNo = 2, Ad = "Songül", Soyad = "Gökyiðit"},
                new Ýþçi {Yýl = 1961, MeslekNo = 2, Ad = "M.Nedim", Soyad = "Yavaþ"},
                new Ýþçi {Yýl = 1963, MeslekNo = 2, Ad = "Sevim", Soyad = "Yavaþ"}
            };
            var sorgu2a = iþçiler.Where ((iþ, endeks) => iþ.Yýl >= endeks+1947).Select (iþ=>new{iþ.Ad, iþ.Soyad, iþ.Yýl});
            Console.WriteLine ("-->{0} adet 'Yýl >= endeks+1947' iþçiler:", sorgu2a.Count());
            foreach (var iþ in sorgu2a) Console.WriteLine (iþ);
            var sorgu2b = iþçiler.Where ((iþ, endeks) => iþ.Yýl < endeks+1947).Select (iþ=>new{iþ.Ad, iþ.Soyad, iþ.Yýl});
            Console.WriteLine ("-->{0} adet 'Yýl < endeks+1947' yöneticiler:", sorgu2b.Count());
            foreach (var iþ in sorgu2b) Console.WriteLine (iþ);
            List<Maaþ> maaþlar = new List<Maaþ> {
                new Maaþ {MeslekNo = 1, Yýl = 2024, Maaþý = 1612987.54},
                new Maaþ {MeslekNo = 2, Yýl = 2024, Maaþý = 355783.76}
            };
            var sorgu2c = from iþ in iþçiler
                                where iþ.MeslekNo == 1
                                from m in maaþlar
                                where m.MeslekNo == iþ.MeslekNo
                                select new {iþ.Ad, iþ.Soyad, m.Yýl, m.Maaþý};
            Console.WriteLine ("-->{0} adet 'Yönetici' yýllýk maaþlarý:", sorgu2c.Count());
            foreach (var iþ in sorgu2c) Console.WriteLine (iþ);
            var sorgu2d = from iþ in iþçiler
                                where iþ.MeslekNo == 2
                                from m in maaþlar
                                where m.MeslekNo == iþ.MeslekNo
                                select new {iþ.Ad, iþ.Soyad, m.Yýl, m.Maaþý};
            Console.WriteLine ("-->{0} adet 'Ýþçi' yýllýk maaþlarý:", sorgu2d.Count());
            foreach (var iþ in sorgu2d) Console.WriteLine (iþ);

            Console.WriteLine ("\nÜrün fiyatý ve stok miktarýna dair sorgular:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            var sorgu3a =
                from ü in ürünler
                where ü.StoktaKalan > 0 && ü.BirimFiyat > 400
                select new {ü.ÜrünAdý, ü.BirimFiyat, ü.StoktaKalan};
            Console.WriteLine ("-->{0} adet '400TL üstü mevcut' ürünler:", sorgu3a.Count());
            foreach (var ü in sorgu3a) Console.WriteLine (ü);
            var sorgu3b =
                from ü in ürünler
                where ü.StoktaKalan <= 10
                select new {ü.ÜrünAdý, ü.BirimFiyat, ü.StoktaKalan};
            Console.WriteLine ("-->{0} adet '10 adetten az' ürünler:", sorgu3b.Count());
            foreach (var ü in sorgu3b) Console.WriteLine (ü);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}