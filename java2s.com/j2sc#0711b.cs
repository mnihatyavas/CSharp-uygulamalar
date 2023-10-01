// j2sc#0711b.cs: Anasýnýf, altsýnýf ve istisnasýnýf kurucularýnýn iliþkileri örneði.

using System;
namespace Sýnýflar {
    public class TemelSýnýf {
        int x;
        public int y;
        public int X {get {return x;} set {x = value;} }
        public TemelSýnýf() {Console.WriteLine ("Parametresiz TemelSýnýf() kuruluyor..."); x=y=0;}
        public TemelSýnýf (int i) {Console.WriteLine ("Tek parametreli TemelSýnýf(int) kuruluyor..."); x=i; y=0;}
        public TemelSýnýf (int i, int j) {Console.WriteLine ("Çift parametreli TemelSýnýf(int, int) kuruluyor..."); x=i; y=j;}
        public void Göster() {Console.WriteLine ("\tint (x, y) = ({0}, {1})", x, y);}
    }
    public class AltSýnýf : TemelSýnýf {
        public AltSýnýf() {Console.WriteLine ("Parametresiz AltSýnýf() kuruluyor..."); X=base.y=0;}
        public AltSýnýf (int i) {Console.WriteLine ("Tek parametreli AltSýnýf(int) kuruluyor..."); X=i; base.y=0;}
        public AltSýnýf (int i, int j) {Console.WriteLine ("Çift parametreli AltSýnýf(int, int) kuruluyor..."); X=i; base.y=j;}
    }
    class KrkDiziSýnýfý {
        char[] krkDizi;
        int güncelEbat;
        public KrkDiziSýnýfý (int azamiEbat) {
            krkDizi = new char [azamiEbat];
            güncelEbat = 0;
        }
        public KrkDiziSýnýfý (KrkDiziSýnýfý kds) {
            krkDizi = new char [kds.krkDizi.Length];
            for (int i=0; i < kds.güncelEbat; i++) krkDizi [i] = kds.krkDizi [i];
            güncelEbat = kds.güncelEbat;
        }
        public void krkEkle (char krk) {
            if (güncelEbat == krkDizi.Length) {Console.WriteLine ("-- krkDizi dolu."); return;}
            krkDizi [güncelEbat] = krk;
            güncelEbat++;
        }
        public char krkÇýkar() {
            if (güncelEbat == 0) {Console.WriteLine ("-- krkDizi boþ."); return (char)0;}
            güncelEbat--;
            return krkDizi [güncelEbat];
        }
        public bool doluMu() {return güncelEbat == krkDizi.Length;}
        public bool boþMu() {return güncelEbat == 0;}
        public int azamiKapasite() {return krkDizi.Length;}
        public int aktüelEbat() {return güncelEbat;}
    }
    class Þekil {
        double en; //private
        double boy; //private
        public double En {get {return en;} set {en = value;} }
        public double Boy {get {return boy;} set {boy = value;} }
        public void gösterEnBoy() {Console.WriteLine ("(en, boy) = ({0}, {1})", En, Boy);}
    }
    class Üçgen : Þekil {
        string tip; // private
        public Üçgen (string t, double e, double b) {En = e; Boy = b; tip = t;}
        public double alan() {return En * Boy / 2;}
        public void gösterTip() {Console.WriteLine ("Üçgen'in tipi: " + tip);}
    }
    public class Ýskonto {
        private int yüzde;
        public Ýskonto (int yüzde) {
            this.yüzde = yüzde;
            if (yüzde > 50) throw new Ýskontom ("Hatalý iskonto > 50%: %" + this.yüzde);
            else Console.WriteLine ("Onaylý iskonto: %" + this.yüzde);
        }
    }
    public class Ýskontom: Exception {public Ýskontom (String mesaj) : base (mesaj) {} }
    class Kurucu2 {
        static void Main() {
            Console.Write ("Altsýnýftan temelsýnýf 'private' alanýna temelsýnýf get/set'iyle, 'public' alanýnaysa base.alan'la eriþilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Türetilenin temel sýnýf alan ve metotlarýný kullanmasý:");
            var r=new Random(); int ts1, ts2, i;
            AltSýnýf as1 = new AltSýnýf(); as1.Göster();
            ts1=r.Next (-100, 100); as1 = new AltSýnýf (ts1); as1.Göster();
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); as1 = new AltSýnýf (ts1, ts2); as1.Göster();
            ts1=r.Next (-100, 100); ts2=r.Next (-100, 100); as1 = new AltSýnýf (ts1, ts2); as1.Göster();

            Console.WriteLine ("\nAzami krkDizi'ye [boþ, dolu] krk ekleme, kopyalama ve çýkarma:");
            KrkDiziSýnýfý kds1 = new KrkDiziSýnýfý (26);
            char krk;
            Console.WriteLine ("Öncelikle kds1'e 26 krk [A, Z] ekle.");
            for (i=0; !kds1.doluMu(); i++) kds1.krkEkle ((char) ('A' + i));
            Console.WriteLine ("Sonra kds1'i kds2'ye kopyala.");
            KrkDiziSýnýfý kds2 = new KrkDiziSýnýfý (kds1); //Ýlkini kopyala
            Console.Write ("krkDiz1/kds1 içeriklerini sondan-baþa çýkar: ");
            while (!kds1.boþMu()) {krk = kds1.krkÇýkar(); Console.Write (krk);} Console.WriteLine();
            Console.Write ("krkDiz1/kds2 içeriklerini sondan-baþa çýkar: ");
            while (!kds2.boþMu()) {krk = kds2.krkÇýkar(); Console.Write (krk);} Console.WriteLine();
            Console.WriteLine ("kds1 boþ mu? " + kds1.boþMu()); Console.WriteLine ("kds2 boþ mu? " + kds2.boþMu());
            Console.WriteLine ("kds1 güncelEbat/azamiKapasite: {0}/{1}", kds1.aktüelEbat(), kds1.azamiKapasite()); 

            Console.WriteLine ("\nÞekil'i miraslayan (ikizkenar ve dik) üçgen alanlarý:");
            Üçgen ü1 = new Üçgen ("ikizkenar", 18.5, 18.5);
            Üçgen ü2 = new Üçgen ("dik", 18.5, 52.60);
            Console.WriteLine ("\t==>ü1 bilgileri: ");
            ü1.gösterTip(); ü1.gösterEnBoy();
            Console.WriteLine ("Alaný " + ü1.alan());
            Console.WriteLine ("\t==>ü2 bilgileri: ");
            ü2.gösterTip(); ü2.gösterEnBoy();
            Console.WriteLine ("Alaný " + ü2.alan());

            Console.WriteLine ("\nÝndirim >= %50'de istisna fýrlatýlmasý:");
            Ýskonto indirim;
            for (i=0; i<5; i++) {
                ts1=r.Next (0, 100);
                try {indirim=new Ýskonto (ts1);}catch (Ýskontom ht) {Console.WriteLine ("HATA: " + ht.Message);}
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}