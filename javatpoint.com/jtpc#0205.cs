// jtpc#0205.cs: De�i�kenler ve kurallar� �rne�i.

using System;
namespace CSE�itimi {
    class De�i�kenler {
        static void Main () {
            Console.Write ("De�i�ken, i�ine de�er y�klenen bellek konumu sembol�d�r.\nDe�i�ken �e�itleri: decimal/ondal�k, boolean/ikili (true, false), tamsay� (int, char, byte, short, long), kayannokta (float, double), hi�lenebilen.\n�rn1: int i, j; double d; float f; char krk;\n�rn2: int i=2023, j=1957; float f=3.14; char krk='A';\nKurallar�: De�i�ken ad� harf ve alt�izgiyle ba�layabilir, sonras�nda say� da olabilir. Anahtarkelimeler (int, class, fixed, for gibi) ve bo�luk kullan�lmaz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}