// j2sc#0714b.cs: �oklu a��r�y�kl� temel kurucular ve harici temelin miraslanmas� �rne�i.
// csc j2sc#0714b.cs j2sc#0714bx.cs ==>j2sc#0714b

using System;
using TemelS�n�fNS;
namespace S�n�flar {
    class Temel {
        protected int ts = 1938;
        public void TemelYaz() {Console.WriteLine ("Temel �ye int ts = {0}", ts);}
    }
    class T�redi : Temel {
        double ds = 1938.11100905;
        public void T�rediYaz() {Console.WriteLine ("Temel �ye int ts = {0},\tT�redi �ye double ds = {1}", ts, ds);}
    }
    class �ekil {
        double en;  // private
        double boy; // private
        public �ekil() {En = Boy = 0.0;}
        public �ekil (double e, double b) {En = e; Boy = b;}
        public �ekil (double x) {En = Boy = x;}
        public �ekil (�ekil ns) {En = ns.En; Boy = ns.Boy;}
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
        public void �l��G�ster() {Console.WriteLine ("En ve boy: " + En + " ve " + Boy);}
    }
    class ��gen : �ekil {
        string stil; // private
        public ��gen() {stil = "null";}
        public ��gen (string d, double e, double b) : base (e, b) {stil = d;}
        public ��gen (double x) : base (x) {stil = "e�kenar";}
        public ��gen (��gen ns) : base (ns) {stil = ns.stil;}
        public double alan() {return En * Boy / 2;}
        public void stilG�ster() {Console.WriteLine ("��gen tipi: " + stil);}
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
    class T�rediS�n�f : TemelS�n�f {
        public T�rediS�n�f (string s) : base (s) {}
    }
    class S�n�fHiyerar�isi2 {
        static void Main() {
            Console.Write ("Private s�n�f alanlar�na public set-get �zelliklendirmeyle eri�ilir. �oklu a��r� y�kl� kurucu se�imi �a��ran parametre say�s� ve tipiyle otomatik se�ilir. T�redi s�n�f miraslad���n�n t�m �yelerine ilaveten kendi �zel �yelerini de kullanabilir. Temel ayr� uygulamadaysa 'using NS' duhulle, birlikte derlenmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Temel'in kendi metodunu, t�redinin hem kendi hem de miraslad���n� �a��rmas�:");
            Temel temel = new Temel(); Console.WriteLine ("\ttemel:"); temel.TemelYaz();
            T�redi t�redi = new T�redi(); Console.WriteLine ("\tt�redi:"); t�redi.TemelYaz(); t�redi.T�rediYaz();

            Console.WriteLine ("\nA��r�y�kl� kurucularla farkl� tip ��genler yaratma:");
            ��gen t1 = new ��gen ("dik", 8.0, 12.0);
            ��gen t2 = new ��gen (t1); //Kopya
            ��gen t3 = new ��gen (4.0);
            ��gen t4 = new ��gen ("e�kenar", 4.0, 4.0); 
            Console.WriteLine ("\tt1 i�in bilgi: "); t1.stilG�ster(); t1.�l��G�ster(); Console.WriteLine ("Alan: " + t1.alan());
            Console.WriteLine ("\tt2 i�in bilgi: "); t2.stilG�ster(); t2.�l��G�ster(); Console.WriteLine ("Alan: " + t2.alan());
            Console.WriteLine ("\tt3 i�in bilgi: "); t3.stilG�ster(); t3.�l��G�ster(); Console.WriteLine ("Alan: " + t3.alan());
            Console.WriteLine ("\tt4 i�in bilgi: "); t4.stilG�ster(); t4.�l��G�ster(); Console.WriteLine ("Alan: " + t4.alan());

            Console.WriteLine ("\nEn, boy, y�kseli�i verilen kutunun hacmi:");
            var r=new Random(); int ts1, ts2, ts3, i, j;
            Derived tn;
            for(i=0; i<5;i++) {
                ts1=r.Next (0, 100); ts2=r.Next (0, 100); ts3=r.Next (0, 100);
                tn= new Derived (ts1, ts2, ts3);
                Console.WriteLine ("(En * Boy * Y�kseklik = Hacim) = ({0}, {1}, {2}, {3:#,#})", tn.X, tn.Y, tn.Z, tn.X*tn.Y*tn.Z);
            }

            Console.WriteLine ("\nAyr� uygulamadaki temel-s�n�f�n 'using NS'le cari uygulamaya duhul�:");
            T�rediS�n�f ts; string m;
            ts = new T�rediS�n�f ("M.Nihat Yava�'tan rasgele mesajlar..."); ts.Yaz(-1);
            for(i=0;i<5;i++) {
                m="";
                for(j=0;j<30;j++) {if (j>0 && j%5==0) m+=" "; ts1=r.Next (65, 92); m+=(char)ts1;}
                ts = new T�rediS�n�f (m); ts.Yaz (i);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}