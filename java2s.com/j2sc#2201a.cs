// j2sc#2201a.cs: 'Var' anonim tip ve from-select sorgular �rne�i.

using System;
using System.Collections.Generic; //List<> i�in
using System.Diagnostics; //Process i�in
using System.Linq; //from-select i�in
using System.Collections; //ArrayList i�in
namespace AnonimTip {
    class S�n�fA {
        public Int32 No32 {get; set;}
        public Int64 No64 {get; set;}
        public String Ad {get; set;}
    }
    public class S�n�fB1 {
        private string ad, soyad;
        private decimal maa�;
        public String Ad {get {return ad;} set {ad = value;}}
        public String Soyad {get {return soyad;} set {soyad = value;}}
        public decimal Maa� {get {return maa�;} set {maa� = value;}}
    }
    public class S�n�fB2 {
        public String Ad {get; set;}
        public String Soyad {get; set;}
        public Decimal Maa� {get; set;}
    }
    public struct Adres {
         public String isim;
         public String �irket; //Ev adreste �irket ihmal edilebilir
         public String adres1;
         public String adres2;
         public String �ehir;
         public String il�e;
         public int pk;
    }
    class Var_1 {
        static void Main() {
            Console.Write ("Anonim tip 'var' Main() metotta t�m ilkel tip, s�n�f, (soysal) liste referans� olarak kullan�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Bellekte elan aktif t�m s�re�lerin ad, ipNo, i�No detaylar�:");
            var s�re� = new List<S�n�fA>();
            foreach (var sr� in Process.GetProcesses()) {
                var veri = new S�n�fA();
                veri.No32 = sr�.Id;
                veri.Ad = sr�.ProcessName;
                veri.No64 = sr�.WorkingSet64;
                s�re�.Add (veri);
        }
        Console.WriteLine (s�re�);
        foreach(var sr� in s�re�) Console.WriteLine ("Ad: {0}\tSicimNo: {1}\t��No: {2}", sr�.Ad, sr�.No32, sr�.No64);

            Console.WriteLine ("\nAnonim 'var' tipli new tiplemeli ki�i �zellikleri atfetme:");
            var ki�i1 = new {�sim = "M.Nihat Yava�", Ya� = 2024-1957, Meslek = "Emekli"};
            var ki�i2 = new {�sim = "Atilla G�kt�rk", Ya� = 2024-1985, Meslek = "Doktor"};
            var ki�i3 = new {�sim = "Hilal G�kt�rk", Ya� = 2024-1982, Meslek = "Doktor"};
            Console.WriteLine ("{0} {1}, elan {2} ya��ndad�r.", ki�i1.Meslek, ki�i1.�sim, ki�i1.Ya�);
            Console.WriteLine ("{0} {1}, elan {2} ya��ndad�r.", ki�i2.Meslek, ki�i2.�sim, ki�i2.Ya�);
            Console.WriteLine ("{0} {1}, elan {2} ya��ndad�r.", ki�i3.Meslek, ki�i3.�sim, ki�i3.Ya�);
            var adres = new {�ehir="Antalya", il�e="Kalei�i", cadde="318", sokak="canan", no="2024B/8"};
            Console.WriteLine ("Adres: {0}.Cd, {1}.Sk, No: {2} - {3} / {4}", adres.cadde, adres.sokak, adres.no, adres.il�e, adres.�ehir);
            Console.WriteLine ("'var adres'in tipi: [{0}]", adres.GetType());

            Console.WriteLine ("\nSoysal<string> ba�kanlar listesi ve anonim <var> ba�kan birimleri:");
            List<string> ba�kanlar = new List<string> {"Selim Dikel", "H�seyin Kurt", "H�lya Piray", "Fatih Kaplan"};
            foreach (var ba�kan in ba�kanlar) Console.WriteLine (ba�kan +"\tTip: "+ba�kan.GetType());
            Console.WriteLine ("'ba�kanlar'�n tipi: [{0}]", ba�kanlar.GetType());

            Console.WriteLine ("\nSehirler dizisi, se�ici sorgu, tipleri ve kurgular�:");
            string[] �ehirler = {"�anl�Urfa", "Mersin", "Bursa", "Malatya", "Van", "�stanbul", "Ankara", "�zmir", "KahramanMara�"};
            var sorgu = from �ehir in �ehirler 
                where �ehir.Length > 6
                orderby �ehir
                select �ehir;
            Console.Write ("B�t�n �ehirler: "); foreach (var �ehir in �ehirler) Console.Write (�ehir+" ");
            Console.Write ("\nUzunluk > 6 a-->z �ehirler: "); foreach (var �ehir in sorgu) Console.Write (�ehir+" ");
            Console.WriteLine ("\nTip(�ehirler): {0} / [{1}]", �ehirler.GetType().Name, �ehirler.GetType().Assembly);
            Console.WriteLine ("Tip(sorgu): {0} / [{1}]", sorgu.GetType().Name, sorgu.GetType().Assembly);

            Console.WriteLine ("\nSorgu'da string ay ve foreach'de anonim tip var ay:");
            ArrayList aylar = new ArrayList {"Ocak", "�ubat", "Mart", "Nisan", "May�s", "Haziran", "Temmuz", "A�ustos", "Eyl�l", "Ekim", "Kas�m", "Aral�k"};
            var sorgu2 = from string ay in aylar
                select ay.Substring (0, 3);
            Console.Write ("Tam adla aylar: "); foreach (var ay in aylar) Console.Write (ay+" ");
            Console.Write ("\n3 harfli adla aylar: "); foreach (var ay in sorgu2) Console.Write (ay+" ");

            Console.WriteLine ("\n\nGet-Set s�n�f alan-�zellik, liste ve var pratikleri:");
            int i, j, ts; decimal dm; string dzg; var r=new Random();
            var i��iler = new List<S�n�fB2>();
            S�n�fB1 sb1=new S�n�fB1();
            for(i=0;i<10;i++) {
                var i��i = new S�n�fB2();
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,92); sb1.Ad=dzg;
                ts=r.Next(3,10); dzg=""; for(j=0;j<ts;j++) dzg+=(char)r.Next(65,92); sb1.Soyad=dzg;
                dm=r.Next(12500,150000)+r.Next(10,100)/100m; sb1.Maa�=dm;
                i��i.Ad = sb1.Ad;
                i��i.Soyad = sb1.Soyad;
                i��i.Maa� = sb1.Maa�;
                i��iler.Add (i��i);
            }
            foreach(var i��i in i��iler) Console.WriteLine ("Ad: {0,-9}  Soyad: {1,-9}  Maa�: {2,10:#,0.00} TL", i��i.Ad, i��i.Soyad, i��i.Maa�);

            Console.WriteLine ("\nSoysal Adres yap�l� listeyle bilgi y�kleme ve d�k�m:");
            var adresler = new List<Adres> {
                new Adres {isim = "M.Nihat Yava�", adres1 = "Yusufk�l�� mh, 2024 cd.", adres2 = "Kap� no: 39/D", �ehir = "Mersin", il�e = "Toroslar", pk = 33999},
                new Adres {isim = "Hamza Candan", adres1 = "Yenihastane cd. ��rm��t� sk.", adres2 = "Kap� no: 127/7A", �ehir = "Malatya", il�e = "Ye�ilyurt", pk = 44555},
                new Adres {isim = "Hatice Yava� Ka�ar", adres1 = "FS.Mehmet mh, 1019 cd.", adres2 = "Kap� no: 1951/2B", �ehir = "Bursa", il�e = "Ba�larba��", pk = 16888},
            };
            foreach (var adr in adresler) Console.WriteLine (adr.isim + ", " + adr.adres1 + " " + adr.adres2 + ", " + adr.pk + " " + adr.il�e + " - " + adr.�ehir);

            Console.WriteLine ("\nS�zl�k<anahtar,de�er>/<string, object>, sorgu ve foreach'de 'var' kullan�m�:");
            var s�zl�k = new Dictionary<string, object>();
            s�zl�k.Add ("1", 2024); s�zl�k.Add ("�ki", "�kinci kay�t"); s�zl�k.Add ("3", "Ekim"); s�zl�k.Add ("D�rt", "D�rd�nc� kay�t"); s�zl�k.Add ("5", 19); s�zl�k.Add ("Alt�", "Alt�nc� kay�t");
            var sorgu4 = s�zl�k.Values.OfType<object>(); foreach (var no in s�zl�k) Console.WriteLine (no);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}