// jtpc#0306.cs: break ile döngüyü ve içiçe döngüyü þartlý erken kýrma örneði.

using System;
namespace ControlÝfadeleri {
    class Break {
        static void Main () {
            Console.Write ("Break, þartý gerçekleþtiðinde içindeki (içiçe) döngüyü kýrarak, döngüden bir sonraki ifadeye atlar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            do {
                Console.WriteLine ("{0}.inci rasgele [0, 1000] sayý: {1}", i++, rasgele.Next (0, 1001));
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

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}