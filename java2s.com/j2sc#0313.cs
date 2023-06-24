// j2sc#0313.cs: "a as tip" ile de�i�ken tipleme kabul�n�n irdelenmesi �rne�i.

using System;
using System.IO;
namespace ��lemciler {
    interface Yaz�labilir {
        void MarjX (float �arpan);
        void MarjY (float �arpan);
        void MarjZ (float �arpan);
    }
    public class Bile�en {
        public Bile�en() {}
    }
    public class MetinAlan�: Bile�en, Yaz�labilir {
        private string metin;
        public MetinAlan� (string metin) {this.metin = metin;}
        public void MarjX (float �arpan) {Console.WriteLine ("MarjX: {0} * {1}", metin, �arpan);}
        public void MarjY (float �arpan) {Console.WriteLine ("MarjY: {0} * {1}", metin, �arpan);}
        public void MarjZ (float �arpan) {Console.WriteLine ("MarjZ: {0} * {1}", metin, �arpan);}
    }
    class A {}
    class B : A {}
    class as_��lemci {
        static void Main() {
            Console.Write ("'as' tip atfederken ba�ar�s�z olur, tipli referans yerine 'null' d�nd�rse de istisna f�rlatmaz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("\n'if ((bl�n as Yaz�labilir) != null)' ise belge marjlar�n�n tan�mlanmas�:");
            Bile�en[] bile�enDizisi = new Bile�en [10];
            bile�enDizisi [0] = new Bile�en();
            bile�enDizisi [1] = new MetinAlan� ("A");
            bile�enDizisi [2] = new MetinAlan� ("B");
            bile�enDizisi [3] = new Bile�en();
            bile�enDizisi [4] = new MetinAlan� ("C");
            foreach (Bile�en bl�n in bile�enDizisi) {
                Yaz�labilir �l�ekliBelge = bl�n as Yaz�labilir;
                if (�l�ekliBelge != null) {
                     �l�ekliBelge.MarjX (0.1F);
                     �l�ekliBelge.MarjY (10.0F);
                     �l�ekliBelge.MarjZ (100.0F);
                }
            }

            Console.WriteLine ("\n'if((new StringReader() as TextReader) != null)' ise:");
            Object okurNesnesi = new StringReader ("okurNesnesi bir StringReader veya t�revi'dir.");
            var okuyucu1 = okurNesnesi as TextReader;
            if (okuyucu1 != null) {Console.WriteLine ("as: okurNesnesi bir StringReader veya t�revi'dir.");}
            var okuyucu2 = okurNesnesi as Bile�en;
            if (okuyucu2 != null) {Console.WriteLine ("as: okurNesnesi bir StringReader veya t�revi'dir.");}
            else {Console.WriteLine ("as: (okurNesnesi as Bile�en) = null'dur.");}

            Console.WriteLine ("\n'if ((a as B) == null)' ile A ve t�revi B tiplemelerinin irdelenmesi:");
            A a = new A();
            B b = new B();
            var c = a as B;
            var d = b as A;
            if (c==null) Console.WriteLine ("'c = a as B' kabul edilmemi�tir.");
            else Console.WriteLine ("'c = a as B' kabul edilmi�tir.");
            if (d==null) Console.WriteLine ("'d = (A) b' kabul edilmemi�tir.");
            else Console.WriteLine ("'d = (A) b' kabul edilmi�tir.");
 
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}