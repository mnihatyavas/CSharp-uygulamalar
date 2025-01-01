// j2sc#2202h.cs: Take, Skip, TakeWhile, SkipWhile öncekiler-sonrakiler örneði.

using System;
using System.Linq; //Take için
using System.Collections.Generic; //IEnumerable<> için
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
    class Take_TakeWhile {
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
            Console.Write ("'dizi.Take(n)' dizinin ilk n elamanýný alýr. 'dizi.Skip(n)' dizinin ilk n elemanýný atlayýp, sona kalanlarý alýr. 'dizi.TakeWhile/SkipWhile' alma ve atlamaya lambda þartý uygular.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ýlk 3'ü al, ilk 4'ü atlayýp kalaný al, al/atlayý yýl<=1917+index þartlý yap:");
            int[] yýllar = {1881, 1914, 1918, 1919, 1920, 1923, 1930, 1938};
            Console.Write ("-->Tüm yýllar: "); foreach(var yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            IEnumerable<int> al3 = yýllar.Take (3);
            IEnumerable<int> atla4 = yýllar.Skip (4);
            var þartlýAl = yýllar.TakeWhile ((yýl, index) => yýl <= (1917+index));
            var þartlýAtla = yýllar.SkipWhile ((yýl, index) => yýl <= (1917+index));
            Console.Write ("-->yýllar.Take(3): "); foreach(var yýl in al3) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->yýllar.Skip(4): "); foreach(var yýl in atla4) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->yýllar.TakeWhile(yýl<=1917+index): "); foreach(var yýl in þartlýAl) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->yýllar.SkipWhile(yýl<=1917+index): "); foreach(var yýl in þartlýAtla) Console.Write (yýl+" "); Console.WriteLine();
   
            Console.WriteLine ("\nÝlk 5 peygamber ve krk'lerinin ardýþýk dizilimi:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.Write ("-->Tüm peygamberler: "); foreach(var pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            var al5=peygamberler.Take (5);
            Console.Write ("-->peygamberler.Take(5): "); foreach(var pey in al5) Console.Write (pey+" "); Console.WriteLine();
            IEnumerable<char> krk5 = peygamberler.Take (5).SelectMany (k => k.ToArray());
            Console.Write ("-->peygamberler.Take(5).SelectMany(k=>k.ToArray()): "); foreach(var k in krk5) Console.Write (k.ToString().ToLower()); Console.WriteLine();

            Console.WriteLine ("\nTüm Ankara'lý müþterilerin ilk ve son 3 sipariþ bilgileri:");
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var sorgu1 = (
                from m in müþteriler
                from s in m.Sipariþler
                where m.Adresi == "Ankara"
                select new {m.MüþteriNo, s.ÜrünNo, s.SipariþTarihi})
            .Take (3);
            Console.WriteLine ("-->Ankara'lý müþterilerin ilk/Take(3) 3 sipariþleri:");
            foreach (var sip in sorgu1) Console.WriteLine (sip);
            var sorgu2 = (
                from m in müþteriler
                from s in m.Sipariþler
                where m.Adresi == "Ankara"
                select new {m.MüþteriNo, s.ÜrünNo, s.SipariþTarihi})
            .Skip (11);
            Console.WriteLine ("-->Ankara'lý müþterilerin son/Skip(11) 3 sipariþleri:");
            foreach (var sip in sorgu2) Console.WriteLine (sip);

            Console.WriteLine ("\nTakeWhile ile sayýsal/dizgesel þartlý ilkil alýmlar:");            
            var önce1919 = yýllar.TakeWhile (y => y < 1919);
            var sonra1919 = yýllar.SkipWhile (y => y < 1919);
            IEnumerable<int> istisna1918 = yýllar.TakeWhile (y => y.CompareTo (1918) != 0);
            IEnumerable<string> uzun10_5 = peygamberler.TakeWhile ((p, i) => p.Length < 10 && i < 5);
            var atlaAl = peygamberler.SkipWhile (p => p != "Davut").TakeWhile (p => p != "Buda");
            Console.Write ("-->yýllar.TakeWhile(y=>y<1919): "); foreach(var yýl in önce1919) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->yýllar.SkipWhile(y=>y<1919): "); foreach(var yýl in sonra1919) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->yýllar.TakeWhile(y!=1918): "); foreach(var yýl in istisna1918) Console.Write (yýl+" "); Console.WriteLine();
            Console.Write ("-->peygamberler.TakeWhile(p.Length<10&&i<5): "); foreach(var pey in uzun10_5) Console.Write (pey+" "); Console.WriteLine();
            Console.Write ("-->peygamberler.Take/Skip-While('Davut'<=p<'Buda': "); foreach(var pey in atlaAl) Console.Write (pey+" "); Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}