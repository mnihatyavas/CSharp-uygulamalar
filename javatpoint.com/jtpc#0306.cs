// jtpc#0306.cs: break ile d�ng�y� ve i�i�e d�ng�y� �artl� erken k�rma �rne�i.

using System;
namespace Control�fadeleri {
    class Break {
        static void Main () {
            Console.Write ("Break, �art� ger�ekle�ti�inde i�indeki (i�i�e) d�ng�y� k�rarak, d�ng�den bir sonraki ifadeye atlar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            do {
                Console.WriteLine ("{0}.inci rasgele [0, 1000] say�: {1}", i++, rasgele.Next (0, 1001));
                if (i == 5) break;
            } while (i <= 10);

            Console.WriteLine(); i=0;
            do {
                do {
                    Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j++));
                    if (i == 2 && j == 2) break;
                    else if (i == 3 && j > 2) break;
                } while (j <= 3);
                j=0; ++i;
            } while (i <= 3);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}