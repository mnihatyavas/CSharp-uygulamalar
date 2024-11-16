// j2sc#2201a.cs: 'Var' anonim tip ve from-select sorgular örneði.

using System;
using System.Collections.Generic; //List<> için
using System.Diagnostics; //Process için
using System.Linq; //from-select için
using System.Collections; //ArrayList için
namespace AnonimTip {
    class SýnýfA {
        public Int32 No32 {get; set;}
        public Int64 No64 {get; set;}
        public String Ad {get; set;}
    }
    public class SýnýfB1 {
        private string ad, soyad;
        private decimal maaþ;
        public String Ad {get {return ad;} set {ad = value;}}
        public String Soyad {get {return soyad;} set {soyad = value;}}
        public decimal Maaþ {get {return maaþ;} set {maaþ = value;}}
    }
    public class SýnýfB2 {
        public String Ad {get; set;}
        public String Soyad {get; set;}
        public Decimal Maaþ {get; set;}
    }
    public struct Adres {
         public String isim;
         public String þirket; //Ev adreste þirket ihmal edilebilir
         public String adres1;
         public String adres2;
         public String þehir;
         public String ilçe;
         public int pk;
    }
    class Var_1 {
        static void Main() {
            Console.Write ("Anonim tip 'var' Main() metotta tüm ilkel tip, sýnýf, (soysal) liste referansý olarak kullanýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bellekte elan aktif tüm süreçlerin ad, ipNo, iþNo detaylarý:");
            var süreç = new List<SýnýfA>();
            foreach (var srç in Process.GetProcesses()) {
                var veri = new SýnýfA();
                veri.No32 = srç.Id;
                veri.Ad = srç.ProcessName;
                veri.No64 = srç.WorkingSet64;
                süreç.Add (veri);
        }
        Console.WriteLine (süreç);
        foreach(var srç in süreç) Console.WriteLine ("Ad: {0}\tSicimNo: {1}\tÝþNo: {2}", srç.Ad, srç.No32, srç.No64);

            Console.WriteLine ("\nAnonim 'var' tipli new tiplemeli kiþi özellikleri atfetme:");
            var kiþi1 = new {Ýsim = "M.Nihat Yavaþ", Yaþ = 2024-1957, Meslek = "Emekli"};
            var kiþi2 = new {Ýsim = "Atilla Göktürk", Yaþ = 2024-1985, Meslek = "Doktor"};
            var kiþi3 = new {Ýsim = "Hilal Göktürk", Yaþ = 2024-1982, Meslek = "Doktor"};
            Console.WriteLine ("{0} {1}, elan {2} yaþýndadýr.", kiþi1.Meslek, kiþi1.Ýsim, kiþi1.Yaþ);
            Console.WriteLine ("{0} {1}, elan {2} yaþýndadýr.", kiþi2.Meslek, kiþi2.Ýsim, kiþi2.Yaþ);
            Console.WriteLine ("{0} {1}, elan {2} yaþýndadýr.", kiþi3.Meslek, kiþi3.Ýsim, kiþi3.Yaþ);
            var adres = new {þehir="Antalya", ilçe="Kaleiçi", cadde="318", sokak="canan", no="2024B/8"};
            Console.WriteLine ("Adres: {0}.Cd, {1}.Sk, No: {2} - {3} / {4}", adres.cadde, adres.sokak, adres.no, adres.ilçe, adres.þehir);
            Console.WriteLine ("'var adres'in tipi: [{0}]", adres.GetType());

            Console.WriteLine ("\nSoysal<string> baþkanlar listesi ve anonim <var> baþkan birimleri:");
            List<string> baþkanlar = new List<string> {"Selim Dikel", "Hüseyin Kurt", "Hülya Piray", "Fatih Kaplan"};
            foreach (var baþkan in baþkanlar) Console.WriteLine (baþkan +"\tTip: "+baþkan.GetType());
            Console.WriteLine ("'baþkanlar'ýn tipi: [{0}]", baþkanlar.GetType());

            Console.WriteLine ("\nSehirler dizisi, seçici sorgu, tipleri ve kurgularý:");
            string[] þehirler = {"ÞanlýUrfa", "Mersin", "Bursa", "Malatya", "Van", "Ýstanbul", "Ankara", "Ýzmir", "KahramanMaraþ"};
            var sorgu = from þehir in þehirler 
                where þehir.Length > 6
                orderby þehir
                select þehir;
            Console.Write ("Bütün þehirler: "); foreach (var þehir in þehirler) Console.Write (þehir+" ");
            Console.Write ("\nUzunluk > 6 a-->z þehirler: "); foreach (var þehir in sorgu) Console.Write (þehir+" ");
            Console.WriteLine ("\nTip(þehirler): {0} / [{1}]", þehirler.GetType().Name, þehirler.GetType().Assembly);
            Console.WriteLine ("Tip(sorgu): {0} / [{1}]", sorgu.GetType().Name, sorgu.GetType().Assembly);

            Console.WriteLine ("\nSorgu'da string ay ve foreach'de anonim tip var ay:");
            ArrayList aylar = new ArrayList {"Ocak", "Þubat", "Mart", "Nisan", "Mayýs", "Haziran", "Temmuz", "Aðustos", "Eylül", "Ekim", "Kasým", "Aralýk"};
            var sorgu2 = from string ay in aylar
                select ay.Substring (0, 3);
            Console.Write ("Tam adla aylar: "); foreach (var ay in aylar) Console.Write (ay+" ");
            Console.Write ("\n3 harfli adla aylar: "); foreach (var ay in sorgu2) Console.Write (ay+" ");

            Console.WriteLine ("\n\nGet-Set sýnýf alan-özellik, liste ve var pratikleri:");
            int i, j, ts; decimal dm; string dzg; var r=new Random();
            var iþçiler = new List<SýnýfB2>();
            SýnýfB1 sb1=new SýnýfB1();
            for(i=0;i<10;i++) {
                var iþçi = new SýnýfB2();
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,92); sb1.Ad=dzg;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,92); sb1.Soyad=dzg;
                dm=r.Next(12500,150000)+r.Next(10,100)/100m; sb1.Maaþ=dm;
                iþçi.Ad = sb1.Ad;
                iþçi.Soyad = sb1.Soyad;
                iþçi.Maaþ = sb1.Maaþ;
                iþçiler.Add (iþçi);
            }
            foreach(var iþçi in iþçiler) Console.WriteLine ("Ad: {0,-9}  Soyad: {1,-9}  Maaþ: {2,10:#,0.00} TL", iþçi.Ad, iþçi.Soyad, iþçi.Maaþ);

            Console.WriteLine ("\nSoysal Adres yapýlý listeyle bilgi yükleme ve döküm:");
            var adresler = new List<Adres> {
                new Adres {isim = "M.Nihat Yavaþ", adres1 = "Yusufkýlýç mh, 2024 cd.", adres2 = "Kapý no: 39/D", þehir = "Mersin", ilçe = "Toroslar", pk = 33999},
                new Adres {isim = "Hamza Candan", adres1 = "Yenihastane cd. Çýrmýðtý sk.", adres2 = "Kapý no: 127/7A", þehir = "Malatya", ilçe = "Yeþilyurt", pk = 44555},
                new Adres {isim = "Hatice Yavaþ Kaçar", adres1 = "FS.Mehmet mh, 1019 cd.", adres2 = "Kapý no: 1951/2B", þehir = "Bursa", ilçe = "Baðlarbaþý", pk = 16888},
            };
            foreach (var adr in adresler) Console.WriteLine (adr.isim + ", " + adr.adres1 + " " + adr.adres2 + ", " + adr.pk + " " + adr.ilçe + " - " + adr.þehir);

            Console.WriteLine ("\nSözlük<anahtar,deðer>/<string, object>, sorgu ve foreach'de 'var' kullanýmý:");
            var sözlük = new Dictionary<string, object>();
            sözlük.Add ("1", 2024); sözlük.Add ("Ýki", "Ýkinci kayýt"); sözlük.Add ("3", "Ekim"); sözlük.Add ("Dört", "Dördüncü kayýt"); sözlük.Add ("5", 19); sözlük.Add ("Altý", "Altýncý kayýt");
            var sorgu4 = sözlük.Values.OfType<object>(); foreach (var no in sözlük) Console.WriteLine (no);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}