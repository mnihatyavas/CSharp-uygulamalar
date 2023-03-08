// jtpc#2306d.cs: Ayný metod içinden yerel fonksiyon çaðýrma örneði.

using System;
namespace YeniÖzellikler {
    class YerelFonksiyon {
        static string topla (double a, double b) {return "Topla("+a+", "+b+") = " + (a + b);}
        static void Main() {
            Console.Write ("Ayný metod içinden atanan deðiþkenle ayný tipte geridönüþ yapan fonksiyon doðrudan ('new' ile tiplenmeden) çaðrýlabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string sonuç = topla (10, 20); Console.WriteLine (sonuç);
            sonuç = topla (Math.E, Math.PI); Console.WriteLine (sonuç);
            sonuç = topla (Math.PI*2.5, Math.E/28.65e-2); Console.WriteLine (sonuç);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}