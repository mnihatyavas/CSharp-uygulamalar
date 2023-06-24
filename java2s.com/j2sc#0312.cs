// j2sc#0312.cs: "a is tip" ile de�i�ken tipinin irdelenmesi �rne�i.

using System;
using System.IO;
namespace ��lemciler {
    interface Yaz�labilir1 {
        void yaz (string ad);
    }
    class Yaz�labilirBelge: Yaz�labilir1 {
        public void yaz (string ad) {Console.WriteLine ("Yaz�lan belge ad�: {0}", ad);}
    }
    class Yaz�lamazBelge{}
    class A {}
    class B : A {}
    interface Yaz�labilir2 {
        void MarjX (float �arpan);
        void MarjY (float �arpan);
        void MarjZ (float �arpan);
    }
    public class Bile�en {
        public Bile�en() {}
    }
    public class MetinAlan�: Bile�en, Yaz�labilir2 {
        private string metin;
        public MetinAlan� (string metin) {this.metin = metin;}
        public void MarjX (float �arpan) {Console.WriteLine ("MarjX: {0} * {1}", metin, �arpan);}
        public void MarjY (float �arpan) {Console.WriteLine ("MarjY: {0} * {1}", metin, �arpan);}
        public void MarjZ (float �arpan) {Console.WriteLine ("MarjZ: {0} * {1}", metin, �arpan);}
    }
    class is_��lemci {
        public static void Yaz�labilirlikTesti (string belge, params object[] belgeler) {
            foreach (object ns in belgeler) {
                if (ns is Yaz�labilir1) {
                    Yaz�labilir1 y = (Yaz�labilir1) ns;
                    y.yaz (belge);
                }else Console.WriteLine (ns + ": Bu belge yaz�lamaz...");
            }
        }
        static void Main() {
            Console.Write ("'Nesne, belirtilen tipte mi?' sorar..\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'if (ns is Yaz�labilir1)' ile belge yaz�labilirli�inin irdelenmesi:");
            Yaz�labilirlikTesti ("j2sc#0312.cs", new Yaz�labilirBelge(), new Yaz�lamazBelge());
            Yaz�labilirlikTesti ("j2sc#0312.exe", new Yaz�lamazBelge(), new Yaz�labilirBelge());

            Console.WriteLine ("\n'if (a is A)' ile A ve t�revi B nesnelerin tiplerinin irdelenmesi:");
            A a = new A();
            B b = new B();
            if (a is A) Console.WriteLine ("a tiplemesi bir A s�n�f nesnesidir.");
            if (b is A) Console.WriteLine ("b tiplemesi bir A s�n�f nesnesidir, ��nk� A'dan t�revlenmi�tir.");
            if (!(a is B)) Console.WriteLine ("a tiplemesi bir B s�n�f nesnesi de�ildir, ondan t�revlenmemi�tir.");
            if (b is B) Console.WriteLine ("b tiplemesi bir B s�n�f nesnesidir.");
            if (a is object & b is object) Console.WriteLine ("a ve b tiplemeleri bir object/nesne'dir.");

            Console.WriteLine ("\n'if (d is Yaz�labilir2)' ise belge marjlar�n�n tan�mlanmas�:");
            Bile�en[] bile�enDizisi = new Bile�en [10];
            bile�enDizisi [0] = new Bile�en();
            bile�enDizisi [1] = new MetinAlan� ("A");
            bile�enDizisi [2] = new MetinAlan� ("B");
            bile�enDizisi [3] = new Bile�en();
            bile�enDizisi [4] = new MetinAlan� ("C");
            foreach (Bile�en bl� in bile�enDizisi) {
                if (bl� is Yaz�labilir2) {
                    Yaz�labilir2 �l�ekliBelge = (Yaz�labilir2) bl�;
                     �l�ekliBelge.MarjX (0.1F);
                     �l�ekliBelge.MarjY (10.0F);
                     �l�ekliBelge.MarjZ (100.0F);
                }
            }

            Console.WriteLine ("\nnew StringReader() is TextReader?");
            Object okurNesnesi = new StringReader ("Bu bir StringReader DizgeOkuyucu'dur.");
            if (okurNesnesi is TextReader) {Console.WriteLine ("is: okurNesnesi bir TextReader MetinOkuyucu veya t�revli s�n�f�d�r.");}

            Console.WriteLine ("\nlong ls is (int, long, float)?");
            long longSay�=20230623;
            Console.WriteLine ("longSay� is int = " + (longSay� is int));
            Console.WriteLine ("longSay� is long = " + (longSay� is long));
            Console.WriteLine ("longSay� is float = " + (longSay� is float));
            Console.WriteLine ("longSay� is object = " + (longSay� is object));

            Console.WriteLine ("\n(dizge, nesne) is (string, object)?");
            String dizge = "MNYava�";
            Object nesne1 = new Object(); nesne1="MNY";
            Object nesne2 = dizge;
            Object nesne3 = longSay�;
            Console.WriteLine ("dizge({0}) bir String{1}dir.", dizge, dizge is String ? "'" : " de�il");
            Console.WriteLine ("nesne1({0}) bir Object{1}dir.", nesne1, nesne1 is Object ? "'" : " de�il");
            Console.WriteLine ("nesne2({0}) bir Object{1}dir.", nesne2, nesne2 is Object ? "'" : " de�il");
            Console.WriteLine ("nesne3({0}) bir Object{1}dir.", nesne3, nesne3 is Object ? "'" : " de�il");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}