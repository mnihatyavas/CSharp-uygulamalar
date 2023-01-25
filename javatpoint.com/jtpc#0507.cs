// jtpc#0507.cs: Komutsat�r� verilerinin dizgesel dizi olarak yakalan�p i�lenmesi �rne�i.

using System;
namespace Diziler {
    class Komutsat�rl�Dizi {
        static void DiziyiYaz (int[] dizi) {foreach (Object eleman in dizi) Console.Write (eleman + " ");}  
        static void Main (string[] arg�manlar) {
            Console.Write ("Komutsat�r�ndan girilen veriler Main (string[] arg�manlar) taraf�ndan dizgesel dizi olarak yakalan�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            // >jtpc#0507 M.Nihat Yava�'tan herkese selam!..
            Console.WriteLine ("Arg�manlar�n say�s�: " + arg�manlar.Length);  
            Console.Write ("Girilen komutsat�r� arg�manlar�: ");  
            foreach (Object arg�man in arg�manlar) Console.Write (arg�man + " ");       

            Console.Write ("\n\nTu�.."); Console.ReadKey();
        }
    }
}