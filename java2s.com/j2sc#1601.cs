// j2sc#1601.cs: Öniþlem direktifleri (#define/undef/if/line/region/warning) örneði.

#define HATAAYIKLA //Ýfade sonunda ; kullanýlmaz
#define Ver_A
#define Ver_B
#define Ver_C
//#define Ver_X
#define RELEASE
//#define METOT1
#define win98
#define win2000
#define release
#define winNT
#undef win98
#undef win2000
#undef release
#warning ikaz_mesajý

using System;
using System.Diagnostics; //[Conditional...] için
namespace Öniþlemler {
    class Direktif {
        [Conditional ("METOT1")]
        public static void Metot1() {Console.WriteLine ("Metot1 içindeyim...");}
        public static void Metot2() {Console.WriteLine ("Metot2 içindeyim...");}
        [Conditional ("win2000")]
        public static void Dökümle() {Console.WriteLine ("Tanýmlýysa win2000'i dökümle...");}
        static void Main() {
            Console.Write ("Öniþlem direktifleri: #define-#undef, #if-#else-#elif-#endif, #line, #error, #warning, #region, #pragma.#define sembolü #if-#elif'le irdelenip kod akýþý yönetilebilir. #define sonuna ; konulmamalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'#define TANIM'a baðlý #if-#endif þartlý program akýþlarý:");
            #if HATAAYIKLA //;'lü ifade bulunmamalý, alt satýra konulmalýdýr
                Console.WriteLine ("Program hatalarýndan arýndýrma mümkün kýlýnmýþtýr");
            #else
                Console.WriteLine ("Program hatalarýndan arýndýrma mümkün kýlýnmamýþtýr");
            #endif

            #if Ver_A && Ver_B && Ver_C
                Console.WriteLine ("Tüm sürümler test ediliyor.");
            #elif Ver_A 
                Console.WriteLine ("Sürüm Ver_A test ediliyor.");
            #elif Ver_B
                Console.WriteLine ("Sürüm Ver_B test ediliyor.");
            #elif Ver_C
                Console.WriteLine ("Sürüm Ver_C test ediliyor.");
            #else
                Console.WriteLine ("Tes edilen sürüm yok.");
            #endif

            Console.WriteLine ("Main metot içindeyim...");
            #if METOT1
                Metot1();
            #else
                Metot2();
            #endif

            Console.WriteLine ("\n#if-#elif-#else-#endif direktifleri þartlý derleme gerçekleþtirir:");
            #if Ver_X
                Console.WriteLine ("Sürüm Ver_X için derleniyor.");
            #else
                Console.WriteLine ("Sürüm Ver_X için derlenmiyor.");
            #endif

            #if !Ver_A
                Console.WriteLine ("Sürüm Ver_A için derlemeye dahil."); 
            #elif RELEASE
                Console.WriteLine ("RELEASE yayýmý için derlemeye dahil."); 
            #else
                Console.WriteLine ("Dahili test için derlemeye dahil."); 
            #endif

            Console.WriteLine ("\n#undef, önceki #define sembol tanýmýný geçersiz kýlar:");
            string platformAdý;
            #if winXP
                platformAdý = "Microsoft Windows XP";
            #elif win2000
                platformAdý = "Microsoft Windows 2000";
            #elif winNT
                platformAdý = "Microsoft Windows 2007-NT";
            #elif win98
                platformAdý = "Microsoft Windows 98";
            #else           // Unknown platform specified
                platformAdý = "Bilinmeyen platform";
            #endif
            Console.WriteLine (platformAdý);
            Dökümle(); //"#undef win200" olduðundan çaðrýlmaz

            Console.WriteLine ("\n'#line xx' sadece programcýya satýr_no bilgisini hatýrlatýr:");
            #line default
            #line 90
            #line 91 "C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1601.cs"
            #line 92 "nihat.txt"

            Console.WriteLine ("\n'#region-#endregion' VS editöründe açýlan/kapanan kod satýrlarýný tanýmlar:");
            #region "Visual Studio IDE" 
                //Kodlama satýrlarý
            #endregion

            Console.WriteLine ("\n'#warning mesaj' derleme esnasýnda yansýtýlacak ikazlardýr:");
            #warning Beware dog! //Dikkat köpek(ten sakýn)
            #pragma warning disable 0169
                int x=20240613; Console.WriteLine ("x = " + x);
            #pragma warning restore 0169

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}