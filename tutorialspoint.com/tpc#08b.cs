// tpc#08b.cs: Sabit tan�ml� pi ile dairenin alan� �rne�i.

using System;
namespace SabilerDura�anlar {
    class DaireninAlan� {
        static void Main (string[] args) {
            const double pi = 3.14159; // Sabit pi tan�m�
            Console.Write ("Dairenin yar��ap�n� girin [12,34] Ent: "); double y�ap = Convert.ToDouble (Console.ReadLine());
            double alan = pi * y�ap * y�ap;
            Console.Write ("Yar��ap� {0} birim olan dairenin alan� {1} birim kare'dir.\nTu�...", y�ap, alan);
            Console.ReadKey();
        }
    }
}