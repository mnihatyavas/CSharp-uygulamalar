// jtpc#2203d.cs: Verilen iki tarihin birbirinden b�y�k-k���k-e�itlik kontrolu �rne�i.

using System;
namespace �e�itli {
    class TarihZamanD {
        static void Main() {
            Console.Write ("�ki tarihin kar��la�t�r�lmas� DateTime.Compare(tarih1,tarih2) veya tarih1.CompareTo(tarih2) metodlar�yla yap�labilir. Gerid�n��leri -1<, 0=, 1>'dir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih1 = new DateTime (2023, 2, 8, 3, 49, 58);
            var tarih2 = new DateTime (2023, 2, 8, 3, 49, 59);
            int sonu� = DateTime.Compare (tarih1, tarih2);
            if (sonu� < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den k���kt�r.", tarih1, tarih2);
            else if (sonu� == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] e�ittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den b�y�kt�r.", tarih1, tarih2);

            tarih2 = new DateTime (2023, 2, 8, 3, 49, 58);
            sonu� = tarih1.CompareTo (tarih2);
            if (sonu� < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den k���kt�r.", tarih1, tarih2);
            else if (sonu� == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] e�ittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den b�y�kt�r.", tarih1, tarih2);

            tarih2 = new DateTime (2023, 2, 8, 3, 49, 57, 999);
            sonu� = tarih1.CompareTo (tarih2);
            if (sonu� < 0) Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den k���kt�r.", tarih1, tarih2);
            else if (sonu� == 0) Console.WriteLine ("Tarih1:[{0}] ile tarih2:[{1}] e�ittir.", tarih1, tarih2);
            else Console.WriteLine ("Tarih1:[{0}] tarih2:[{1}]'den b�y�kt�r.", tarih1, tarih2);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}