// jtpc#2305c.cs: Try-catch-finally bloðundan await'li asenkron metod çaðýrma örneði.

using System;
using System.Threading.Tasks;
namespace YeniÖzellikler {
    class AwaitliCatchFinally {
        async static Task eþzamansýzMetod() {
            try {int[] tdizi = new int[5]; tdizi [10] = 2023;
            }catch (Exception hata) {/*await*/ ÝstisnaOluþtu (hata.ToString());
            }finally {/*await*/ SonÝþlemler();}
        }
        async static Task ÝstisnaOluþtu (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        async static Task SonÝþlemler() {Console.WriteLine ("FINALLY: Try-catch-finally bloðu sonlandýrýlýyor...");}
        static void Main() {
            Console.Write ("Try-catch-finally bloðunda async static Task metoduna await'le eþzamansýz çaðrý yapýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            eþzamansýzMetod();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}