// j2sc#0305.cs: K�sakesek birart�r++/azalt--, +=, -=, *=, /=, %=, <<=, >>=, &=, |=, ^= �rne�i.

using System;
namespace ��lemciler {
    class K�sakesek��lemci {
        static bool Metod1() {Console.Write ("Metod1: False "); return false;}
        static bool Metod2() {Console.Write ("Metod2: True "); return true;}
        static void Main() {
            Console.Write ("K�sakesekler: birart�r/azalt, aritmetik +-*/%, mant�ksal &|^, bitsel <<>> i�lemlerdir. K�sadevre AND=&& ilki false ise veya OR=|| ilki true ise ikinciye bakmaz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int x=5, y=1;
            Console.WriteLine ("K�sakesek birart�r, bireksilt i�lemcileri:");
            Console.WriteLine ("x({0})++: {1}, ++x: {2}, x--: {3}, --x: {4}", x, (x++), (++x), (x--), (--x));

            Console.WriteLine ("\nK�sakesek aritmetik +-*/% i�lemcileri:");
            Console.WriteLine ("y({0})+=10: {1}, y-=2: {2}, y*=2: {3}, y/=3: {4}, y%=4: {5}", y, (y+=10), (y-=2), (y*=2), (y/=3), (y%=4));

            Console.WriteLine ("\nK�sakesek mant�ksal &|^ i�lemcileri:");
            Console.WriteLine ("x({0})&=y({1}): {2}, x|=y: {3}, x^=y: {4}", x, y, (x&=y), (x|=y), (x^=y));

            Console.WriteLine ("\nK�sakesek bitsel <<>> i�lemcileri:");
            x=5; Console.WriteLine ("x({0})<<=y({1}): {2}, x>>=y: {3}", x, y, (x<<=y), (x>>=y));

            Console.WriteLine ("\nK�sakesek ve k�sadevre AND, OR:");
            Console.WriteLine ("==>K�sakesek AND: Metod1() & Metod2() = {0}", (Metod1() & Metod2()));
            Console.WriteLine ("==>K�sadevre AND: Metod1() && Metod2() = {0}", (Metod1() && Metod2()));
            Console.WriteLine ("==>K�sakesek OR: Metod1() | Metod2() = {0}", (Metod1() | Metod2()));
            Console.WriteLine ("==>K�sadevre OR: Metod2() || Metod1() = {0}", (Metod2() || Metod1()));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}