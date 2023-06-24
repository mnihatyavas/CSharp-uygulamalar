// j2sc#0304.cs: % kalan'la bölünemeyen son artýðýn bulunmasý örneði.

using System;
namespace Ýþlemciler {
    class KalanÝþlemci {
        static void Main() {
            Console.Write ("Tamsayý bölüm kalanlarý atýlýr. x%y kalan iþlemi x kapsamýndaki tekrarlý y'lerden sonraki artýðý bulur.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10/3, ts2=10%3, i; 
            double ds1=10.0/3.0, ds2=10.0%3.0;
            Console.WriteLine ("Tamsayý ve dublesayý bölüm ve kalan kýyasý:"); 
            Console.WriteLine ("Tamsayý (10/3={0}) ve (10%3={1})", ts1, ts2);
            Console.WriteLine ("Dublesayý (10.0/3.0={0}) ve (10.0%3.0={1})", ds1, ds2);

            Console.WriteLine ("\n[2, 20] sayýlarýn enküçük bölenleri:");
            for (i = 2; i <= 20; i++) {
                if ((i % 2) == 0) Console.WriteLine (i + "'nin enküçük böleni: 2'dir.");
                else if ((i % 3) == 0) Console.WriteLine (i + "'nin enküçük böleni: 3'dir.");
                else if ((i % 5) == 0) Console.WriteLine (i + "'nin enküçük böleni: 5'dir.");
                else if ((i % 7) == 0) Console.WriteLine (i + "'nin enküçük böleni: 7'dir.");
                else Console.WriteLine (i + " sayýsý (2, 3, 5, 7)'ye bölünmez.");
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}