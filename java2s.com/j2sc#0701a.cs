// j2sc#0701a.cs: Sýnýf alan, metot, ebeveyn taþmasý, içiçe sýnýf çaðýrma örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {public int x = 0;}
    class Nokta {
        public int x;
        public int y;
        public Nokta (int x, int y) {this.x = x; this.y = y;} //Sýnýf kurucusu
    }
    class Bina {
        public int kat;
        public int alan;
        public int mukim;
    }
    class Dikdörtgen {
        private uint en;
        private uint boy;
        private uint alan;
        public uint En {get {return en;} set {en = value; AlanýHesapla();} }
        public uint Boy {get {return boy;} set {boy = value; AlanýHesapla();} }
        public uint Alan {get {return alan;} }
        private void AlanýHesapla() {alan = en * boy;}
    }
    public class Araba {
        private int hýz;
        private AraçRadyosu müzik = new AraçRadyosu();
        public Araba() {hýz = 100;}
        public int Hýz {get {return hýz;} set {hýz = value;} }
        public void RadyoyuDüðmele (bool durum) {müzik.AçýkMý (durum);}
    }
    public class AraçRadyosu {
        public void AçýkMý (bool drm) {
            if (drm) Console.WriteLine ("AÇIK...");
            else Console.WriteLine ("KAPALI...");
        }
    }
    class TemelSýnýf {
        public string Alan1 = "TemelSýnýf Alan1";
        public void Metod1 (string dizge) {Console.WriteLine ("TemelSýnýf Metod1(): {0}", dizge);}
        public void Yaz() {Console.WriteLine ("Bu TemelSýnýf'ýn Yaz() metodudur.");}
    }
    class TürediSýnýf: TemelSýnýf {
        public string Alan2 = "TürediSýnýf Alan2";
        public void Metod2 (string dizge) {Console.WriteLine ("TürediSýnýf Metod2(): {0}", dizge);}
        public void Yaz() {Console.WriteLine ("Bu TürediSýnýf'ýn Yaz() metodudur.");}
    }
    class SýnýfTanýmý1 {
        SýnýfTanýmý1() {Console.WriteLine ("SýnýfTanýmý1 kurucusu çaðrýldý.");}
        ~SýnýfTanýmý1() {Console.WriteLine ("SýnýfTanýmý1 yýkýcýsý çaðrýldý.");}
        void MesajYaz (string mesaj) {Console.WriteLine ("MesajYaz(): {0}", mesaj);}
        void Dispose() {GC.SuppressFinalize (this);}
        static void Main() {
            Console.Write ("Sýnýf/class bir nesne tiplemesi olup, tanýmlý üyeler ve metodlar þablonudur. Tipleme deðiþkenleri 'eriþim tip ad'la tanýmlanýr, 'nesne.üye'yle eriþilir. Nesnel tip sýnýf kopyalarý referanssal olduðundan deðiþiklikler birbirlerini etkiler. Türetilen yavru sýnýf kendi alan ve metodlarýnýn yanýsýra mirasladýðý ebeveyninkileri de (aynýysa taþma/overload önceliðiyle) kullanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf tanýmlarý ve üyelerine eriþimler:");
            var r=new Random();
            Sýnýf1 s1 = new Sýnýf1(); s1.x = r.Next (-10000, 10000);
            Console.WriteLine ("s1.GetType() = {0}\ns1.x = {1}", s1.GetType(), s1.x);
            Console.WriteLine ("\t==>Main() metod anasýnýfý SýnýfTanýmý1()'nýn tepesi.");
            SýnýfTanýmý1 uyg = new SýnýfTanýmý1();
            uyg.MesajYaz ("SýnýfTanýmý1 sýnýfýndan herkese selamlar!");
            Console.WriteLine("\t==>Main() fonksiyonun dibi.");
            uyg.Dispose();
            Nokta n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);
            n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);
            n1 = new Nokta (r.Next (-100, 100), r.Next (-100, 100)); Console.WriteLine ("Nokta (x, y) = ({0}, {1})", n1.x, n1.y);

            Console.WriteLine ("\nEviçi kullaným alanýnýn mukim kiþibaþý m^2 payý:");
            Bina ev1 = new Bina();
            int kiþibaþýAlan; ev1.mukim = 11; ev1.alan = 200; ev1.kat = 2; kiþibaþýAlan = ev1.alan / ev1.mukim;
            Console.WriteLine ("Evin katsayýsý={0}\tHanehalký={1}\tAlan = {2}\tKiþibaþý alan={3}", ev1.kat, ev1.mukim, ev1.alan, kiþibaþýAlan);
            Bina ev2 = new Bina(); ev2.mukim = 4; ev2.alan = 2500; ev2.kat = 2; Console.WriteLine ("Evin katsayýsý={0}\tHanehalký={1}\tAlan = {2}\tKiþibaþý alan={3}", ev2.kat, ev2.mukim, ev2.alan, ev2.alan / ev2.mukim);
            Bina ev3 = new Bina(); ev3.mukim = 7; ev3.alan = 300; ev3.kat = 3; Console.WriteLine ("Evin katsayýsý={0}\tHanehalký={1}\tAlan = {2}\tKiþibaþý alan={3}", ev3.kat, ev3.mukim, ev3.alan, ev3.alan / ev3.mukim);

            Console.WriteLine ("\nNesnel tip sýnýfýn kopyasý birbirlerini etkiler:");
            Sýnýf1 a = new Sýnýf1(); Sýnýf1 b = new Sýnýf1();
            a.x = r.Next (0, 10000);  b.x = r.Next (0, 10000); Console.WriteLine ("Ayrýk: a.x = {0}\tb.x = {1}", a.x, b.x);
            a = b; b.x = r.Next (0, 10000); Console.WriteLine ("Kopyalý: a.x = {0}\tb.x = {1}", a.x, b.x);
            a.x = r.Next (0, 10000); Console.WriteLine ("Kopyalý: a.x = {0}\tb.x = {1}", a.x, b.x);
            Dikdörtgen d1 = new Dikdörtgen(); Dikdörtgen d2 = new Dikdörtgen();
            d1.En = (uint)r.Next (0, 100); d1.Boy = (uint)r.Next (0, 100); d2.En = (uint)r.Next (0, 100); d2.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Ayrýk: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);
            d1 = d2; d1.En = (uint)r.Next (0, 100); d1.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Kopyalý: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);
            d2.En = (uint)r.Next (0, 100); d2.Boy = (uint)r.Next (0, 100); Console.WriteLine ("Kopyalý: d1.Alan = {0}\td2.Alan = {1}", d1.Alan, d2.Alan);

            Console.WriteLine ("\nÝçiçe Araba/Radyo sýnýflarýyla sürat deðiþtir/oku ve müziði aç/kapa:");
            Araba a1 = new Araba();
            a1.Hýz = r.Next (0, 150); Console.WriteLine ("Arabanýn þuanki hýzý = {0} km/st", a1.Hýz);
            Console.Write ("Lütfen radyoyu açar mýsýn? "); a1.RadyoyuDüðmele (true);
            a1.Hýz = r.Next (0, 150); Console.WriteLine ("Arabanýn þuanki hýzý = {0} km/st", a1.Hýz);
            Console.Write ("Lütfen radyoyu kapar mýsýn? "); a1.RadyoyuDüðmele (false);

            Console.WriteLine ("\nTüredi sýnýf kendi ve temel sýnýfýn metotlarýnda tüm alanlarý kullanabilir:");
            TürediSýnýf ts1 = new TürediSýnýf();
            ts1.Metod1(ts1.Alan1);
            ts1.Metod1(ts1.Alan2);
            ts1.Metod2(ts1.Alan1);
            ts1.Metod2(ts1.Alan2);
            //ts1 = new TürediSýnýf();
            TemelSýnýf es1 = (TemelSýnýf)ts1;
            ts1.Yaz(); //Yavru taþma/overload önceliði
            es1.Yaz(); //Ebeveyn taþma/overload önceliði

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}