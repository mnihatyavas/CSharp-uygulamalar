// jtpc#0303.cs: for d�ng�s�yle 11 tekrar, i�i�e for'la 3*4=12 tekrar ve sonsuz for(;;)'la 11 tekrar �rne�i.

using System;
namespace Control�fadeleri {
    class For {
        static void Main () {
            Console.Write ("E�er sabit kereli d�ng�yse while veya do-while yerine for tercih edilir. ��i�e for d�ng� tekrar� = i�Kere * d��Kere olacakt�r. for(;;) sonsuz d�ng�d�r; CTRL-C yada ektsra i� kontrolla k�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            for (int i=0; i < 11; i++) {Console.WriteLine ("Rasgele [0, 10] say�: {0}", rasgele.Next (0, 11));}

            Console.WriteLine();
            for (int i=0; i < 3; i++) {
                for (int j=0; j < 4; j++) {Console.WriteLine ("i * j = {0} * {1} = {2}", i, j, i*j);}
            }

            Console.WriteLine(); int k=0;
            for (;;) {Console.WriteLine ("{0}.inci sonsuz d�ng�", k); if (++k == 11) break;}

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}