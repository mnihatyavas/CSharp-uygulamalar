// j2sc#2202j.cs: Linq-->First/OrDefault(), Last/OrDefault() metotlarý örneði.

using System;
using System.Linq; //First(), Last() için
using System.Collections.Generic; //IEnumerable<>, List<> için için
namespace LinqMetot {
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
    class First_Last {
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
            Console.Write ("'dizi.First()/Last()' mevcutsa ilk/son elemaný, namevcutsa hata döndürür. 'dizi.First/LastOrDefault()' namevcutsa 0/boþ/null döndürür, hata fýrlatmaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sayýsal dizinin ilk, son, varsayýlý elemanlarý:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[10];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("Tüm yýllar: "); foreach(var y in yýllar) Console.Write (y+" "); Console.WriteLine();
            Console.WriteLine ("yýllar.First() = {0}", yýllar.First());
            Console.WriteLine ("yýllar.Last() = {0}", yýllar.Last());
            Console.WriteLine ("yýllar.ElementAt (yýllar.Length/2) = {0}", yýllar.ElementAt (yýllar.Length/2));
            Console.WriteLine ("yýllar.FirstOrDefault (n => n % 2 == 0) = {0}", yýllar.FirstOrDefault (n => n % 2 == 0));
            Console.WriteLine ("yýllar.LastOrDefault (n => n % 2 == 1) = {0}", yýllar.LastOrDefault (n => n % 2 == 1));
            int[] yýllar2 = {};
            Console.WriteLine ("Boþ sayýsal dizinin ilk elemaný: {0}", yýllar2.FirstOrDefault());
            Console.WriteLine ("Boþ sayýsal dizinin son elemaný: {0}", yýllar2.LastOrDefault());

            Console.WriteLine ("\nPeygamberlerin ilkharfli ve sýralý ilk/son elemanlarý:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.WriteLine ("'M' ile baþlayan ilk peygamber = {0}", peygamberler.First (p => p.StartsWith ("M")));
            Console.WriteLine ("'M' ile baþlayan son peygamber = {0}", peygamberler.Last (p => p.StartsWith ("M")));
            Console.WriteLine ("'J' ile baþlayan/varsayýlý ilk peygamber = [{0}]", peygamberler.FirstOrDefault (p => p.StartsWith ("J")));
            Console.WriteLine ("'J' ile baþlayan/varsayýlý son peygamber = [{0}]", peygamberler.LastOrDefault (p => p.StartsWith ("J")));
            Console.WriteLine ("Artan sýralý ilk peygamber = {0}", peygamberler.OrderBy (p => p).First());
            Console.WriteLine ("Azalan sýralý ilk peygamber = {0}", peygamberler.OrderByDescending (p => p).First());
            Console.WriteLine ("Artan sýralý son peygamber = {0}", peygamberler.OrderBy (p => p).Last());
            Console.WriteLine ("Azalan sýralý son peygamber = {0}", peygamberler.OrderByDescending (p => p).Last());

            Console.WriteLine ("\nÜrün sýnýf tipli listenin þartý saðlayan ilk/son elemaný:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            Ürün ürün = (from p in ürünler where p.ÜrünNo == 123 select p).First();
            Console.WriteLine ("ÜrünNo=={0} olan ilk ürün: {1}({2}) = {3:#,0.00} TL", 123, ürün.Katagori, ürün.ÜrünAdý, ürün.BirimFiyat);
            ürün = (from p in ürünler where p.ÜrünNo == 123 select p).Last();
            Console.WriteLine ("ÜrünNo=={0} olan son ürün: {1}({2}) = {3:#,0.00} TL", 123, ürün.Katagori, ürün.ÜrünAdý, ürün.BirimFiyat);
            ürün = ürünler.FirstOrDefault (ü => ü.ÜrünNo == 123);
            Console.WriteLine ("Ürün 123 mevcut mu?: {0}", ürün != null?"EVET":"HAYIR");
            ürün = ürünler.LastOrDefault (ü => ü.ÜrünNo == 2024);
            Console.WriteLine ("Ürün {0} mevcut mu?: {1}", 2024, ürün != null?"EVET":"HAYIR");

            Console.WriteLine ("\nBayii sýnýf tipli listenin 'Kýta' þartlý ilk/son elemaný:");
            List<Bayii> bayiler = new List<Bayii> {
                new Bayii {No="2024P", Þehir="Tahran", Ülke="Ýran", Kýta="Asya", Ciro=7285.76m},
                new Bayii {No="2024Q", Þehir="Londra", Ülke="BK", Kýta="Avrupa", Ciro=8872.14m},
                new Bayii {No="2024R", Þehir="Beijing", Ülke="Çin", Kýta="Asya", Ciro=9456.87m},
                new Bayii {No="2024T", Þehir="Ýstanbul", Ülke="Türkiye", Kýta="Avrupa", Ciro=2523.65m},
                new Bayii {No="2024T", Þehir="Ankara", Ülke="Türkiye", Kýta="Asya", Ciro=5742.34m}
            };
            var sorgu = from b in bayiler select new {b.Kýta, b.Ülke, b.Þehir};
            Console.WriteLine ("{0}'da bayimiz var mý? {1}", "Afrika", sorgu.FirstOrDefault (b => b.Kýta == "Afrika")!=null?"VAR":"YOK");
            Console.WriteLine ("{0}'daki ilk bayii þehri: {1}", "Avrupa", sorgu.FirstOrDefault (b => b.Kýta == "Avrupa").Þehir);
            Console.WriteLine ("{0}'daki son bayii þehri: {1}", "Avrupa", sorgu.LastOrDefault (b => b.Kýta == "Avrupa").Þehir);


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}