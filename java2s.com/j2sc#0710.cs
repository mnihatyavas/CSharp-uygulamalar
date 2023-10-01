// j2sc#0710.cs: S�n�f alan 'this', 'new'le nesnel tipleme, 'null'la nesnel hi�leme �rne�i.

using System;
namespace S�n�flar {
    class S�n�f1 {
        int x;
        int y;
        public S�n�f1 (int x) {this.x = x;} //Tek parametreli kurucu
        public S�n�f1 (int x, int y): this (x) {this.y = y;}
        public int X {get {return (x);} }
        public int Y {get {return (y);} }
    }
    class XYZkordinat {//3 farkl� (a��r�y�kl�) kuruculu
        int x, y, z;   
        public XYZkordinat() : this (0, 0, 0) {Console.WriteLine ("XYZkordinat() kurucusunday�m");}
        public XYZkordinat (XYZkordinat nesne) : this (nesne.x, nesne.y, nesne.z) {Console.WriteLine ("XYZkordinat (nesne) kurucusunday�m");}
        public XYZkordinat (int i, int j, int k) {Console.WriteLine ("XYZkordinat (int, int, int) kurucusunday�m"); x = i; y = j; this.z = k;}
        public void G�ster() {Console.WriteLine ("XYZkordinat (x, y, z) = ({0}, {1}, {2})", this.x, y, z);}
    }
    class Ev {
        public string marka;
        public string model;
        public string renk;
        public int in�aaY�l�;
        public void Ba�lat (DateTime t) {Console.WriteLine ("��aat [{0}] tarihinde ba�lad�", t);}
        public void Bitir() {Console.WriteLine ("��aat [{0}] tarihte tamamland�", DateTime.Now);}
    }
    class ThisNewNull {
        int saya�;
        public void Say() {saya� +=2; this.saya�--;}
        static void Main() {
            Console.Write ("Ayn� adl� parametre ve s�n�f alan �yelerinde, ay�rtedici olan s�n�f�nkinin �n�ndeki'this'dir. 'new' var/s�n�fad� ile yeni bir tipleme yarat�r. 'new' ile yarat�lan nesne 'null' ile bellekten (hi�lenerek) silinir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("S�n�f alan adlar�n� ayn� adl� parametrelerden ay�ran 'this':");
            var r=new Random(); int ts1, ts2, ts3, i, j; S�n�f1 s1;
            for (i=0; i<5; i++) {
                ts1=r.Next (-1000, 1000); ts2=r.Next (-1000, 1000);
                s1=new S�n�f1 (ts1, ts2);
                Console.WriteLine ("(x, y) = ({0}, {1})", s1.X, s1.Y);
            }

            Console.WriteLine ("\nS�n�f alan �yesi this ile yada gerekmedikce yal�n kullan�labilir;");
            ThisNewNull s2=new ThisNewNull();
            for (i=0; i<5; i++) {
                s2.saya�=0; ts1=r.Next (0, 100);
                Console.WriteLine ("Saya� sonu: {0}", ts1);
                for (j=0; j<ts1; j++) {s2.Say(); Console.Write (s2.saya� + " ");}
                Console.WriteLine();
            }

            Console.WriteLine ("\nKurucular� parametresiz, 3 int parametreli ve nesne olan s�n�f:");
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100);
            XYZkordinat xyz1 = new XYZkordinat();
            var xyz2 = new XYZkordinat (ts1, ts2, ts3);
            var xyz3 = new XYZkordinat (xyz2);
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100); var xyz4 = new XYZkordinat (ts1,ts2,ts3);
            xyz1.G�ster(); xyz2.G�ster(); xyz3.G�ster(); xyz4.G�ster();

            Console.WriteLine ("\n'new' ile �e�itli ilkde�erli tiplemeler yaratma:");
            int x1 = new int(); Console.WriteLine ("int x1: " + x1);
            double x2 = new double(); Console.WriteLine ("double x2: " + x2);
            bool x3 = new bool(); Console.WriteLine ("bool x3: " + x3);
            string x4 = new string (new Char[]{'N', 'i', 'h', 'a', 't'}); Console.WriteLine ("string x4: " + x4);
            object x5 = new object(); x5=r.Next (1000, 10000); Console.WriteLine ("object x5: " + x5);
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); ts3=r.Next (-100, 100); var x6 = new XYZkordinat (ts1,ts2,ts3); x6.G�ster();

            Console.WriteLine ("\n'null' ev 'new'la tiplenip �zelliklendirilmekte:");
            Ev evim=null; Console.WriteLine ("evim: {0}", evim==null? "null": evim.marka);
            evim = new Ev(); evim.marka="Tripleks"; evim.model="M�stakil"; evim.renk="Mavi"; evim.in�aaY�l�=2023;
            Console.WriteLine ("{0} {1} {2} evim {3} y�l�nda in�a edildi.", evim.renk, evim.model, evim.marka, evim.in�aaY�l�);
            evim.Ba�lat (new DateTime (2001, 4, 17)); evim.Bitir();
            evim = null; Console.WriteLine ("evim: {0}", evim==null? "Tekrar 'null'": evim.marka);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}