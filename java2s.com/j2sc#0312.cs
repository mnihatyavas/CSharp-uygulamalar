// j2sc#0312.cs: "a is tip" ile deðiþken tipinin irdelenmesi örneði.

using System;
using System.IO;
namespace Ýþlemciler {
    interface Yazýlabilir1 {
        void yaz (string ad);
    }
    class YazýlabilirBelge: Yazýlabilir1 {
        public void yaz (string ad) {Console.WriteLine ("Yazýlan belge adý: {0}", ad);}
    }
    class YazýlamazBelge{}
    class A {}
    class B : A {}
    interface Yazýlabilir2 {
        void MarjX (float çarpan);
        void MarjY (float çarpan);
        void MarjZ (float çarpan);
    }
    public class Bileþen {
        public Bileþen() {}
    }
    public class MetinAlaný: Bileþen, Yazýlabilir2 {
        private string metin;
        public MetinAlaný (string metin) {this.metin = metin;}
        public void MarjX (float çarpan) {Console.WriteLine ("MarjX: {0} * {1}", metin, çarpan);}
        public void MarjY (float çarpan) {Console.WriteLine ("MarjY: {0} * {1}", metin, çarpan);}
        public void MarjZ (float çarpan) {Console.WriteLine ("MarjZ: {0} * {1}", metin, çarpan);}
    }
    class is_Ýþlemci {
        public static void YazýlabilirlikTesti (string belge, params object[] belgeler) {
            foreach (object ns in belgeler) {
                if (ns is Yazýlabilir1) {
                    Yazýlabilir1 y = (Yazýlabilir1) ns;
                    y.yaz (belge);
                }else Console.WriteLine (ns + ": Bu belge yazýlamaz...");
            }
        }
        static void Main() {
            Console.Write ("'Nesne, belirtilen tipte mi?' sorar..\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'if (ns is Yazýlabilir1)' ile belge yazýlabilirliðinin irdelenmesi:");
            YazýlabilirlikTesti ("j2sc#0312.cs", new YazýlabilirBelge(), new YazýlamazBelge());
            YazýlabilirlikTesti ("j2sc#0312.exe", new YazýlamazBelge(), new YazýlabilirBelge());

            Console.WriteLine ("\n'if (a is A)' ile A ve türevi B nesnelerin tiplerinin irdelenmesi:");
            A a = new A();
            B b = new B();
            if (a is A) Console.WriteLine ("a tiplemesi bir A sýnýf nesnesidir.");
            if (b is A) Console.WriteLine ("b tiplemesi bir A sýnýf nesnesidir, çünkü A'dan türevlenmiþtir.");
            if (!(a is B)) Console.WriteLine ("a tiplemesi bir B sýnýf nesnesi deðildir, ondan türevlenmemiþtir.");
            if (b is B) Console.WriteLine ("b tiplemesi bir B sýnýf nesnesidir.");
            if (a is object & b is object) Console.WriteLine ("a ve b tiplemeleri bir object/nesne'dir.");

            Console.WriteLine ("\n'if (d is Yazýlabilir2)' ise belge marjlarýnýn tanýmlanmasý:");
            Bileþen[] bileþenDizisi = new Bileþen [10];
            bileþenDizisi [0] = new Bileþen();
            bileþenDizisi [1] = new MetinAlaný ("A");
            bileþenDizisi [2] = new MetinAlaný ("B");
            bileþenDizisi [3] = new Bileþen();
            bileþenDizisi [4] = new MetinAlaný ("C");
            foreach (Bileþen blþ in bileþenDizisi) {
                if (blþ is Yazýlabilir2) {
                    Yazýlabilir2 ölçekliBelge = (Yazýlabilir2) blþ;
                     ölçekliBelge.MarjX (0.1F);
                     ölçekliBelge.MarjY (10.0F);
                     ölçekliBelge.MarjZ (100.0F);
                }
            }

            Console.WriteLine ("\nnew StringReader() is TextReader?");
            Object okurNesnesi = new StringReader ("Bu bir StringReader DizgeOkuyucu'dur.");
            if (okurNesnesi is TextReader) {Console.WriteLine ("is: okurNesnesi bir TextReader MetinOkuyucu veya türevli sýnýfýdýr.");}

            Console.WriteLine ("\nlong ls is (int, long, float)?");
            long longSayý=20230623;
            Console.WriteLine ("longSayý is int = " + (longSayý is int));
            Console.WriteLine ("longSayý is long = " + (longSayý is long));
            Console.WriteLine ("longSayý is float = " + (longSayý is float));
            Console.WriteLine ("longSayý is object = " + (longSayý is object));

            Console.WriteLine ("\n(dizge, nesne) is (string, object)?");
            String dizge = "MNYavaþ";
            Object nesne1 = new Object(); nesne1="MNY";
            Object nesne2 = dizge;
            Object nesne3 = longSayý;
            Console.WriteLine ("dizge({0}) bir String{1}dir.", dizge, dizge is String ? "'" : " deðil");
            Console.WriteLine ("nesne1({0}) bir Object{1}dir.", nesne1, nesne1 is Object ? "'" : " deðil");
            Console.WriteLine ("nesne2({0}) bir Object{1}dir.", nesne2, nesne2 is Object ? "'" : " deðil");
            Console.WriteLine ("nesne3({0}) bir Object{1}dir.", nesne3, nesne3 is Object ? "'" : " deðil");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}