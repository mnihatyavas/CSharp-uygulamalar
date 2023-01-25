// jtpc#0504.cs: �ki boyutlu 2x4-6 ve 4x4-6-2-7'li �entikli dizilerin beyan, ilkde�erleme ve d�k�m �rne�i.

using System;
namespace Diziler {
    class �entikliDizi {
        static void Main() {
            Console.Write ("�entikli dizide, dizinin altdizileri olup altdizi boyutlar�, �okboyutlu dizi gibi ayn� de�il farkl� olabilmektedir. �lkde�erleme, beyan sonras� oldu�u gibi, beyanla birlikte de yap�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[][] dizi1 = new int[2][];
            dizi1 [0] = new int[] {11, 21, 56, 78};
            dizi1 [1] = new int[] {42, 61, 37, 41, 59, 63};
            Console.WriteLine ("Beyan ve ilkde�erleme AYRI, 2x4-6'l�k �entikli dizi");
            for (int i = 0; i < dizi1.Length; i++) {// dizi1.Length
                for (int j = 0; j < dizi1 [i].Length; j++) {// dizi1 [i].Length
                    Console.Write (dizi1 [i][j] + " ");
                }
                Console.WriteLine();
            }

            int[][] dizi2 = new int[4][] {new int[]{11, 21, 56, 78}, new int[]{2, 5, 6, 7, 98, 5}, new int[]{2, 5}, new int[]{12, 51, 21, 43, 0, -4, 2023} };
            Console.WriteLine ("\nBeyan ve ilkde�erleme AYNI, 2x4-6-2-7'lik �entikli dizi");
            for (int i = 0; i < dizi2.Length; i++) {// dizi2.Length
                for (int j = 0; j < dizi2 [i].Length; j++) {// dizi2 [i].Length
                    Console.Write (dizi2 [i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}