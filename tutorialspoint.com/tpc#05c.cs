// tpc#05c.cs: C# referans ve g�sterge veri tipleri �rne�i.

using System;
namespace VeriTipleri {
    class ReferansG�stergeTipler {
        static void Main (string[] args) {
            Console.WriteLine ("Built-in/ar�iv referanslar: object/nesne, dinamik ve string/dizge veri tipleridir. De�i�kenler burda de�er de�il de�erin bellek adresini i�erir.");
            Console.WriteLine ("Tipi nesneye �evirmeye boxing/kutulama; tersine de unboxing/kutusuzlama denir (object nesne = 100;).\nDinami�in tip kontrolu derlemede de�il �al��ma an�nda yap�l�r (dinamic d = 20;).\nDizge de�i�kene de�er atama do�rudan yada @ ile yap�l�r (String dizge = 'Nihat', veya @'Nihat').");
            Console.WriteLine ("Kullan�c�-tan�ml� referans tipler: class/s�n�f, interface/araba�la� ve delegate/yetkiaktar�m�.");
            Console.Write ("\nPointer/g�sterge veri tipi, ba�ka tipin adresini saklar (char* krkg�sterge; int* tamsay�g�sterge;).\nTu�...");
            Console.ReadKey();
        }
    }
}