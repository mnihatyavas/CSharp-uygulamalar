// jtpc#2306d.cs: Ayn� metod i�inden yerel fonksiyon �a��rma �rne�i.

using System;
namespace Yeni�zellikler {
    class YerelFonksiyon {
        static string topla (double a, double b) {return "Topla("+a+", "+b+") = " + (a + b);}
        static void Main() {
            Console.Write ("Ayn� metod i�inden atanan de�i�kenle ayn� tipte gerid�n�� yapan fonksiyon do�rudan ('new' ile tiplenmeden) �a�r�labilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string sonu� = topla (10, 20); Console.WriteLine (sonu�);
            sonu� = topla (Math.E, Math.PI); Console.WriteLine (sonu�);
            sonu� = topla (Math.PI*2.5, Math.E/28.65e-2); Console.WriteLine (sonu�);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}