// jtpc#2306g.cs: Metod geridönüþünü deðerle deðil 'ref' adresle yapma örneði.

using System;
namespace YeniÖzellikler {
    class RefGeridönüþ {
        static /*ref*/ string ÖðrenciyiBul (string[] öðrenciler, string öðrenci) {
            for (int i = 0; i < öðrenciler.Length; i++) {if (öðrenciler [i].Equals (öðrenci)) {return /*ref*/ öðrenciler [i];} }
            throw new Exception ("Aranan öðrenci [" + öðrenci + "] dizide bulunamadý.");
        }
        static void Main() {
            Console.Write ("Hem atanacak deðiþken, hem de atayacaðý deðeri döndüren metod önünde 'ref' anahtarkelimesi kullanarak deðerin bellek adresi döndürülebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string[] öðrenciler = {"Hatice", "Süheyla", "Nihal", "Nihat", "Songül", "Nedim", "Sevim"};
            try {/*ref*/ string öðrenci = /*ref*/ ÖðrenciyiBul (öðrenciler, "Nihal"); Console.WriteLine ("Sonuç: [{0}] öðrenciler dizisinde bulundu.", öðrenci);
            öðrenci = ÖðrenciyiBul (öðrenciler, "Süleyha"); Console.WriteLine ("Sonuç: [{0}] öðrenciler dizisinde bulundu.", öðrenci);}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message);}

            Console.WriteLine ("\nDizgeleþen öðrenci dizisi: [{0}]", string.Join (",", öðrenciler));
            string[] öðr = öðrenciler; //Kopyalama adres referansýyladýr
            öðr [2] = "Zeliha"; //Bir dizi deðiþimi diðerini de etkiler
            öðrenciler [1] = "Süleyha";
            Console.WriteLine ("Güncellenen ilk dizi: [{0}]", string.Join (", ", öðrenciler));
            Console.WriteLine ("Güncellenen kopya dizi: [{0}]", string.Join (", ", öðr));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}