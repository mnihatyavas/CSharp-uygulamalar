// jtpc#0301a.cs: If ile say�n�n tek/�ift tespiti �rne�i.

using System;
namespace Control�fadeleri {
    class If {
        static void Main () {
            Console.Write ("�e�itli if �art ifadeleri vard�r: if, if-else, i�ii�e if, if-else-if merdiveni.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            for (int i=0; i < 11; i++) {
                if (i % 2 == 0)  {Console.WriteLine ("{0} bir ��FT say�d�r", i); continue;}
                Console.WriteLine ("{0} bir TEK say�d�r", i);
            }

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}