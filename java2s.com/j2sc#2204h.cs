// j2sc#2204h.cs: Gruplama, 'group a into b' veya 'a.GroupBy/GroupJoin' örneði.

using System;
using System.Linq; //Select için
//using System.Collections; //ArrayList için
using System.Collections.Generic; //IEqualityComparer<> için
namespace Query_Sorgu {
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
    class Group_By_Join {
        public class Kýyascý: IEqualityComparer<string> {
            public bool Equals (string x, string y) {return dizgeyiAl (x) == dizgeyiAl (y);}
            public int GetHashCode (string ns) {return dizgeyiAl (ns).GetHashCode();}
            private string dizgeyiAl (string dizge) {
                char[] krk = dizge.ToCharArray();
                Array.Sort<char> (krk);
                return new string (krk);
            }
        }
        static List<Müþteri> MüþteriListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünNo = 1881, ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1500, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1914, ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 130, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1919, ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 680, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1920, ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 700, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1923, ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, SipariþAdedi = 1600, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1930, ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 290, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1938, ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 290, SipariþTarihi = new DateTime (2025, 01, 16, 06, 32, 52)});
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
            Console.Write ("'group by a into gr' yada 'a.GroupBy()' ayný a verileri birleþik gruplandýrýr. 'a.GroupJoin(b)' ise 2 ayrý veriyi ortak anahtarla birleþtirip, gruplandýrýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Arþiv tamsayý metot gruplarý ve grup içi metotlar:");
            var sorgu1a = from m in typeof (int).GetMethods()
                select m.Name;
            Console.WriteLine ("-->Tüm {0} adet (int)Metot adlarý: ", sorgu1a.Count());
            foreach(var m in sorgu1a) Console.WriteLine (m);
            var sorgu1b = from m in typeof(int).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key};
            Console.WriteLine ("-->Tüm {0} adet (int)Metot gruplarý: ", sorgu1b.Count());
            foreach(var m in sorgu1b) Console.WriteLine (m);
            var sorgu1c = from m in typeof(int).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key, Metotlar = gr};
            Console.WriteLine ("-->Tüm {0} adet (int)Metot gruplarý: ", sorgu1c.Count());
            foreach(var g in sorgu1c) {
                Console.WriteLine ("\t{0} adlý metot grubu", g.Ad);
                foreach (var m in g.Metotlar) Console.WriteLine (m);
            }
            var sorgu1d = from m in typeof (double).GetMethods()
                group m by m.Name into gr
                select new {Ad = gr.Key, Adet = gr.Count()};
            Console.WriteLine ("-->Tüm {0} adet (double)Metot adlarý: ", sorgu1d.Count());
            foreach(var m in sorgu1d) Console.WriteLine (m);


            Console.WriteLine ("\nPeygamberlerin uzunluk gruplarý ve grup içi peygamberler:");
            string[] peygamberler = {"Adem", "Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Zerdüþt", "Buda", "Brahman", "Konfiçyus"};
            var sorgu2a = from p in peygamberler
                orderby p ascending
                group p by p.Length into uzgr
                orderby uzgr.Key descending
                select new {Uzunluk = uzgr.Key, Peygamberler = uzgr};
            Console.WriteLine ("-->Tüm {0} adet azalan uzunluk gruplarý: ", sorgu2a.Count());
            foreach (var g in sorgu2a) {
                Console.WriteLine ("Grup içi artan peygamberlerin uzunluðu: {0}", g.Uzunluk);
                foreach (string p in g.Peygamberler)
                Console.WriteLine ("  " + p);
            }
            var sorgu2b = from p in peygamberler
                orderby p descending
                group p by p.Length into uzgr
                orderby uzgr.Key ascending
                select new {Uzunluk = uzgr.Key, Peygamberler = uzgr};
            Console.WriteLine ("-->Tüm {0} adet artan uzunluk gruplarý: ", sorgu2b.Count());
            foreach (var g in sorgu2b) {
                Console.WriteLine ("Grup içi azalan peygamberlerin uzunluðu: {0}", g.Uzunluk);
                foreach (string p in g.Peygamberler)
                Console.WriteLine ("  " + p);
            }
            var sorgu2c = from p in peygamberler
                orderby p descending
                group p by p.Substring (0, 1) into gr
                orderby gr.Key
                select gr;
            Console.WriteLine ("-->Tüm {0} adet artan ilkharf gruplarý ve azalan peygamberler: ", sorgu2c.Count());
            foreach (var g in sorgu2c) {
                Console.WriteLine ("Ýlkharf: " + g.Key);
                foreach (String p in g) Console.WriteLine ("\t" + p);
            }
            var sorgu2d = from p in peygamberler
                orderby p ascending
                group p by p.Substring (0, 1) into gr
                orderby gr.Key descending
                select gr;
            Console.WriteLine ("-->Tüm {0} adet azalan ilkharf gruplarý ve artan peygamberler: ", sorgu2d.Count());
            foreach (var g in sorgu2d) {
                Console.WriteLine ("Ýlkharf: " + g.Key);
                foreach (String p in g) Console.WriteLine ("\t" + p);
            }
            string[] anagramlar = {"  kelam ", "yavaþ", "from ", " salt", " earn ", "kafana  ", " last ", "savaþ ", "kalem ", " anafak", " near ", " form ", " nafaka   ", " anakaf  "};
            var sorgu2e = anagramlar.GroupBy (//Ayný harflerle farklý kelime dizilimleri
                p => p.Trim(),
                p => p.ToUpper(),
                new Kýyascý()).Select (a=>a);
            Console.Write ("-->Tüm {0} adet kelimelerden {1} anagramik farklýlarý: ", anagramlar.Length, sorgu2d.Count());
            foreach (var a in sorgu2e) Console.Write (a.Key+" "); Console.WriteLine();

            Console.WriteLine ("\nÞirketler ve sipariþ detaylarý sorgusu:");
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var sorgu3a = 
                from m in müþteriler
                select new {
                    m.ÞirketAdý,
                    YýlGruplarý =
                        from s in m.Sipariþler
                        group s by s.SipariþTarihi.Year into yg
                        select new {
                            Yýl = yg.Key,
                            AyGruplarý =
                                from s in yg
                                group s by s.SipariþTarihi.Month into mg
                                select new {Ay = mg.Key, Sipariþler = mg}}};
            Console.WriteLine ("-->Tüm {0} adet þirket gruplarý ve sipariþ detaylarý: ", sorgu3a.Count());
            foreach (var þ in sorgu3a) {
                Console.WriteLine ("  Þirket adý: " + þ.ÞirketAdý);
                foreach (var y in þ.YýlGruplarý) {
                    Console.Write ("    Sipariþ tarihi: " + y.Yýl);
                    foreach (var a in y.AyGruplarý) {
                        Console.Write ("/"+a.Ay+"\n    Sipariþler ad ve adetleri: ");
                        foreach (var s in a.Sipariþler) Console.Write (s.ÜrünAdý+":"+s.SipariþAdedi+" "); Console.WriteLine();}}};
            List<Ürün> ürünler = ÜrünListesiniAl();
            var sorgu3b =
                from ü in ürünler
                group ü by ü.Katagori into g
                select new {Katagori = g.Key, Ürünler = g};
            Console.WriteLine ("-->Tüm {0} adet ürün katagori grup ve detaylarý: ", sorgu3b.Count());
            foreach (var k in sorgu3b) {
                Console.WriteLine (k.Katagori);
                foreach (var ü in k.Ürünler) Console.WriteLine ("  Ürün adý: {0}, Birim fiyatý: {1:#,0} TL", ü.ÜrünAdý, ü.BirimFiyat);
            }

            Console.WriteLine ("\nEnumerable.Range(1881,58) % 5 ve 10 kalanlý yýl gruplamasý:");
            var sorgu4a = from yýl in Enumerable.Range (1881, 58)
                group yýl by yýl % 5 into g
                select new {Kalan = g.Key, Yýllar = g};
            Console.WriteLine ("-->Tüm {0} adet [1881:1938]%5 kalanlý gruplama: ", sorgu4a.Count());
            foreach (var g in sorgu4a) {
                Console.Write ("  Yýl%5={0} yýllar: ", g.Kalan);
                foreach (var y in g.Yýllar) Console.Write (y+" "); Console.WriteLine();
            }
            var sorgu4b = from yýl in Enumerable.Range (1881, 58)
                group yýl by yýl % 10 into g
                select new {Kalan = g.Key, Yýllar = g};
            Console.WriteLine ("-->Tüm {0} adet [1881:1938]%5 kalanlý gruplama: ", sorgu4b.Count());
            foreach (var g in sorgu4b) {
                Console.Write ("\tYýl%10 kalaný = {0} olan yýllar: ", g.Kalan);
                foreach (var y in g.Yýllar) Console.Write (y+" "); Console.WriteLine();
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}