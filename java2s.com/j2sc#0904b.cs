// j2sc#0904b.cs: Delegeli olay metotlarý arasýnda parametrik deðer aktarma örneði.

using System;
namespace YetkiAktarma {
    public delegate void Olay1Yönetimi (Olay1b o1b);
    delegate void AboneYönetimi (string a, string b);
    public delegate void SaatYönetimi (object zaman, Saat1 zm);
    class Olay1a {
        public event Olay1Yönetimi Olayým1;
        public Olay1a() {Olayým1 = null;} //Kurucu
        public void ÇiftSayýÜreteci() {
            int i, ts1; var r=new Random();
            for(i=0;i<100;i++) {
                ts1=r.Next(-10000,10000);
                if(ts1 % 2 == 0) {if (Olayým1 != null) {Olay1b çift; çift = new Olay1b (ts1); Olayým1 (çift);}}
            }
        }
    }
    public class Olay1b {
        private int çiftSayý;
        public Olay1b (int ç) {çiftSayý = ç;}
        public int ÇiftSayý {get {return çiftSayý;}}
    }
    class Olay1c {
        public void ÇiftSayýyýYaz (Olay1b o1b) {Console.Write (o1b.ÇiftSayý+", ");}
    }
    class Olay2 {
        private int n; public int N {set {n=value;}}
        public delegate void Olay2Yönetimi();
        public event Olay2Yönetimi Çift;
        public Olay2() {Çift = null; n=0;} //Kurucu
        public void Çiftse() {if (Çift != null & n % 2 == 0) Console.Write (n+" ");}
    }
    class Abone {
        public string aboneAdý = "yeni abone";
        public Kiþi kiþi = null;
        public AboneYönetimi adDðþDlg = null;
        public Abone (Kiþi k, string ad) {//Kurucu
            aboneAdý = ad;
            adDðþDlg = new AboneYönetimi (kiþininAdýDeðiþti);
            kiþi = k;
            kiþi.AdDeðiþti += adDðþDlg;
        }
        void kiþininAdýDeðiþti (string a, string b) {Console.WriteLine ("[{0}] Kiþi'nin eski adý: [{1}] olarak deðiþti.", aboneAdý, b);}
        public void AboneÝptal() {kiþi.AdDeðiþti -= adDðþDlg;}
    }
    class Kiþi {
        private string ad;
        private event AboneYönetimi AdDeðiþimi;
        public event AboneYönetimi AdDeðiþti {
            add {
                AdDeðiþimi += value;
                if (value.Target is Abone) {Console.WriteLine ("Abone '{0}' AdDeðiþti'ye henüz kaydoldu.", ((Abone)value.Target).aboneAdý);}
            }
            remove {
                AdDeðiþimi -= value;
                if (value.Target is Abone) {Console.WriteLine ("\tAbone '{0}' AdDeðiþti'den henüz silindi.", ((Abone)value.Target).aboneAdý);}
            }
        }
        public string Ad {get {return ad;} set {ad = value; AdDeðiþimi ("xx", value);}}
    }
    public class Saat1 {
        public readonly int saat;
        public readonly int dakika;
        public readonly int saniye;
        public Saat1 (int saat, int dakika, int saniye) {//Kurucu
            this.saat = saat;
            this.dakika = dakika;
            this.saniye = saniye;
        }
    }
    public class Saat2 {
        private int saat;
        private int dakika;
        private int saniye;
        public event SaatYönetimi SaniyeDeðiþti;
        protected virtual void SaniyeDeðiþtiyse (Saat1 z) {if (SaniyeDeðiþti != null) {SaniyeDeðiþti (this, z);}}
        public void Koþtur() {
            int i=0;
            for (;;) {//Sonsuz döngü
                System.DateTime dt = System.DateTime.Now;
                if (dt.Second != saniye) {if (i++>10) break;
                    Saat1 zaman = new Saat1 (dt.Hour, dt.Minute, dt.Second);
                    SaniyeDeðiþtiyse (zaman);
                }
                this.saniye = dt.Second;
                this.dakika = dt.Minute;
                this.saat = dt.Hour;
            }
        }
    }
    public class GörüntüYönetimi {
        public void YönetimiEkle (Saat2 zaman) {zaman.SaniyeDeðiþti += new SaatYönetimi (ZamanDeðiþti);}
        public void ZamanDeðiþti (object zaman, Saat1 zm) {Console.WriteLine ("Deðiþen zaman: [{0}:{1}:{2}]",zm.saat.ToString(),zm.dakika.ToString(),zm.saniye.ToString());}
    }
    public class Buton {
        public delegate void ButonYönetimi (int x);
        public event ButonYönetimi Týklanýrsa;
        public void Týkla (int x) {Týklanýrsa (x);}
    }
    class Delege4b {
        public static void ButonuTýkla(int x) {Console.WriteLine ("Button {0}.nci kez týklandý...", ++x);}
        static void Main() {
            Console.Write ("Sýnýf tiplemesinin delegeli olayýna eklenen olay metodu olaya dair her çeþit kritiði (deðiþim, tuþ-fare, tek-çift) süzgeçleyip sonucu sunabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Delegeli olayla seçilen rasgele 100 sayýdaki -+çiftlerin sunulmasý:");
            Olay1a o1a = new Olay1a();
            Olay1c o1c = new Olay1c();
            o1a.Olayým1 += new Olay1Yönetimi (o1c.ÇiftSayýyýYaz);
            o1a.ÇiftSayýÜreteci();

            Console.WriteLine ("\n\nDelegeli olay yönetimiyle rasgele 100 sayýdaki -+çiftler:");
            int i, ts1; var r=new Random();
            Olay2 o2=new Olay2();
            o2.Çift +=new Olay2.Olay2Yönetimi (o2.Çiftse);
            for(i=0;i<100;i++) {ts1=r.Next(-10000,10000); o2.N=ts1; o2.Çiftse();}

            Console.WriteLine ("\n\nDelegeli olayla abone kaydetme, silme, adlarýný deðiþtirme:");
            string ad;
            Kiþi kiþi = new Kiþi();
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a1 = new Abone (kiþi, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a2 = new Abone (kiþi, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a3 = new Abone (kiþi, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a4 = new Abone (kiþi, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a5 = new Abone (kiþi, ad);
            a2.AboneÝptal(); a4.AboneÝptal(); a1.AboneÝptal();
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} kiþi.Ad = ad;

            Console.WriteLine ("\n10 sn'lik saatten [^C] ile çýkabilirsiniz:");
            Saat2 zaman = new Saat2();
            GörüntüYönetimi gy = new GörüntüYönetimi();
            gy.YönetimiEkle (zaman);
            zaman.Koþtur();

            Console.WriteLine ("\nDelegeli olay metotlarý arasýnda parametrik deðer aktarýmý:");
            Buton düðme = new Buton();
            düðme.Týklanýrsa += new Buton.ButonYönetimi (ButonuTýkla);
            for(i=0;i<5;i++) {düðme.Týkla (i);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}