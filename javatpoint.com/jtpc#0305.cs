// jtpc#0305.cs: do-while d�ng�s�yle 11 tekrar, i�i�e do-while'la 3*4=12 tekrar ve sonsuz do-while(true)'yla 11 tekrar �rne�i.

using System;
namespace Control�fadeleri {
    class DoWhile {
        static void Main () {
            Console.Write ("E�er sabit kereli d�ng� de�ilse ve enaz bir tekrar gerekiyorsa for yerine do-while tercih edilir. ��i�e d0-while d�ng� tekrar� = i�Kere * d��Kere olacakt�r. do-while(true) sonsuz d�ng�d�r; CTRL-C yada ektsra i� kontrolla k�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            do {Console.WriteLine ("{0}.inci rasgele [0, 10] say�: {1}", i++, rasgele.Next (0, 11));} while (i <= 10);

            Console.WriteLine(); i=0;
            do {
                do {Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j++));} while (j < 4);
                j=0; ++i;
            } while (i < 3);

            Console.WriteLine(); i=0;
            do {Console.WriteLine ("{0}.inci sonsuz d�ng�", i); if (i++ == 11) break;} while (true);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}