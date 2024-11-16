// j2sc#2202a.cs: Ling from-select sorgularýnýn foreach'le sunumu örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Linq; //Where için
using System.Collections; //ArrayList için
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
    class Araba {
        public string ÞoförAdý;
        public string Markasý;
        public string Rengi;
        public int AktüelHýzý;
        public override string ToString() {return string.Format ("Marka={0}, Renk={1}, Þuanki hýzý={2}, Sürücü adý={3}", Markasý, Rengi, AktüelHýzý, ÞoförAdý);
        }
    }
    public class Fihrist {
        public string Ad {get; set;}
        public string Soyad {get; set;}
        public string Eposta {get; set;}
        public override string ToString() {return string.Format ("Ýsim: [{0} {1}]\tEposta: [{2}]", Ad, Soyad, Eposta);}
    }
    class Foreach {
        static List<Müþteri> MüþteriListesiniAl() {
        List<Ürün> ürünListesi = new List<Ürün>();
        ürünListesi.Add (new Ürün {ÜrünAdý = "Kalem", Katagori = "Kýrtasite", BirimFiyat = 43, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 12});
        ürünListesi.Add (new Ürün {ÜrünAdý = "Defter", Katagori = "Kýrtasite", BirimFiyat = 452, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 23});
        ürünListesi.Add (new Ürün {ÜrünAdý = "Silgi", Katagori = "Kýrtasite", BirimFiyat = 25, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 8});
        ürünListesi.Add (new Ürün {ÜrünAdý = "Cetvel", Katagori = "Kýrtasite", BirimFiyat = 112, SipariþAdedi = 1000, SipariþTarihi = new DateTime (2024, 11, 06, 01, 34, 45), ÜrünNo = 14});
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
        static void Main() {
            Console.Write ("Liste veya dizi içi sorgular 'var' veya IEnumerable<T> referanslý from-where-orderby-select'le yapýlýp sonuçlar foreach'le dökümlenir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tüm farklý þehir müþteri firmalar üreticiye faraza ayný sipariþi versin:");
            List<Müþteri> müþteriler = MüþteriListesiniAl();
            var müþteriSorgusu = from müþ in müþteriler
                where müþ.Adresi == "Ankara"
                select müþ;
            foreach (var müþ in müþteriSorgusu) {
                Console.WriteLine ("Müþteri [{0}: {1} - {2}]", müþ.MüþteriNo, müþ.ÞirketAdý, müþ.Adresi);
                foreach (var sipariþ in müþ.Sipariþler) Console.WriteLine ("\tSipariþ [{0}: {1}]", sipariþ.ÜrünNo, sipariþ.ÜrünAdý, sipariþ.SipariþTarihi);
            }

            Console.WriteLine ("\nForeach-var'la aylarýn sorgulu ve sýralý dökümleri:");
            string[] aylar = {"Ocak", "Þubat", "Mart", "Nisan","Mayýs", "Haziran", "Temmuz", "Aðustos", "Eylül", "Ekim","Kasým", "Aralýk"};
            var aySorgusu = from ay in aylar where ay.Length > 5 orderby ay select ay;
            Console.WriteLine ("-->Ay.Length > 5 aylarýn artan sýralýlarý:");
            foreach (var ay in aySorgusu) Console.Write (ay+" "); Console.WriteLine();
            aySorgusu = from ay in aylar where ay.Length <= 5 orderby ay select ay;
            Console.WriteLine ("-->Ay.Length <= 5 aylarýn artan sýralýlarý:");
            foreach (var ay in aySorgusu) Console.Write (ay+" "); Console.WriteLine();

            Console.WriteLine ("\nSürücülerin aktüel radarla araba sürüþ hýzlarýnýn tespiti:");
            ArrayList arabalar = new ArrayList();  
            arabalar.Add (new Araba {ÞoförAdý = "Sevim", Rengi = "Beyaz", AktüelHýzý = 160, Markasý = "BMW"});
            arabalar.Add (new Araba {ÞoförAdý = "Canan", Rengi = "Yeþil", AktüelHýzý = 95, Markasý = "Wolvo"});
            arabalar.Add (new Araba {ÞoförAdý = "Belkýs", Rengi = "Mavi", AktüelHýzý = 68, Markasý = "Ford"});
            IEnumerable<Araba> arabalarEnum = arabalar.OfType<Araba>();
            var arabaSorgusu = from araba in arabalarEnum where araba.AktüelHýzý > 90 select araba;
            foreach (var oto in arabaSorgusu) Console.WriteLine ("{0}, {1}-{2} arabasýný hýzlý (>90) sürüyor!", oto.ÞoförAdý, oto.Rengi, oto.Markasý);
            arabaSorgusu = from araba in arabalarEnum where araba.AktüelHýzý <= 90 select araba;
            foreach (var oto in arabaSorgusu) Console.WriteLine ("{0}, {1}-{2} arabasýný normal (<=90) sürüyor.", oto.ÞoförAdý, oto.Rengi, oto.Markasý);

            Console.WriteLine ("\nÜst örneðin ArrayList yerine Araba[] dizili benzeri:");
            Araba[] arabalar2 = new []{
                new Araba {ÞoförAdý = "Sevim", Rengi = "Beyaz", AktüelHýzý = 160, Markasý = "BMW"},
                new Araba {ÞoförAdý = "Belkýs", Rengi = "Mavi", AktüelHýzý = 138, Markasý = "Ford"},
                new Araba {ÞoförAdý = "Canan", Rengi = "Yeþil", AktüelHýzý = 95, Markasý = "Wolvo"}
            };
            var arabaSorgusu2 = from araba in arabalar2 where araba.AktüelHýzý > 90 orderby araba.ÞoförAdý descending select araba;
            Console.WriteLine ("-->AktüelHýzý > 90 azalan ad sýrada:");
            foreach (Araba oto in arabaSorgusu2) Console.WriteLine (oto);
            arabaSorgusu2 = from araba in arabalar2 where araba.AktüelHýzý > 100 orderby araba.ÞoförAdý select araba;
            Console.WriteLine ("-->AktüelHýzý > 100 aran ad sýrada:");
            foreach (Araba oto in arabaSorgusu2) Console.WriteLine (oto);

            Console.WriteLine ("\nAdlarýn >M ve <=M kýstaslý artan sýralý seçili dökümleri:");
            string[] adlar = {"Fatma", "Bekir", "Haným", "Memet", "Hatice", "Süheyla", "Zeliha", "Nihat", "Songül", "Nedim", "Sevim"};
            IEnumerable<string> adSorgusu = from ad in adlar where (byte)ad[0] > 77 orderby ad select ad;
            Console.Write ("Artan sýralý ad[0] > \"M\": ");
            foreach (var ad in adSorgusu) Console.Write (ad+" "); Console.WriteLine();
            adSorgusu = from ad in adlar where (byte)ad[0] <= 77 orderby ad select ad;
            Console.Write ("Artan sýralý ad[0] <= \"M\": ");
            foreach (var ad in adSorgusu) Console.Write (ad+" "); Console.WriteLine();

            Console.WriteLine ("\nRasgele 20 yýlý ortancadan küçük/büyük artan sýralý seçili dökme:");
            int[] yýllar = new int[20]; int i, ts; var r=new Random();
            for(i=0;i<20;i++) {ts=r.Next(1881,1939); yýllar [i]=ts;}
            var yýlSorgusu = from yýl in yýllar where yýl < (1881+1938)/2 orderby yýl select yýl;
            Console.Write ("+Sýralý yýl < 1909: ");
            foreach(var yýl in yýlSorgusu) Console.Write (yýl+" "); Console.WriteLine();
            yýlSorgusu = from yýl in yýllar where yýl >= (1881+1938)/2 orderby yýl descending select yýl;
            Console.Write ("-Sýralý yýl >= 1909: ");
            foreach(var yýl in yýlSorgusu) Console.Write (yýl+" "); Console.WriteLine();
            Console.WriteLine ("yýlSorgusu'nun tip adý: [{0}]", yýlSorgusu.GetType().Name);
            Console.WriteLine ("yýlSorgusu'nun tip kurgusu: [{0}]", yýlSorgusu.GetType().Assembly);

            Console.WriteLine ("\nSoysal List<Fihrist> içinde ad ve ad.Length'e göre azalan/artan sorgular:");
            List<Fihrist> kiþiler = new List<Fihrist>{
                new Fihrist {Ad = "Hüseyin", Soyad = "Kurt", Eposta = "hkurt@gmail.com"},
                new Fihrist {Ad = "Fatih", Soyad = "Kaplan", Eposta = "fkaplan@gmail.com"},
                new Fihrist {Ad = "Selim", Soyad = "Dikel", Eposta = "sdikel@gmail.com"},
                new Fihrist {Ad = "Hülya", Soyad = "Piray", Eposta = "hpiray@gmail.com"},
                new Fihrist {Ad = "Özgür", Soyad = "Aslan", Eposta = "oaslan@gmail.com"},
                new Fihrist {Ad = "Ali", Soyad = "Eralp", Eposta = "aeralp@gmail.com"},
                new Fihrist {Ad = "Özgür", Soyad = "Özel", Eposta = "oozel@gmail.com"}
            };
            IEnumerable<Fihrist> kiþiSorgusu = from kiþi in kiþiler where kiþi.Ad == "Özgür" orderby kiþi.Soyad descending select kiþi;
            Console.WriteLine ("-->Ad == \"Özgür\" azalan soyad sorgu:");
            foreach (Fihrist kiþi in kiþiSorgusu) Console.WriteLine (kiþi);
            kiþiSorgusu = from kiþi in kiþiler where kiþi.Ad.Length < 6 orderby kiþi.Soyad select kiþi;
            Console.WriteLine ("-->AdLength < 6 artan soyad sorgu:");
            foreach (Fihrist kiþi in kiþiSorgusu) Console.WriteLine (kiþi);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}