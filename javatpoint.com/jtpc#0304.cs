// jtpc#0304.cs: while d�ng�s�yle 11 tekrar, i�i�e while'la 3*4=12 tekrar ve sonsuz while(true)'yla 11 tekrar �rne�i.

using System;
namespace Control�fadeleri {
    class While {
        static void Main () {
            Console.Write ("E�er sabit kereli d�ng� de�ilse for yerine while veya do-while tercih edilir. ��i�e while d�ng� tekrar� = i�Kere * d��Kere olacakt�r. while(true) sonsuz d�ng�d�r; CTRL-C yada ektsra i� kontrolla k�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            while (i <= 10) {Console.WriteLine ("{0}.inci rasgele [0, 10] say�: {1}", i++, rasgele.Next (0, 11));}

            Console.WriteLine(); i=0;
            while (i < 3) {
                while (j < 4) {Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j++));}
                j=0; ++i;
            }

            Console.WriteLine(); i=0;
            while (true) {Console.WriteLine ("{0}.inci sonsuz d�ng�", i); if (i++ == 11) break;}

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}