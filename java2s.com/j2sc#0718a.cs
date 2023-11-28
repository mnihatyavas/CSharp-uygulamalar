// j2sc#0718a.cs: Sınıf alan değerinin set-get'li özellikle konulması-alınması örneği.

using System;
namespace Sınıflar {
    class Özellik {
        int özlk;
        public Özellik() {özlk = 0;} //İlkdeğerleyen kurucu
        public int Özlk {get {return özlk;} set {özlk = value;}}
    }
    class Sınıf {
        public double A = 0, B = 0;
        public double Topla {get {return (A + B);}}
        public double Çıkar {get {return (A - B);}}
        public double Çarp {get {return (A * B);}}
        public double Böl {get {return (A / B);}}
        public double Kalan {get {return (Math.Abs(A) > Math.Abs(B)? Math.Abs(A)%Math.Abs(B) : Math.Abs(B)%Math.Abs(A));}}
    }
    class Adres {
        protected string şehir;
        public string Şehir {get {return şehir;}}
        protected string pk;
        public string PK {get {return pk;} set {pk = value; şehir = "Mersin";}}
    }
    class Şekil {
        double en, boy; //private  
        public double En {get {return en;} set {en = value;}}
        public double Boy {get {return boy;} set {boy = value;}}
    }
    class Üçgen : Şekil {
        string tür; //Üçgenin türü
        public string Tür {get {return tür;} set {tür = value;}}
        public double alan() {return En * Boy / 2;} 
    }
    class Dizim { 
        float[] a;
        int uz;
        public bool hatalıMı;
        public Dizim (int ebat) {a = new float [ebat]; uz = ebat;} //Tek parametreli kurucu
        public int Uz {get {return uz;}}
        public float this [int endeks] {
            get {if (endeksKontrol (endeks)) {hatalıMı = false; return a [endeks];}
                else {hatalıMı = true; return 0;}
            }
            set {if (endeksKontrol (endeks)) {a [endeks] = value; hatalıMı = false;}
                else hatalıMı = true;
            }
        }
        private bool endeksKontrol (int endeks) {
            if (endeks >= 0 & endeks < Uz) return true;
            return false;
        }
    }
    class Atam {
        private int yıl = 1881;
        public int Yıl {set {yıl = value;} get {return yıl;}}
    }
    public class A {
        private int n;
        public int N {
           set {Console.Write ("Değer konuluyor..."); n = value;}
           get {Console.Write ("\tKonulan değer alınıyor: " ); return n;}
        }
    }
    class Özellik1 {
        static void Main() {
            Console.Write ("Özellik, bir ad ve içi değer al-koy/get-set'li bir {} gövdeden oluşur. Metot parametresiyken ref veya out olamaz. Özelliğin aşırıyüklenimi/overload olmaz. Ait olduğu alan değişkenin tipini değiştiremez.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Özelliğe set-get'li değer/value atama ve okuma:");
            var r=new Random(); int ts1, i;
            Özellik öz = new Özellik(); Console.WriteLine ("öz.Özlk'in ilk kurulum değeri = " + öz.Özlk);
            for(i=1;i<=5;i++) {
                ts1=r.Next(-1000, 1000);
                öz=new Özellik();
                öz.Özlk = ts1;
                Console.WriteLine ("{0})inci öz.Özlk değeri = {1}", i, öz.Özlk);
            }

            Console.WriteLine ("\nA ve B ile özellikler (topla, çıkar, çarp, böl, abs(kalan)):");
            double ds1, ds2;
            Sınıf s;
            for(i=1;i<=5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(1000,10000)/10000D; ds2=r.Next(-1000,1000)+r.Next(1000,10000)/10000D;
                s=new Sınıf();
                s.A = ds1; s.B = ds2;
                Console.WriteLine ("{0}) A={1} ve B={2} ise: ({3:0.00}, {4:0.00}, {5:0.00}, {6:.00}, {7:0.00})", i, s.A, s.B, s.Topla, s.Çıkar, s.Çarp, s.Böl, s.Kalan);
            }

            Console.WriteLine ("\nMetsin'in Şehir ve PK özellikleri:");
            Adres adr;
            for(i=1;i<=5;i++) {
                ts1=r.Next(100,1000);
                adr=new Adres();
                adr.PK="33"+ts1;
                Console.WriteLine ("{0}.inci (Şehir, PK) = ({1}, {2})", i, adr.Şehir, adr.PK);
            }

            Console.WriteLine ("\nÜçgen'in Tür, En, Boy özelliklerini koy-al ve alan()'ını hesapla:");
            string[] tür=new string[] {"dik", "ikizkenar", "eşkenar", "farklıkenar", "eğrikenar"};
            Üçgen üçg;
            for(i=0;i<5;i++) {
                üçg=new Üçgen();
                üçg.En=r.Next(1,20)+r.Next(1000,10000)/10000D; üçg.Boy=r.Next(1,20)+r.Next(1000,10000)/10000D;
                üçg.Tür=tür [i];
                Console.WriteLine ("{0}.inci {1} üçgenin (en, boy, alan) = ({2}, {3}, {4:0.0000})", (i+1), üçg.Tür, üçg.En, üçg.Boy, üçg.alan());
            }

            Console.WriteLine ("\nŞartlı get-set'le dizinin eksi ve taşan endekslerinin tespiti:"); //Tespit edilenen değeri 0.00 döndürür.
            Dizim dizim = new Dizim (10);
            float x;
            for (i=0; i < dizim.Uz; i++)  dizim [i] = r.Next(-100,100)+r.Next(1000,10000)/10000F;
            for (i=-2; i < dizim.Uz+2; i++) {
                x = dizim [i];
                Console.Write ("dizim[{0}]={1:0.00##}, ", i, x);
            } Console.WriteLine();

            Console.WriteLine ("\n'private' alana 'public' set-get özellikle erişim:");
            Atam ata = new Atam();
            Console.Write  ("İlk Yıl: {0},\t", ata.Yıl);
            for(i=1882;i<1938;i++) {
                ata.Yıl=i;
                Console.Write (ata.Yıl + ", ");
            } Console.Write  ("\tSon Yıl: {0}\n", ++ata.Yıl);

            Console.WriteLine ("\nÖzellik vasıtasıyla değer konulması ve alınması:");
            A nes = new A();
            for(i=1;i<=5;i++) {
                nes.N=r.Next(-10000,10000);
                Console.Write (nes.N + "\n");
            }

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}