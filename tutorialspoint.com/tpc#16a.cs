// tpc#16a.cs: Çeþitli dizge yaratma yöntemleri örneði.

using System;
namespace Dizgeler {
    class DizgelerYaratma {
        static void Main (string[] args) {
            // Dizgesel birleþmeler:
            string ad, soyad;
            ad = "Nihat";
            soyad = "Yavaþ";
            string tamÝsim = ad + " " + soyad;
            Console.WriteLine ("Ad ve soyadýnýz: [{0}]", "M." + tamÝsim);

            // "new string" kurucunun krk dizisini kullanmasý:
            char[] krkDizi = {'S', 'e', 'l', 'a','m'};
            string selamlaþma = new string (krkDizi);
            Console.WriteLine ("Selamlaþma: [{0} {1}!]", selamlaþma, ad);

            // Dizgesel dizi elemanlarýný birleþtiren (hazýr) fonksiyon:
            string[] dzgDizi = {"www.tutorialspoint.com'dan", "tüm", "herkese", "selamlar!.."};
            string mesaj = String.Join (" ", dzgDizi);
            Console.WriteLine ("Mesajýnýz var: [{0}]", mesaj);

            // Tarih verisini ayrýþtýran biçimleyerek dizgeye dönüþtürme:
            DateTime tarih = new DateTime (2022, 12, 2, 18, 35, 55, 945);
            string sohbet = String.Format ("{0:D} tarih ve {0:t} vaktinde bir sohbete çaðrýsý aldýnýz.", tarih);
            Console.WriteLine ("Mesajýnýz var: [{0}]", sohbet);
            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}