// jtpc#0305.cs: do-while döngüsüyle 11 tekrar, içiçe do-while'la 3*4=12 tekrar ve sonsuz do-while(true)'yla 11 tekrar örneði.

using System;
namespace ControlÝfadeleri {
    class DoWhile {
        static void Main () {
            Console.Write ("Eðer sabit kereli döngü deðilse ve enaz bir tekrar gerekiyorsa for yerine do-while tercih edilir. Ýçiçe d0-while döngü tekrarý = içKere * dýþKere olacaktýr. do-while(true) sonsuz döngüdür; CTRL-C yada ektsra iç kontrolla kýrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            do {Console.WriteLine ("{0}.inci rasgele [0, 10] sayý: {1}", i++, rasgele.Next (0, 11));} while (i <= 10);

            Console.WriteLine(); i=0;
            do {
                do {Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j++));} while (j < 4);
                j=0; ++i;
            } while (i < 3);

            Console.WriteLine(); i=0;
            do {Console.WriteLine ("{0}.inci sonsuz döngü", i); if (i++ == 11) break;} while (true);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}