// j2sc#0718b.cs: S�n�f alan de�erinin set-get'li �zellikle konulmas�-al�nmas� �rne�i.

using System;
using System.Reflection;
namespace S�n�flar {
    public sealed class De�er {public int ts = 20231022;}
    public sealed class Kontrol {
        private readonly De�er nesne;
        public Kontrol (De�er nesne) {this.nesne = nesne;} //Kurucu
        public int TS {get {return nesne.ts;}}
    }
    class Ki�i {
        private string _soyad�;
        private string _ad�;
        public void Adlar�Koy (string ad�, string soyad�) {_soyad� = soyad�; _ad� = ad�;}
        public string TamAdKoyAl {
            get {return _ad� + " " + _soyad�;}
            set {
                string[] adlar = value.Split (' '); //' ' ==> new string[] {" "}, StringSplitOptions.RemoveEmptyEntries
                _ad� = adlar [0];
                _soyad� = adlar [adlar.Length - 1];
            }
        }
    }
    public class S�n�f {
        private int ts;
        public S�n�f (int i) {ts = i;} //Kurucuyla de�er atama
        public int TS {set {ts = value;} get {return ts;}} //�zellik'le de�er koyma alma
    }
    public class AdYa� {
        public readonly string isim;
        private int ya�;
        public int Ya� {
            set {if (value >= 0 && value <= 100) ya� = value; else throw (new ArgumentOutOfRangeException ("[0 <= Ya� <= 120] aras�nda olmal�d�r!"));}
            get {return ya�;}
        }
        public override string ToString() {return (isim + "'�n ya��: " + ya�);}
        private AdYa�() : this ("Varsay�l� isim"){}
        public AdYa� (string isim) {this.isim = isim; ya� = 0;}
    }
    class Tarih {
        DateTime[] tarihler = new DateTime [5];
        private DateTime do�umTarihi;
        private string alan;
        public DateTime this [int endeks] {set {tarihler [endeks] = value;} get {return tarihler [endeks];}}
        public DateTime Do�umTarihi {set {do�umTarihi = value;} get {return do�umTarihi;}}
        public string Alan {set {alan = value;} get {return alan;}}
        public void Test() {Console.WriteLine ("Test metodu �a�r�ld�.");}
    }
    public interface IAd {string AdAl();}
    public interface IAdres {string AdresiAl();}
    public class �ah�s : IAd, IAdres {
        private string ad, adres;
        public �ah�s(){}
        public string Ad {set {ad = value;}}
        public string Adres {set {adres = value;}}
        public string AdAl() {return ad;}
        public string AdresiAl() {return adres;}
    }
    public abstract class ��g�ren {public abstract string Ad {set;get;}}
    class Meslek: ��g�ren {
        string ad, vas�f;
        public override string Ad {set {ad=value;} get {return (ad);}}
        public string Vas�f {set {vas�f=value;} get {return (vas�f);}}
    }
    class �zellik2 {
        static void Main() {
            Console.Write ("�artl� set-get kodlanabilir. De�er koyma set'li �zellik'le, alma ise return metotla yap�labilir. S�n�f endeksli dizile�tirilebilir (Tarih). Abstract/virtual mirasl� s�n�f �zelli�i override yapar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("De�er s�n�f tamsay�s�n�n Kontrol s�n�fdaki get'li �zellikle al�nmas�:");
            var r=new Random(); int i, ts1;
            De�er de�er = new De�er();
            Kontrol k=new Kontrol (de�er);
            Console.WriteLine ("Kurulu�taki ilk tamsay� = {0}", k.TS);
            for(i=1;i<=5;i++) {
                de�er.ts=r.Next(10000000,100000000);
                Console.WriteLine ("{0}.inci konulup al�nan tamsay� = {1}", i, k.TS);
            }

            Console.WriteLine ("\nKurucuyla veya �zellik'le ad-soyad koyup alma:");
            string[] adlar=new string[]{"Zafer Nihat Candan", "Nihal Zeliha Yava� Candan", "Hatice Yava� Ka�ar", "Sevim Yava�", "Ali R�za Dervi� Binbo�a"};
            Ki�i ki�i = new Ki�i();
            ki�i.Adlar�Koy ("Nihat", "Yava�"); //Kurucuyla ikili ad-soyad� koyma
            Console.WriteLine ("ki�i'nin ad� ve soyad�: {0}", ki�i.TamAdKoyAl);
            for(i=0;i<5;i++) {
                ki�i.TamAdKoyAl = adlar [i]; //�zellik'le iki ve daha�oklu addan ilk ve son ad� ay�rma
                Console.WriteLine ("ki�i'nin ilkad� ve soyad�: {0}", ki�i.TamAdKoyAl);
            }

            Console.WriteLine ("\nKurucuyla veya �zellik'le rasgele tamsay� koyup alma:");
            ts1=r.Next(-10000,10000);
            S�n�f snf = new S�n�f (ts1); Console.WriteLine ("Kurucuyla konulan say�: {0}", snf.TS);
            for(i=1;i<=5;i++) {
                snf.TS=r.Next(-10000,10000);
                Console.WriteLine ("�zellik'le konup al�nan {0}.say�: {1}", i, snf.TS);
            }

            Console.WriteLine ("\nKi�i ya� hadleri hatas� f�rlatan Ya� �zelli�i:");
            AdYa� ay = new AdYa�(""); Console.WriteLine ("AdYa� nesnesi yarat�ld�.");
            for(i=0;i<5;i++) {
                ay = new AdYa� (adlar [i]);
                try {ts1=r.Next(-20,200);
                    ay.Ya�=ts1;
                    Console.WriteLine ("\t"+ay.ToString());
                }catch  (Exception h) {Console.WriteLine ("Hatal� ya� ({0}): [{1}]\nMesaj�: [{2}]", ts1, h.GetType().FullName, h.Message);}
            }

            Console.WriteLine ("\nTarih dizisel nesnenin alan, �zellik ve metot �a�r�lmas�:");
            Type tip = typeof (Tarih); Console.WriteLine ("S�n�f tipi: " + tip.FullName);
            object nes = Activator.CreateInstance (tip);
            tip.InvokeMember ("", 
                BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public,
                null, nes, new object[] {0, new DateTime (2023, 10, 23, 5, 22, 54)});
            Console.WriteLine ("Tarih [0] = " + ((Tarih)nes) [0].ToString());
            Tarih t=new Tarih(); t.Do�umTarihi=new DateTime (1955, 8, 7, 14, 45, 12); Console.WriteLine ("Do�um tarihi: " + t.Do�umTarihi);
            t [0]= DateTime.Now; Console.WriteLine ("Tarih [0] = " + t [0]);
            t [1]= new DateTime (1957, 4, 7, 11, 35, 52); Console.WriteLine ("Tarih [1] = " + t [1]);
            t.Alan= "M.Nihat Yava�"; Console.WriteLine ("t.Alan: " + t.Alan);
            t.Test();

            Console.WriteLine ("\nS�n�f alanlar�n�n �zellikle de�er koyup metotla almas�:");
            string[] adresler=new string[]{"�stanbul", "Malatya", "Bursa", "Ankara", "�zmir"};
            �ah�s �hs;
            for(i=0;i<5;i++) {
                �hs = new �ah�s();
                �hs.Ad = adlar [i]; �hs.Adres = adresler [i];
                Console.WriteLine ("{0}'�n ikamet �ehri: {1}", �hs.AdAl(), �hs.AdresiAl());
            }

            Console.WriteLine ("\nSoyut/sanal alan �zelli�i esge�meli/override olmal�d�r:");
            Meslek i�g = new Meslek(); //Referans ��g�ren olunca Vas�f �ablonu da isteniyor
            i�g.Ad="Belk�s Candan"; i�g.Vas�f="Hostes"; Console.WriteLine ("{0}'�n mesle�i: {1}", i�g.Ad, i�g.Vas�f);
            i�g.Ad="Canan Candan"; i�g.Vas�f="Ziraat M�hendisi"; Console.WriteLine ("{0}'�n mesle�i: {1}", i�g.Ad, i�g.Vas�f);
            i�g.Ad="Zafer N.Candan"; i�g.Vas�f="Genetik M�hendis"; Console.WriteLine ("{0}'�n mesle�i: {1}", i�g.Ad, i�g.Vas�f);
            i�g.Ad="Atilla G�kt�rk"; i�g.Vas�f="Doktor"; Console.WriteLine ("{0}'�n mesle�i: {1}", i�g.Ad, i�g.Vas�f);
            i�g.Ad="Sema �zbay"; i�g.Vas�f="��retmen"; Console.WriteLine ("{0}'�n mesle�i: {1}", i�g.Ad, i�g.Vas�f);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}