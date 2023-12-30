// j2sc#0904b.cs: Delegeli olay metotlar� aras�nda parametrik de�er aktarma �rne�i.

using System;
namespace YetkiAktarma {
    public delegate void Olay1Y�netimi (Olay1b o1b);
    delegate void AboneY�netimi (string a, string b);
    public delegate void SaatY�netimi (object zaman, Saat1 zm);
    class Olay1a {
        public event Olay1Y�netimi Olay�m1;
        public Olay1a() {Olay�m1 = null;} //Kurucu
        public void �iftSay��reteci() {
            int i, ts1; var r=new Random();
            for(i=0;i<100;i++) {
                ts1=r.Next(-10000,10000);
                if(ts1 % 2 == 0) {if (Olay�m1 != null) {Olay1b �ift; �ift = new Olay1b (ts1); Olay�m1 (�ift);}}
            }
        }
    }
    public class Olay1b {
        private int �iftSay�;
        public Olay1b (int �) {�iftSay� = �;}
        public int �iftSay� {get {return �iftSay�;}}
    }
    class Olay1c {
        public void �iftSay�y�Yaz (Olay1b o1b) {Console.Write (o1b.�iftSay�+", ");}
    }
    class Olay2 {
        private int n; public int N {set {n=value;}}
        public delegate void Olay2Y�netimi();
        public event Olay2Y�netimi �ift;
        public Olay2() {�ift = null; n=0;} //Kurucu
        public void �iftse() {if (�ift != null & n % 2 == 0) Console.Write (n+" ");}
    }
    class Abone {
        public string aboneAd� = "yeni abone";
        public Ki�i ki�i = null;
        public AboneY�netimi adD��Dlg = null;
        public Abone (Ki�i k, string ad) {//Kurucu
            aboneAd� = ad;
            adD��Dlg = new AboneY�netimi (ki�ininAd�De�i�ti);
            ki�i = k;
            ki�i.AdDe�i�ti += adD��Dlg;
        }
        void ki�ininAd�De�i�ti (string a, string b) {Console.WriteLine ("[{0}] Ki�i'nin eski ad�: [{1}] olarak de�i�ti.", aboneAd�, b);}
        public void Abone�ptal() {ki�i.AdDe�i�ti -= adD��Dlg;}
    }
    class Ki�i {
        private string ad;
        private event AboneY�netimi AdDe�i�imi;
        public event AboneY�netimi AdDe�i�ti {
            add {
                AdDe�i�imi += value;
                if (value.Target is Abone) {Console.WriteLine ("Abone '{0}' AdDe�i�ti'ye hen�z kaydoldu.", ((Abone)value.Target).aboneAd�);}
            }
            remove {
                AdDe�i�imi -= value;
                if (value.Target is Abone) {Console.WriteLine ("\tAbone '{0}' AdDe�i�ti'den hen�z silindi.", ((Abone)value.Target).aboneAd�);}
            }
        }
        public string Ad {get {return ad;} set {ad = value; AdDe�i�imi ("xx", value);}}
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
        public event SaatY�netimi SaniyeDe�i�ti;
        protected virtual void SaniyeDe�i�tiyse (Saat1 z) {if (SaniyeDe�i�ti != null) {SaniyeDe�i�ti (this, z);}}
        public void Ko�tur() {
            int i=0;
            for (;;) {//Sonsuz d�ng�
                System.DateTime dt = System.DateTime.Now;
                if (dt.Second != saniye) {if (i++>10) break;
                    Saat1 zaman = new Saat1 (dt.Hour, dt.Minute, dt.Second);
                    SaniyeDe�i�tiyse (zaman);
                }
                this.saniye = dt.Second;
                this.dakika = dt.Minute;
                this.saat = dt.Hour;
            }
        }
    }
    public class G�r�nt�Y�netimi {
        public void Y�netimiEkle (Saat2 zaman) {zaman.SaniyeDe�i�ti += new SaatY�netimi (ZamanDe�i�ti);}
        public void ZamanDe�i�ti (object zaman, Saat1 zm) {Console.WriteLine ("De�i�en zaman: [{0}:{1}:{2}]",zm.saat.ToString(),zm.dakika.ToString(),zm.saniye.ToString());}
    }
    public class Buton {
        public delegate void ButonY�netimi (int x);
        public event ButonY�netimi T�klan�rsa;
        public void T�kla (int x) {T�klan�rsa (x);}
    }
    class Delege4b {
        public static void ButonuT�kla(int x) {Console.WriteLine ("Button {0}.nci kez t�kland�...", ++x);}
        static void Main() {
            Console.Write ("S�n�f tiplemesinin delegeli olay�na eklenen olay metodu olaya dair her �e�it kriti�i (de�i�im, tu�-fare, tek-�ift) s�zge�leyip sonucu sunabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Delegeli olayla se�ilen rasgele 100 say�daki -+�iftlerin sunulmas�:");
            Olay1a o1a = new Olay1a();
            Olay1c o1c = new Olay1c();
            o1a.Olay�m1 += new Olay1Y�netimi (o1c.�iftSay�y�Yaz);
            o1a.�iftSay��reteci();

            Console.WriteLine ("\n\nDelegeli olay y�netimiyle rasgele 100 say�daki -+�iftler:");
            int i, ts1; var r=new Random();
            Olay2 o2=new Olay2();
            o2.�ift +=new Olay2.Olay2Y�netimi (o2.�iftse);
            for(i=0;i<100;i++) {ts1=r.Next(-10000,10000); o2.N=ts1; o2.�iftse();}

            Console.WriteLine ("\n\nDelegeli olayla abone kaydetme, silme, adlar�n� de�i�tirme:");
            string ad;
            Ki�i ki�i = new Ki�i();
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a1 = new Abone (ki�i, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a2 = new Abone (ki�i, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a3 = new Abone (ki�i, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a4 = new Abone (ki�i, ad);
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} Abone a5 = new Abone (ki�i, ad);
            a2.Abone�ptal(); a4.Abone�ptal(); a1.Abone�ptal();
            ad=""; for(i=0;i<5;i++) {ts1=r.Next(65,87); ad+=(char)ts1;} ki�i.Ad = ad;

            Console.WriteLine ("\n10 sn'lik saatten [^C] ile ��kabilirsiniz:");
            Saat2 zaman = new Saat2();
            G�r�nt�Y�netimi gy = new G�r�nt�Y�netimi();
            gy.Y�netimiEkle (zaman);
            zaman.Ko�tur();

            Console.WriteLine ("\nDelegeli olay metotlar� aras�nda parametrik de�er aktar�m�:");
            Buton d��me = new Buton();
            d��me.T�klan�rsa += new Buton.ButonY�netimi (ButonuT�kla);
            for(i=0;i<5;i++) {d��me.T�kla (i);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}