// j2sc#2202n.cs: Yegane Distinct ve sayýsal toplam Sum metotlarý örneði.

using System;
using System.Linq; //Distinct() için
using System.Collections.Generic; //List<> için
using System.Collections; //ArrayList iiçin
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
    public class Ýþçi {
        public int yýl;
        public string ad;
        public string soyad;
        public static ArrayList ÝþçiListesiniAl() {
            ArrayList liste = new ArrayList();
            liste.Add (new Ýþçi {yýl = 1891, ad = "Fatma", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1899, ad = "Bekir", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1931, ad = "Haným", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1934, ad = "Memet", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1951, ad = "Hatice", soyad = "Kaçar"});
            liste.Add (new Ýþçi {yýl = 1953, ad = "Süheyla", soyad = "Özbay"});
            liste.Add (new Ýþçi {yýl = 1955, ad = "Zeliha", soyad = "Candan"});
            liste.Add (new Ýþçi {yýl = 1957, ad = "M.Nihat", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1959, ad = "Songül", soyad = "Gökyiðit"});
            liste.Add (new Ýþçi {yýl = 1961, ad = "M.Nedim", soyad = "Yavaþ"});
            liste.Add (new Ýþçi {yýl = 1963, ad = "Sevim", soyad = "Yavaþ"});
            return (liste);
        }
        public static Ýþçi[] ÝþListeAl() {return ((Ýþçi[])ÝþçiListesiniAl().ToArray (typeof(Ýþçi)));}
    }
    public class Maaþ {
        public int yýl;
        public decimal maaþ;
        public static ArrayList MaaþListesiniAl() {
            Random r=new Random(); decimal dc;
            ArrayList liste = new ArrayList();
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1891, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1899, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1931, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1934, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1951, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1953, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1955, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1957, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1959, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1961, maaþ=dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; liste.Add (new Maaþ {yýl = 1963, maaþ=dc});
            return (liste);
        }
        public static Maaþ[] MListeAl() {return ((Maaþ[])MaaþListesiniAl().ToArray (typeof(Maaþ)));}
    }
    public class Düzen<Düðüm>: IEnumerable<Düðüm> where Düðüm: IComparable<Düðüm>{
        public Düðüm Veri {get; set;}
        public Düzen<Düðüm> Sola {get; set;}
        public Düzen<Düðüm> Saða {get; set;}
        public Düzen (Düðüm deðer) {this.Veri = deðer; this.Sola = null; this.Saða = null;} //Kurucu
        public void Sok (Düðüm þu) {
            Düðüm aktüel = this.Veri;
            if (aktüel.CompareTo (þu) > 0) {
                if (this.Sola == null) {this.Sola = new Düzen<Düðüm>(þu);
                }else {this.Sola.Sok (þu);}
            }else {
                if (this.Saða == null) { this.Saða = new Düzen<Düðüm>(þu);
                }else {this.Saða.Sok (þu);}
            }
        }
        public void Dolaþ() {
            if (this.Sola != null) {this.Sola.Dolaþ();}
            Console.WriteLine (this.Veri.ToString());
            if (this.Saða != null) {this.Saða.Dolaþ();}
        }
        IEnumerator<Düðüm> IEnumerable<Düðüm>.GetEnumerator() {
            if (this.Sola != null) {foreach (Düðüm birim in this.Sola) {yield return birim;}}
            yield return this.Veri;
            if (this.Saða != null) {foreach (Düðüm birim in this.Saða) {yield return birim;}}
        }
        IEnumerator IEnumerable.GetEnumerator() {throw new NotImplementedException();}
    }
    class Ýþçi2: IComparable<Ýþçi2> {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public string Branþ {get; set;}
        public int No {get; set;}
        public decimal Aylýk {get; set;}
        public override string ToString() {return String.Format ("No: {0}, Ýsim: {1} {2}, Branþ: {3}, Maaþ: {4:#,0.00} TL", this.No, this.Ad, this.Soyad, this.Branþ, this.Aylýk);}
        int IComparable<Ýþçi2>.CompareTo (Ýþçi2 þu) {
            if (þu == null) return 1;
            if (this.Aylýk > þu.Aylýk) return 1;
            if (this.Aylýk < þu.Aylýk) return -1;
            return 0;
        }
    }
    class Distinct_Sum {
        static List<Ürün> ÜrünListesiniAl() {
            List<Ürün> ürünListesi = new List<Ürün>();
            ürünListesi.Add (new Ürün {ÜrünNo = 1881, ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1500, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1914, ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 130, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1919, ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 680, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1920, ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 700, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1923, ÜrünAdý = "Kitap", Katagori = "Kýrtasite", BirimFiyat = 257, SipariþAdedi = 1600, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1930, ÜrünAdý = "Çanta", Katagori = "Valiz", BirimFiyat = 1235, SipariþAdedi = 290, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            ürünListesi.Add (new Ürün {ÜrünNo = 1938, ÜrünAdý = "Forma", Katagori = "Giysi", BirimFiyat = 2368, SipariþAdedi = 285, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45)});
            return ürünListesi;
        }
        static void Main() {
            Console.Write ("'dizi.Distinct()' dizi elemanlarýnýn tekrarsýz yeganelerini süzer. 'dizi.Sum()' sayýsal dizi elemanlarýnýn toplamýný verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("50 adet rasgele yýllar, yeganeleri, seçimli sorgu ve toplamlarý:");
            int i, ts; var r=new Random();
            int[] yýllar = new int[50];
            for(i=0;i<yýllar.Length;i++) {ts=r.Next(1881,1939); yýllar [i] = ts;}
            Console.Write ("-->Tüm rasgele {0} adet yýllar: ", yýllar.Length);
            foreach (int yýl in yýllar) Console.Write (yýl+" "); Console.WriteLine();
            var yegane1 = yýllar.Distinct();
            Console.Write ("-->Yegane {0} yýl: ", yegane1.Count());
            foreach (var yýl in yegane1) Console.Write (yýl+ " "); Console.WriteLine();
            Console.WriteLine ("-->Rasgele {0} yýlýn toplamý: {1},\tOrtalamasý: {2}", yýllar.Length, yýllar.Sum(), yýllar.Sum() / yýllar.Length);
            ts=r.Next(0,yýllar.Length);
            var sorgu1 = (from yýl in yýllar where yýl > yýllar [ts] select yýl).Distinct();
            Console.Write ("-->{0}'den büyük {1} adet yegane yýllar: ", yýllar [ts], sorgu1.Count());
            foreach (int yýl in sorgu1) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("-->Seçili yýllarýn toplamý: {0},\tOrtalamasý: {1}", sorgu1.Sum(), sorgu1.Sum() / sorgu1.Count());

            Console.WriteLine ("\nÜrünleri, yegane katagorileri, toplam fatura tutarýný sunma:");
            List<Ürün> ürünler = ÜrünListesiniAl();
            Console.WriteLine ("-->Tüm {0} adet ürünler (no, ad, katagori, birimFiyat, sipariþAdedi): ", ürünler.Count());
            foreach (var ü in ürünler) Console.WriteLine ("({0}, {1}, {2}, {3}, {4})", ü.ÜrünNo, ü.ÜrünAdý, ü.Katagori, ü.BirimFiyat, ü.SipariþAdedi);
            var sorgu2 = (from ürn in ürünler select ürn.Katagori).Distinct();
            Console.Write ("-->Yegane katagori adlarý: ");
            foreach (var ad in sorgu2) Console.Write (ad+" "); Console.WriteLine();
            Console.WriteLine ("-->Yegane katagori adlarýnýn uzunluðu: {0}", sorgu2.Sum (ad => ad.Length));
            var sorgu3 =
                from ü in ürünler
                group ü by ü.Katagori into gr
                select new {Katagori = gr.Key, ToplamSipariþ = gr.Sum (ü => ü.SipariþAdedi)};
            foreach (var sip in sorgu3) Console.WriteLine (sip);
            var sorgu4 = from ü in ürünler select ü.BirimFiyat * ü.SipariþAdedi;
            Console.WriteLine ("-->Toplam(BirimFiyat * SipariþAdedi) fatura tutarý: {0:#,0.00} TL", sorgu4.Sum());

            Console.WriteLine ("\nÝþçi ve Maaþ liste birleþimi, maaþ toplamý, yegane soyadlar:");
            Ýþçi[] iþçiler = Ýþçi.ÝþListeAl();
            Maaþ[] maaþlar = Maaþ.MListeAl();
            var sorgu5 = from iþ in iþçiler
                join m in maaþlar on iþ.yýl equals m.yýl
                select new {no=iþ.yýl, ad=iþ.ad, soyad=iþ.soyad, maaþ=m.maaþ};
            Console.WriteLine ("-->Tüm {0} adet iþçiler ve maaþlarý:", sorgu5.Count());
            foreach (var im in sorgu5) Console.WriteLine (im);
            Console.WriteLine ("-->Maaþlarýn toplamý: {0:#,0.00} TL\tOrtalamasý: {1:#,0.00} TL", sorgu5.Sum (m=>m.maaþ), sorgu5.Sum (m=>m.maaþ) / sorgu5.Count());
            Console.Write ("-->Yegane soyadlar: "); foreach (var sa in (from iþ in iþçiler select iþ.soyad).Distinct()) Console.Write (sa+" "); Console.WriteLine();

            Console.WriteLine ("\nÇeþitli branþlý personel listesi, yegane branþlar, maaþlar toplamý ve ortalamasý:");
            decimal dc; dc=r.Next(10000,150000)+r.Next(10,100)/100m;
            Düzen<Ýþçi2> personel = new Düzen<Ýþçi2>(new Ýþçi2 {No = 1975, Ad = "Canan", Soyad = "Candan", Branþ = "Ziraat", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1951, Branþ = "Muhasebe", Soyad = "Kaçar", Ad = "Hatice", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1953, Branþ = "Vardiya", Soyad = "Özbay", Ad = "Süheyla", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1955, Branþ = "Aþçý", Soyad = "Candan", Ad = "Zeliha", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1957, Branþ = "Vardiya", Soyad = "Yavaþ", Ad = "M.Nihat", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1959, Branþ = "Eðitim", Soyad = "Gökyiðit", Ad = "Songül", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1961, Branþ = "Satýþ", Soyad = "Yavaþ", Ad = "M.Nedim", Aylýk = dc});
            dc=r.Next(10000,150000)+r.Next(10,100)/100m; personel.Sok (new Ýþçi2 {No = 1963, Branþ = "Ýnþaat", Soyad = "Yavaþ", Ad = "Sevim", Aylýk = dc});
            Console.WriteLine ("-->Tüm {0} kiþilik artan-maaþlý personel listesi:", personel.Count()); foreach (var p in personel) Console.WriteLine (p);
            var sorgu6 = (from b in personel select b.Branþ).Distinct();
            Console.Write ("-->Yegane {0} departman: ", sorgu6.Count()); foreach (var b in sorgu6) Console.Write (b+" "); Console.WriteLine();
            Console.WriteLine ("-->Maaþlarýn toplamý: {0:#,0.00} TL\tOrtalamasý: {1:#,0.00} TL", personel.Sum (m=>m.Aylýk), personel.Sum (m=>m.Aylýk) / personel.Count());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}