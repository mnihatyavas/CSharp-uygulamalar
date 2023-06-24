// j2sc#0213.cs: Kýsa/short tamsayý, kutulama/kutusuzlama örneði.

using System;
namespace VeriTipleri {
    class Short {
        static void Main() {
            Console.Write ("Kýsa/short tamsayý [-32768, 32767] kapsamlý olup; Int16, yani bellekte 2 byte yer kaplar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            short k1 = 2023;
            Console.WriteLine ("short k1 = {0}\nTipi: {1}\nEnküçük ve enbüyük deðeri: [{2}, {3}]", k1, k1.GetType(), short.MinValue, short.MaxValue);

            object ns1 = k1;
            Console.WriteLine ("\nKýsa'yý kutulayan nesne ve tipi: {0}, {1}", ns1, ns1.GetType().ToString());
            short k2 = (short) ns1;
            Console.WriteLine ("Kutulayan nesneden tekrar kýsa'ya kutusuzlanan: short k2 = {0}", k2, k2.GetType());
            object ns2 = ns1.ToString();
            Console.WriteLine ("Kutulu nesneden baþka nesneye dizge kopya: object ns2 = {0}, {1}", ns2, ns2.GetType());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}