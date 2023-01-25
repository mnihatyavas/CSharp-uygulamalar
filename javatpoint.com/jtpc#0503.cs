// jtpc#0503.cs: Ýki boyutlu 3x3 ve 3x5 dizilerin beyan, ilkdeðerleme ve döküm örneði.

using System;
namespace Diziler {
    class ÇokboyutluDizi {
        static void Main() {
            Console.Write ("Çokboyutlu dizi tanýmýnda [] yerine [,], [,,], [,,,] vb kullanýlýr. Dökümde kolon verileri yanyana gelirken, satýrlarýn altalta getirilmesine dikkat edilmelidir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            // 3x3'lük 2 boyutlu dizi
            int[,] dizi1 = new int [3,3]; // Beyan
            dizi1 [0,1] = 10;// Ýlkdeðerleme
            dizi1 [1,2] = 20;
            dizi1 [2,0] = 30;
            Console.WriteLine ("2 boyutlu, 3x3'lük dizi dökümü:");
            for (int i=0; i <3; i++) {// Tarayarak döküm
                for (int j = 0; j < 3; j++) {Console.Write (dizi1 [i,j] + " ");} //Sütun verileri yanyana
                Console.WriteLine(); //Satýr verileri altalta
            }

            // 2 boyutlu, 3x5'li, aynýzamanlý beyan ve ilkdeðerlemeli dizi
            int[,] dizi2 = { {0, 1, 2, 3, 4}, {2, 3, 4, 5, 6}, {5, 6, 7, 8, 9} };
            Console.WriteLine ("\n2 boyutlu, 3x5'lik dizi dökümü:");
            for (int i=0; i <3; i++) {
                for (int j = 0; j < 5; j++) {Console.Write (dizi2 [i,j] + " ");} //Sütun verileri yanyana
                Console.WriteLine();
            }

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}