// jtpc#0507.cs: Komutsatýrý verilerinin dizgesel dizi olarak yakalanýp iþlenmesi örneði.

using System;
namespace Diziler {
    class KomutsatýrlýDizi {
        static void DiziyiYaz (int[] dizi) {foreach (Object eleman in dizi) Console.Write (eleman + " ");}  
        static void Main (string[] argümanlar) {
            Console.Write ("Komutsatýrýndan girilen veriler Main (string[] argümanlar) tarafýndan dizgesel dizi olarak yakalanýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            // >jtpc#0507 M.Nihat Yavaþ'tan herkese selam!..
            Console.WriteLine ("Argümanlarýn sayýsý: " + argümanlar.Length);  
            Console.Write ("Girilen komutsatýrý argümanlarý: ");  
            foreach (Object argüman in argümanlar) Console.Write (argüman + " ");       

            Console.Write ("\n\nTuþ.."); Console.ReadKey();
        }
    }
}