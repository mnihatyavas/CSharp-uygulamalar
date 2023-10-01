// j2sc#0708.cs: Sayýsal parametrelerde, çoklu kurucularda ve miraslayanda aþýrýyükleme örneði.

using System;
namespace Sýnýflar {
    class Aþýrýyükleme1 {
        public void aþyükMetot() {Console.WriteLine ("Parametresiz");}
        public void aþyükMetot (int a) {Console.WriteLine ("Geridönüþsüz tek int parametreli: " + a);}
        //public int aþyükMetot (int a) {Console.WriteLine ("int geridönüþlü tek int parametreli: " + a); return a*2;} //Birüstteki yüzünden derleme hatasý verir
        public int aþyükMetot (int a, int b) {Console.Write ("int geridönüþlü çift int parametreli: " + a + " + " + b + " = "); return a + b;}
        public double aþyükMetot (double a, double b) {Console.Write ("double geridönüþlü çift double parametreli: " + a + " + "+ b + " = "); return a + b;}
        public double aþyükMetot (double a, int b) {Console.Write ("int geridönüþlü çift double+int parametreli: " + a + " + "+ b + " = "); return a + b;}
    }
    public class Araba {
        private string marka;
        private string model;
        private string renk;
        private int imalYýlý;
        public Araba() {//Parametresiz kurucu
            this.marka = "Ford";
            this.model = "Mustang";
            this.renk = "kýrmýzý";
            this.imalYýlý = 1970;
        }
        public Araba (string marka) {//Tek parametreli kurucu aþýrýyükleme
            this.marka = marka;
            this.model = "Corvette";
            this.renk = "gümüþ";
            this.imalYýlý = 1969;
        }
        public Araba (string marka, string model, string renk, int imalYýlý) {//4 parametreli kurucu aþýrýyükleme
            this.marka = marka;
            this.model = model;
            this.renk = renk;
            this.imalYýlý = imalYýlý;
        }
        public void Göster() {Console.WriteLine ("(" + marka + ", " + model + ", " + renk + ", " + imalYýlý + ")");}
    }
    public class ÇýrakÝþgören {
        private int yaþ;
        public ÇýrakÝþgören() {yaþ = 15;} //Parametresiz ilkdeðer atamalý kurucu
        public virtual void yaþKoy (int yþ) {yaþ = yþ;}
        public virtual int yaþAl() {return yaþ;}
    }
    public class ReþitÝþgören : ÇýrakÝþgören {
        public ReþitÝþgören() {} //Parametresiz ilkdeðer atamasýz kurucu
        override public void yaþKoy (int yþ) {if (yþ > 18) base.yaþKoy (yþ); else base.yaþKoy (18);} //Aþýrýyükleme metot
    }
    class Aþýrýyükleme2 {
        public void aþyükMetot (int x) {Console.WriteLine ("aþyükMetot(int) içinde: " + x);} //int olmazsa long farzedilir
        public void aþyükMetot (long x) {Console.WriteLine ("aþyükMetot(long) içinde: " + x);}
        public void aþyükMetot (double x) {Console.WriteLine ("aþyükMetot(double) içinde: " + x);}
    }
    class MetotAþýrýYükleme {
        static void Main() {
            Console.Write ("Ayný adlý aþýrýyüklenen metotlarýn sadece geridönüþ tip farklýlýðý yetersiz olup, parametre tip ve sayýlarýnýn farklýlýðý esastýr. Parametre tiplerinden 'byte, short' birüstü 'int' yada mevcutsa 'long', 'float' ise 'double' olarak algýlanýr. Miraslayanda ayný adlý (esas) geçerli 'override' metodlar aþýrýyüklemelerdir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Ayný adlý farklý parametre ve geridönüþlü 5 metot:");
            var r=new Random(); int ts1=r.Next(1000, 10000), ts2=r.Next(1000, 10000); double ds1=r.Next(1000, 10000)+r.Next(1000, 10000)/10000D, ds2=r.Next(1000, 10000)+r.Next(1000, 10000)/10000D;
            Aþýrýyükleme1 ay1 = new Aþýrýyükleme1();
            ay1.aþyükMetot();
            ay1.aþyükMetot (ts1);
            Console.WriteLine (ay1.aþyükMetot (ts1, ts2) );
            Console.WriteLine (ay1.aþyükMetot (ds1, ds2) );
            Console.WriteLine (ay1.aþyükMetot (ds1, ts1) );
            Console.WriteLine (ay1.aþyükMetot (ts2, ds2) ); //Parametreleri double+double farzeder

            Console.WriteLine ("\nAst yoksa tamsayý üst 'long', küsüratlý üst 'double'dýr:");
            Aþýrýyükleme2 ay2 = new Aþýrýyükleme2();
            ts1=r.Next (1000, 10000);
            ds1=Math.PI;
            long ls1=long.MaxValue;
            byte b = 200;
            short s = 2023;
            float f = (float)Math.E; 
            ay2.aþyükMetot (ls1);
            ay2.aþyükMetot (ts1);
            ay2.aþyükMetot (b);
            ay2.aþyükMetot (s);
            ay2.aþyükMetot (ds1);
            ay2.aþyükMetot (f);

            Console.WriteLine ("\nAþýrýyüklemeli kurucularla araba (marka, model, renk, imalYýlý):");
            Araba arabam = new Araba ("Toyota", "MR2", "siyah", 1995); arabam.Göster();
            arabam = new Araba(); arabam.Göster();
            arabam = new Araba ("Chevrolet"); arabam.Göster();

            Console.WriteLine ("\nÇýrak temelli de olsa reþit yaþý 18 ve üstü yansýr:");
            ÇýrakÝþgören çi = new ÇýrakÝþgören(); çi.yaþKoy (13); Console.WriteLine ("ÇýrakÝþgören yaþ: {0}", çi.yaþAl());
            ReþitÝþgören ri = new ReþitÝþgören(); ri.yaþKoy (15); Console.WriteLine ("ReþitÝþgören yaþ: {0}", ri.yaþAl());
            ri = new ReþitÝþgören(); ri.yaþKoy (19); Console.WriteLine ("ReþitÝþgören yaþ: {0}", ri.yaþAl());
            ts1=r.Next (10, 65); ri = new ReþitÝþgören(); ri.yaþKoy (ts1); Console.WriteLine ("ReþitÝþgören yaþ: {0}", ri.yaþAl());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}