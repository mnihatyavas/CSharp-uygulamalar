// tpc#25b.cs: �artl� �ni�lemci direktif tan�m�n�n kodlamada kullan�lmas� �rne�i.

#define HTAYIK
#define VC_V10
using System;
namespace �ni�lemciDirektifleri {
    class �artl�Direktif {
        static void Main() {
            Console.Write ("�artl� direktifler i�in == (e�it), != (e�it de�il), && (ve), || (veya) karma��k �artl� #if-elif-else-endif direktifleri kullan�lmaktad�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            #if (HTAYIK && !VC_V10)
                Console.WriteLine ("Sadece HTAYIK/hata-ay�kla tan�ml�d�r.");
            #elif (!HTAYIK && VC_V10)
                Console.WriteLine ("Sadece VC_V10/g�rsel-c#10 tan�ml�d�r.");
            #elif (HTAYIK && VC_V10)
                Console.WriteLine ("Hem HTAYIK/hata-ay�kla ve hem de VC_V10/g�rsel-c#10 tan�ml�d�r.");
            #else
                Console.WriteLine ("Ne HTAYIK/hata-ay�kla veya ne de VC_V10/g�rsel-c#10 tan�ml�d�r.");
            #endif

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}