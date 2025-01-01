// j2sc#2202e.cs: Ýçeren Linq-->dizi.Contains() ve ortalama dizi.Average() örneði.

using System;
using System.Linq; //Contains() için
using System.Collections.Generic; //IEqualityComparer<>, List<> için
namespace LinqMetot {
    public class SýnýfA : IEqualityComparer<string> {
        public bool Equals (string x, string y) {return (Int32.Parse (x) == Int32.Parse (y));}
        public int GetHashCode (string obj) {return 20241114;}
    }
    class Ürün : IComparable<Ürün> {
        public int ÜrünNo {get; set;}
        public string ÜrünAdý {get; set;}
        public string Katagori {get; set;}
        public int BirimFiyat {get; set;}
        public int SipariþAdedi {get; set;}
        public DateTime SipariþTarihi {get; set;}
        public override string ToString() {return String.Format ("Ürün no: {0}, Ürün adý: {1} , Katagori: {3}", this.ÜrünNo, this.ÜrünAdý, this.Katagori);}
        int IComparable<Ürün>.CompareTo (Ürün þu) {
            if (þu == null) return 1;
            if (this.ÜrünNo > þu.ÜrünNo) return 1;
            if (this.ÜrünNo < þu.ÜrünNo) return -1;
            return 0;
        }
    }
    class Maaþ {
        int _no, _yýl;
        double _maaþ;
        public int No {get {return _no;} set {_no = value;}}
        public int Yýl {get {return _yýl;} set {_yýl = value;}}
        public double Maaþý {get {return _maaþ;} set {_maaþ = value;}}
    }
    class Ýþçi {
        int _no, _branþ;
        string _soyad, _ad;
        public int No {get {return _no;} set {_no = value;}}
        public int Branþý {get {return _branþ;} set {_branþ = value;}}
        public string Soyad {get {return _soyad;} set {_soyad = value;}}
        public string Ad {get {return _ad;} set {_ad = value;}}
    }
/*  class Branþ {
        int _no;
        string rol;
        public int No {get {return _no;} set {_no = value;}}
        public string Rol {get {return rol;} set {rol = value;}}
    }
*/
    class Contains_Average {
        static List<Ürün> ÜrünListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünAdý = "Kalem", Katagori = "Kýrtasiye", BirimFiyat = 43, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 12});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Defter", Katagori = "Kýrtasiye", BirimFiyat = 452, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 23});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Silgi", Katagori = "Kýrtasiye", BirimFiyat = 25, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 8});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Cetvel", Katagori = "Kýrtasiye", BirimFiyat = 112, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 14});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 123});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 3265, SipariþAdedi = 120, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 123});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 243});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 3278, SipariþAdedi = 85, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 243});
            return ürünListesi;
        }
        static void Main() {
            Console.Write ("Ýçeriyorsa 'dizi.Contains(arg)' true döndürür. Double 'dizi.Average()' sayýsal elemanlarýn ortalamasýný döndürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Linq-Contains bool tip olup, dizide aranan haizse 'true' döndürür:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            bool haiz = peygamberler.Contains ("Buda"); Console.WriteLine ("peygamberler.Contains(\"Buda\")? {0}", haiz?"Evet":"Hayýr");
            haiz = peygamberler.Contains ("Budala"); Console.WriteLine ("peygamberler.Contains(\"Budala\")? {0}", haiz?"Evet":"Hayýr");

            Console.WriteLine ("\n'dizi.Contains(arg, kýyas)' için özel kýyaslama kullanýlabilir:");
            string[] yýlDizge = new string[30];
            int i, ts; var r=new Random();
            for(i=0;i<30;i++) {ts=r.Next(1881,1939); yýlDizge [i]="00" + ts.ToString();}
            ts=r.Next(1881,1939);
            Array.Sort (yýlDizge);
            Console.Write ("Rasgele dizgesel-yýllar: "); foreach(var yýl in yýlDizge) Console.Write (yýl+" "); Console.WriteLine();
            haiz=yýlDizge.Contains (ts.ToString(), new SýnýfA());
            Console.WriteLine ("'{0}' yýlDizge dizisinde mevcut mu? {1}", ts, haiz?"Mevcut":"Namevcut");

            Console.WriteLine ("\nBelirtilen harfe haiz, azalan uzunlukta sorgu kelimeleri:");
            IEnumerable<string> adSorgusu =
                from ad in peygamberler
                where ad.Contains ("u")
                orderby ad.Length descending
                select ad.ToUpper();
            Console.Write ("Sorgu adlarý içinde 'u' bulunanlar: "); foreach (var ad in adSorgusu) Console.Write (ad + "  ");

            Console.WriteLine ("\nVerili sayýsal dizilerin Linq-->Average ile ortalamalarý:");
            double ortalama1 = yýlDizge.Average (yýl => Int32.Parse (yýl));
            Console.WriteLine ("-->Önceki yýlDizge[30]'nin ortalamasý: " + ortalama1);
            IEnumerable<int> tsKapsam = Enumerable.Range (1881, 58);
            Console.Write ("-->Range (1881, 58): "); foreach (int n in tsKapsam) Console.Write (n+" "); Console.WriteLine();
            ortalama1 = tsKapsam.Average();
            Console.WriteLine ("tsKapsam(1881,58)'in ortalamasý: " + ortalama1);
            var yýlSorgu = from n in tsKapsam where n > 1919 select n;
            Console.Write ("-->yýlSorgu where n > 1919: "); foreach (int n in yýlSorgu) Console.Write (n+" "); Console.WriteLine();
            ortalama1 = yýlSorgu.Average();
            Console.WriteLine ("yýlSorgu'nun ortalamasý: " + ortalama1);
            tsKapsam = Enumerable.Range (-2024, 2024+2024);
            Console.WriteLine ("tsKapsam(-2024,4048)'in ortalamasý: " + tsKapsam.Average());
            ortalama1 = peygamberler.Average (pey => pey.Length);
            Console.WriteLine ("-->Önceki peygamberler[{0}] kelime uzunluklarý ortalamasý: {1} harf.", peygamberler.Length, ortalama1);

            Console.WriteLine ("\nÜrün kategori gruplarýnýn fiyat ortalamalarý:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            var katagoriSorgu =
                from ürn in ürünler
                group ürn by ürn.Katagori into grup
                select new {Katagori = grup.Key, OrtalamaFiyat = grup.Average (ür => ür.BirimFiyat)};
            foreach(var kat in katagoriSorgu) Console.WriteLine (kat);

            Console.WriteLine ("\nBranþý 3=Vardiya'lý yýllýk maaþlarýn ortalamasý:");
            List<Ýþçi> iþçiler = new List<Ýþçi> {
                new Ýþçi {No = 1951, Branþý = 1, Soyad = "Kaçar", Ad = "Hatice"},
                new Ýþçi {No = 1953, Branþý = 3, Soyad = "Özbay", Ad = "Süheyla"},
                new Ýþçi {No = 1955, Branþý = 2, Soyad = "Candan", Ad = "Zeliha"},
                new Ýþçi {No = 1957, Branþý = 3, Soyad = "Yavaþ", Ad = "M.Nihat"},
                new Ýþçi {No = 1959, Branþý = 3, Soyad = "Gökyiðit", Ad = "Songül"},
                new Ýþçi {No = 1961, Branþý = 2, Soyad = "Yavaþ", Ad = "M.Nedim"},
                new Ýþçi {No = 1963, Branþý = 1, Soyad = "Yavaþ", Ad = "Sevim"}
            };
/*          List<Branþ> roller = new List<Branþ> {
                new Branþ {No = 1, Rol = "Yönetim"},
                new Branþ {No = 2, Rol = "Muhasebe"},
                new Branþ {No = 3, Rol = "Vardiya"}
            };
*/
            List<Maaþ> maaþlar = new List<Maaþ> {
                new Maaþ {No = 1951, Yýl = 2024, Maaþý = 120675.87},
                new Maaþ {No = 1953, Yýl = 2024, Maaþý = 105302.15},
                new Maaþ {No = 1955, Yýl = 2024, Maaþý = 118765.54},
                new Maaþ {No = 1957, Yýl = 2024, Maaþý = 165674.43},
                new Maaþ {No = 1959, Yýl = 2024, Maaþý = 218765.43},
                new Maaþ {No = 1961, Yýl = 2024, Maaþý = 146734.17},
                new Maaþ {No = 1963, Yýl = 2024, Maaþý = 215458.98}
            };
            var branþMaaþSorgu = from iþ in iþçiler
                    join mþ in maaþlar on iþ.No equals mþ.No
                    where iþ.Branþý == 3
                    select mþ.Maaþý;
            foreach(var seç in branþMaaþSorgu) Console.WriteLine ("Maaþ = {0,14:#,0.00} TL", seç);
            Console.WriteLine ("Ortalama = {0:#,0.00} TL", branþMaaþSorgu.Average());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}