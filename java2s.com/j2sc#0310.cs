// j2sc#0310.cs: Bitsel sola (a<<=b) ve saða (a>>=b) kaydýrma örneði.

using System;
namespace Ýþlemciler {
    class KaydýranÝþlemci {
        static void Main() {
            Console.Write ("Sola herbir kaydýrma:<< sayýyý 2'yle çarpar, saðaysa:>> 2'ye böler (solu iþaretsizde 0'la, iþaretlide iþaret-bit'le doldurur).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            int a=r.Next(1, 1000), b=r.Next(1, 5), i;
            Console.WriteLine ("Sola kaydýrma: {0}:{0:X} << {1} <= {2:#,###}", a, b, int.MaxValue);
            for (i=0;;i++) {if ((a<<=b) < 0) break; Console.WriteLine ("{0}) {1}:{1:X}", i, a);}

            a=r.Next(10000, int.MaxValue); b=r.Next(1, 5);
            Console.WriteLine ("\nSaða kaydýrma: {0}:{0:X} >> {1} > 0", a, b);
            for (i=0;;i++) {if ((a>>=b) <= 0) break; Console.WriteLine ("{0}) {1}:{1:X}", i, a);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}