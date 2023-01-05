// tpc#25a.cs: Bir sembolik sabitli öniþlemci direktif tanýmýnýn kodlamada kullanýlmasý örneði.

#define PI
using System;
namespace ÖniþlemciDirektifleri {
    class SembolTanýmý {
        static void Main() {
            Console.Write ("Öniþlemci direktifleri, gerçek derleme öncesi, programdaki derlenecek seçimli kodlamalarý saptar.\nC# direktifleri: #define, #undef, #if, #else, #elif, #endif, #line, #error, #warning, #region, #endregion.\n#define, sembolik sabitler tanýmlar. Direktifler # ile baþlar, sonra boþluk ve sembol gelir, fakat sonlarýnda ; kullanýlmaz.\nTuþ..."); Console.ReadKey();

            #if (PI)
                Console.WriteLine ("\n\nPI sembolik öniþlemci sabiti tanýmlanmýþtýr.");
            #else
                Console.WriteLine ("\n\nPI öniþlemci direktifi tanýmlanmamýþtýr.");
            #endif

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}