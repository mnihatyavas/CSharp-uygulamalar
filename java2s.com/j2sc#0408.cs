// j2sc#0408.cs: �artl� continue ile d�ng� kalan�n�n esge�ilmesi �rne�i.

using System;
namespace �fadeler {
    class Continue {
        static void Main() {
            Console.Write ("D�ng� i�i continue, d�ng�deki kalan ifadelerin atlanarak birsonraki taramaya ge�er.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("1000'lik for d�ng�de rasgele atlamal� toplam:");
            var r=new Random(); int j=r.Next (1, 100), i, k=0;
            for(i = 1; i <= 1000; i++) {  
                if ((i%j) != 0)  continue;
                Console.Write (i + " ");
                k +=i;
            } Console.WriteLine ("\nArd���k 1000 say�n�n {0}'�er atlamal� toplam� = {1}", j, k);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}