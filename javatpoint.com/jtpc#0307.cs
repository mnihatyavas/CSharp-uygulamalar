// jtpc#0307.cs: continue ile d�ng�n�n ve i�i�e d�ng�n�n kalan�n� �artl� esge�me �rne�i.

using System;
namespace Control�fadeleri {
    class Continue {
        static void Main () {
            Console.Write ("Continue, �art� ger�ekle�ti�inde i�indeki (i�i�e) d�ng�n�n kalan ifadelerini esge�erek d�ng�ye devam eder.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=-1, j=-1;
            do {i++;
                if (i >= 3 && i <= 6) continue; // Sadece 3->5 aras�n� esge�er
                Console.WriteLine ("{0}.inci rasgele [0, 1000] say�: {1}", i, rasgele.Next (0, 1001));
            } while (i <= 10);

            Console.WriteLine(); i=-1;
            do {i++;
                do {j++;
                    if (i == 2 && j >= 2) continue;
                    else if (i == 3 && j >= 3) continue;
                    Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j));
                } while (j < 3);
                j=-1;
            } while (i < 3);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}