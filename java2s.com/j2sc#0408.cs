// j2sc#0408.cs: Þartlý continue ile döngü kalanýnýn esgeçilmesi örneði.

using System;
namespace Ýfadeler {
    class Continue {
        static void Main() {
            Console.Write ("Döngü içi continue, döngüdeki kalan ifadelerin atlanarak birsonraki taramaya geçer.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("1000'lik for döngüde rasgele atlamalý toplam:");
            var r=new Random(); int j=r.Next (1, 100), i, k=0;
            for(i = 1; i <= 1000; i++) {  
                if ((i%j) != 0)  continue;
                Console.Write (i + " ");
                k +=i;
            } Console.WriteLine ("\nArdýþýk 1000 sayýnýn {0}'þer atlamalý toplamý = {1}", j, k);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}