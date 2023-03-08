// jtpc#2306e.cs: Sayýsal rakamlar arasýndaki altçizgi ayracý örneði.

using System;
namespace YeniÖzellikler {
    class RakamAyracý {
        static void Main() {
            Console.Write ("Sayýsal rakamlar arasýna, okunabilirliði artýrma amaçlý geliþigüzel altçizgi ayracý konulabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i = 100000; //1_00_000;
            long l = 10000000000L; //10_000_000_000L;
            double d = 1000000.001D; //1_000_000.001D;
            Console.WriteLine ("Tamsayý: {0}\nUzunsayý: {1}\nDublesayý: {2}", i, l, d);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}