// tpc#15a.cs: For döngüsüyle iþlenen tamsayý dizi örneði.

using System;
namespace Diziler {
    class ForDöngülüDizi {
        static void Main (string[] args) {
            Console.Write ("Dizi beyaný: 'veriTipi[] diziAdý'.\n\nÖrnek beyanlar:\ndouble[] bakiye;\ndouble[] bakiye = new double[10];\nbakiye[0] = 4500.50;\ndouble[] bakiye = {2340.0, 4523.69, 3421.0};\nint [] notlar = new int[5] {99, 98, 92, 97, 95};\nint [] notlar = new int[] {99, 98, 92, 97, 95}; int[] skor = notlar;==>Ayný belleði görürler\ndouble netMaaþ = bakiye[9];\nEnter..."); Console.ReadLine();

            int[] n = new int[10]; // n, 10 tamsayýlý bir dizidir
            int i,j;
            for (i = 0; i < 10; i++) {n [i] = i + 100;} // Ýlk deðer atama
            for (j = 0; j < 10; j++ ) {Console.WriteLine ("Eleman [{0}] = {1}", j, n [j]);} // Çýktý

            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}