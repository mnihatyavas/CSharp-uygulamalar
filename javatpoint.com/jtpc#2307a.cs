// jtpc#2307a.cs: Ana Main() metodun 'async Task' olarak tanýmlanabilmesi örneði.

using System;
using System.Threading.Tasks;
namespace YeniÖzellikler {
    class EþzamansýzMain {
        async static Task EþzamansýzMetod() {
            try {int[] tdizi = new int[5]; tdizi [10] = 2023;
            }catch (Exception hata) {ÝstisnaOluþtu (hata.Message);}
            await SonÝþlemler();
        }
        async static Task ÝstisnaOluþtu (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        async static Task SonÝþlemler() {Console.WriteLine ("\nEþzamansýzMetod() sonlandýrýlýyor...");}
        static void Main() {
            Console.Write ("'await' ifadeli asenkron/eþzamansýz görev icrasý için ilgili metodun 'async Task' öntanýmlý olmasý gerekmektedir. C# program yürütümünü baþlatan Main() metodu için de bunlar kullanýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            EþzamansýzMetod();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}