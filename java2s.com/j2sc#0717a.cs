// j2sc#0717a.cs: Aray�z �ablon metot esasl� g�vdeli t�redi metotlar �rne�i.

using System;
namespace S�n�flar {
    public interface IDosya {
        int DosyaA� (string dosyaAd�);
        int DosyaKapa (string dosyaAd�);
        void DosyaKaydet (string dosyaKayd�);
    }
    public class Dosyam : IDosya {
        public int DosyaA� (string dosyaAd�) {Console.WriteLine ("\"{0}\" adl� dosya a��l�yor.", dosyaAd�); return 0;}
        public int DosyaKapa (string dosyaAd�) {Console.WriteLine ("\"{0}\" adl� kay�t dosyas� kapan�yor.", dosyaAd�); return 0;}
        public void DosyaKaydet (string dosyaKayd�) {Console.WriteLine ("Dosya kayd�: \"{0}\"", dosyaKayd�);}
    }
    public interface ISeri {
        void ba�lat(int x);
        int birart�r();
    }
    class S�rala : ISeri {
        int n;
        public S�rala() {n = 0;}
        public void ba�lat (int x) {n = x;}
        public int birart�r() {return n++;}
    }
    interface Aray�z {void Aray�zMetodu();}
    public class Temel: Aray�z {public void Aray�zMetodu() {Console.WriteLine ("Temel.Aray�zMetodu()");}}
    public class T�redi: Temel {public new void Aray�zMetodu() {Console.WriteLine ("T�redi.Aray�zMetodu()");}}
    public class Bile�en {public Bile�en(){}}
    interface Sayfa�l�ekleme {
        void sayfaBa�l��� (float �l�ek);
        void sayfaAyakl��� (float �l�ek);
        void sayfaSolmarj� (float �l�ek);
        void sayfaSa�marj� (float �l�ek);
        void yaz();
    }
    public class MetinYaz�l�m�: Bile�en, Sayfa�l�ekleme {
        protected string metin;
        protected float ba�l�k, ayakl�k, solmarj, sa�marj;
        public MetinYaz�l�m� (string metin) {this.metin = metin;}
        public void sayfaBa�l��� (float �l�ek) {ba�l�k = �l�ek;}
        public void sayfaAyakl��� (float �l�ek) {ayakl�k = �l�ek;}
        public void sayfaSolmarj� (float �l�ek) {solmarj = �l�ek;}
        public void sayfaSa�marj� (float �l�ek) {sa�marj = �l�ek;}
        public void yaz () {
            Console.WriteLine ("\t\tSayfa ba�l�k marj�: {0}", ba�l�k);
            Console.WriteLine ("Sayfa sol marj: {0}\t[Metin: \"{1}\"]\tSayfa sa� marj: {2}", solmarj, metin, sa�marj);
            Console.WriteLine ("\t\tSayfa ayakl�k marj�: {0}", ayakl�k);
        }
    }
    public interface Kanal {void Sonraki(); void �nceki();}
    public interface Kitap {void Sonraki(); void B�l�m();}
    public interface M�zik {void Sonraki(); void �nceki();}
    public class T�rediS�n�f : Kanal, Kitap, M�zik {
        void Kanal.Sonraki() {Console.WriteLine ("Kanal.Sonraki()");}
        void Kitap.Sonraki() {Console.WriteLine ("Kitap.Sonraki()");}
        void M�zik.Sonraki() {Console.WriteLine ("M�zik.Sonraki()");}
        void Kanal.�nceki() {Console.WriteLine ("Kanal.�nceki()");}
        void M�zik.�nceki() {Console.WriteLine ("M�zik.�nceki()");}
        public void B�l�m() {Console.WriteLine ("B�l�m()");}
    }
    public interface IK�yas {
        int De�eriAl();
        int K�yasla (IK�yas ik);
    }
    abstract public class TemelS�n�f : IK�yas {
        int n;
        public TemelS�n�f (int n0) {n = n0;}
        public int N {get {return De�eriAl();}}
        public int De�eriAl() {return n;}
        abstract public int K�yasla (IK�yas tk);
    }
    public class AltS�n�f : TemelS�n�f {
        public AltS�n�f (int n0) : base (n0){}
        override public int K�yasla (IK�yas ik) {return De�eriAl().CompareTo (ik.De�eriAl());}
    }
    class Aray�z1 {
    public static void Kar��la�t�r (IK�yas ik1, IK�yas ik2) {Console.WriteLine ("tmlk1 [{0}].K�yasla (tmlk2 [{1}]): Sonu� = {2}", ik1.De�eriAl(), ik2.De�eriAl(), ik1.K�yasla (ik2));}
        static void Main() {
            Console.Write ("Soyut s�n�f�n soyut metotlar� gibi aray�z metotlar� da tamamen g�vdesiz �ablonlard�r; referans yada tiplemeleri olmaz, miraslayan, �ablon metotlar� public eri�imle esge�mesiz g�vdelendirir. T�redi s�n�f�n tek temeli ve virg�llerle ayr�k �oklu aray�zleri olabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Aray�z metotlar�n�n miraslanarak i�levselle�tirilmesi:");
            Dosyam dos = new Dosyam();
            dos.DosyaA� ("mny.log");
            dos.DosyaKaydet ("�lk kay�t: Merhaba d�nya!");
            dos.DosyaKaydet ("�kinci kay�t: Nas�ls�n�z?..");
            dos.DosyaKaydet ("Son kay�t: Ho��akal�n.");
            dos.DosyaKapa ("mny.log");

            Console.WriteLine ("\nAray�z metotlar� i�lenerek artan saya�lar�n s�ralanmas�:");
            var r=new Random(); int ts1=r.Next (1, 100), ts2=r.Next (5, 50), i; 
            S�rala sr = new S�rala();
            Console.WriteLine ("\tBa�latma say�s� = {0}", 0);
            for(i=0; i < ts2; i++) Console.Write (sr.birart�r() + " "); Console.WriteLine();
            Console.WriteLine ("\tBa�latma say�s� = {0}", ts1); sr.ba�lat (ts1);
            for(i=0; i < ts2; i++) Console.Write (sr.birart�r() + " "); Console.WriteLine();

            Console.WriteLine ("\nReferans (Aray�z, Temel, T�redi) ile tipleme (T�redi)'nin ge�erliledi�i metot:");
            T�redi t�r = new T�redi(); t�r.Aray�zMetodu();
            Aray�z ay = (Aray�z) t�r; ay.Aray�zMetodu();
            Aray�z at�r = new T�redi(); at�r.Aray�zMetodu();
            Temel tt�r = new T�redi(); tt�r.Aray�zMetodu();

            Console.WriteLine ("\nMetni sayfa bile�enine �st-alt-sol-sa� marj/sm ayarl� yazd�rma:");
            float fs1=r.Next(0, 10)+r.Next(10, 100)/100F, fs2=r.Next(0, 10)+r.Next(10, 100)/100F, fs3=r.Next(0, 10)+r.Next(10, 100)/100F, fs4=r.Next(0, 10)+r.Next(10, 100)/100F;
            MetinYaz�l�m� metin = new MetinYaz�l�m� ("Merhaba d�nya!");
            Sayfa�l�ekleme �l� = (Sayfa�l�ekleme) metin;
            �l�.sayfaBa�l��� (fs1); �l�.sayfaAyakl��� (fs2); �l�.sayfaSolmarj� (fs3); �l�.sayfaSa�marj� (fs4);
            �l�.yaz();

            Console.WriteLine ("\n�oklu aray�z�n ayn�/farkl� metotlar�n�n tiplenmesi:");
            T�rediS�n�f ts = new T�rediS�n�f();
            ((Kanal)ts).Sonraki(); ((Kitap)ts).Sonraki(); ((M�zik)ts).Sonraki();
            ((Kanal)ts).�nceki(); ((M�zik)ts).�nceki();
            ts.B�l�m();

            Console.WriteLine ("\nAray�z, temel, t�redi, CompareTo() ve Kar��la�t�r()'la 2 tamsay�n�n k�yas�:");
            AltS�n�f as1; AltS�n�f as2;
            as1 = new AltS�n�f (20231510);  as2 = new AltS�n�f (20231510);
            Kar��la�t�r (as1, as2);
            for(i=0; i < 5; i++) {
                ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000);
                as1 = new AltS�n�f (ts1);  as2 = new AltS�n�f (ts2);
                Kar��la�t�r (as1, as2);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}