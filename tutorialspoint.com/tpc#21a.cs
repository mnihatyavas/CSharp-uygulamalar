// tpc#21a.cs: A��r�y�klenen fonksiyonlar�n arg�man tipleriyle se�ilmesi �rne�i.

using System;
namespace �oklubi�im {
    class StatikFonksiyonA��r�Y�klenme {
        void yaz (int t) {Console.WriteLine ("\n\nTamsay� yaz�l�yor: {0}", t );}
        void yaz (double k) {Console.WriteLine ("Kayannokta yaz�l�yor: {0}", k );}
        void yaz (string d) {Console.WriteLine ("Dizge yaz�l�yor: {0}", d );}
        static void Main() {
            Console.Write ("�oklubi�imt tek araba�la�, �ok fonksiyon demektir. Statik (erken-ba�lama) �oklubi�imse derleme, dinamikse �al��ma s�recinde fonksiyon a��r�y�kleme irdelenir.\nFonksiyon a��r� y�kleme sadece d�nd�r�lenin tipiyle de�il, ayr�ca arg�man say�s� ve tipleriyle de irdelenir.\nTu�..."); Console.ReadKey();

            StatikFonksiyonA��r�Y�klenme y = new StatikFonksiyonA��r�Y�klenme();
            y.yaz (2022); // Arg�man tamsay�
            y.yaz (3.141592653589793); // Arg�man kayannokta
            y.yaz ("M.Nihat Yava� ile C#"); // Arg�man dizge

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}