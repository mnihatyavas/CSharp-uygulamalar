// tpc#25a.cs: Bir sembolik sabitli �ni�lemci direktif tan�m�n�n kodlamada kullan�lmas� �rne�i.

#define PI
using System;
namespace �ni�lemciDirektifleri {
    class SembolTan�m� {
        static void Main() {
            Console.Write ("�ni�lemci direktifleri, ger�ek derleme �ncesi, programdaki derlenecek se�imli kodlamalar� saptar.\nC# direktifleri: #define, #undef, #if, #else, #elif, #endif, #line, #error, #warning, #region, #endregion.\n#define, sembolik sabitler tan�mlar. Direktifler # ile ba�lar, sonra bo�luk ve sembol gelir, fakat sonlar�nda ; kullan�lmaz.\nTu�..."); Console.ReadKey();

            #if (PI)
                Console.WriteLine ("\n\nPI sembolik �ni�lemci sabiti tan�mlanm��t�r.");
            #else
                Console.WriteLine ("\n\nPI �ni�lemci direktifi tan�mlanmam��t�r.");
            #endif

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}