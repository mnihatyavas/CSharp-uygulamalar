// jtpc#2306e.cs: Say�sal rakamlar aras�ndaki alt�izgi ayrac� �rne�i.

using System;
namespace Yeni�zellikler {
    class RakamAyrac� {
        static void Main() {
            Console.Write ("Say�sal rakamlar aras�na, okunabilirli�i art�rma ama�l� geli�ig�zel alt�izgi ayrac� konulabilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i = 100000; //1_00_000;
            long l = 10000000000L; //10_000_000_000L;
            double d = 1000000.001D; //1_000_000.001D;
            Console.WriteLine ("Tamsay�: {0}\nUzunsay�: {1}\nDublesay�: {2}", i, l, d);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}