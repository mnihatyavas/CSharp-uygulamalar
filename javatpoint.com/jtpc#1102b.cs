// jtpc#1102b.cs: Protected belirte�li de�i�ken ve fonksiyona miraslamayla eri�im �rne�i.

using System;
namespace Aduzamlar {
   class ProtectedEri�im {
        protected string isim = "M.Nihat Yava�";
        protected void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class Eri�imDe�i�tire�leri2: ProtectedEri�im {//Miraslamayla eri�im
        static void Main() {
            Console.Write ("Protected/korumal� �yeye sadece tan�ml� s�n�f ve alts�n�flar� i�inden veya miraslanmayla eri�ilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Eri�imDe�i�tire�leri2 pe = new Eri�imDe�i�tire�leri2();
            Console.WriteLine ("Merhabalar " + pe.isim); //protected de�i�kene miraslamayla eri�im
            pe.Mesaj ("Zafer N.Candan"); //protected fonksiyona miraslamayla eri�im
            pe.Mesaj ("Y�cel K���kbay");

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}