// jtpc#2306g.cs: Metod gerid�n���n� de�erle de�il 'ref' adresle yapma �rne�i.

using System;
namespace Yeni�zellikler {
    class RefGerid�n�� {
        static /*ref*/ string ��renciyiBul (string[] ��renciler, string ��renci) {
            for (int i = 0; i < ��renciler.Length; i++) {if (��renciler [i].Equals (��renci)) {return /*ref*/ ��renciler [i];} }
            throw new Exception ("Aranan ��renci [" + ��renci + "] dizide bulunamad�.");
        }
        static void Main() {
            Console.Write ("Hem atanacak de�i�ken, hem de atayaca�� de�eri d�nd�ren metod �n�nde 'ref' anahtarkelimesi kullanarak de�erin bellek adresi d�nd�r�lebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string[] ��renciler = {"Hatice", "S�heyla", "Nihal", "Nihat", "Song�l", "Nedim", "Sevim"};
            try {/*ref*/ string ��renci = /*ref*/ ��renciyiBul (��renciler, "Nihal"); Console.WriteLine ("Sonu�: [{0}] ��renciler dizisinde bulundu.", ��renci);
            ��renci = ��renciyiBul (��renciler, "S�leyha"); Console.WriteLine ("Sonu�: [{0}] ��renciler dizisinde bulundu.", ��renci);}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}

            Console.WriteLine ("\nDizgele�en ��renci dizisi: [{0}]", string.Join (",", ��renciler));
            string[] ��r = ��renciler; //Kopyalama adres referans�ylad�r
            ��r [2] = "Zeliha"; //Bir dizi de�i�imi di�erini de etkiler
            ��renciler [1] = "S�leyha";
            Console.WriteLine ("G�ncellenen ilk dizi: [{0}]", string.Join (", ", ��renciler));
            Console.WriteLine ("G�ncellenen kopya dizi: [{0}]", string.Join (", ", ��r));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}