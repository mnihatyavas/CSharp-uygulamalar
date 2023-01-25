// jtpc#1102a.cs: Public belirte�li de�i�ken ve fonksiyona eri�im �rne�i.

using System;
namespace Aduzamlar {
   class PublicEri�im {
        public string isim = "M.Nihat Yava�";
        public void Mesaj (string m) {Console.WriteLine ("Merhaba " + m);}
    }
    class Eri�imDe�i�tire�leri1 {
        static void Main() {
            Console.Write ("De�i�tire� veya belirte�ler, de�i�ken ve fonksiyonlar�n nas�l eri�ilebilirli�ini ve kapsam�n� saptar. Enazdan en�ok s�n�rlanana do�ru 5 farkl� belirte�: public/genel, protected/korunan, internal/i�, protected internal, private/�zel. Public s�n�rs�z eri�ilebilirli�i g�sterir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            PublicEri�im pe = new PublicEri�im();
            Console.WriteLine ("Merhabalar " + pe.isim); //public de�i�kene eri�im
            pe.Mesaj ("Atilla G�kt�rk"); //public fonksiyona eri�im
            pe.Mesaj ("Fatih �zbay");

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}