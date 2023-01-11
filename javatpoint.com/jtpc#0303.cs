// jtpc#0303.cs: for döngüsüyle 11 tekrar, içiçe for'la 3*4=12 tekrar ve sonsuz for(;;)'la 11 tekrar örneði.

using System;
namespace ControlÝfadeleri {
    class For {
        static void Main () {
            Console.Write ("Eðer sabit kereli döngüyse while veya do-while yerine for tercih edilir. Ýçiçe for döngü tekrarý = içKere * dýþKere olacaktýr. for(;;) sonsuz döngüdür; CTRL-C yada ektsra iç kontrolla kýrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random rasgele = new Random();
            for (int i=0; i < 11; i++) {Console.WriteLine ("Rasgele [0, 10] sayý: {0}", rasgele.Next (0, 11));}

            Console.WriteLine();
            for (int i=0; i < 3; i++) {
                for (int j=0; j < 4; j++) {Console.WriteLine ("i * j = {0} * {1} = {2}", i, j, i*j);}
            }

            Console.WriteLine(); int k=0;
            for (;;) {Console.WriteLine ("{0}.inci sonsuz döngü", k); if (++k == 11) break;}

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}