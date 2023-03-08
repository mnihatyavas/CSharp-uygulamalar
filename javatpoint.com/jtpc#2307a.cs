// jtpc#2307a.cs: Ana Main() metodun 'async Task' olarak tan�mlanabilmesi �rne�i.

using System;
using System.Threading.Tasks;
namespace Yeni�zellikler {
    class E�zamans�zMain {
        async static Task E�zamans�zMetod() {
            try {int[] tdizi = new int[5]; tdizi [10] = 2023;
            }catch (Exception hata) {�stisnaOlu�tu (hata.Message);}
            await Son��lemler();
        }
        async static Task �stisnaOlu�tu (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        async static Task Son��lemler() {Console.WriteLine ("\nE�zamans�zMetod() sonland�r�l�yor...");}
        static void Main() {
            Console.Write ("'await' ifadeli asenkron/e�zamans�z g�rev icras� i�in ilgili metodun 'async Task' �ntan�ml� olmas� gerekmektedir. C# program y�r�t�m�n� ba�latan Main() metodu i�in de bunlar kullan�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            E�zamans�zMetod();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}