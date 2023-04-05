// j2sc#0108.cs: De�i�ken tan�m�, ilk ve dinamik de�er atama �rne�i.

using System;
namespace DilTemelleri {
    class De�i�kenTan�m� {
        static void Main() {
            Console.Write ("De�i�ken, 'tip de�Ad' tan�ml�, de�er atanan bellek konumunun ad�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int x;
            int y;
            x = 100;
            Console.WriteLine ("int x = " + x);
            y = x / 2;
            Console.WriteLine ("int y = x / 2 = " + y);

            double a = 12.3, b = 123.4, c = Math.PI, d = Math.E; 
            double hipoten�s = Math.Sqrt ((a * a) + (b * b));
            double �evre = 2 * c * d;
            double alan = c * (d * d);
            Console.WriteLine ("\nKom�u kenar� {0}, kar�� kenar� {1} olan dik��genin hipoten�s� {2:#.#####} birimdir.", b, a, hipoten�s);
            Console.WriteLine ("Yar��ap� {0:#.###} olan dairenin �evresi {1:#.###} birim ve alan� {2:#.###} birim-karedir.", d, �evre, alan);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}