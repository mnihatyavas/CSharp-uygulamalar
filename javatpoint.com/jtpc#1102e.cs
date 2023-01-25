// jtpc#1102e.cs: Private belirte�li de�i�ken ve fonksiyona s�n�fi�i tiplemeyle eri�im �rne�i.

using System;
namespace Aduzamlar {
    class Eri�imDe�i�tire�leri5 {
        private string isim = "M.Nihat Yava�";
        private void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
        static void Main() {
            Console.Write ("Private/�zel �yeye sadece ayn� s�n�f i�i tiplemeyle eri�ilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Eri�imDe�i�tire�leri5 pe = new Eri�imDe�i�tire�leri5();
            Console.WriteLine ("Merhabalar " + pe.isim); //private de�i�kene ayn� s�n�fta tiplemeyle eri�im
            pe.Mesaj ("Y�cel K���kbay"); //private fonksiyona ayn� s�n�fta tiplemeyle eri�im
            pe.Mesaj ("Fatih �zbay");

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}