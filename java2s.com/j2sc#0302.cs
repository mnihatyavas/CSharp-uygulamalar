// j2sc#0302.cs: Aritmetik, kýsakesek ve birartýr/birazalt iþlemleri örneði.

using System;
namespace Ýþlemciler {
    class AritmetikÝþlemci {
        static void Main() {
            Console.Write ("Aritmetik iþlemciler: toplama +, çýkarma veya eksileme -, çarpma *, bölme /, kalan %, birartýr ++, bireksilt --. Bölme / tamsayýya uygulanýrsa, küsürat kesilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int a,b,c,d,e,f;
            a = 1;
            b = a + 6;
            Console.WriteLine ("Atama, toplama, çýkarma, çarpma, bölme ve kalan:");
            Console.WriteLine ("Atama ve Toplama: a ({0}) ve b=a + 6: {1}", a, b);
            c = b - 3;
            Console.WriteLine ("Çýkarma: c=b - 3: {0}", c);
            d = c * 6;
            Console.WriteLine ("Çarpma: d=c * 6: {0}", d);
            e = d / 2;
            Console.WriteLine ("Bölme: e=d / 2: {0}", e);
            f = e % 5;
            Console.WriteLine ("Kalan: f=e % 5: {0}", f);

            Console.WriteLine ("\nKýsakesek artýr, azalt, çarp, böl ve kalan:");
            Console.WriteLine ("Bir artýr: a += 1: {0}", (a+=1));
            Console.WriteLine ("Ýki azalt: b -= 2: {0}", (b-=2));
            Console.WriteLine ("Üç katla: c *= 3: {0}", (c*=3));
            Console.WriteLine ("Yarýya böl: d /= 2: {0}", (d/=2));
            Console.WriteLine ("Yediliden kalan: e %= 7: {0}", (e%=7));

            Console.WriteLine ("\nBirartýr ve bireksilt:");
            Console.WriteLine ("Önekli birartýr: ++a = {0}: {1}", (++a), a);
            Console.WriteLine ("Sonekli birartýr: b++ = {0}: {1}", (b++), b);
            Console.WriteLine ("Önekli birazalt: --c = {0}: {1}", (--c), c);
            Console.WriteLine ("Sonekli birazalt: d-- = {0}: {1}", (d--), d);

            Console.WriteLine ("\nAyný f ({0}) deðiþkenle 5 farklý kýsakesek iþlemi:", f);
            Console.WriteLine ("15 artýr: f += 15: {0}", (f+=15));
            Console.WriteLine ("3 azalt: f -= 3: {0}", (f-=3));
            Console.WriteLine ("2 katla: f *= 2: {0}", (f*=2));
            Console.WriteLine ("4 böl: f /= 4: {0}", (f/=4));
            Console.WriteLine ("5 kalan: f %= 5: {0}", (f%=5));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}