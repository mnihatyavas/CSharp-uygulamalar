// jtpc#0304.cs: while döngüsüyle 11 tekrar, içiçe while'la 3*4=12 tekrar ve sonsuz while(true)'yla 11 tekrar örneði.

using System;
namespace ControlÝfadeleri {
    class While {
        static void Main () {
            Console.Write ("Eðer sabit kereli döngü deðilse for yerine while veya do-while tercih edilir. Ýçiçe while döngü tekrarý = içKere * dýþKere olacaktýr. while(true) sonsuz döngüdür; CTRL-C yada ektsra iç kontrolla kýrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            int i=0, j=0;
            while (i <= 10) {Console.WriteLine ("{0}.inci rasgele [0, 10] sayý: {1}", i++, rasgele.Next (0, 11));}

            Console.WriteLine(); i=0;
            while (i < 3) {
                while (j < 4) {Console.WriteLine ("i + j = {0} + {1} = {2}", i, j, (i + j++));}
                j=0; ++i;
            }

            Console.WriteLine(); i=0;
            while (true) {Console.WriteLine ("{0}.inci sonsuz döngü", i); if (i++ == 11) break;}

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}