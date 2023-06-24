// j2sc#0305.cs: Kýsakesek birartýr++/azalt--, +=, -=, *=, /=, %=, <<=, >>=, &=, |=, ^= örneði.

using System;
namespace Ýþlemciler {
    class KýsakesekÝþlemci {
        static bool Metod1() {Console.Write ("Metod1: False "); return false;}
        static bool Metod2() {Console.Write ("Metod2: True "); return true;}
        static void Main() {
            Console.Write ("Kýsakesekler: birartýr/azalt, aritmetik +-*/%, mantýksal &|^, bitsel <<>> iþlemlerdir. Kýsadevre AND=&& ilki false ise veya OR=|| ilki true ise ikinciye bakmaz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int x=5, y=1;
            Console.WriteLine ("Kýsakesek birartýr, bireksilt iþlemcileri:");
            Console.WriteLine ("x({0})++: {1}, ++x: {2}, x--: {3}, --x: {4}", x, (x++), (++x), (x--), (--x));

            Console.WriteLine ("\nKýsakesek aritmetik +-*/% iþlemcileri:");
            Console.WriteLine ("y({0})+=10: {1}, y-=2: {2}, y*=2: {3}, y/=3: {4}, y%=4: {5}", y, (y+=10), (y-=2), (y*=2), (y/=3), (y%=4));

            Console.WriteLine ("\nKýsakesek mantýksal &|^ iþlemcileri:");
            Console.WriteLine ("x({0})&=y({1}): {2}, x|=y: {3}, x^=y: {4}", x, y, (x&=y), (x|=y), (x^=y));

            Console.WriteLine ("\nKýsakesek bitsel <<>> iþlemcileri:");
            x=5; Console.WriteLine ("x({0})<<=y({1}): {2}, x>>=y: {3}", x, y, (x<<=y), (x>>=y));

            Console.WriteLine ("\nKýsakesek ve kýsadevre AND, OR:");
            Console.WriteLine ("==>Kýsakesek AND: Metod1() & Metod2() = {0}", (Metod1() & Metod2()));
            Console.WriteLine ("==>Kýsadevre AND: Metod1() && Metod2() = {0}", (Metod1() && Metod2()));
            Console.WriteLine ("==>Kýsakesek OR: Metod1() | Metod2() = {0}", (Metod1() | Metod2()));
            Console.WriteLine ("==>Kýsadevre OR: Metod2() || Metod1() = {0}", (Metod2() || Metod1()));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}