// jtpc#0301a.cs: If ile sayýnýn tek/çift tespiti örneði.

using System;
namespace ControlÝfadeleri {
    class If {
        static void Main () {
            Console.Write ("Çeþitli if þart ifadeleri vardýr: if, if-else, içiiçe if, if-else-if merdiveni.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            for (int i=0; i < 11; i++) {
                if (i % 2 == 0)  {Console.WriteLine ("{0} bir ÇÝFT sayýdýr", i); continue;}
                Console.WriteLine ("{0} bir TEK sayýdýr", i);
            }

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}