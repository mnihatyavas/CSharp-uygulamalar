// jtpc#1102c.cs: Internal belirte�li de�i�ken ve fonksiyona tiplemeyle eri�im �rne�i.

using System;
using InternalAduzam;
namespace InternalAduzam {
   class InternalEri�im {
        internal string isim = "M.Nihat Yava�";
        internal void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
}
namespace Aduzamlar {
    class Eri�imDe�i�tire�leri3 {
        static void Main() {
            Console.Write ("Internal/i� �yeye public gibi fakat sadece akt�el uygulama i�inden ve tiplemeyle eri�ilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            InternalEri�im ie = new InternalEri�im();
            Console.WriteLine ("Merhabalar " + ie.isim); //internal de�i�kene tiplemeyle eri�im
            ie.Mesaj ("Zafer N.Candan"); //internal fonksiyona tiplemeyle eri�im
            ie.Mesaj ("Atilla G�kt�rk");

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}