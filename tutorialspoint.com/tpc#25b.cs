// tpc#25b.cs: Þartlý öniþlemci direktif tanýmýnýn kodlamada kullanýlmasý örneði.

#define HTAYIK
#define VC_V10
using System;
namespace ÖniþlemciDirektifleri {
    class ÞartlýDirektif {
        static void Main() {
            Console.Write ("Þartlý direktifler için == (eþit), != (eþit deðil), && (ve), || (veya) karmaþýk þartlý #if-elif-else-endif direktifleri kullanýlmaktadýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            #if (HTAYIK && !VC_V10)
                Console.WriteLine ("Sadece HTAYIK/hata-ayýkla tanýmlýdýr.");
            #elif (!HTAYIK && VC_V10)
                Console.WriteLine ("Sadece VC_V10/görsel-c#10 tanýmlýdýr.");
            #elif (HTAYIK && VC_V10)
                Console.WriteLine ("Hem HTAYIK/hata-ayýkla ve hem de VC_V10/görsel-c#10 tanýmlýdýr.");
            #else
                Console.WriteLine ("Ne HTAYIK/hata-ayýkla veya ne de VC_V10/görsel-c#10 tanýmlýdýr.");
            #endif

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}