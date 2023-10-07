// j2sc#0714a.cs: Temel, t�redi, aray�z, hiyerar�i, base.temel, new �ye �rne�i.

using System;
namespace S�n�flar {
    class �ekil {
        double en; //private
        double boy; //private
        public �ekil() {En = Boy = 0.0;} //�lkde�erleyen parametsiz kurucu
        public �ekil (double e, double b) {En = e; Boy = b;} //�ift parametreli kurucu
        public �ekil (double x) {En = Boy = x;} //Tek parametreli e�itkenarlayan kurucu
        public double En {get {return en;} set {en = value;}} //En ve Boy �zellikleri
        public double Boy {get {return boy;} set {boy = value;}}
        public void boyutG�ster() {Console.Write ("��genin (en, boy, alan, tip, renk) = ({0:0.00}, {1:0.00}, ", En, Boy);}
    }
    class ��gen : �ekil {
        string tip; //private
        public ��gen() {tip = "null";} //�ekil'i ilkde�erleyen parametresiz kurucu
        public ��gen (string t, double e, double b) : base (e, b) {tip = t;} //3 parametreli kurucu
        public ��gen (double x) : base (x) {tip = "e�kenar";} //Tek parametreli e�kenar kurucu
        public double alan() {return En * Boy / 2;}
        public void tipG�ster() {Console.Write (tip + ", ");}
    }
    class Renkli��gen : ��gen {
        string renk;  //private
        public Renkli��gen (string r, string t, double e, double b) : base (t, e, b) {renk = r;} //4 parametreli kurucu
        public void renkG�ster() {Console.Write (renk + ")\n");}
    }
    class Temel {public Temel() {Console.WriteLine ("\tTemel s�n�f kuruluyor.");}}
    class T�redi1 : Temel {public T�redi1() {Console.WriteLine ("T�redi1 s�n�f kuruluyor.");}}
    class T�redi2 : T�redi1 {public T�redi2() {Console.WriteLine ("T�redi2 s�n�f kuruluyor.");}}
    class T�redi3 : T�redi2 {public T�redi3() {Console.WriteLine ("T�redi3 s�n�f kuruluyor.");}}
    interface Aray�z1 {void Yaz1 (string s);}
    interface Aray�z2 {void Yaz2 (string s);}
    interface Aray�z3 {void Yaz3 (string s);}
    class Ebeveyn {
        public void Yaz1 (string s) {Console.WriteLine ("\tAd ve soyad: {0}", s);}
        public void Yaz2 (string s) {Console.WriteLine ("eposta: {0}", s);}
        public void Yaz3 (string s) {Console.WriteLine ("GSM: {0}", s);}
    }
    class Yavru1 : Ebeveyn, Aray�z1, Aray�z2, Aray�z3 {}
    class Yavru2 : Yavru1 {}
    class Miraslanan {
        public int a;
        public Miraslanan (int i) {a = i;}
    }
    class Miraslayan : Miraslanan {
        public int b;
        public Miraslayan (int i, int j) : base (j) {b = i;}
    }
    public class TemelS�n�f {
        public string isim;
        public string eposta;
        public TemelS�n�f (string isim, string eposta) {
            Console.WriteLine ("\tTemelS�n�f kurucusu i�inden:");
            this.isim = isim;
            this.eposta = eposta;
            Console.WriteLine ("this.isim = " + this.isim);
            Console.WriteLine ("this.eposta = " + this.eposta);
        }
        public void epostaG�ster() {
            Console.WriteLine ("\t\tTemelS�n�f.epostaG�ster() metodu i�inden:");
            Console.WriteLine ("eposta = " + eposta);
        }
    }
    public class T�rediS�n�f : TemelS�n�f {
        public new string eposta; //new ile Temel'dekinden farkl� alan
        public T�rediS�n�f (string isim, string eposta) : base (isim, "Eposta Denemesi") {
            Console.WriteLine ("\tT�rediS�n�f kurucusu i�inden:");
            this.eposta = eposta;
            Console.WriteLine ("this.eposta = " + this.eposta);
        }
        public new void epostaG�ster() {//new ile Temel'dekinden farkl� metot
            Console.WriteLine ("\t\tT�rediS�n�f.epostaG�ster() metodu i�inden:");
            Console.WriteLine ("eposta = " + eposta);
            base.epostaG�ster();
        }
    }
    class S�n�fHiyerar�isi1 {
        static void Main() {
            Console.Write ("Miraslanana temel, temelin t�m alan metot �zellik i�lemci ve endeksleyicilerini miraslayana da t�redi s�n�f denir. T�redinin ayr�ca kendi �zel �yeleri de olabilir. Temel'in private �yeleri miraslanmaz. �oklu altalta t�redi-s�n�f tek temel-s�n�f ve �oklu aray�zler miraslayabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("��l� �ekil:��gen:Renkli��gen hiyerar�isi:");
            var r=new Random(); int i, ts1, ts2; double ds1, ds2;
            string[] d1= new string[]{"dik", "e�kenar", "yamuk", "�okgen", "renkli"};
            string[] d2= new string[]{"mavi", "k�rm�z�", "ye�il", "sar�", "siyah"};
            Renkli��gen r�;
            for(i=0;i<5;i++) {
                ds1=r.Next(0,100) + r.Next(100,1000)/1000D; ds2=r.Next(0,100) + r.Next(100,1000)/1000D;
                r�= new Renkli��gen (d2 [i], d1 [i], ds1, ds2);
                r�.boyutG�ster();
                Console.Write ("{0:0.00}, ", r�.alan());
                r�.tipG�ster();
                r�.renkG�ster();
            }

            Console.WriteLine ("\nTemel ve altalta 3 t�redi s�n�flar�n hiyerar�isi:");
            T�redi3 t3 = new T�redi3(); t3 = new T�redi3(); t3 = new T�redi3();

            Console.WriteLine ("\n3 aray�z, temel ve altalta 2 t�redi s�n�flar�n hiyerar�isi:");
            Yavru2 y2 = new Yavru2(); y2.Yaz1 ("M.Nihat Yava�"); y2.Yaz2 ("mnihatyavas@hotmail.com"); y2.Yaz3 ("+90 551 555 75 65");
            y2 = new Yavru2(); y2.Yaz1 ("M.Nedim Yava�"); y2.Yaz2 ("mnedimyavas@gmail.com"); y2.Yaz3 ("+90 552 555 65 75");
            y2 = new Yavru2(); y2.Yaz1 ("Z.Nihal Yava�"); y2.Yaz2 ("znihalyavas@gmail.com"); y2.Yaz3 ("+90 553 555 95 55");

            Console.WriteLine ("\nTemel'in �yesi a ve t�redi'nin �yesi b'nin ili�kileri:");
            ts1=r.Next (1000, 10000);
            Miraslanan x1 = new Miraslanan (ts1); Miraslanan x2; x2=x1; Console.WriteLine ("x2.a: " + x2.a); //x2.b derleme hatas� verir
            Miraslayan y1;
            for(i=0;i<5;i++) {
                ts1=r.Next (1000, 10000); ts2=r.Next (1000, 10000);
                y1 = new Miraslayan (ts1, ts2); x2=y1; Console.WriteLine ("x2.a = {0},\t(y1.a, y1b) = ({1}, {2})", x2.a, y1.a, y1.b); //x2.b derleme hatas� verir
            }

            Console.WriteLine ("\nTemel/t�redi s�n�f, new �ye, base.�ye() ili�kileri:");
            Console.WriteLine ("Bir T�rediS�n�f nesnesi-ts yarat�l�yor...");
            T�rediS�n�f ts = new T�rediS�n�f ("M.Nihat Yava�", "mnihatyavas@hotmail.com");
            Console.WriteLine ("\tTekrar Main() metoda d�n��...");
            Console.WriteLine ("ts.isim = " + ts.isim);
            Console.WriteLine ("ts.eposta = " + ts.eposta);
            Console.WriteLine ("\tts.epostaG�ster() metodu �a�r�l�yor...");
            ts.epostaG�ster();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}