// j2sc#2202b.cs: Union ve concat'le dizilerin doðrudan/sorgulu birleþimleri örneði.

using System;
using System.Linq; //Union ve Concat için
using System.Collections.Generic; //List<> için
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
        public string BayiiNo {get; set;}
        public string Þehir {get; set;}
        public string Ülke {get; set;}
        public string Kýta {get; set;}
        public decimal Ciro {get; set;}
    }
    class Sipariþ {
        public string BayiiNo {get; set;}
        public decimal Tutar {get; set;}
    }
    class Union_Concat {
        static List<Ürün> ÜrünListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünAdý = "Kalem", Katagori = "Kýrtasiye", BirimFiyat = 43, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 12});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Defter", Katagori = "Kýrtasiye", BirimFiyat = 452, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 23});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Silgi", Katagori = "Kýrtasiye", BirimFiyat = 25, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 8});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Cetvel", Katagori = "Kýrtasiye", BirimFiyat = 112, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 14});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 123});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 243});
            return ürünListesi;
        }
        static List<Müþteri> MüþteriListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünAdý = "Kalem", Katagori = "Kýrtasiye", BirimFiyat = 43, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 12});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Defter", Katagori = "Kýrtasiye", BirimFiyat = 452, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 23});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Silgi", Katagori = "Kýrtasiye", BirimFiyat = 25, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 8});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Cetvel", Katagori = "Kýrtasiye", BirimFiyat = 112, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 14});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 123});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 243});
            List<Müþteri> müþteriListesi = new List<Müþteri>();
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Abdulkerim Ltd", Adresi = "Rize", Sipariþler = ürünListesi, MüþteriNo = 10});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Ziyadede AÞ", Adresi = "Kayseri", Sipariþler = ürünListesi, MüþteriNo = 4});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Camibaþý Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 25});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Billiruye AÞ", Adresi = "Zonguldak", Sipariþler = ürünListesi, MüþteriNo = 93});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Þemseddinpaþa AÞ", Adresi = "Kars", Sipariþler = ürünListesi, MüþteriNo = 64});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Keçiören Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 164});
            return müþteriListesi;
        }
        static void Main() {
            Console.Write ("Linq-Union dizilerin yegane elemanlarýný, Concat ise ardýþýk eklenimlerini birleþtirir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Union sadece yegane adlarý birleþtirirken, concat hepsini birleþtirir:");
            string[] adlar1 = {"Fatma", "Bekir", "Haným", "Memet"};
            string[] adlar2 = {"Hatice", "Süheyla", "Zeliha", "Nihat", "Songül", "Nedim", "Sevim"};
            var union1 = adlar1.Union (adlar2).Union (adlar2); //Sadece yegane dizi elemanlarýný birleþtirir
            var concat1 = adlar1.Concat (adlar2).Concat (adlar2); //Çoklu elemanlarý da aynen birleþtiri
            Console.Write ("Adlar-->Union: "); foreach (String ad in union1) Console.Write (ad+" "); Console.WriteLine();
            Console.Write ("Adlar-->Concat: "); foreach (String ad in concat1) Console.Write (ad+" "); Console.WriteLine();
            int[] doðumlar1 = {1895, 1891, 1932, 1933};
            int[] doðumlar2 = {1951, 1953, 1955, 1957, 1959, 1961, 1963};
            var union2 = doðumlar1.Union (doðumlar2).Union (doðumlar2);
            var concat2 = doðumlar1.Concat (doðumlar2).Concat (doðumlar2);
            Console.Write ("Doðumlar-->Union: "); foreach (var yýl in union2) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("Doðumlar-->Concat: "); foreach (var yýl in concat2) Console.Write (yýl+" "); Console.WriteLine();
            int[] boylar = {165, 185, 170, 167, 165, 168, 167, 171, 168, 169, 164};
            int[] kilolar = {55, 78, 60, 85, 105, 65, 80, 59, 62, 70, 62};
            var union3 = boylar.Union (kilolar);
            var concat3 = boylar.Concat (kilolar);
            Console.Write ("Boy+Kilo-->Union: "); foreach (var bk in union3) Console.Write (bk+" "); Console.WriteLine();
            Console.Write ("Boy+Kilo-->Concat: "); foreach (var bk in concat3) Console.Write (bk+" "); Console.WriteLine();

            Console.WriteLine ("\nAltýþar ürün ve firma adlarý ilkharflerinin yegane ve eklemeli dökümleri:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var ürünadýSorgusu = from ürün in ürünler select ürün.ÜrünAdý [0];
            var þirketadýSorgusu = from þirket in müþteriler select þirket.ÞirketAdý [0];
            var ürünÞirketÝlkharfUnion = ürünadýSorgusu.Union (þirketadýSorgusu);
            var ürünÞirketÝlkharfConcat = ürünadýSorgusu.Concat (þirketadýSorgusu);
            Console.Write ("Ürün-þirket ilkharf-->Union: "); foreach (var k in ürünÞirketÝlkharfUnion) Console.Write (k+" "); Console.WriteLine();
            Console.Write ("Ürün-þirket ilkharf-->Concat: "); foreach (var k in ürünÞirketÝlkharfConcat) Console.Write (k+" "); Console.WriteLine();

            Console.WriteLine ("\nUnion 5+7=12-10=2 örtüþeni dýþlarken Concat 12 ekler:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            IEnumerable<string> ilkBeþ = peygamberler.Take (5);
            IEnumerable<string> üçAtla = peygamberler.Skip (3);
            IEnumerable<string> concat4 = ilkBeþ.Concat<string>(üçAtla);
            IEnumerable<string> union4 = ilkBeþ.Union<string>(üçAtla);
            Console.Write ("Peygamberler: "); foreach (var pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            Console.WriteLine ("Tüm peygamber sayýsý: " + peygamberler.Count());
            Console.WriteLine ("ilkBeþ dizi sayýsý: " + ilkBeþ.Count());
            Console.WriteLine ("üçAtla dizi sayýsý: " + üçAtla.Count());
            Console.WriteLine ("Concat dizi sayýsý: " + concat4.Count());
            Console.WriteLine ("Union dizi sayýsý: " + union4.Count());
            IEnumerable<string> concat5 = peygamberler.Take (5).Concat (peygamberler.Skip (3));
            Console.Write ("ÝlkBeþ+üçAtla-->Concat ardýþýk: "); foreach (string pey in concat5) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<string> concat6 = new[]{peygamberler.Take (5), peygamberler.Skip (3)}.SelectMany (pyg => pyg);
            Console.Write ("ÝlkBeþ+üçAtla-->Concat new[]-selectLambda: "); foreach (string pey in concat6) Console.Write (pey+" "); Console.WriteLine();

            Console.WriteLine ("\nUluslararasý bayiler ve sipariþlerinin yegane-Union ve eklemeli-Concat listesi:");
            List<Sipariþ> sipariþler = new List<Sipariþ> {
                new Sipariþ {BayiiNo="King", Tutar=9000},
                new Sipariþ {BayiiNo="Wolf", Tutar=1000},
                new Sipariþ {BayiiNo="Queen", Tutar=10000},
                new Sipariþ {BayiiNo="Lion", Tutar=1800},
                new Sipariþ {BayiiNo="Diamond", Tutar=1100}
            };
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {BayiiNo="King", Þehir="London", Ülke="UK", Kýta="Europe", Ciro=80000},
                new Bayii {BayiiNo="Queen", Þehir="Beijing", Ülke="China", Kýta="Asia", Ciro=90000},
                new Bayii {BayiiNo="Lion", Þehir="Ýstanbul", Ülke="Turkey", Kýta="Europe", Ciro=1240000},
                new Bayii {BayiiNo="Wolf", Þehir="Cairo", Ülke="Eygpt", Kýta="Africa", Ciro=124000},
                new Bayii {BayiiNo="Parrot", Þehir="SaoPaola", Ülke="Brazil", Kýta="South America", Ciro=40000},
                new Bayii {BayiiNo="Diamond", Þehir="Lima", Ülke="Peru", Kýta="South America", Ciro=315000}
            };
            var bayinoSorgusu = from bayi in bayiler select bayi.BayiiNo;
            var sipariþnoSorgusu = from sipariþ in sipariþler select sipariþ.BayiiNo;
            var bayisipariþUnion = sipariþnoSorgusu.Union (bayinoSorgusu);
            var bayisipariþConcat = sipariþnoSorgusu.Concat (bayinoSorgusu);
            Console.Write ("Bayii+Sipariþ-->Union: "); foreach (var no in bayisipariþUnion) Console.Write (no+" "); Console.WriteLine();
            Console.Write ("Bayii+Sipariþ-->Concat: "); foreach (var no in bayisipariþConcat) Console.Write (no+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}