// j2sc#0603b.cs: Varsayýlý, soysal tipli ve farklý parametreli kurucu tanýmlarý örneði.

using System;
namespace Yapýlar {
    struct Kitap {
         public string yazar; 
         public string kitapadý; 
         public int yayýmyýlý; 
         public Kitap (string y, string ka, int yy) {yazar = y; kitapadý = ka; yayýmyýlý = yy;} //Kurucu
    }
    public struct KompleksSayý {
        private double gerçel;
        private double sanal;
        public KompleksSayý (double gerçel, double sanal) {this.gerçel = gerçel; this.sanal = sanal;}
        //public KompleksSayý (double gerçel):this (gerçel, 0) {this.gerçel = gerçel;}
        public KompleksSayý (double gerçel):this() {this.gerçel = gerçel;}
        public override string ToString() {return String.Format ("Kompleks sayý = ({0} + j{1})", gerçel, sanal);}
    }
    struct SoysalYapý1<T> {
        T x; 
        T y; 
        public SoysalYapý1 (T a, T b) {x = a; y = b;}
        public T X {get {return x;} set {x = value;} }
        public T Y {get {return y;} set {y = value;}}
    }
    struct SoysalYapý2<Tip>{
        private Tip _Veri;
        public SoysalYapý2 (Tip deðer) {_Veri = deðer;}
        public Tip Veri {get {return _Veri;} set {_Veri = value;} }
    }
    class Kurucu2 {
        static void Main() {
            Console.Write ("'new Yapý()' varsayýlý parametresiz nesneyi yaratýr. Farklý parametreli çoklu kurucu tanýmlanabilir. Soysal<Tip> yapýlar, farklý tiplemeli deðer atamalarýný mümkün kýlar. 'set' deðer atamalarý 'set{alan=value;}' ile yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kitap bilgileri gösterilmek için öncelikle yaratýlmalýdýr:");
            Kitap kitap1 = new Kitap ("Hatice Y.Kaçar", "Neden Nebi Olunur?", 1992);
            Kitap kitap2 = new Kitap(); //Varsayýlý kuruculu
            Kitap kitap3;
            Console.WriteLine ("1.Kitap) " + kitap1.kitapadý + "\tYazarý: " + kitap1.yazar + "\tYayým yýlý: " + kitap1.yayýmyýlý);
            if (kitap2.kitapadý == null) Console.WriteLine ("2.Kitap) kitap2.kitapadý henüz atanmamýþ.");
            kitap2.kitapadý = "Dublex Villa Ýnþaatý"; kitap2.yazar = "Sevim Yavaþ"; kitap2.yayýmyýlý = 2005;
            Console.WriteLine ("\t==>kitap2 bilgileri þimdi mevcut.");
            Console.WriteLine ("2.Kitap) " + kitap2.kitapadý + "\tYazarý: " + kitap2.yazar + "\tYayým yýlý: " + kitap2.yayýmyýlý);
            //try {Console.WriteLine ("3.Kitap) " + kitap3.kitapadý);}catch (Exception h){Console.WriteLine ("HATA: {0}", h.Message);}
            kitap3.kitapadý = "Çobanlýktan Anýnda Vahiy-Tiyoculuk Mertebesine Liyakat";
            Console.WriteLine ("3.Kitap) " + kitap3.kitapadý);

            Console.WriteLine ("\nFarklý kuruculu kompleks sayý yaratma:");
            KompleksSayý ks1 = new KompleksSayý (Math.PI, Math.E); Console.WriteLine (ks1);
            KompleksSayý ks2 = new KompleksSayý (Math.E, Math.PI); Console.WriteLine (ks2);
            KompleksSayý ks3 = new KompleksSayý (Math.PI * Math.E, Math.E / Math.PI); Console.WriteLine (ks3);
            KompleksSayý ks4 = new KompleksSayý (Math.PI + Math.E); Console.WriteLine (ks4);
            KompleksSayý ks5 = new KompleksSayý(); Console.WriteLine (ks5);

            Console.WriteLine ("\nSoysalYapý<T>'lý deðiþken çift alan tipli yapýlar:");
            SoysalYapý1<int> xy1 = new SoysalYapý1<int> (1952, 2023);
            SoysalYapý1<double> xy2 = new SoysalYapý1<double> (Math.PI, Math.E);
            SoysalYapý1<bool> xy3 = new SoysalYapý1<bool> (true, false);
            SoysalYapý1<string> xy4 = new SoysalYapý1<string> ("M.Nihat Yavaþ", "Yeþilyurt / Malatya");
            Console.WriteLine ("<int>: (xy1.X, xy1.Y) = ({0}, {1})", xy1.X, xy1.Y);
            Console.WriteLine ("<doublet>: (xy2.X, xy2.Y) = ({0}, {1})", xy2.X, xy2.Y);
            Console.WriteLine ("<bool>: (xy3.X, xy3.Y) = ({0}, {1})", xy3.X, xy3.Y);
            Console.WriteLine ("<string>: (xy4.X, xy4.Y) = ({0}, {1})", xy4.X, xy4.Y);

            Console.WriteLine ("\nSoysalYapý<Tip>'lý deðiþken tek alan tipli yapýlar:");
            SoysalYapý2<int> ts = new SoysalYapý2<int> (1955);
            SoysalYapý2<string> dzg = new SoysalYapý2<string> ("Z.Nihal Candan");
            SoysalYapý2<long> ls = new SoysalYapý2<long> (long.MaxValue);
            SoysalYapý2<double> ds = new SoysalYapý2<double> (double.MinValue);
            Console.WriteLine ("<string> = {0}", dzg.Veri);
            Console.WriteLine ("<long> = {0}", ls.Veri);
            Console.WriteLine ("<double> = {0}", ds.Veri);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}