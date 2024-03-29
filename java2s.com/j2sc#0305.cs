// j2sc#0305.cs: Kısakesek birartır++/azalt--, +=, -=, *=, /=, %=, <<=, >>=, &=, |=, ^= örneği.

using System;
namespace İşlemciler {
    class Kısakesekİşlemci {
        static bool Metod1() {Console.Write ("Metod1: False "); return false;}
        static bool Metod2() {Console.Write ("Metod2: True "); return true;}
        static void Main() {
            Console.Write ("Kısakesekler: birartır/azalt, aritmetik +-*/%, mantıksal &|^, bitsel <<>> işlemlerdir. Kısadevre AND=&& ilki false ise veya OR=|| ilki true ise ikinciye bakmaz.\nTuş...");Console.ReadKey();Console.WriteLine ("\n");

            int x=5, y=1;
            Console.WriteLine ("Kısakesek birartır, bireksilt işlemcileri:");
            Console.WriteLine ("x({0})++: {1}, ++x: {2}, x--: {3}, --x: {4}", x, (x++), (++x), (x--), (--x));

            Console.WriteLine ("\nKısakesek aritmetik +-*/% işlemcileri:");
            Console.WriteLine ("y({0})+=10: {1}, y-=2: {2}, y*=2: {3}, y/=3: {4}, y%=4: {5}", y, (y+=10), (y-=2), (y*=2), (y/=3), (y%=4));

            Console.WriteLine ("\nKısakesek mantıksal &|^ işlemcileri:");
            Console.WriteLine ("x({0})&=y({1}): {2}, x|=y: {3}, x^=y: {4}", x, y, (x&=y), (x|=y), (x^=y));

            Console.WriteLine ("\nKısakesek bitsel <<>> işlemcileri:");
            x=5; Console.WriteLine ("x({0})<<=y({1}): {2}, x>>=y: {3}", x, y, (x<<=y), (x>>=y));

            Console.WriteLine ("\nKısakesek ve kısadevre AND, OR:");
            Console.WriteLine ("==>Kısakesek AND: Metod1() & Metod2() = {0}", (Metod1() & Metod2()));
            Console.WriteLine ("==>Kısadevre AND: Metod1() && Metod2() = {0}", (Metod1() && Metod2()));
            Console.WriteLine ("==>Kısakesek OR: Metod1() | Metod2() = {0}", (Metod1() | Metod2()));
            Console.WriteLine ("==>Kısadevre OR: Metod2() || Metod1() = {0}", (Metod2() || Metod1()));

            Console.Write ("\nTuş..."); Console.ReadKey();
        }
    } 
}