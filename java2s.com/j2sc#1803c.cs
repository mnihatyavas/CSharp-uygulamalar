// j2sc#1803c.cs: Ebeveynin base(arg) kurucusu ve IArayüz þablon alan-metot örneði.

using System;
namespace SoysalSýnýf {
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
    class SýnýfA {
        int no;
        public SýnýfA (int n) {no = n;} //Kurucu
        public int noAl() {return no;}
    }
    class SoysalD<T>: SýnýfA {
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
    interface SoysalArayüz<T> {T deðeriAl (T deðer);}
    class SoysalG<T> : SoysalArayüz<T> {
        public T deðeriAl (T deðer) {return deðer;}
    }
    class SýnýfH : SoysalArayüz<int>, SoysalArayüz<string>, SoysalArayüz<double>, SoysalArayüz<bool> {
        public int deðeriAl (int dðr) {return dðr;}
        public string deðeriAl (string dðr) {return dðr;}
        public double deðeriAl (double dðr) {return dðr;}
        public bool deðeriAl (bool dðr) {return dðr;}
    }
    public interface IDörtÝþlem<T> {
        T Topla (T a, T b);
        T Çýkar (T a, T b);
        T Çarp (T a, T b);
        T Böl (T a, T b);
        T Kalan (T a, T b);
    }
    public class DörtÝþlem: IDörtÝþlem<double> {
        public DörtÝþlem() {} //Kurucu
        public double Topla (double a, double b) {return a + b;}
        public double Çýkar (double a, double b) {return a - b;}
        public double Çarp (double a, double b) {return a * b;}
        public double Böl (double a, double b) {return a / b;}
        public double Kalan (double a, double b) {return a % b;}
    }
    class BulunamadýÝstisnasý: ApplicationException {}
    public interface ArayüzKimlik {
        string No {get; set;}
        string Ýsim {get; set;}
    }
    class Mühendis: ArayüzKimlik {
        string isim;
        string no;
        public Mühendis (string i, string n) {isim = i; no = n;} //Kurucu
        public string No {get {return no;} set {no = value;}}
        public string Ýsim {get {return isim;} set {isim = value;}}
    }
    class Yönetici: ArayüzKimlik {
        string isim, no;
        public Yönetici (string i, string n) {isim = i; no = n;} //Kurucu
        public string No {get {return no;} set {no = value;}}
        public string Ýsim {get {return isim;} set {isim = value;}}
    }
    class Ziyaretçi {} //ArayüzKimlik ebeveynsiz
    class KimlikListesi<T> where T: ArayüzKimlik {
        public T[] kimlikListesi;
        public int ebat;
        public KimlikListesi() {kimlikListesi = new T [10]; ebat = 0;} //Kurucu
        public bool ekle (T yeniKayýt) {
            if (ebat == 10) return false;
            kimlikListesi [ebat] = yeniKayýt;
            ebat++;
            return true;
        }
        public T adlaBul (string ad) { 
            for (int i=0; i<ebat; i++) {if  (kimlikListesi[i].Ýsim == ad) return kimlikListesi [i];}
            throw new BulunamadýÝstisnasý();
        }
        public T noylaBul (string no) {
            for(int i=0; i<ebat; i++) {if(kimlikListesi [i].No == no) return kimlikListesi [i];}
            throw new BulunamadýÝstisnasý();
        }
    }
    class SýnýfT {
        static void Main() {
            Console.Write ("Ebeveyn alaný kurucuda base(prm) ile kullanýlýr. IArayüz ebeveyn genelde alan ve metot þablonlarý sunar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Soysal/Asoysal ebeveyn alanýna ve kendi ayný/farklý alanlarýna eriþim:");
            SoysalB<string> sBstr = new SoysalB<string> ("Merhabalar!"); Console.WriteLine (sBstr.nsAl());
            SoysalB<int> sBint = new SoysalB<int> (20240726); Console.WriteLine (sBint.nsAl());
            SoysalB<bool> sBbool = new SoysalB<bool> (true); Console.WriteLine (sBbool.nsAl());
            SoysalB<double> sBdbl = new SoysalB<double> (20240726.0452); Console.WriteLine (sBdbl.nsAl());
            SoysalC<string, int> sC1 = new SoysalC<string, int> ("Atatürk", 1881); Console.WriteLine ("\t{0}: {1}", sC1.nsAl(), sC1.ns2Al());
            SoysalC<int, string> sC2 = new SoysalC<int, string> (1919, "Samsun"); Console.WriteLine ("\t{0}: {1}", sC2.nsAl(), sC2.ns2Al());
            SoysalC<int, bool> sC3 = new SoysalC<int, bool> (1923, true); Console.WriteLine ("\t{0}: {1}", sC3.nsAl(), sC3.ns2Al());
            SoysalD<String> sD1 = new SoysalD<String> ("Tarih", 20240726); Console.WriteLine (sD1.nsAl() + ": " + sD1.noAl());
            SoysalD<double> sD2 = new SoysalD<double> (20240726.0525, 240726); Console.WriteLine (sD2.nsAl() + ": " + sD2.noAl());
            SoysalE<int> sE = new SoysalE<int> (1881); Console.WriteLine ("\tSoysalE ns: {0}", sE.nsAl());
            sE = new SoysalF<int>(1938); Console.WriteLine ("\tSoysalF ns: {0}", sE.nsAl());

            Console.WriteLine ("\nSoysalArayüz ebeveynin soysal parametreli metot geridönüþ þablonu:");
            SoysalG<int> sGint = new SoysalG<int>();
            SoysalG<string> sGstr = new SoysalG<string>();
            SoysalG<double> sGdbl = new SoysalG<double>();
            SoysalG<bool> sGbool = new SoysalG<bool>();
            Console.WriteLine ("Tamsayý: {0}", sGint.deðeriAl (20240727));
            Console.WriteLine ("Dizge: {0}", sGstr.deðeriAl ("M.Nihat Yavaþ"));
            Console.WriteLine ("Duble: {0}", sGdbl.deðeriAl (20240727.0613));
            Console.WriteLine ("Bool: {0}", sGbool.deðeriAl (true));
            SýnýfH sH = new SýnýfH(); Console.WriteLine ("\tTamsayý: {0}", sH.deðeriAl (20240727));
            Console.WriteLine ("\tDizge: {0}", sH.deðeriAl ("M.Nihat Yavaþ"));
            Console.WriteLine ("\tDuble: {0}", sH.deðeriAl (20240727.0613));
            Console.WriteLine ("\tBool: {0}", sH.deðeriAl (true));

            Console.WriteLine ("\nSoysalArayüz metotlarý þablonlu ebeveynle dört iþlem:");
            DörtÝþlem iþ = new DörtÝþlem();
            var r=new Random(); int a, b, i;
            for(i=0;i<5;i++) {
                a=r.Next(0,1000); b=r.Next(1,1000);
                Console.WriteLine ("a={0,3}, b={1,3} ise +:{2,4}, -:{3,4}, *:{4,6}, /:{5,7:0.0###}, %:{6,3}", a, b, iþ.Topla (a, b), iþ.Çýkar (a, b), iþ.Çarp (a, b), iþ.Böl (a, b), iþ.Kalan (a, b));
            }

            Console.WriteLine ("\nÝsim-No arayüz ebeveynli mühendis ve yönetici listeleri:");
            KimlikListesi<Mühendis> kl1 = new KimlikListesi<Mühendis>();
            kl1.ekle (new Mühendis ("Sevim Yavaþ", "M1001"));
            kl1.ekle (new Mühendis ("Canan Candan", "M1002"));
            kl1.ekle (new Mühendis ("Zafer N.Candan", "M1003"));
            kl1.ekle (new Mühendis ("M.Nihat Yavaþ", "M1004"));
            kl1.ekle (new Mühendis ("Yücel Küçükbay", "M1005"));
            Console.WriteLine ("\t==>Mühendislerin listesi:");
            for(i=0;i<kl1.ebat;i++) {Console.WriteLine ("No: {0}\tÝsim: {1}", kl1.kimlikListesi [i].No, kl1.kimlikListesi [i].Ýsim);}
            string aranan="Canan Candan"; try {Mühendis mbul = kl1.adlaBul (aranan); Console.WriteLine (mbul.Ýsim + ": " + mbul.No);} catch (BulunamadýÝstisnasý) {Console.WriteLine ("Bulunamadý");}
            aranan="Canan Eksioðlu"; try {Mühendis mbul = kl1.adlaBul (aranan); Console.WriteLine ("BULUNDU (" + mbul.Ýsim + ": " + mbul.No + ")");} catch (BulunamadýÝstisnasý) {Console.WriteLine ("BULUNAMADI (" + aranan + ")");}
            KimlikListesi<Yönetici> kl2 = new KimlikListesi<Yönetici>();
            kl2.ekle (new Yönetici ("Hatice Yavaþ Kaçar", "Y2001"));
            kl2.ekle (new Yönetici ("Zehra Nihal Candan", "Y2002"));
            kl2.ekle (new Yönetici ("Songül Y.Göktürk", "Y2003"));
            kl2.ekle (new Yönetici ("Süheyla Y.Özbay", "Y2004"));
            kl2.ekle (new Yönetici ("Hülya Piray", "Y2005"));
            Console.WriteLine ("\t==>Yöneticilerin listesi:");
            for(i=0;i<kl2.ebat;i++) {Console.WriteLine ("No: {0}\tÝsim: {1}", kl2.kimlikListesi [i].No, kl2.kimlikListesi [i].Ýsim);}
            aranan="Y2005"; try {Yönetici mbul = kl2.noylaBul (aranan); Console.WriteLine (mbul.Ýsim + ": " + mbul.No);} catch (BulunamadýÝstisnasý) {Console.WriteLine ("Bulunamadý");}
            aranan="Y2024"; try {Yönetici mbul = kl2.noylaBul (aranan); Console.WriteLine ("BULUNDU (" + mbul.Ýsim + ": " + mbul.No + ")");} catch (BulunamadýÝstisnasý) {Console.WriteLine ("BULUNAMADI (" + aranan + ")");}
            // KimlikListesi<Ziyaretçi> kl3 = new KimlikListesi<Ziyaretçi>(); //Hata! Çünkü ArayüzKimlik ebeveynsiz

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}