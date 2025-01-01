// j2sc#2202k.cs: Except/Intersect ile dýþlayan/jesiþen elemanlar örneði.

using System;
using System.Linq; //Except ve Intersect için
using System.Collections.Generic; //IEnumerable<> ve List<>için
namespace LinqMetot {
    class Müþteri : IComparable<Müþteri> {
        public int MüþteriNo {get; set;}
        public string ÞirketAdý {get; set;}
        public string Adresi {get; set;}
        public List<Ürün> Sipariþler {get; set;}
        public override string ToString() {return String.Format ("Müþteri no: {0}, Þirket adý: {1}, Adresi: {3}", this.MüþteriNo, this.ÞirketAdý, this.Adresi);}
        int IComparable<Müþteri>.CompareTo (Müþteri þu) {
            if (þu == null) return 1;
            if (this.MüþteriNo > þu.MüþteriNo) return 1;
            if (this.MüþteriNo < þu.MüþteriNo) return -1;
            return 0;
        }
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
    class Bayii {
        public string No {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro;
    }
    class Sipariþ {
        public string No {get; set;}
        public decimal Tutar {get; set;}
    }
    class Except_Intersect {
        static List<Müþteri> MüþteriListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünNo = 1881, ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1500, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1914, ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 130, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1919, ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 680, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1920, ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 700, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1923, ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, SipariþAdedi = 1600, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1930, ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 290, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1938, ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 290, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            List<Müþteri> müþteriListesi = new List<Müþteri>();
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Cihan Ltd", Adresi = "Rize", Sipariþler = ürünListesi, MüþteriNo = 10});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Ziyadede AÞ", Adresi = "Kayseri", Sipariþler = ürünListesi, MüþteriNo = 4});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Pýnarbaþý Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 25});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Billiruye AÞ", Adresi = "Zonguldak", Sipariþler = ürünListesi, MüþteriNo = 93});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Þemseddinpaþa AÞ", Adresi = "Kars", Sipariþler = ürünListesi, MüþteriNo = 64});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Keçiören Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 164});
            return müþteriListesi;
        }
        static List<Ürün> ÜrünListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünNo = 1881, ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1500, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1914, ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 130, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1919, ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 680, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1920, ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 700, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1923, ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, SipariþAdedi = 1600, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1930, ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 290, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1938, ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 290, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return ürünListesi;
        }
        static void Main() {
            Console.Write ("'dizi1.Except(dizi2)' ilk diziden ikincileri dýþlayan yegane elemanlarýn altkümesini döndürür. 'dizi1.Intersect(dizi2)' ilk diziden ikincilerle çakýþan yegane elemanlarýn altkümesini döndürür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýki dizi elemanlarýndan yegane istisna ve ortak olanlar:");
            String[] sayýlar1 = {"Bir", "Ýki", "Ýki", "Üç", "Dört"};
            String[] sayýlar2 = {"Üç", "Üç", "Dört", "Beþ", "Altý"};
            var hariç1 = sayýlar1.Except (sayýlar2);
            Console.Write ("sayýlar1.Except (sayýlar2): ");
            foreach (var n in hariç1) Console.Write (n+" "); Console.WriteLine();
            var kesiþen1 = sayýlar1.Intersect (sayýlar2);
            Console.Write ("sayýlar1.Intersect (sayýlar2): ");
            foreach (var n in kesiþen1) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\nÝki yýllar dizinin dýþlayan ve kesiþen elemanlarý:");
            int[] yýllarA = {1919, 1920, 1921, 1922, 1923, 1927, 1938};
            int[] yýllarB = {1920, 1923, 1926, 1930, 1938};
            IEnumerable<int> hariç2 = yýllarA.Except (yýllarB);
            Console.Write ("yýllarA.Except (yýllarB): ");
            foreach (var n in hariç2) Console.Write (n+" "); Console.WriteLine();
            IEnumerable<int> kesiþen2 = yýllarA.Intersect (yýllarB);
            Console.Write ("yýllarA.Intersect (yýllarB): ");
            foreach (var n in kesiþen2) Console.Write (n+" "); Console.WriteLine();

            Console.WriteLine ("\nÜrün ve müþteri ilk harflerinin dýþlayan ve kesiþenleri:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var ürünHarf = from ü in ürünler select ü.ÜrünAdý [0];
            var müþteriHarf = from m in müþteriler select m.ÞirketAdý [0];
            var hariç3 = ürünHarf.Except (müþteriHarf);
            Console.Write ("ürünHarf.Except (müþteriHarf): ");
            foreach (var k in hariç3) Console.Write (k+" "); Console.WriteLine();
            var kesiþen3 = ürünHarf.Intersect (müþteriHarf);
            Console.Write ("ürünHarf.Intersect (müþteriHarf): ");
            foreach (var k in kesiþen3) Console.Write (k+" "); Console.WriteLine();

            Console.WriteLine ("\nBayiler ve sipariþlerinin dýþlayan ve kesiþen no'larý:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", Þehir="Tahran", Ülke="Ýran", Kýta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m}
            };
            List<Sipariþ> sipariþler = new List<Sipariþ> {
                new Sipariþ {No="2024R", Tutar=912.66m},
                new Sipariþ {No="2024S", Tutar=1054.38m},
                new Sipariþ {No="2024T", Tutar=897.56m}
            };
            var bnolar = from b in bayiler select b.No;
            var snolar = from s in sipariþler select s.No;
            var hariç4 = bnolar.Except (snolar);
            Console.Write ("bnolar.Except (snolar): ");
            foreach (var no in hariç4) Console.Write ("{0} ", no); Console.WriteLine();
            var kesiþen4 = bnolar.Intersect (snolar);
            Console.Write ("bnolar.Intersect (snolar): ");
            foreach (var no in kesiþen4) Console.Write ("{0} ", no); Console.WriteLine();

            Console.WriteLine ("\nPeygamberlerin Take/Skip altkümelerinin dýþlayan ve çakýþanlarý:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> pey1 = peygamberler.Take (7);
            IEnumerable<string> pey2 = peygamberler.Skip (4);
            IEnumerable<string> hariç5 = pey1.Except (pey2);
            IEnumerable<string> kesiþen5 = pey1.Intersect (pey2);
            Console.WriteLine ("Peygamberlerin sayýsý: " + peygamberler.Count());
            Console.WriteLine ("Ýlk pey1 dizinin sayýsý: " + pey1.Count());
            Console.WriteLine ("Ýkinci pey2 dizinin sayýsý: " + pey2.Count());
            Console.WriteLine ("Dýþlayan dizinin sayýsý: " + hariç5.Count());
            Console.WriteLine ("Çakýþan dizinin sayýsý: " + kesiþen5.Count());
            Console.Write ("Tüm peygamberler: ");
            foreach (string ad in peygamberler) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("pey1.Except (pey2): ");
            foreach (string ad in hariç5) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("pey1.Intersect (pey2): ");
            foreach (string ad in kesiþen5) Console.Write (ad+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}