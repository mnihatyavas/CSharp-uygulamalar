// j2sc#0603b.cs: Varsay�l�, soysal tipli ve farkl� parametreli kurucu tan�mlar� �rne�i.

using System;
namespace Yap�lar {
    struct Kitap {
         public string yazar; 
         public string kitapad�; 
         public int yay�my�l�; 
         public Kitap (string y, string ka, int yy) {yazar = y; kitapad� = ka; yay�my�l� = yy;} //Kurucu
    }
    public struct KompleksSay� {
        private double ger�el;
        private double sanal;
        public KompleksSay� (double ger�el, double sanal) {this.ger�el = ger�el; this.sanal = sanal;}
        //public KompleksSay� (double ger�el):this (ger�el, 0) {this.ger�el = ger�el;}
        public KompleksSay� (double ger�el):this() {this.ger�el = ger�el;}
        public override string ToString() {return String.Format ("Kompleks say� = ({0} + j{1})", ger�el, sanal);}
    }
    struct SoysalYap�1<T> {
        T x; 
        T y; 
        public SoysalYap�1 (T a, T b) {x = a; y = b;}
        public T X {get {return x;} set {x = value;} }
        public T Y {get {return y;} set {y = value;}}
    }
    struct SoysalYap�2<Tip>{
        private Tip _Veri;
        public SoysalYap�2 (Tip de�er) {_Veri = de�er;}
        public Tip Veri {get {return _Veri;} set {_Veri = value;} }
    }
    class Kurucu2 {
        static void Main() {
            Console.Write ("'new Yap�()' varsay�l� parametresiz nesneyi yarat�r. Farkl� parametreli �oklu kurucu tan�mlanabilir. Soysal<Tip> yap�lar, farkl� tiplemeli de�er atamalar�n� m�mk�n k�lar. 'set' de�er atamalar� 'set{alan=value;}' ile yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Kitap bilgileri g�sterilmek i�in �ncelikle yarat�lmal�d�r:");
            Kitap kitap1 = new Kitap ("Hatice Y.Ka�ar", "Neden Nebi Olunur?", 1992);
            Kitap kitap2 = new Kitap(); //Varsay�l� kuruculu
            Kitap kitap3;
            Console.WriteLine ("1.Kitap) " + kitap1.kitapad� + "\tYazar�: " + kitap1.yazar + "\tYay�m y�l�: " + kitap1.yay�my�l�);
            if (kitap2.kitapad� == null) Console.WriteLine ("2.Kitap) kitap2.kitapad� hen�z atanmam��.");
            kitap2.kitapad� = "Dublex Villa �n�aat�"; kitap2.yazar = "Sevim Yava�"; kitap2.yay�my�l� = 2005;
            Console.WriteLine ("\t==>kitap2 bilgileri �imdi mevcut.");
            Console.WriteLine ("2.Kitap) " + kitap2.kitapad� + "\tYazar�: " + kitap2.yazar + "\tYay�m y�l�: " + kitap2.yay�my�l�);
            //try {Console.WriteLine ("3.Kitap) " + kitap3.kitapad�);}catch (Exception h){Console.WriteLine ("HATA: {0}", h.Message);}
            kitap3.kitapad� = "�obanl�ktan An�nda Vahiy-Tiyoculuk Mertebesine Liyakat";
            Console.WriteLine ("3.Kitap) " + kitap3.kitapad�);

            Console.WriteLine ("\nFarkl� kuruculu kompleks say� yaratma:");
            KompleksSay� ks1 = new KompleksSay� (Math.PI, Math.E); Console.WriteLine (ks1);
            KompleksSay� ks2 = new KompleksSay� (Math.E, Math.PI); Console.WriteLine (ks2);
            KompleksSay� ks3 = new KompleksSay� (Math.PI * Math.E, Math.E / Math.PI); Console.WriteLine (ks3);
            KompleksSay� ks4 = new KompleksSay� (Math.PI + Math.E); Console.WriteLine (ks4);
            KompleksSay� ks5 = new KompleksSay�(); Console.WriteLine (ks5);

            Console.WriteLine ("\nSoysalYap�<T>'l� de�i�ken �ift alan tipli yap�lar:");
            SoysalYap�1<int> xy1 = new SoysalYap�1<int> (1952, 2023);
            SoysalYap�1<double> xy2 = new SoysalYap�1<double> (Math.PI, Math.E);
            SoysalYap�1<bool> xy3 = new SoysalYap�1<bool> (true, false);
            SoysalYap�1<string> xy4 = new SoysalYap�1<string> ("M.Nihat Yava�", "Ye�ilyurt / Malatya");
            Console.WriteLine ("<int>: (xy1.X, xy1.Y) = ({0}, {1})", xy1.X, xy1.Y);
            Console.WriteLine ("<doublet>: (xy2.X, xy2.Y) = ({0}, {1})", xy2.X, xy2.Y);
            Console.WriteLine ("<bool>: (xy3.X, xy3.Y) = ({0}, {1})", xy3.X, xy3.Y);
            Console.WriteLine ("<string>: (xy4.X, xy4.Y) = ({0}, {1})", xy4.X, xy4.Y);

            Console.WriteLine ("\nSoysalYap�<Tip>'l� de�i�ken tek alan tipli yap�lar:");
            SoysalYap�2<int> ts = new SoysalYap�2<int> (1955);
            SoysalYap�2<string> dzg = new SoysalYap�2<string> ("Z.Nihal Candan");
            SoysalYap�2<long> ls = new SoysalYap�2<long> (long.MaxValue);
            SoysalYap�2<double> ds = new SoysalYap�2<double> (double.MinValue);
            Console.WriteLine ("<string> = {0}", dzg.Veri);
            Console.WriteLine ("<long> = {0}", ls.Veri);
            Console.WriteLine ("<double> = {0}", ds.Veri);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}