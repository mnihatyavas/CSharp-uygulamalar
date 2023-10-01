// j2sc#0710.cs: Sýnýf alan 'this', 'new'le nesnel tipleme, 'null'la nesnel hiçleme örneði.

using System;
namespace Sýnýflar {
    class Sýnýf1 {
        int x;
        int y;
        public Sýnýf1 (int x) {this.x = x;} //Tek parametreli kurucu
        public Sýnýf1 (int x, int y): this (x) {this.y = y;}
        public int X {get {return (x);} }
        public int Y {get {return (y);} }
    }
    class XYZkordinat {//3 farklý (aþýrýyüklü) kuruculu
        int x, y, z;   
        public XYZkordinat() : this (0, 0, 0) {Console.WriteLine ("XYZkordinat() kurucusundayým");}
        public XYZkordinat (XYZkordinat nesne) : this (nesne.x, nesne.y, nesne.z) {Console.WriteLine ("XYZkordinat (nesne) kurucusundayým");}
        public XYZkordinat (int i, int j, int k) {Console.WriteLine ("XYZkordinat (int, int, int) kurucusundayým"); x = i; y = j; this.z = k;}
        public void Göster() {Console.WriteLine ("XYZkordinat (x, y, z) = ({0}, {1}, {2})", this.x, y, z);}
    }
    class Ev {
        public string marka;
        public string model;
        public string renk;
        public int inþaaYýlý;
        public void Baþlat (DateTime t) {Console.WriteLine ("Ýþaat [{0}] tarihinde baþladý", t);}
        public void Bitir() {Console.WriteLine ("Ýþaat [{0}] tarihte tamamlandý", DateTime.Now);}
    }
    class ThisNewNull {
        int sayaç;
        public void Say() {sayaç +=2; this.sayaç--;}
        static void Main() {
            Console.Write ("Ayný adlý parametre ve sýnýf alan üyelerinde, ayýrtedici olan sýnýfýnkinin önündeki'this'dir. 'new' var/sýnýfadý ile yeni bir tipleme yaratýr. 'new' ile yaratýlan nesne 'null' ile bellekten (hiçlenerek) silinir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sýnýf alan adlarýný ayný adlý parametrelerden ayýran 'this':");
            var r=new Random(); int ts1, ts2, ts3, i, j; Sýnýf1 s1;
            for (i=0; i<5; i++) {
                ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000);
                s1=new Sýnýf1 (ts1, ts2);
                Console.WriteLine ("(x, y) = ({0}, {1})", s1.X, s1.Y);
            }

            Console.WriteLine ("\nSýnýf alan üyesi this ile yada gerekmedikce yalýn kullanýlabilir;");
            ThisNewNull s2=new ThisNewNull();
            for (i=0; i<5; i++) {
                s2.sayaç=0; ts1=r.Next (0, 100);
                Console.WriteLine ("Sayaç sonu: {0}", ts1);
                for (j=0; j<ts1; j++) {s2.Say(); Console.Write (s2.sayaç + " ");}
                Console.WriteLine();
            }

            Console.WriteLine ("\nKurucularý parametresiz, 3 int parametreli ve nesne olan sýnýf:");
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100);
            XYZkordinat xyz1 = new XYZkordinat();
            var xyz2 = new XYZkordinat (ts1, ts2, ts3);
            var xyz3 = new XYZkordinat (xyz2);
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100); var xyz4 = new XYZkordinat (ts1,ts2,ts3);
            xyz1.Göster(); xyz2.Göster(); xyz3.Göster(); xyz4.Göster();

            Console.WriteLine ("\n'new' ile çeþitli ilkdeðerli tiplemeler yaratma:");
            int x1 = new int(); Console.WriteLine ("int x1: " + x1);
            double x2 = new double(); Console.WriteLine ("double x2: " + x2);
            bool x3 = new bool(); Console.WriteLine ("bool x3: " + x3);
            string x4 = new string (new Char[]{'N', 'i', 'h', 'a', 't'}); Console.WriteLine ("string x4: " + x4);
            object x5 = new object(); x5=r.Next (1000, 10000); Console.WriteLine ("object x5: " + x5);
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100); var x6 = new XYZkordinat (ts1,ts2,ts3); x6.Göster();

            Console.WriteLine ("\n'null' ev 'new'la tiplenip özelliklendirilmekte:");
            Ev evim=null; Console.WriteLine ("evim: {0}", evim==null? "null": evim.marka);
            evim = new Ev(); evim.marka="Tripleks"; evim.model="Müstakil"; evim.renk="Mavi"; evim.inþaaYýlý=2023;
            Console.WriteLine ("{0} {1} {2} evim {3} yýlýnda inþa edildi.", evim.renk, evim.model, evim.marka, evim.inþaaYýlý);
            evim.Baþlat (new DateTime (2001, 4, 17)); evim.Bitir();
            evim = null; Console.WriteLine ("evim: {0}", evim==null? "Tekrar 'null'": evim.marka);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}