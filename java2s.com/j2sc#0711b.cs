// j2sc#0711b.cs: Anas�n�f, alts�n�f ve istisnas�n�f kurucular�n�n ili�kileri �rne�i.

using System;
namespace S�n�flar {
    public class TemelS�n�f {
        int x;
        public int y;
        public int X {get {return x;} set {x = value;} }
        public TemelS�n�f() {Console.WriteLine ("Parametresiz TemelS�n�f() kuruluyor..."); x=y=0;}
        public TemelS�n�f (int i) {Console.WriteLine ("Tek parametreli TemelS�n�f(int) kuruluyor..."); x=i; y=0;}
        public TemelS�n�f (int i, int j) {Console.WriteLine ("�ift parametreli TemelS�n�f(int, int) kuruluyor..."); x=i; y=j;}
        public void G�ster() {Console.WriteLine ("\tint (x, y) = ({0}, {1})", x, y);}
    }
    public class AltS�n�f : TemelS�n�f {
        public AltS�n�f() {Console.WriteLine ("Parametresiz AltS�n�f() kuruluyor..."); X=base.y=0;}
        public AltS�n�f (int i) {Console.WriteLine ("Tek parametreli AltS�n�f(int) kuruluyor..."); X=i; base.y=0;}
        public AltS�n�f (int i, int j) {Console.WriteLine ("�ift parametreli AltS�n�f(int, int) kuruluyor..."); X=i; base.y=j;}
    }
    class KrkDiziS�n�f� {
        char[] krkDizi;
        int g�ncelEbat;
        public KrkDiziS�n�f� (int azamiEbat) {
            krkDizi = new char [azamiEbat];
            g�ncelEbat = 0;
        }
        public KrkDiziS�n�f� (KrkDiziS�n�f� kds) {
            krkDizi = new char [kds.krkDizi.Length];
            for (int i=0; i < kds.g�ncelEbat; i++) krkDizi [i] = kds.krkDizi [i];
            g�ncelEbat = kds.g�ncelEbat;
        }
        public void krkEkle (char krk) {
            if (g�ncelEbat == krkDizi.Length) {Console.WriteLine ("-- krkDizi dolu."); return;}
            krkDizi [g�ncelEbat] = krk;
            g�ncelEbat++;
        }
        public char krk��kar() {
            if (g�ncelEbat == 0) {Console.WriteLine ("-- krkDizi bo�."); return (char)0;}
            g�ncelEbat--;
            return krkDizi [g�ncelEbat];
        }
        public bool doluMu() {return g�ncelEbat == krkDizi.Length;}
        public bool bo�Mu() {return g�ncelEbat == 0;}
        public int azamiKapasite() {return krkDizi.Length;}
        public int akt�elEbat() {return g�ncelEbat;}
    }
    class �ekil {
        double en; //private
        double boy; //private
        public double En {get {return en;} set {en = value;} }
        public double Boy {get {return boy;} set {boy = value;} }
        public void g�sterEnBoy() {Console.WriteLine ("(en, boy) = ({0}, {1})", En, Boy);}
    }
    class ��gen : �ekil {
        string tip; // private
        public ��gen (string t, double e, double b) {En = e; Boy = b; tip = t;}
        public double alan() {return En * Boy / 2;}
        public void g�sterTip() {Console.WriteLine ("��gen'in tipi: " + tip);}
    }
    public class �skonto {
        private int y�zde;
        public �skonto (int y�zde) {
            this.y�zde = y�zde;
            if (y�zde > 50) throw new �skontom ("Hatal� iskonto > 50%: %" + this.y�zde);
            else Console.WriteLine ("Onayl� iskonto: %" + this.y�zde);
        }
    }
    public class �skontom: Exception {public �skontom (String mesaj) : base (mesaj) {} }
    class Kurucu2 {
        static void Main() {
            Console.Write ("Alts�n�ftan temels�n�f 'private' alan�na temels�n�f get/set'iyle, 'public' alan�naysa base.alan'la eri�ilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("T�retilenin temel s�n�f alan ve metotlar�n� kullanmas�:");
            var r=new Random(); int ts1, ts2, i;
            AltS�n�f as1 = new AltS�n�f(); as1.G�ster();
            ts1=r.Next (-100, 100); as1 = new AltS�n�f (ts1); as1.G�ster();
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); as1 = new AltS�n�f (ts1, ts2); as1.G�ster();
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); as1 = new AltS�n�f (ts1, ts2); as1.G�ster();

            Console.WriteLine ("\nAzami krkDizi'ye [bo�, dolu] krk ekleme, kopyalama ve ��karma:");
            KrkDiziS�n�f� kds1 = new KrkDiziS�n�f� (26);
            char krk;
            Console.WriteLine ("�ncelikle kds1'e 26 krk [A, Z] ekle.");
            for (i=0; !kds1.doluMu(); i++) kds1.krkEkle ((char) ('A' + i));
            Console.WriteLine ("Sonra kds1'i kds2'ye kopyala.");
            KrkDiziS�n�f� kds2 = new KrkDiziS�n�f� (kds1); //�lkini kopyala
            Console.Write ("krkDiz1/kds1 i�eriklerini sondan-ba�a ��kar: ");
            while (!kds1.bo�Mu()) {krk = kds1.krk��kar(); Console.Write (krk);} Console.WriteLine();
            Console.Write ("krkDiz1/kds2 i�eriklerini sondan-ba�a ��kar: ");
            while (!kds2.bo�Mu()) {krk = kds2.krk��kar(); Console.Write (krk);} Console.WriteLine();
            Console.WriteLine ("kds1 bo� mu? " + kds1.bo�Mu()); Console.WriteLine ("kds2 bo� mu? " + kds2.bo�Mu());
            Console.WriteLine ("kds1 g�ncelEbat/azamiKapasite: {0}/{1}", kds1.akt�elEbat(), kds1.azamiKapasite()); 

            Console.WriteLine ("\n�ekil'i miraslayan (ikizkenar ve dik) ��gen alanlar�:");
            ��gen �1 = new ��gen ("ikizkenar", 18.5, 18.5);
            ��gen �2 = new ��gen ("dik", 18.5, 52.60);
            Console.WriteLine ("\t==>�1 bilgileri: ");
            �1.g�sterTip(); �1.g�sterEnBoy();
            Console.WriteLine ("Alan� " + �1.alan());
            Console.WriteLine ("\t==>�2 bilgileri: ");
            �2.g�sterTip(); �2.g�sterEnBoy();
            Console.WriteLine ("Alan� " + �2.alan());

            Console.WriteLine ("\n�ndirim >= %50'de istisna f�rlat�lmas�:");
            �skonto indirim;
            for (i=0; i<5; i++) {
                ts1=r.Next (0, 100);
                try {indirim=new �skonto (ts1);}catch (�skontom ht) {Console.WriteLine ("HATA: " + ht.Message);}
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}