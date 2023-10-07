// j2sc#0714b.cs: Çoklu aþýrýyüklü temel kurucular ve harici temelin miraslanmasý örneði.
// csc j2sc#0714b.cs j2sc#0714bx.cs ==>j2sc#0714b

using System;
using TemelSýnýfNS;
namespace Sýnýflar {
    class Temel {
        protected int ts = 1938;
        public void TemelYaz() {Console.WriteLine ("Temel üye int ts = {0}", ts);}
    }
    class Türedi : Temel {
        double ds = 1938.11100905;
        public void TürediYaz() {Console.WriteLine ("Temel üye int ts = {0},\tTüredi üye double ds = {1}", ts, ds);}
    }
    class Þekil {
        double en;  // private
        double boy; // private
        public Þekil() {En = Boy = 0.0;}
        public Þekil (double e, double b) {En = e; Boy = b;}
        public Þekil (double x) {En = Boy = x;}
        public Þekil (Þekil ns) {En = ns.En; Boy = ns.Boy;}
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
        public void ölçüGöster() {Console.WriteLine ("En ve boy: " + En + " ve " + Boy);}
    }
    class Üçgen : Þekil {
        string stil; // private
        public Üçgen() {stil = "null";}
        public Üçgen (string d, double e, double b) : base (e, b) {stil = d;}
        public Üçgen (double x) : base (x) {stil = "eþkenar";}
        public Üçgen (Üçgen ns) : base (ns) {stil = ns.stil;}
        public double alan() {return En * Boy / 2;}
        public void stilGöster() {Console.WriteLine ("Üçgen tipi: " + stil);}
    }
    public class BaseClass {
        int x, y;
        public BaseClass (int x, int y) {this.x = x; this.y = y;}
        public int X {get {return(x);}}
        public int Y {get {return(y);}}
    }
    public class Derived: BaseClass {
        int z;
        public Derived (int x, int y, int z): base (x, y) {this.z = z;}
        public int Z {get {return(z);}}
    }
    class TürediSýnýf : TemelSýnýf {
        public TürediSýnýf (string s) : base (s) {}
    }
    class SýnýfHiyerarþisi2 {
        static void Main() {
            Console.Write ("Private sýnýf alanlarýna public set-get özelliklendirmeyle eriþilir. Çoklu aþýrý yüklü kurucu seçimi çaðýran parametre sayýsý ve tipiyle otomatik seçilir. Türedi sýnýf mirasladýðýnýn tüm üyelerine ilaveten kendi özel üyelerini de kullanabilir. Temel ayrý uygulamadaysa 'using NS' duhulle, birlikte derlenmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Temel'in kendi metodunu, türedinin hem kendi hem de mirasladýðýný çaðýrmasý:");
            Temel temel = new Temel(); Console.WriteLine ("\ttemel:"); temel.TemelYaz();
            Türedi türedi = new Türedi(); Console.WriteLine ("\ttüredi:"); türedi.TemelYaz(); türedi.TürediYaz();

            Console.WriteLine ("\nAþýrýyüklü kurucularla farklý tip üçgenler yaratma:");
            Üçgen t1 = new Üçgen ("dik", 8.0, 12.0);
            Üçgen t2 = new Üçgen (t1); //Kopya
            Üçgen t3 = new Üçgen (4.0);
            Üçgen t4 = new Üçgen ("eþkenar", 4.0, 4.0); 
            Console.WriteLine ("\tt1 için bilgi: "); t1.stilGöster(); t1.ölçüGöster(); Console.WriteLine ("Alan: " + t1.alan());
            Console.WriteLine ("\tt2 için bilgi: "); t2.stilGöster(); t2.ölçüGöster(); Console.WriteLine ("Alan: " + t2.alan());
            Console.WriteLine ("\tt3 için bilgi: "); t3.stilGöster(); t3.ölçüGöster(); Console.WriteLine ("Alan: " + t3.alan());
            Console.WriteLine ("\tt4 için bilgi: "); t4.stilGöster(); t4.ölçüGöster(); Console.WriteLine ("Alan: " + t4.alan());

            Console.WriteLine ("\nEn, boy, yükseliði verilen kutunun hacmi:");
            var r=new Random(); int ts1, ts2, ts3, i, j;
            Derived tn;
            for(i=0; i<5;i++) {
                ts1=r.Next (0, 100); ts2=r.Next (0, 100); ts3=r.Next (0, 100);
                tn= new Derived (ts1, ts2, ts3);
                Console.WriteLine ("(En * Boy * Yükseklik = Hacim) = ({0}, {1}, {2}, {3:#,#})", tn.X, tn.Y, tn.Z, tn.X*tn.Y*tn.Z);
            }

            Console.WriteLine ("\nAyrý uygulamadaki temel-sýnýfýn 'using NS'le cari uygulamaya duhulü:");
            TürediSýnýf ts; string m;
            ts = new TürediSýnýf ("M.Nihat Yavaþ'tan rasgele mesajlar..."); ts.Yaz(-1);
            for(i=0;i<5;i++) {
                m="";
                for(j=0;j<30;j++) {if (j>0 && j%5==0) m+=" "; ts1=r.Next (65, 92); m+=(char)ts1;}
                ts = new TürediSýnýf (m); ts.Yaz (i);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}