// tpc#32b.cs: �sim listesini a��r�y�kl� endeksleyicinin konum ve adlar�yla yazma ve okuma �rne�i.

using System;
namespace Endeksleyiciler {
    class A��r�y�klenenEndeksleyici {
        private string[] isimListesi = new string [ebat];
        static public int ebat = 10;
        public A��r�y�klenenEndeksleyici() {for (int i = 0; i < ebat; i++) isimListesi [i] = "NaMevcut";}
        public string this [int endeks] {
            get {
                string ge�ici;
                if (endeks >= 0 && endeks <= ebat-1) {ge�ici = isimListesi [endeks];
                }else {ge�ici = "";}
                return (ge�ici);
            }
            set {if (endeks >= 0 && endeks <= ebat-1) {isimListesi [endeks] = value;} }
        }
        public int this [string ad] {// A��r�y�klenen this
            get {
                int endeks = 0;
                while (endeks < ebat) {if (isimListesi [endeks] == ad) {return endeks;} endeks++;}
                return 0; // Gereksiz
            }
        }
        static void Main() {
            Console.Write ("Endeksleyici a��r�y�klenebilir. 'this' endeksleyicinin gerid�n��� dizgesel isim oldu�u gibi tamsay� endeksNo da olabilir. Ve tiplenenin eri�im endeksi ebat say�lar� oldu�u gibi isimler de olabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            A��r�y�klenenEndeksleyici isimler = new A��r�y�klenenEndeksleyici();
            isimler [0] = "M.Nihat Yava�";
            isimler [1] = "Hatice Yava� Ka�ar";
            isimler [2] = "S�heyla Y.�zbay";
            isimler [3] = "Zeliha Y.Candan";
            isimler [4] = "M.Nedim Yava�";
            isimler [5] = "Song�l Y.G�kt�rk";
            isimler [6] = "Sevim Yava�";
            for (int i = 0; i < A��r�y�klenenEndeksleyici.ebat; i++) {Console.WriteLine (isimler [i]);}
            Console.WriteLine (isimler ["Sevim Yava�"]);
            Console.WriteLine ("{0}'�n endeks no'su: {1}", isimler [3], isimler ["Zeliha Y.Candan"]); // isimler[] endeksi hem tamsay�, hem de a��r�y�klenen dizge olabilir

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}