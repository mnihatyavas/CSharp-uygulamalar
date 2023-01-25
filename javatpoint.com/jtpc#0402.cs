// jtpc#0402.cs: De�erle fonksiyon �a�r�s�nda orijinal de�erin de�i�mezli�i �rne�i.

using System;
namespace Fonksiyonlar {
    class De�erle�a�r� {
        public void G�ster (int n) {
            n *=n;
            Console.WriteLine ("Fonksiyon i�indeki i�lenen de�er: {0}", n);
        }
        static void Main () {
            Console.Write ("De�erle �a�r�da, fonksiyona parametreli g�nderilen de�i�kenin kopya i�eri�i, fonksiyon i�inde de�i�se dahi, de�i�iklik �a��ran programdaki orijinal de�i�kenin de�erini de�i�tirmez.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int n = 50;
            Console.WriteLine ("Fonksiyonu �a��rmadan �nceki de�i�ken de�eri: {0}", n);
            new De�erle�a�r�().G�ster (n);
            Console.WriteLine ("Fonksiyonu �a��rd�ktan sonraki orijinal de�i�ken de�eri: {0}", n);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}