// tpc#16a.cs: �e�itli dizge yaratma y�ntemleri �rne�i.

using System;
namespace Dizgeler {
    class DizgelerYaratma {
        static void Main (string[] args) {
            // Dizgesel birle�meler:
            string ad, soyad;
            ad = "Nihat";
            soyad = "Yava�";
            string tam�sim = ad + " " + soyad;
            Console.WriteLine ("Ad ve soyad�n�z: [{0}]", "M." + tam�sim);

            // "new string" kurucunun krk dizisini kullanmas�:
            char[] krkDizi = {'S', 'e', 'l', 'a','m'};
            string selamla�ma = new string (krkDizi);
            Console.WriteLine ("Selamla�ma: [{0} {1}!]", selamla�ma, ad);

            // Dizgesel dizi elemanlar�n� birle�tiren (haz�r) fonksiyon:
            string[] dzgDizi = {"www.tutorialspoint.com'dan", "t�m", "herkese", "selamlar!.."};
            string mesaj = String.Join (" ", dzgDizi);
            Console.WriteLine ("Mesaj�n�z var: [{0}]", mesaj);

            // Tarih verisini ayr��t�ran bi�imleyerek dizgeye d�n��t�rme:
            DateTime tarih = new DateTime (2022, 12, 2, 18, 35, 55, 945);
            string sohbet = String.Format ("{0:D} tarih ve {0:t} vaktinde bir sohbete �a�r�s� ald�n�z.", tarih);
            Console.WriteLine ("Mesaj�n�z var: [{0}]", sohbet);
            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}