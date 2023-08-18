// j2sc#0605a.cs: Yapý özelliði, alaný, kopyalanmasý ve arayüz mirasý örneði.

using System;
namespace Yapýlar {
    public struct Dikdörtgen {
        private int en;
        private int boy;
        public int En {get {return en;} set {en = value;} }
        public int Boy {get {return boy;} set {boy = value;}}
    }
    public struct AlanlýYapý {
        public int X;
        public int Y;
    }
    public struct ÖzellikliYapý {
        private int ÖzelX;
        private int ÖzelY;
        public int X {get {return ÖzelX;} set {ÖzelX = value;}}
        public int Y {get {return ÖzelY;} set {ÖzelY = value;}}
    }
    struct KompleksSayý {
        public double gerçel;
        public double sanal;
        public KompleksSayý (double gerçel, double sanal) {this.gerçel = gerçel; this.sanal = sanal;}
        public override string ToString() {return String.Format ("{0} + j{1}", gerçel, sanal);}
    }
    struct Yapý1 {public int x;}
    public struct Yapý2 {
        public int x;
        public int y;
        public int z;
        public Yapý2 (int x, int y, int z) {this.x = x; this.y = y; this.z = z;}
        public void Göster (string a) {Console.Write ( "{0} (x, y, z) = ({1}, {2}, {3})\t", a, x, y, z);}
    }
    struct SayýsalYapý: IComparable {//Interface/Arabaðlaç ebeveyn
        public int ts;
        public SayýsalYapý (int ts) {this.ts = ts;} //Kurucu
        public int CompareTo (object nesne2) {
            SayýsalYapý sy = (SayýsalYapý) nesne2;
            if (ts < sy.ts) return -1;
            else if (ts > sy.ts) return +1;
            else return 0; //eþitse
        }
    }
    class YapýAlanlarý1 {
        static void Main() {
            Console.Write ("'new' ile yaratýlan ve get-set'le eriþilen yapý alanlarý ayný zamanda özellikleridir. 'set'le deðer atanmasýnda 'value'/deðer anahtarkelimesi, 'get'leyse tanýmlý alan adý kullanýlýr. Yapý kopyalarýnýn deðer deðiþimleri diðerlerini etkilemez. Ebeveyn arayüz IComparable miraslandýðýnda ona ait 'System.IComparable.CompareTo(object)' kullanýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Yapýsal dikdörtgenin en/boy atamalarý ve alan hesabý:");
            var r=new Random();
            Dikdörtgen dd1 = new Dikdörtgen();
            dd1.En = r.Next (1, 100); dd1.Boy = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd1.En, dd1.Boy, dd1.En * dd1.Boy);
            dd1.En = r.Next (1, 100); dd1.Boy = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd1.En, dd1.Boy, dd1.En * dd1.Boy);
            Dikdörtgen dd2 = new Dikdörtgen();
            dd2.En = r.Next (1, 100); dd2.Boy = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd2.En, dd2.Boy, dd2.En * dd2.Boy);
            dd2.En = r.Next (1, 100); dd2.Boy = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", dd2.En, dd2.Boy, dd2.En * dd2.Boy);

            Console.WriteLine ("\nYapýsal alanlarýn ve özelliklerin kurulum farký:");
            AlanlýYapý üyeliYapý1;
            ÖzellikliYapý özellikliYapý1 = new ÖzellikliYapý();
            üyeliYapý1.X = r.Next (1, 100); üyeliYapý1.Y = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", üyeliYapý1.X, üyeliYapý1.Y, üyeliYapý1.X * üyeliYapý1.Y);
            özellikliYapý1.X = r.Next (1, 100); özellikliYapý1.Y = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", özellikliYapý1.X, özellikliYapý1.Y, özellikliYapý1.X * özellikliYapý1.Y);
            AlanlýYapý üyeliYapý2 = new AlanlýYapý();
            ÖzellikliYapý özellikliYapý2 = new ÖzellikliYapý();
            üyeliYapý2.X = r.Next (1, 100); üyeliYapý2.Y = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", üyeliYapý2.X, üyeliYapý2.Y, üyeliYapý2.X * üyeliYapý2.Y);
            özellikliYapý2.X = r.Next (1, 100); özellikliYapý2.Y = r.Next (1, 100); Console.WriteLine ("Dikdörtgen (en, boy) = ({0}, {1})\tAlan = {2}", özellikliYapý2.X, özellikliYapý2.Y, özellikliYapý2.X * özellikliYapý2.Y);

            Console.WriteLine ("\nYapýsal (public) alanlarýn deðerlerini farklý yöntemlerle atamalar:");
            KompleksSayý ks1;
            ks1 = new KompleksSayý(); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1 = new KompleksSayý (3.14, 2.718D); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1 = new KompleksSayý (r.Next (1, 100) + r.Next (1000, 10000) / 10000D, r.Next (1, 100) + r.Next (1000, 10000) / 10000D); Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);
            ks1.gerçel = Math.PI; ks1.sanal = Math.E; Console.WriteLine ("Kompleks say1-1 = ({0})", ks1);

            Console.WriteLine ("\nYapýlarýn kopyalanmasý referanssal deðil deðerseldir:");
            Yapý1 y1a;
            Yapý1 y1b;
            y1a.x = r.Next (1, 100); y1b.x = r.Next (1, 100); Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            y1a = y1b; y1b.x = r.Next (1, 100);  Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            y1a = y1b; y1b.x = r.Next (1, 100);  Console.WriteLine ("y1a.x = {0}\ty1b.x = {1}", y1a.x, y1b.x);
            Yapý2 y2a = new Yapý2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100));
            Yapý2 y2b = y2a; y2a.Göster ("y2a"); y2b.Göster ("y2b"); Console.WriteLine();
            y2a = new Yapý2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100)); y2a.Göster ("y2a"); y2b.Göster ("y2b"); Console.WriteLine();
            y2b = new Yapý2 (r.Next (1, 100), r.Next (1, 100), r.Next (1, 100)); y2a.Göster ("y2a"); y2b.Göster ("y2b"); Console.WriteLine();

            Console.WriteLine ("\nÝki sayýnýn >,<,=/+1,-1,0 durumlarýnýn karþýlaþtýrýlmasý:");
            SayýsalYapý x = new SayýsalYapý (r.Next (-100, 100));
            SayýsalYapý y = new SayýsalYapý (r.Next (-100, 100));
            IComparable z = (IComparable) x;
            Console.WriteLine ("x(=z[{0}]) karþýlaþtýr y({1}) = {2}\tz karþýlaþtýr y = {3}", x.ts, y.ts, x.CompareTo (y), z.CompareTo (y));
            x.ts=r.Next (-100, 100); y.ts=r.Next (-100, 100); z = (IComparable) y;
            Console.WriteLine ("x({0}) karþýlaþtýr y(=z[{1}]) = {2}\tz karþýlaþtýr y = {3}", x.ts, y.ts, x.CompareTo (y), z.CompareTo (y));
            y.ts=r.Next (-100, 100); z = (IComparable) y; int a=y.ts; x.ts=y.ts=r.Next (-100, 100);
            Console.WriteLine ("x(=y[{0}]) karþýlaþtýr y = {1}\tz({2}) karþýlaþtýr y = {3}", x.ts, x.CompareTo (y), a, z.CompareTo (y));


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}