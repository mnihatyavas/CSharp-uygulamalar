// jtpc#2203a.cs: DateTime ile aktüel tarihin çeþitli özelliklerini alma örneði.

using System;
namespace Çeþitli {
    class TarihZamanA {
        static void Main() {
            Console.Write ("DateTime deðerleri 01 Ocak 0001 geceyarýsý 12:00:00 AM'den baþlar ve 31 Aralýk 9999 geceyarýsý 11:59:59 PM'de sona erer.\nDateTime yaratma yöntemleri: new DateTime(19,56,8,12,8,12,23), DateTime.Parse('8/12/1956 7:10:24 AM', System.Globalization.CultureInfo.InvariantCulture), new DateTime(), new DateTime(2023,2,7), new DateTime(10000000), new DateTime(2023,02,07,01,01,45, DateTimeKind.Localization), new DateTime(2023,2,7,2,3,45,189)\nDateTime özellikleri: Hour, Minute, Second, Millisecond, Year, Month, Day, DayOfWeek, DayOfYear, TimeOfDay, Today, Now, Utc, Ticks, Kind\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = new DateTime (2023, 2, 8, 1, 27, 45, 873);
            Console.WriteLine ("Verili [2023, 2, 8, 1, 27, 45, 873] tarihin özellikleri:");
            Console.WriteLine ("Yýl: {0}", tarih.Year);
            Console.WriteLine ("Ay: {0}", tarih.Month);
            Console.WriteLine ("Aktüel gün: {0}", tarih.Day);
            Console.WriteLine ("Saat: {0}", tarih.Hour);
            Console.WriteLine ("Dakika: {0}", tarih.Minute);
            Console.WriteLine ("Saniye: {0}", tarih.Second);
            Console.WriteLine ("Milisaniye: {0}", tarih.Millisecond);
            Console.WriteLine ("Haftanýn günü: {0}", tarih.DayOfWeek);
            Console.WriteLine ("Yýlýn günü: {0}", tarih.DayOfYear);
            Console.WriteLine ("Günün zamaný: {0}", tarih.TimeOfDay);
            Console.WriteLine ("Týk 100nS: {0}", tarih.Ticks);
            Console.WriteLine ("Tarih çeþidi: {0}", tarih.Kind);

            Console.WriteLine ("\nGüncel tarih ve zaman: [{0}]", DateTime.Now);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}