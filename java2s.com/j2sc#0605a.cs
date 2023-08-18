// j2sc#0605a.cs: Yap� �zelli�i, alan�, kopyalanmas� ve aray�z miras� �rne�i.

using System;
namespace Yap�lar {
    public struct Dikd�rtgen {
        private int en;
        private int boy;
        public int En {get {return en;} set {en = value;} }
        public int Boy {get {return boy;} set {boy = value;}}
    }
    public struct Alanl�Yap� {
        public int X;
        public int Y;
    }
    public struct �zellikliYap� {
        private int �zelX;
        private int �zelY;
        public int X {get {return �zelX;} set {�zelX = value;}}
        public int Y {get {return �zelY;} set {�zelY = value;}}
    }
    struct KompleksSay� {
        public double ger�el;
        public double sanal;
        public KompleksSay� (double ger�el, double sanal) {this.ger�el = ger�el; this.sanal = sanal;}
        public override string ToString() {return String.Format ("{0} + j{1}", ger�el, sanal);}
    }
    struct Yap�1 {public int x;}
    public struct Yap�2 {
        public int x;
        public int y;
        public int z;
        public Yap�2 (int x, int y, int z) {this.x = x; this.y = y; this.z = z;}
        public void G�ster (string a) {Console.Write ( "{0} (x, y, z) = ({1}, {2}, {3})\t", a, x, y, z);}
    }
    struct Say�salYap�: IComparable {//Interface/Araba�la� ebeveyn
        public int ts;
        public Say�salYap� (int ts) {this.ts = ts;} //Kurucu
        public int CompareTo (object nesne2) {
            Say�salYap� sy = (Say�salYap�) nesne2;
            if (ts < sy.ts) return -1;
            else if (ts > sy.ts) return +1;
            else return 0; //e�itse
        }
    }
    class Yap�Alanlar�1 {
        static void Main() {
            Console.Write ("'new' ile yarat�lan ve get-set'le eri�ilen yap� alanlar� ayn� zamanda �zellikleridir. 'set'le de�er atanmas�nda 'value'/de�er anahtarkelimesi, 'get'leyse tan�ml� alan ad� kullan�l�r. Yap� kopyalar�n�n de�er de�i�imleri di�erlerini etkilemez. Ebeveyn aray�z IComparable mirasland���nda ona ait 'System.IComparable.CompareTo(object)' kullan�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yap�sal dikd�rtgenin en/boy atamalar� ve alan hesab�:");
            var r=new Random();
            Dikd�rtgen dd1 = new Dikd�rtgen();
            dd1.En = r.Next (1, 100); dd1.Boy = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd1.En, dd1.Boy, dd1.En * dd1.Boy);
            dd1.En = r.Next (1, 100); dd1.Boy = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd1.En, dd1.Boy, dd1.En * dd1.Boy);
            Dikd�rtgen dd2 = new Dikd�rtgen();
            dd2.En = r.Next (1, 100); dd2.Boy = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd2.En, dd2.Boy, dd2.En * dd2.Boy);
            dd2.En = r.Next (1, 100); dd2.Boy = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd2.En, dd2.Boy, dd2.En * dd2.Boy);

            Console.WriteLine ("\nYap�sal alanlar�n ve �zelliklerin kurulum fark�:");
            Alanl�Yap� �yeliYap�1;
            �zellikliYap� �zellikliYap�1 = new �zellikliYap�();
            �yeliYap�1.X = r.Next (1, 100); �yeliYap�1.Y = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", �yeliYap�1.X, �yeliYap�1.Y, �yeliYap�1.X * �yeliYap�1.Y);
            �zellikliYap�1.X = r.Next (1, 100); �zellikliYap�1.Y = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", �zellikliYap�1.X, �zellikliYap�1.Y, �zellikliYap�1.X * �zellikliYap�1.Y);
            Alanl�Yap� �yeliYap�2 = new Alanl�Yap�();
            �zellikliYap� �zellikliYap�2 = new �zellikliYap�();
            �yeliYap�2.X = r.Next (1, 100); �yeliYap�2.Y = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", �yeliYap�2.X, �yeliYap�2.Y, �yeliYap�2.X * �yeliYap�2.Y);
            �zellikliYap�2.X = r.Next (1, 100); �zellikliYap�2.Y = r.Next (1, 100); Console.WriteLine ("Dikd�rtgen (en, boy) = ({0}, {1})\tAlan = {2}", �zellikliYap�2.X, �zellikliYap�2.Y, �zellikliYap�2.X * �zellikliYap�2.Y);

            Console.WriteLine ("\nYap�sal (public) alanlar�n de�erlerini farkl� y�ntemlerle atamalar:");
            KompleksSay� ks1;
            ks1 = new KompleksSay�(); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1 = new KompleksSay� (3.14, 2.718D); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1 = new KompleksSay� (r.Next (1, 100) + r.Next (1000, 10000) / 10000D, r.Next (1, 100) + r.Next (1000, 10000) / 10000D); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1.ger�el = Math.PI; ks1.sanal = Math.E; Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);

            Console.WriteLine ("\nYap�lar�n kopyalanmas� referanssal de�il de�erseldir:");
            Yap�1 y1a;
            Yap�1 y1b;
            y1a.x = r.Next (1, 100); y1b.x = r.Next (1, 100); Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            y1a = y1b; y1b.x = r.Next (1, 100);  Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            y1a = y1b; y1b.x = r.Next (1, 100);  Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            Yap�2 y2a = new Yap�2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100));
            Yap�2 y2b = y2a; y2a.G�ster ("y2a"); y2b.G�ster ("y2b"); Console.WriteLine();
            y2a = new Yap�2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100)); y2a.G�ster ("y2a"); y2b.G�ster ("y2b"); Console.WriteLine();
            y2b = new Yap�2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100)); y2a.G�ster ("y2a"); y2b.G�ster ("y2b"); Console.WriteLine();

            Console.WriteLine ("\n�ki say�n�n >,<,=/+1,-1,0 durumlar�n�n kar��la�t�r�lmas�:");
            Say�salYap� x = new Say�salYap� (r.Next (-100, 100));
            Say�salYap� y = new Say�salYap� (r.Next (-100, 100));
            IComparable z = (IComparable) x;
            Console.WriteLine ("x(=z[{0}]) kar��la�t�r y({1}) = {2}\tz kar��la�t�r y = {3}", x.ts, y.ts, x.CompareTo (y), z.CompareTo (y));
            x.ts=r.Next (-100, 100); y.ts=r.Next (-100, 100); z = (IComparable) y;
            Console.WriteLine ("x({0}) kar��la�t�r y(=z[{1}]) = {2}\tz kar��la�t�r y = {3}", x.ts, y.ts, x.CompareTo (y), z.CompareTo (y));
            y.ts=r.Next (-100, 100); z = (IComparable) y; int a=y.ts; x.ts=y.ts=r.Next (-100, 100);
            Console.WriteLine ("x(=y[{0}]) kar��la�t�r y = {1}\tz({2}) kar��la�t�r y = {3}", x.ts, x.CompareTo (y), a, z.CompareTo (y));


            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}