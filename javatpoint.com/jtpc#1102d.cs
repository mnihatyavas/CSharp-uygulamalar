// jtpc#1102d.cs: ProtectedInternal belirte�li de�i�ken ve fonksiyona tiplemeyle eri�im �rne�i.

using System;
namespace Aduzamlar {
   class ProtectedInternalEri�im {
        protected internal string isim = "M.Nihat Yava�";
        protected internal void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class Eri�imDe�i�tire�leri4 {
        static void Main() {
            Console.Write ("ProtectedInternal/Korumal��� �yeye public gibi fakat sadece akt�el uygulama i�inden veya harici uygulamadaysa miraslamayla eri�ilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ProtectedInternalEri�im pie = new ProtectedInternalEri�im();
            Console.WriteLine ("Merhabalar " + pie.isim); //protected internal de�i�kene tiplemeyle eri�im
            pie.Mesaj ("Fatih �zbay"); //protected internal fonksiyona tiplemeyle eri�im
            pie.Mesaj ("Atilla G�kt�rk");

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}