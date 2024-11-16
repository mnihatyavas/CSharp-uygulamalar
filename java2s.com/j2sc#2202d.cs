// j2sc#2202d.cs: IComparable<T>.CompareTo (T þu) ile özel kýyas alaný örneði.

using System;
using System.Linq; //from-select için
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
    class Compareto {
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
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Abdulkerim Ltd", Adresi = "Rize", Sipariþler = ürünListesi, MüþteriNo = 10});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Ziyadede AÞ", Adresi = "Kayseri", Sipariþler = ürünListesi, MüþteriNo = 4});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Pýnarbaþý Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 25});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Billiruye AÞ", Adresi = "Zonguldak", Sipariþler = ürünListesi, MüþteriNo = 93});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Þemseddinpaþa AÞ", Adresi = "Kars", Sipariþler = ürünListesi, MüþteriNo = 64});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Keçiören Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 164});
            return müþteriListesi;
        }
        static void Main() {
            Console.Write ("Ýki çok-alanlý nesne kýyaslanýrken 'IComparable<T>.CompareTo (T þu)' ile kýyasýn hangi alanla yapýlacaðý tanýmlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýki sayý dizisinde (a < b) çiftleri:");
            int[] sayýlarA = {10, 20, 40, 15, 65, 850, 999};
            int[] sayýlarB = {10, 30, 50, 70, 82};
            Console.Write ("A sayý dizisi: "); foreach(var n in sayýlarA) Console.Write (n+" "); Console.WriteLine();
            Console.Write ("B sayý dizisi: "); foreach(var n in sayýlarB) Console.Write (n+" "); Console.WriteLine();
            var çiftler =
                from a in sayýlarA //Ýçiçe for-i --> for-j misali A'nýn her bir sayýsý B'nin baþtan sona tüm sayýlarýyla kýyaslanýr
                from b in sayýlarB
                where a < b
                select new {a, b};
            Console.Write ("a < b çiftleri: "); foreach (var çift in çiftler) Console.Write ("({0} < {1})  ", çift.a, çift.b); Console.WriteLine();

            Console.WriteLine ("\nHerbir müþterinin farklý kriterli sipariþ listeleri:");
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var sipariþler =
                from müþ in müþteriler
                from sip in müþ.Sipariþler
                where sip.SipariþAdedi < 500 // ">= 500" de denenebilir
                select new {müþ.MüþteriNo, sip.ÜrünNo, sip.ÜrünAdý, sip.SipariþAdedi};
            Console.WriteLine ("-->Herbir müþterinin 'SipariþAdedi < 500' olan sipariþleri:");
            foreach(var sip in sipariþler) Console.WriteLine (sip);
            Console.WriteLine ("-->'Ankara'lý herbir endeksli müþterinin sipariþ ürün no'larý:");
            DateTime SonTarih = DateTime.Now;
            var sipariþler2 =
                from müþ in müþteriler
                where müþ.Adresi == "Ankara"
                from sip in müþ.Sipariþler
                where sip.SipariþTarihi < SonTarih
                select new {müþ.ÞirketAdý, sip.SipariþTarihi};
            foreach(var sip in sipariþler2) Console.WriteLine (sip);
            Console.WriteLine ("-->Herbir 'Ankara'lý endeksli müþterinin sipariþ ürün no'larý:");
            var sipariþler3 =
                müþteriler.Where (müþ => müþ.Adresi == "Ankara")
                .SelectMany ((müþ, müþEndeks) => müþ.Sipariþler.Select (sip => "Müþteri#" + (müþEndeks + 1) + "'e ait ürün no: " + sip.ÜrünNo));
            foreach(var sip in sipariþler3) Console.WriteLine (sip);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}