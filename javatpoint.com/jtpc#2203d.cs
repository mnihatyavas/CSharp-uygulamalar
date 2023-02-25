// jtpc#2203d.cs: Verilen iki tarihin birbirinden büyük-küçük-eþitlik kontrolu örneði.

using System;
namespace Çeþitli {
    class TarihZamanD {
        static void Main() {
            Console.Write ("Ýki tarihin karþýlaþtýrýlmasý DateTime.Compare(tarih1,tarih2) veya tarih1.CompareTo(tarih2) metodlarýyla yapýlabilir. Geridönüþleri -1<, 0=, 1>'dir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih1 = new DateTime (2023, 2, 8, 3, 49, 58);
            var tarih2 = new DateTime (2023, 2, 8, 3, 49, 59);
            int sonuç = DateTime.Compare (tarih1, tarih2);
            if (sonuç < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den küçüktür.", tarih1, tarih2);
            else if (sonuç == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] eþittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den büyüktür.", tarih1, tarih2);

            tarih2 = new DateTime (2023, 2, 8, 3, 49, 58);
            sonuç = tarih1.CompareTo (tarih2);
            if (sonuç < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den küçüktür.", tarih1, tarih2);
            else if (sonuç == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] eþittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den büyüktür.", tarih1, tarih2);

            tarih2 = new DateTime (2023, 2, 8, 3, 49, 57, 999);
            sonuç = tarih1.CompareTo (tarih2);
            if (sonuç < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den küçüktür.", tarih1, tarih2);
            else if (sonuç == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] eþittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den büyüktür.", tarih1, tarih2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}