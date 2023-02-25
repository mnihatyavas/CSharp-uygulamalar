// jtpc#2203a.cs: DateTime ile akt�el tarihin �e�itli �zelliklerini alma �rne�i.

using System;
namespace �e�itli {
    class TarihZamanA {
        static void Main() {
            Console.Write ("DateTime de�erleri 01 Ocak 0001 geceyar�s� 12:00:00 AM'den ba�lar ve 31 Aral�k 9999 geceyar�s� 11:59:59 PM'de sona erer.\nDateTime yaratma y�ntemleri: new DateTime(19,56,8,12,8,12,23), DateTime.Parse('8/12/1956 7:10:24 AM', System.Globalization.CultureInfo.InvariantCulture), new DateTime(), new DateTime(2023,2,7), new DateTime(10000000), new DateTime(2023,02,07,01,01,45, DateTimeKind.Localization), new DateTime(2023,2,7,2,3,45,189)\nDateTime �zellikleri: Hour, Minute, Second, Millisecond, Year, Month, Day, DayOfWeek, DayOfYear, TimeOfDay, Today, Now, Utc, Ticks, Kind\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = new DateTime (2023, 2, 8, 1, 27, 45, 873);
            Console.WriteLine ("Verili [2023, 2, 8, 1, 27, 45, 873] tarihin �zellikleri:");
            Console.WriteLine ("Y�l: {0}", tarih.Year);
            Console.WriteLine ("Ay: {0}", tarih.Month);
            Console.WriteLine ("Akt�el g�n: {0}", tarih.Day);
            Console.WriteLine ("Saat: {0}", tarih.Hour);
            Console.WriteLine ("Dakika: {0}", tarih.Minute);
            Console.WriteLine ("Saniye: {0}", tarih.Second);
            Console.WriteLine ("Milisaniye: {0}", tarih.Millisecond);
            Console.WriteLine ("Haftan�n g�n�: {0}", tarih.DayOfWeek);
            Console.WriteLine ("Y�l�n g�n�: {0}", tarih.DayOfYear);
            Console.WriteLine ("G�n�n zaman�: {0}", tarih.TimeOfDay);
            Console.WriteLine ("T�k 100nS: {0}", tarih.Ticks);
            Console.WriteLine ("Tarih �e�idi: {0}", tarih.Kind);

            Console.WriteLine ("\nG�ncel tarih ve zaman: [{0}]", DateTime.Now);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}