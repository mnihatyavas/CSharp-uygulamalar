// j2sc#2202c.cs: Linq-Count, Min, Max, Distinct, Range, LongCount metotlarý örneði.

using System;
using System.Linq; // Count için
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
    class Dikdörtgen {
        public int en {get; set;}
        public int boy {get; set;}
        public override string ToString() {return string.Format ("(En, Boy= = ({0}, {1})", en, boy);}
    }
    class Count_Long {
        static List<Müþteri> MüþteriListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 12});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 23});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 8});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 14});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 58});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 123});
            ürünListesi.Add (new Ürün {ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 200, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 243});
            List<Müþteri> müþteriListesi = new List<Müþteri>();
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Abdulkerim Ltd", Adresi = "Rize", Sipariþler = ürünListesi, MüþteriNo = 10});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Ziyadede AÞ", Adresi = "Kayseri", Sipariþler = ürünListesi, MüþteriNo = 4});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Pýnarbaþý Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 25});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Billiruye AÞ", Adresi = "Zonguldak", Sipariþler = ürünListesi, MüþteriNo = 93});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Þemseddinpaþa AÞ", Adresi = "Kars", Sipariþler = ürünListesi, MüþteriNo = 64});
            müþteriListesi.Add (new Müþteri {ÞirketAdý = "Keçiören Ltd", Adresi = "Ankara", Sipariþler = ürünListesi, MüþteriNo = 164});
            return müþteriListesi;
        }
        static void listeyiGöster1<T>(IEnumerable<T> liste) {foreach (var ölçü in liste) {Console.WriteLine (ölçü);}}
        static void listeyiGöster2<T>(IEnumerable<T> liste) {foreach (var ölçü in liste) {Console.Write (ölçü+" ");} Console.WriteLine();}
        static void Main() {
            Console.Write ("Linq'in dizi.Count()/Min()/Max()/Distinct()/Range()/LongCount metotlarý.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Linq-Count() metoduyla tüm ve lambda sorgulu peygamber sayýlarý:");
            string[] peygamberler = {"Nuh", "Ýbrahim", "Musa", "Davut", "Süleyman", "Ýsa", "Muhammed", "Buda", "Konfiçyus", "Zerdüþt"};
            Console.Write ("Peygamberler dizisi: "); foreach (string pey in peygamberler) Console.Write (pey+" "); Console.WriteLine();
            int sayý = peygamberler.Count(); Console.WriteLine ("Dizideki peygamber sayýsý: " + sayý);
            sayý = peygamberler.Count (p => p.StartsWith ("M")); Console.WriteLine ("'M'yle baþlayan peygamber sayýsý: " + sayý);

            Console.WriteLine ("\nLinq-yýllar.Count(), yýllar.Min() ve yýllar.Max():");
            int i, ts;
            int[] yýllar = new int [1939-1881];
            for(i=0;i<yýllar.Length;i++) yýllar [i]=i+1881;
            Console.Write ("Ardýþýk yýllar dizisi: "); foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("Toplam yýl sayýsý: " + yýllar.Count());
            Console.WriteLine ("Yýl(enküçük, enbüyük) = ({0}, {1})", yýllar.Min(), yýllar.Max());
              
            Console.WriteLine ("\nRasgele yýllarýn tüm, yegane, tek/çift yýl sayýlarý:");
            var r=new Random();
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i]=ts;} Array.Sort (yýllar);
            Console.Write ("Rasgele yýllar dizisi: "); foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("Tüm yýlar sayýsý: " + yýllar.Count());
            Console.WriteLine ("Yegane yýlar sayýsý: " + yýllar.Distinct().Count());
            Console.WriteLine ("Sayý(tekyýllar, çiftyýllar) = ({0}, {1})", yýllar.Count (n => n % 2 == 1), yýllar.Count (n => n % 2 == 0));

            Console.WriteLine ("\nListedeki herbir müþterinin verdiði sipariþ sayýlarýnýn sorgulanmasý:");
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var sipariþSayýSorgusu = from müþ in müþteriler
                orderby müþ.MüþteriNo
                select new {müþ.MüþteriNo, sipariþSayýsý = müþ.Sipariþler.Count()};
            foreach (var sip in sipariþSayýSorgusu) Console.WriteLine (sip);

            Console.WriteLine ("\nRasgele 100.000 sayýnýn her 10.000 barem adedi ve ortalamasý 10.000 civarýdýr:");
            int[] sayýlar = new int [100000];
            for(i = 0; i < 100000; i++) sayýlar [i] = r.Next(0,100000);
            IEnumerable<int> sayýSorgusu=null; ts=0;
            for(i=0;i<100000;i+=10000) {
                sayýSorgusu = from n in sayýlar where n > i & n <= i+10000 select n;
                Console.WriteLine ("Sayý({0} < n <= {1}) = {2}", i, i+10000, sayýSorgusu.Count());
                ts+=sayýSorgusu.Count();
            }
            Console.WriteLine ("10 sorgu sayýsýnýn ortalamasý = " + ts/10d);

            Console.WriteLine ("\nRasgele dikdörtgen(en,boy) sayýlarý ve Range (1881,58):");
            int ts2, ts3=r.Next(2,10);
            List<Dikdörtgen> ölçüler = new List<Dikdörtgen>();
            for(i=0;i<ts3;i++) {
                ts=r.Next(1,100); ts2=r.Next(1,100);
                ölçüler.Add (new Dikdörtgen {boy = ts, en = ts2});
            }
            listeyiGöster1 (ölçüler);
            Console.WriteLine ("Dikdörtgen sayýsý: {0}", ölçüler.Count());
            var seneler = Enumerable.Range (1881, 58);
            listeyiGöster2 (seneler);
            Console.WriteLine ("Senelerin sayýsý: {0}\tÇift sene sayýsý: {1}", seneler.Count(), seneler.Count (n => n % 2 == 0));

            Console.WriteLine ("\nÇok bekleten 'long Range(0,int.MaxValue).Concat(0,int.MaxValue)' sayýsý (4.294.967.294):");
/*            long adet = Enumerable.Range (0, int.MaxValue).Concat (Enumerable.Range (0, int.MaxValue)).LongCount(); Console.WriteLine ("2 kat Range(0,int.MaxValue) sayýsý: {0:#,0}", adet);
            //adet = Enumerable.Range (0, int.MaxValue).Concat (Enumerable.Range (0, int.MaxValue)).LongCount (n => n > 1 && n < 4); Console.WriteLine (adet);
*/
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}