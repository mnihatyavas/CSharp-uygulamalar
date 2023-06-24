// j2sc#0302.cs: Aritmetik, k�sakesek ve birart�r/birazalt i�lemleri �rne�i.

using System;
namespace ��lemciler {
    class Aritmetik��lemci {
        static void Main() {
            Console.Write ("Aritmetik i�lemciler: toplama +, ��karma veya eksileme -, �arpma *, b�lme /, kalan %, birart�r ++, bireksilt --. B�lme / tamsay�ya uygulan�rsa, k�s�rat kesilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int a,b,c,d,e,f;
            a = 1;
            b = a + 6;
            Console.WriteLine ("Atama, toplama, ��karma, �arpma, b�lme ve kalan:");
            Console.WriteLine ("Atama ve Toplama: a ({0}) ve b=a + 6: {1}", a, b);
            c = b - 3;
            Console.WriteLine ("��karma: c=b - 3: {0}", c);
            d = c * 6;
            Console.WriteLine ("�arpma: d=c * 6: {0}", d);
            e = d / 2;
            Console.WriteLine ("B�lme: e=d / 2: {0}", e);
            f = e % 5;
            Console.WriteLine ("Kalan: f=e % 5: {0}", f);

            Console.WriteLine ("\nK�sakesek art�r, azalt, �arp, b�l ve kalan:");
            Console.WriteLine ("Bir art�r: a += 1: {0}", (a+=1));
            Console.WriteLine ("�ki azalt: b -= 2: {0}", (b-=2));
            Console.WriteLine ("�� katla: c *= 3: {0}", (c*=3));
            Console.WriteLine ("Yar�ya b�l: d /= 2: {0}", (d/=2));
            Console.WriteLine ("Yediliden kalan: e %= 7: {0}", (e%=7));

            Console.WriteLine ("\nBirart�r ve bireksilt:");
            Console.WriteLine ("�nekli birart�r: ++a = {0}: {1}", (++a), a);
            Console.WriteLine ("Sonekli birart�r: b++ = {0}: {1}", (b++), b);
            Console.WriteLine ("�nekli birazalt: --c = {0}: {1}", (--c), c);
            Console.WriteLine ("Sonekli birazalt: d-- = {0}: {1}", (d--), d);

            Console.WriteLine ("\nAyn� f ({0}) de�i�kenle 5 farkl� k�sakesek i�lemi:", f);
            Console.WriteLine ("15 art�r: f += 15: {0}", (f+=15));
            Console.WriteLine ("3 azalt: f -= 3: {0}", (f-=3));
            Console.WriteLine ("2 katla: f *= 2: {0}", (f*=2));
            Console.WriteLine ("4 b�l: f /= 4: {0}", (f/=4));
            Console.WriteLine ("5 kalan: f %= 5: {0}", (f%=5));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}