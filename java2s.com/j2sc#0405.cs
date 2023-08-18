// j2sc#0405.cs: While(þart){ifade-ler} döngü örneði.

using System;
namespace Ýfadeler {
    class While {
        static void Main() {
            Console.Write ("While(þart){ifade-ler} ile þart true/doðru kaldýðý sürece döngü tekrarlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("While döngüsünün ardýþýk [0, 100] sayýlarýný yansýtmasý:");
            int i = 0, j;
            while (i <= 100) Console.Write ("{0} ", i++);

            Console.WriteLine ("\n\nWhile döngüsünün rasgele int hane sayýsýný tespiti:");
            var r=new Random(); i=0; int ts1=r.Next (0, int.MaxValue);
            Console.WriteLine ("Rasgele int sayý = " + ts1); 
            while (ts1 >= 1) {i++; ts1 /=10;};
            Console.WriteLine ("Hane adedi = " + i);

            long ls1; ts1=r.Next (0, 63);
            Console.WriteLine ("\n2^[0-->{0}] sayýsýnýn içiçe for-while döngüsüyle listelenmesi:", ts1); 
            for (i=0; i <= ts1; i++) {
                ls1 = 1;
                j = i;
                while (j-- > 0) ls1 *=2;
                Console.WriteLine ("2 ** " + i + " = " + ls1);
            }

            long ls2, ls3; i=r.Next (0, 92);
            Console.WriteLine ("\n[1, 1, 2, 3, 5,..-->{0} adet] fiboneki sayýlarýnýn while döngüsüyle dökümü:", (i+1)); 
            ls1=ls2=1;
            Console.Write (ls2 + " ");
            while (i-- >= 1) {
                Console.Write (ls2 + " ");
                ls3 = ls2 + ls1;
                ls1 = ls2;
                ls2 = ls3;
            }

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    } 
}