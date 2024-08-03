// j2sc#1803c.cs: Ebeveynin base(arg) kurucusu ve IAray�z �ablon alan-metot �rne�i.

using System;
namespace SoysalS�n�f {
    class SoysalA<T> {
        T ns;
        public SoysalA (T n) {ns = n;}  //Kurucu
        public T nsAl() {return ns;}
    }
    class SoysalB<T>: SoysalA<T> {
        public SoysalB (T ns) : base (ns) {} //Kurucu
    }
    class SoysalC <T1, T2> : SoysalA<T1> {
        T2 ns2;
        public SoysalC (T1 n1, T2 n2) : base (n1) {ns2 = n2;} //Kurucu
        public T2 ns2Al() {return ns2;}
    }
    class S�n�fA {
        int no;
        public S�n�fA (int n) {no = n;} //Kurucu
        public int noAl() {return no;}
    }
    class SoysalD<T>: S�n�fA {
        T ns;
        public SoysalD (T n, int m) : base (m) {ns = n;}  //Kurucu
        public T nsAl() {return ns;}
    }
    class SoysalE<T> {
        protected T ns;
        public SoysalE (T n) {ns = n;} //Kurucu
        public virtual T nsAl() {return ns;}
    }
    class SoysalF<T>: SoysalE<T> {
        public SoysalF (T n) : base (n) {} //Kurucu
        public override T nsAl() {return ns;}
    }
    interface SoysalAray�z<T> {T de�eriAl (T de�er);}
    class SoysalG<T> : SoysalAray�z<T> {
        public T de�eriAl (T de�er) {return de�er;}
    }
    class S�n�fH : SoysalAray�z<int>, SoysalAray�z<string>, SoysalAray�z<double>, SoysalAray�z<bool> {
        public int de�eriAl (int d�r) {return d�r;}
        public string de�eriAl (string d�r) {return d�r;}
        public double de�eriAl (double d�r) {return d�r;}
        public bool de�eriAl (bool d�r) {return d�r;}
    }
    public interface ID�rt��lem<T> {
        T Topla (T a, T b);
        T ��kar (T a, T b);
        T �arp (T a, T b);
        T B�l (T a, T b);
        T Kalan (T a, T b);
    }
    public class D�rt��lem: ID�rt��lem<double> {
        public D�rt��lem() {} //Kurucu
        public double Topla (double a, double b) {return a + b;}
        public double ��kar (double a, double b) {return a - b;}
        public double �arp (double a, double b) {return a * b;}
        public double B�l (double a, double b) {return a / b;}
        public double Kalan (double a, double b) {return a % b;}
    }
    class Bulunamad��stisnas�: ApplicationException {}
    public interface Aray�zKimlik {
        string No {get; set;}
        string �sim {get; set;}
    }
    class M�hendis: Aray�zKimlik {
        string isim;
        string no;
        public M�hendis (string i, string n) {isim = i; no = n;} //Kurucu
        public string No {get {return no;} set {no = value;}}
        public string �sim {get {return isim;} set {isim = value;}}
    }
    class Y�netici: Aray�zKimlik {
        string isim, no;
        public Y�netici (string i, string n) {isim = i; no = n;} //Kurucu
        public string No {get {return no;} set {no = value;}}
        public string �sim {get {return isim;} set {isim = value;}}
    }
    class Ziyaret�i {} //Aray�zKimlik ebeveynsiz
    class KimlikListesi<T> where T: Aray�zKimlik {
        public T[] kimlikListesi;
        public int ebat;
        public KimlikListesi() {kimlikListesi = new T [10]; ebat = 0;} //Kurucu
        public bool ekle (T yeniKay�t) {
            if (ebat == 10) return false;
            kimlikListesi [ebat] = yeniKay�t;
            ebat++;
            return true;
        }
        public T adlaBul (string ad) { 
            for (int i=0; i<ebat; i++) {if  (kimlikListesi[i].�sim == ad) return kimlikListesi [i];}
            throw new Bulunamad��stisnas�();
        }
        public T noylaBul (string no) {
            for(int i=0; i<ebat; i++) {if(kimlikListesi [i].No == no) return kimlikListesi [i];}
            throw new Bulunamad��stisnas�();
        }
    }
    class S�n�fT {
        static void Main() {
            Console.Write ("Ebeveyn alan� kurucuda base(prm) ile kullan�l�r. IAray�z ebeveyn genelde alan ve metot �ablonlar� sunar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal/Asoysal ebeveyn alan�na ve kendi ayn�/farkl� alanlar�na eri�im:");
            SoysalB<string> sBstr = new SoysalB<string> ("Merhabalar!"); Console.WriteLine (sBstr.nsAl());
            SoysalB<int> sBint = new SoysalB<int> (20240726); Console.WriteLine (sBint.nsAl());
            SoysalB<bool> sBbool = new SoysalB<bool> (true); Console.WriteLine (sBbool.nsAl());
            SoysalB<double> sBdbl = new SoysalB<double> (20240726.0452); Console.WriteLine (sBdbl.nsAl());
            SoysalC<string, int> sC1 = new SoysalC<string, int> ("Atat�rk", 1881); Console.WriteLine ("\t{0}: {1}", sC1.nsAl(), sC1.ns2Al());
            SoysalC<int, string> sC2 = new SoysalC<int, string> (1919, "Samsun"); Console.WriteLine ("\t{0}: {1}", sC2.nsAl(), sC2.ns2Al());
            SoysalC<int, bool> sC3 = new SoysalC<int, bool> (1923, true); Console.WriteLine ("\t{0}: {1}", sC3.nsAl(), sC3.ns2Al());
            SoysalD<String> sD1 = new SoysalD<String> ("Tarih", 20240726); Console.WriteLine (sD1.nsAl() + ": " + sD1.noAl());
            SoysalD<double> sD2 = new SoysalD<double> (20240726.0525, 240726); Console.WriteLine (sD2.nsAl() + ": " + sD2.noAl());
            SoysalE<int> sE = new SoysalE<int> (1881); Console.WriteLine ("\tSoysalE ns: {0}", sE.nsAl());
            sE = new SoysalF<int>(1938); Console.WriteLine ("\tSoysalF ns: {0}", sE.nsAl());

            Console.WriteLine ("\nSoysalAray�z ebeveynin soysal parametreli metot gerid�n�� �ablonu:");
            SoysalG<int> sGint = new SoysalG<int>();
            SoysalG<string> sGstr = new SoysalG<string>();
            SoysalG<double> sGdbl = new SoysalG<double>();
            SoysalG<bool> sGbool = new SoysalG<bool>();
            Console.WriteLine ("Tamsay�: {0}", sGint.de�eriAl (20240727));
            Console.WriteLine ("Dizge: {0}", sGstr.de�eriAl ("M.Nihat Yava�"));
            Console.WriteLine ("Duble: {0}", sGdbl.de�eriAl (20240727.0613));
            Console.WriteLine ("Bool: {0}", sGbool.de�eriAl (true));
            S�n�fH sH = new S�n�fH(); Console.WriteLine ("\tTamsay�: {0}", sH.de�eriAl (20240727));
            Console.WriteLine ("\tDizge: {0}", sH.de�eriAl ("M.Nihat Yava�"));
            Console.WriteLine ("\tDuble: {0}", sH.de�eriAl (20240727.0613));
            Console.WriteLine ("\tBool: {0}", sH.de�eriAl (true));

            Console.WriteLine ("\nSoysalAray�z metotlar� �ablonlu ebeveynle d�rt i�lem:");
            D�rt��lem i� = new D�rt��lem();
            var r=new Random(); int a, b, i;
            for(i=0;i<5;i++) {
                a=r.Next(0,1000); b=r.Next(1,1000);
                Console.WriteLine ("a={0,3}, b={1,3} ise +:{2,4}, -:{3,4}, *:{4,6}, /:{5,7:0.0###}, %:{6,3}", a, b, i�.Topla (a, b), i�.��kar (a, b), i�.�arp (a, b), i�.B�l (a, b), i�.Kalan (a, b));
            }

            Console.WriteLine ("\n�sim-No aray�z ebeveynli m�hendis ve y�netici listeleri:");
            KimlikListesi<M�hendis> kl1 = new KimlikListesi<M�hendis>();
            kl1.ekle (new M�hendis ("Sevim Yava�", "M1001"));
            kl1.ekle (new M�hendis ("Canan Candan", "M1002"));
            kl1.ekle (new M�hendis ("Zafer N.Candan", "M1003"));
            kl1.ekle (new M�hendis ("M.Nihat Yava�", "M1004"));
            kl1.ekle (new M�hendis ("Y�cel K���kbay", "M1005"));
            Console.WriteLine ("\t==>M�hendislerin listesi:");
            for(i=0;i<kl1.ebat;i++) {Console.WriteLine ("No: {0}\t�sim: {1}", kl1.kimlikListesi [i].No, kl1.kimlikListesi [i].�sim);}
            string aranan="Canan Candan"; try {M�hendis mbul = kl1.adlaBul (aranan); Console.WriteLine (mbul.�sim + ": " + mbul.No);} catch (Bulunamad��stisnas�) {Console.WriteLine ("Bulunamad�");}
            aranan="Canan Eksio�lu"; try {M�hendis mbul = kl1.adlaBul (aranan); Console.WriteLine ("BULUNDU (" + mbul.�sim + ": " + mbul.No + ")");} catch (Bulunamad��stisnas�) {Console.WriteLine ("BULUNAMADI (" + aranan + ")");}
            KimlikListesi<Y�netici> kl2 = new KimlikListesi<Y�netici>();
            kl2.ekle (new Y�netici ("Hatice Yava� Ka�ar", "Y2001"));
            kl2.ekle (new Y�netici ("Zehra Nihal Candan", "Y2002"));
            kl2.ekle (new Y�netici ("Song�l Y.G�kt�rk", "Y2003"));
            kl2.ekle (new Y�netici ("S�heyla Y.�zbay", "Y2004"));
            kl2.ekle (new Y�netici ("H�lya Piray", "Y2005"));
            Console.WriteLine ("\t==>Y�neticilerin listesi:");
            for(i=0;i<kl2.ebat;i++) {Console.WriteLine ("No: {0}\t�sim: {1}", kl2.kimlikListesi [i].No, kl2.kimlikListesi [i].�sim);}
            aranan="Y2005"; try {Y�netici mbul = kl2.noylaBul (aranan); Console.WriteLine (mbul.�sim + ": " + mbul.No);} catch (Bulunamad��stisnas�) {Console.WriteLine ("Bulunamad�");}
            aranan="Y2024"; try {Y�netici mbul = kl2.noylaBul (aranan); Console.WriteLine ("BULUNDU (" + mbul.�sim + ": " + mbul.No + ")");} catch (Bulunamad��stisnas�) {Console.WriteLine ("BULUNAMADI (" + aranan + ")");}
            // KimlikListesi<Ziyaret�i> kl3 = new KimlikListesi<Ziyaret�i>(); //Hata! ��nk� Aray�zKimlik ebeveynsiz

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}