// tpc#15b.cs: ForEach döngüsüyle iþlenen tamsayý dizi örneði.

using System;
namespace Diziler {
    class ForEachDöngülüDizi {
        static void Main (string[] args) {
            int[] n = new int[10]; // n, 10 tamsayýlý bir dizidir
            for (int i = 0; i < 10; i++) {n [i] = i + 100;} // Ýlk deðer atama
            foreach (int j in n ) {int i = j - 100; Console.WriteLine ("Eleman [{0}] = {1}", i, j);} // Çýktý

            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}