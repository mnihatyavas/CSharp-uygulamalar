// jtpc#2304b.cs: �a��ran ifadenin metod ad�, tam yollu dosya ad� ve sat�r no vas�flar� �rne�i.

using System;
using System.Runtime.CompilerServices;
namespace Yeni�zellikler {
    class �a��ranVas�flar� {
        static void �a��ran�nVas�flar�n�G�ster (
                [CallerMemberName] string �a��ranMetodAd� = null,
                [CallerFilePath] string �a��ranDosyaYolu = null,
                [CallerLineNumber] int �a��ranSat�rNo = -1) {
            Console.WriteLine ("�a��ran metodun ad�: [{0}]", �a��ranMetodAd�);
            Console.WriteLine ("�a��ran dosyan�n tam yolu: [{0}]", �a��ranDosyaYolu);
            Console.WriteLine ("�a��ran ifadenin sat�r no'su: [{0}]", �a��ranSat�rNo);
        }
        static void Main() {
            Console.Write ("�a��ran metod ifadesine dair metodad� (string CallerMemberNameAttribute), sat�r numaras� (int CallerLineNumberAttribute) ve tam yollu dosya ad� (string CallerFilePathAttribute) vas�flar� elde edilebilir. Bu vas�f parametreleri �a�r�lan metodun se�enekli parametreleri olarak tan�mlanmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");
            �a��ran�nVas�flar�n�G�ster();
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}