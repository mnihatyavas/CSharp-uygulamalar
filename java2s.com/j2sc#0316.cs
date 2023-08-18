// j2sc#0316.cs: Arþiv yada özel tanýmlý tipin byte ebatý sizeof örneði.
// unsafe kodlamalar: ">>csc /unsafe örnek.cs" seçenekli derlenir. Kodlamada ya metod satýrýnda, yada metod içi özel blok'ta "unsafe" beyaný gerekir.

using System;
namespace Ýþlemciler {
    struct Yapý {
        public short s;
        public int i;
        public long l;
    }
    class Sýnýf {private int no; public string ad;}
    class sizeof_Ýþlemci {
        static unsafe void Main() {
            Console.Write ("sizeof(tip) iþlemcisi arþiv yada özel tipin byte ebatýný verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("sizeof iþlemcili tip ebatlarý:");
            Console.WriteLine ("(bool, short, char, int, long, float, double, decimal) ebatlarý = ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}) BYTE", sizeof (bool), sizeof (short), sizeof (char), sizeof (int), sizeof (long), sizeof (float), sizeof (double), sizeof (decimal));
            Console.WriteLine ("sizeof (Yapý) = {0} BYTE", sizeof (Yapý));
            //Console.WriteLine ("sizeof (Sýnýf) = {0} BYTE", sizeof (Sýnýf));//sizeof(class) hata...

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}