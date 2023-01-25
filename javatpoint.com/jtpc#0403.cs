// jtpc#0403.cs: "ref"le fonksiyon �a�r�s�nda orijinal de�erin de de�i�irli�i �rne�i.

using System;
namespace Fonksiyonlar {
    class Ref�a�r� {
        public void G�ster (ref int n2) {
            n2 *=n2;
            Console.WriteLine ("Fonksiyon i�indeki i�lenen de�er: {0}", n2);
        }
        static void Main () {
            Console.Write ("Arg�manla �a��ran ve parametreyle alan fonksiyon de�erleri �n�ndeki 'ref' anahtarkelimesiyle, ayn� bellek adresini g�rd�klerinden, fonksiyondaki de�i�iklik aynen orijinal de�i�kene de yans�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n1 = 50;
            Console.WriteLine ("Fonksiyonu �a��rmadan �nceki de�i�ken de�eri: {0}", n1);
            new Ref�a�r�().G�ster (ref n1);
            Console.WriteLine ("Fonksiyonu �a��rd�ktan sonraki orijinal de�i�ken de�eri: {0}", n1);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}