// j2sc#0313.cs: "a as tip" ile deðiþken tipleme kabulünün irdelenmesi örneði.

using System;
using System.IO;
namespace Ýþlemciler {
    interface Yazýlabilir {
        void MarjX (float çarpan);
        void MarjY (float çarpan);
        void MarjZ (float çarpan);
    }
    public class Bileþen {
        public Bileþen() {}
    }
    public class MetinAlaný: Bileþen, Yazýlabilir {
        private string metin;
        public MetinAlaný (string metin) {this.metin = metin;}
        public void MarjX (float çarpan) {Console.WriteLine ("MarjX: {0} * {1}", metin, çarpan);}
        public void MarjY (float çarpan) {Console.WriteLine ("MarjY: {0} * {1}", metin, çarpan);}
        public void MarjZ (float çarpan) {Console.WriteLine ("MarjZ: {0} * {1}", metin, çarpan);}
    }
    class A {}
    class B : A {}
    class as_Ýþlemci {
        static void Main() {
            Console.Write ("'as' tip atfederken baþarýsýz olur, tipli referans yerine 'null' döndürse de istisna fýrlatmaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\n'if ((blþn as Yazýlabilir) != null)' ise belge marjlarýnýn tanýmlanmasý:");
            Bileþen[] bileþenDizisi = new Bileþen [10];
            bileþenDizisi [0] = new Bileþen();
            bileþenDizisi [1] = new MetinAlaný ("A");
            bileþenDizisi [2] = new MetinAlaný ("B");
            bileþenDizisi [3] = new Bileþen();
            bileþenDizisi [4] = new MetinAlaný ("C");
            foreach (Bileþen blþn in bileþenDizisi) {
                Yazýlabilir ölçekliBelge = blþn as Yazýlabilir;
                if (ölçekliBelge != null) {
                     ölçekliBelge.MarjX (0.1F);
                     ölçekliBelge.MarjY (10.0F);
                     ölçekliBelge.MarjZ (100.0F);
                }
            }

            Console.WriteLine ("\n'if((new StringReader() as TextReader) != null)' ise:");
            Object okurNesnesi = new StringReader ("okurNesnesi bir StringReader veya türevi'dir.");
            var okuyucu1 = okurNesnesi as TextReader;
            if (okuyucu1 != null) {Console.WriteLine ("as: okurNesnesi bir StringReader veya türevi'dir.");}
            var okuyucu2 = okurNesnesi as Bileþen;
            if (okuyucu2 != null) {Console.WriteLine ("as: okurNesnesi bir StringReader veya türevi'dir.");}
            else {Console.WriteLine ("as: (okurNesnesi as Bileþen) = null'dur.");}

            Console.WriteLine ("\n'if ((a as B) == null)' ile A ve türevi B tiplemelerinin irdelenmesi:");
            A a = new A();
            B b = new B();
            var c = a as B;
            var d = b as A;
            if (c==null) Console.WriteLine ("'c = a as B' kabul edilmemiþtir.");
            else Console.WriteLine ("'c = a as B' kabul edilmiþtir.");
            if (d==null) Console.WriteLine ("'d = (A) b' kabul edilmemiþtir.");
            else Console.WriteLine ("'d = (A) b' kabul edilmiþtir.");
 
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}