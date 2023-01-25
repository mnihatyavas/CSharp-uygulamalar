// jtpc#0504.cs: Ýki boyutlu 2x4-6 ve 4x4-6-2-7'li çentikli dizilerin beyan, ilkdeðerleme ve döküm örneði.

using System;
namespace Diziler {
    class ÇentikliDizi {
        static void Main() {
            Console.Write ("Çentikli dizide, dizinin altdizileri olup altdizi boyutlarý, çokboyutlu dizi gibi ayný deðil farklý olabilmektedir. Ýlkdeðerleme, beyan sonrasý olduðu gibi, beyanla birlikte de yapýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[][] dizi1 = new int[2][];
            dizi1 [0] = new int[] {11, 21, 56, 78};
            dizi1 [1] = new int[] {42, 61, 37, 41, 59, 63};
            Console.WriteLine ("Beyan ve ilkdeðerleme AYRI, 2x4-6'lýk çentikli dizi");
            for (int i = 0; i < dizi1.Length; i++) {// dizi1.Length
                for (int j = 0; j < dizi1 [i].Length; j++) {// dizi1 [i].Length
                    Console.Write (dizi1 [i][j] + " ");
                }
                Console.WriteLine();
            }

            int[][] dizi2 = new int[4][] {new int[]{11, 21, 56, 78}, new int[]{2, 5, 6, 7, 98, 5}, new int[]{2, 5}, new int[]{12, 51, 21, 43, 0, -4, 2023} };
            Console.WriteLine ("\nBeyan ve ilkdeðerleme AYNI, 2x4-6-2-7'lik çentikli dizi");
            for (int i = 0; i < dizi2.Length; i++) {// dizi2.Length
                for (int j = 0; j < dizi2 [i].Length; j++) {// dizi2 [i].Length
                    Console.Write (dizi2 [i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}