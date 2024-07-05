// j2sc#1601.cs: �ni�lem direktifleri (#define/undef/if/line/region/warning) �rne�i.

#define HATAAYIKLA //�fade sonunda ; kullan�lmaz
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
#warning ikaz_mesaj�

using System;
using System.Diagnostics; //[Conditional...] i�in
namespace �ni�lemler {
    class Direktif {
        [Conditional ("METOT1")]
        public static void Metot1() {Console.WriteLine ("Metot1 i�indeyim...");}
        public static void Metot2() {Console.WriteLine ("Metot2 i�indeyim...");}
        [Conditional ("win2000")]
        public static void D�k�mle() {Console.WriteLine ("Tan�ml�ysa win2000'i d�k�mle...");}
        static void Main() {
            Console.Write ("�ni�lem direktifleri: #define-#undef, #if-#else-#elif-#endif, #line, #error, #warning, #region, #pragma.#define sembol� #if-#elif'le irdelenip kod ak��� y�netilebilir. #define sonuna ; konulmamal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'#define TANIM'a ba�l� #if-#endif �artl� program ak��lar�:");
            #if HATAAYIKLA //;'l� ifade bulunmamal�, alt sat�ra konulmal�d�r
                Console.WriteLine ("Program hatalar�ndan ar�nd�rma m�mk�n k�l�nm��t�r");
            #else
                Console.WriteLine ("Program hatalar�ndan ar�nd�rma m�mk�n k�l�nmam��t�r");
            #endif

            #if Ver_A && Ver_B && Ver_C
                Console.WriteLine ("T�m s�r�mler test ediliyor.");
            #elif Ver_A 
                Console.WriteLine ("S�r�m Ver_A test ediliyor.");
            #elif Ver_B
                Console.WriteLine ("S�r�m Ver_B test ediliyor.");
            #elif Ver_C
                Console.WriteLine ("S�r�m Ver_C test ediliyor.");
            #else
                Console.WriteLine ("Tes edilen s�r�m yok.");
            #endif

            Console.WriteLine ("Main metot i�indeyim...");
            #if METOT1
                Metot1();
            #else
                Metot2();
            #endif

            Console.WriteLine ("\n#if-#elif-#else-#endif direktifleri �artl� derleme ger�ekle�tirir:");
            #if Ver_X
                Console.WriteLine ("S�r�m Ver_X i�in derleniyor.");
            #else
                Console.WriteLine ("S�r�m Ver_X i�in derlenmiyor.");
            #endif

            #if !Ver_A
                Console.WriteLine ("S�r�m Ver_A i�in derlemeye dahil."); 
            #elif RELEASE
                Console.WriteLine ("RELEASE yay�m� i�in derlemeye dahil."); 
            #else
                Console.WriteLine ("Dahili test i�in derlemeye dahil."); 
            #endif

            Console.WriteLine ("\n#undef, �nceki #define sembol tan�m�n� ge�ersiz k�lar:");
            string platformAd�;
            #if winXP
                platformAd� = "Microsoft Windows XP";
            #elif win2000
                platformAd� = "Microsoft Windows 2000";
            #elif winNT
                platformAd� = "Microsoft Windows 2007-NT";
            #elif win98
                platformAd� = "Microsoft Windows 98";
            #else           // Unknown platform specified
                platformAd� = "Bilinmeyen platform";
            #endif
            Console.WriteLine (platformAd�);
            D�k�mle(); //"#undef win200" oldu�undan �a�r�lmaz

            Console.WriteLine ("\n'#line xx' sadece programc�ya sat�r_no bilgisini hat�rlat�r:");
            #line default
            #line 90
            #line 91 "C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\j2sc#1601.cs"
            #line 92 "nihat.txt"

            Console.WriteLine ("\n'#region-#endregion' VS edit�r�nde a��lan/kapanan kod sat�rlar�n� tan�mlar:");
            #region "Visual Studio IDE" 
                //Kodlama sat�rlar�
            #endregion

            Console.WriteLine ("\n'#warning mesaj' derleme esnas�nda yans�t�lacak ikazlard�r:");
            #warning Beware dog! //Dikkat k�pek(ten sak�n)
            #pragma warning disable 0169
                int x=20240613; Console.WriteLine ("x = " + x);
            #pragma warning restore 0169

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}