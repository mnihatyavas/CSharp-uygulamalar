// jtpc#2205.cs: Read ile satýr, karakter ve tuþ giriþi örneði.

using System;
namespace Çeþitli {
    class Oku {
        static void Main() {
            Console.Write ("System.ReadLine() metodu dizgesel satýr giriþinin bitiminde Enter'la girileni okur.\nSystem.Read() sadece tek karakter giriþini okur.\nSystem.ReadKey() ise program akýþýnýn devamý için herhangibir tuþa (veya Ent) basýlmasýný bekler ve basýlan tuþ karakteri ekranda yansýr.\nFýrlatýlan istisnalar: IOException, OutOfMemoryException, ArgumentOutOfRangeException\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string satýr, ad, soyad;
            Console.WriteLine ("Lütfen tam adresini yazýp Enter bas:");  
            satýr = Console.ReadLine();
            Console.WriteLine ("Buyur, yazdýklarýnýn doðruluðunu kontrol et: [{0}]", satýr);

            Console.Write ("\nLütfen adýnýzý yazýp Enter bas: "); ad = Console.ReadLine();
            Console.Write ("Lütfen soyadýnýzý yazýp Enter bas: "); soyad = Console.ReadLine();
            Console.WriteLine ("Girdiðiniz soyad ve ad: [{0}, {1}]", soyad, ad);

            char krk1, krk2, krk3, krk4;  
            Console.Write ("\nLütfen 4 karakterli þifrenizi girip Ent bas: "); krk1 = Convert.ToChar (Console.Read()); krk2 = Convert.ToChar (Console.Read());  krk3 = Convert.ToChar (Console.Read()); krk4 = Convert.ToChar (Console.Read());
            Console.WriteLine ("Girdiðiniz harfler (tersten): [{0}, {1}, {2} ve {3}]", krk4, krk3, krk2, krk1);

            var tarih = DateTime.Now;
            Console.WriteLine ("\nAktüel tarih ve zaman: [{0}]", tarih);
            Console.Write ("Program akýþý için herhangibir tuþa basýn: ["); Console.ReadKey();
            Console.Write ("] <== tuþuna bastýnýz");

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    }
}