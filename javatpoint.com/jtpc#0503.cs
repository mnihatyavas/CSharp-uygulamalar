// jtpc#0503.cs: �ki boyutlu 3x3 ve 3x5 dizilerin beyan, ilkde�erleme ve d�k�m �rne�i.

using System;
namespace Diziler {
    class �okboyutluDizi {
        static void Main() {
            Console.Write ("�okboyutlu dizi tan�m�nda [] yerine [,], [,,], [,,,] vb kullan�l�r. D�k�mde kolon verileri yanyana gelirken, sat�rlar�n altalta getirilmesine dikkat edilmelidir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            // 3x3'l�k 2 boyutlu dizi
            int[,] dizi1 = new int [3,3]; // Beyan
            dizi1 [0,1] = 10;// �lkde�erleme
            dizi1 [1,2] = 20;
            dizi1 [2,0] = 30;
            Console.WriteLine ("2 boyutlu, 3x3'l�k dizi d�k�m�:");
            for (int i=0; i <3; i++) {// Tarayarak d�k�m
                for (int j = 0; j < 3; j++) {Console.Write (dizi1 [i,j] + " ");} //S�tun verileri yanyana
                Console.WriteLine(); //Sat�r verileri altalta
            }

            // 2 boyutlu, 3x5'li, ayn�zamanl� beyan ve ilkde�erlemeli dizi
            int[,] dizi2 = { {0, 1, 2, 3, 4}, {2, 3, 4, 5, 6}, {5, 6, 7, 8, 9} };
            Console.WriteLine ("\n2 boyutlu, 3x5'lik dizi d�k�m�:");
            for (int i=0; i <3; i++) {
                for (int j = 0; j < 5; j++) {Console.Write (dizi2 [i,j] + " ");} //S�tun verileri yanyana
                Console.WriteLine();
            }

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}