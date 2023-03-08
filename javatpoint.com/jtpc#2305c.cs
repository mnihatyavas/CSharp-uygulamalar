// jtpc#2305c.cs: Try-catch-finally blo�undan await'li asenkron metod �a��rma �rne�i.

using System;
using System.Threading.Tasks;
namespace Yeni�zellikler {
    class AwaitliCatchFinally {
        async static Task e�zamans�zMetod() {
            try {int[] tdizi = new int[5]; tdizi [10] = 2023;
            }catch (Exception hata) {/*await*/ �stisnaOlu�tu (hata.ToString());
            }finally {/*await*/ Son��lemler();}
        }
        async static Task �stisnaOlu�tu (string h) {Console.WriteLine ("HATA: [{0}]", h);}
        async static Task Son��lemler() {Console.WriteLine ("FINALLY: Try-catch-finally blo�u sonland�r�l�yor...");}
        static void Main() {
            Console.Write ("Try-catch-finally blo�unda async static Task metoduna await'le e�zamans�z �a�r� yap�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            e�zamans�zMetod();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}