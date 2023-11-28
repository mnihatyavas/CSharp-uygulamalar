// j2sc#0721a.cs: Statik sınıf metotlarının tiplemesiz uzantılı yürütülmesi örneği.

using System;
namespace Sınıflar {
    static class StatikSınıf1 {  
        static public double bireBölümü (double n) {return 1/n;}
        static public double küsüratı (double n) {return n - (int)n;}
        static public bool çiftMi (double n) {return ((int)n % 2) == 0 ? true : false;}
        static public bool tekMi(double n) {return !çiftMi (n);}
    }
    public static class StatikSınıf2 {
        public static int Sayaç = 0;
        public static void İşYap() {++Sayaç; Console.Write ("StatikSınıf2.İşYap()");}
        public class İçSınıf {public İçSınıf() {Console.Write ("\tİçSınıf.İçSınıf() kuruculu tipleme");}}
    }
    class DışSınıf<A> {
        public class NormalİçSınıf<B, C> {
            static int Sayaç = 0;
            public static void StatikMetot1() {Console.WriteLine ("DışSınıf<{0}>.NormalİçSınıf<{1},{2}>.StatikMetot1()\tSayaç = {3}", typeof (A).Name, typeof (B).Name, typeof (C).Name, ++Sayaç);}
            public static void StatikMetot2() {Console.WriteLine ("\tDışSınıf<A>.NormalİçSınıf<B,C>.StatikMetot2()\tSayaç = {0}", ++Sayaç);}
        }
    }
    class SınıfA {
        public static int N=20231102;
        static SınıfA() {Console.WriteLine ("SınıfA'nın statik kurucusu: {0}", N);}
    }
    class SınıfB {
        private static Random RasgeleTS;
        static SınıfB() {RasgeleTS = new Random(); Console.WriteLine ("SınıfB'nin statik kurucusu 'new Random()' atadı.");}
        public int DeğeriAl() {return RasgeleTS.Next();}
    }
    class Statik1 {
        static void Main() {
            Console.Write ("Statik sınıf tiplenmeden metotları doğrudan sınıf adı uzantılı kullanılmalıdır. Tiplennmesi derleme hatası verir. Ancak statik sınıf içindeki normal sınıf-lar tiplenebilir.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Verili sayıların (bireBölümü, küsüratı, çiftMi, tekMi) sonuçları:");
            var r=new Random(); int ts1, i; double ds1;
            for(i=0;i<5;i++) {
                ds1=r.Next(-1000,1000)+r.Next(10,100)/100D;
                Console.WriteLine ("{0:0.00} sayısı = ({1:0.0000}, {2:0.00}, {3}, {4})", ds1, StatikSınıf1.bireBölümü (ds1), StatikSınıf1.küsüratı (ds1), StatikSınıf1.çiftMi (ds1), StatikSınıf1.tekMi (ds1));
            }
            //StatikSınıf1 ss1 = new StatikSınıf1(); Console.WriteLine (ss1.bireBölümü (ds1)); //Derleme hatası 

            Console.WriteLine ("\nStatik ve içerdiği normal sınıf'la her çağrıda artan sayaç:");
            StatikSınıf2.İçSınıf iç;
            for(i=0;i<5;i++) {
                StatikSınıf2.İşYap(); iç=new StatikSınıf2.İçSınıf();
                Console.Write("\tSayaç = {0}\n", StatikSınıf2.Sayaç);
            }

            Console.WriteLine ("\nİçiçe normal sınıftaki statik metotların çağrılması:");
            for(i=0;i<5;i++) {
                DışSınıf<int>.NormalİçSınıf<string, DateTime>.StatikMetot1();
                DışSınıf<int>.NormalİçSınıf<string, DateTime>.StatikMetot2();
            }

            Console.WriteLine ("\nÇoklu döngüde sadece tek kere yürütülen statik kurucu:");
            for(i=0;i<5;i++) {ts1=r.Next(1000,10000); SınıfA.N = ts1; Console.WriteLine (SınıfA.N);}

            Console.WriteLine ("\nStatik kurucunun tek kerelik rasgele tipleme yapması:");
            SınıfB sb = new SınıfB();
            for(i=0;i<5;i++) {sb=new SınıfB(); Console.WriteLine ("{0:#,0}", sb.DeğeriAl());}

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}