// tpc#06a.cs: Veri tipleri aras�nda �evrimler �rne�i.

using System;
namespace Tip�evrimi {
    class DoubleInt {
        static void Main (string[] args) {
            Console.WriteLine ("��sel �evrimler program�n g�venli�i bak�m�ndan otomatikmen yap�l�r.\nD��sal �evrimlerse i�lemci/metod kullan�larak kullan�c�n�n ger�ekle�tirdi�i �evrimlerdir.\n�rnek:\n");
            double d = 5673.74;
            int i;
            i = (int) d;
            Console.Write ("double d de�eri: {0} ve ebat�: {1} byte\nint i de�eri: {2} ve ebat�: {3} byte\n\nTu�...", d, sizeof (double), i, sizeof (int));
            Console.ReadKey();
        }
    }
}