// j2sc#0714a.cs: Temel, türedi, arayüz, hiyerarþi, base.temel, new üye örneði.

using System;
namespace Sýnýflar {
    class Þekil {
        double en; //private
        double boy; //private
        public Þekil() {En = Boy = 0.0;} //Ýlkdeðerleyen parametsiz kurucu
        public Þekil (double e, double b) {En = e; Boy = b;} //Çift parametreli kurucu
        public Þekil (double x) {En = Boy = x;} //Tek parametreli eþitkenarlayan kurucu
        public double En {get {return en;} set {en = value;}} //En ve Boy özellikleri
        public double Boy {get {return boy;} set {boy = value;}}
        public void boyutGöster() {Console.Write ("Üçgenin (en, boy, alan, tip, renk) = ({0:0.00}, {1:0.00}, ", En, Boy);}
    }
    class Üçgen : Þekil {
        string tip; //private
        public Üçgen() {tip = "null";} //Þekil'i ilkdeðerleyen parametresiz kurucu
        public Üçgen (string t, double e, double b) : base (e, b) {tip = t;} //3 parametreli kurucu
        public Üçgen (double x) : base (x) {tip = "eþkenar";} //Tek parametreli eþkenar kurucu
        public double alan() {return En * Boy / 2;}
        public void tipGöster() {Console.Write (tip + ", ");}
    }
    class RenkliÜçgen : Üçgen {
        string renk;  //private
        public RenkliÜçgen (string r, string t, double e, double b) : base (t, e, b) {renk = r;} //4 parametreli kurucu
        public void renkGöster() {Console.Write (renk + ")\n");}
    }
    class Temel {public Temel() {Console.WriteLine ("\tTemel sýnýf kuruluyor.");}}
    class Türedi1 : Temel {public Türedi1() {Console.WriteLine ("Türedi1 sýnýf kuruluyor.");}}
    class Türedi2 : Türedi1 {public Türedi2() {Console.WriteLine ("Türedi2 sýnýf kuruluyor.");}}
    class Türedi3 : Türedi2 {public Türedi3() {Console.WriteLine ("Türedi3 sýnýf kuruluyor.");}}
    interface Arayüz1 {void Yaz1 (string s);}
    interface Arayüz2 {void Yaz2 (string s);}
    interface Arayüz3 {void Yaz3 (string s);}
    class Ebeveyn {
        public void Yaz1 (string s) {Console.WriteLine ("\tAd ve soyad: {0}", s);}
        public void Yaz2 (string s) {Console.WriteLine ("eposta: {0}", s);}
        public void Yaz3 (string s) {Console.WriteLine ("GSM: {0}", s);}
    }
    class Yavru1 : Ebeveyn, Arayüz1, Arayüz2, Arayüz3 {}
    class Yavru2 : Yavru1 {}
    class Miraslanan {
        public int a;
        public Miraslanan (int i) {a = i;}
    }
    class Miraslayan : Miraslanan {
        public int b;
        public Miraslayan (int i, int j) : base (j) {b = i;}
    }
    public class TemelSýnýf {
        public string isim;
        public string eposta;
        public TemelSýnýf (string isim, string eposta) {
            Console.WriteLine ("\tTemelSýnýf kurucusu içinden:");
            this.isim = isim;
            this.eposta = eposta;
            Console.WriteLine ("this.isim = " + this.isim);
            Console.WriteLine ("this.eposta = " + this.eposta);
        }
        public void epostaGöster() {
            Console.WriteLine ("\t\tTemelSýnýf.epostaGöster() metodu içinden:");
            Console.WriteLine ("eposta = " + eposta);
        }
    }
    public class TürediSýnýf : TemelSýnýf {
        public new string eposta; //new ile Temel'dekinden farklý alan
        public TürediSýnýf (string isim, string eposta) : base (isim, "Eposta Denemesi") {
            Console.WriteLine ("\tTürediSýnýf kurucusu içinden:");
            this.eposta = eposta;
            Console.WriteLine ("this.eposta = " + this.eposta);
        }
        public new void epostaGöster() {//new ile Temel'dekinden farklý metot
            Console.WriteLine ("\t\tTürediSýnýf.epostaGöster() metodu içinden:");
            Console.WriteLine ("eposta = " + eposta);
            base.epostaGöster();
        }
    }
    class SýnýfHiyerarþisi1 {
        static void Main() {
            Console.Write ("Miraslanana temel, temelin tüm alan metot özellik iþlemci ve endeksleyicilerini miraslayana da türedi sýnýf denir. Türedinin ayrýca kendi özel üyeleri de olabilir. Temel'in private üyeleri miraslanmaz. Çoklu altalta türedi-sýnýf tek temel-sýnýf ve çoklu arayüzler miraslayabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Üçlü Þekil:Üçgen:RenkliÜçgen hiyerarþisi:");
            var r=new Random(); int i, ts1, ts2; double ds1, ds2;
            string[] d1= new string[]{"dik", "eþkenar", "yamuk", "çokgen", "renkli"};
            string[] d2= new string[]{"mavi", "kýrmýzý", "yeþil", "sarý", "siyah"};
            RenkliÜçgen rü;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100) + r.Next(100,1000)/1000D; ds2=r.Next(0,100) + r.Next(100,1000)/1000D;
                rü= new RenkliÜçgen (d2 [i], d1 [i], ds1, ds2);
                rü.boyutGöster();
                Console.Write ("{0:0.00}, ", rü.alan());
                rü.tipGöster();
                rü.renkGöster();
            }

            Console.WriteLine ("\nTemel ve altalta 3 türedi sýnýflarýn hiyerarþisi:");
            Türedi3 t3 = new Türedi3(); t3 = new Türedi3(); t3 = new Türedi3();

            Console.WriteLine ("\n3 arayüz, temel ve altalta 2 türedi sýnýflarýn hiyerarþisi:");
            Yavru2 y2 = new Yavru2(); y2.Yaz1 ("M.Nihat Yavaþ"); y2.Yaz2 ("mnihatyavas@hotmail.com"); y2.Yaz3 ("+90 551 555 75 65");
            y2 = new Yavru2(); y2.Yaz1 ("M.Nedim Yavaþ"); y2.Yaz2 ("mnedimyavas@gmail.com"); y2.Yaz3 ("+90 552 555 65 75");
            y2 = new Yavru2(); y2.Yaz1 ("Z.Nihal Yavaþ"); y2.Yaz2 ("znihalyavas@gmail.com"); y2.Yaz3 ("+90 553 555 95 55");

            Console.WriteLine ("\nTemel'in üyesi a ve türedi'nin üyesi b'nin iliþkileri:");
            ts1=r.Next (1000, 10000);
            Miraslanan x1 = new Miraslanan (ts1); Miraslanan x2; x2=x1; Console.WriteLine ("x2.a: " + x2.a); //x2.b derleme hatasý verir
            Miraslayan y1;
            for(i=0;i<5;i++) {
                ts1=r.Next (1000, 10000); ts2=r.Next (1000, 10000);
                y1 = new Miraslayan (ts1, ts2); x2=y1; Console.WriteLine ("x2.a = {0},\t(y1.a, y1b) = ({1}, {2})", x2.a, y1.a, y1.b); //x2.b derleme hatasý verir
            }

            Console.WriteLine ("\nTemel/türedi sýnýf, new üye, base.üye() iliþkileri:");
            Console.WriteLine ("Bir TürediSýnýf nesnesi-ts yaratýlýyor...");
            TürediSýnýf ts = new TürediSýnýf ("M.Nihat Yavaþ", "mnihatyavas@hotmail.com");
            Console.WriteLine ("\tTekrar Main() metoda dönüþ...");
            Console.WriteLine ("ts.isim = " + ts.isim);
            Console.WriteLine ("ts.eposta = " + ts.eposta);
            Console.WriteLine ("\tts.epostaGöster() metodu çaðrýlýyor...");
            ts.epostaGöster();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}