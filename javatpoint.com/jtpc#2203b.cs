// jtpc#2203b.cs: Aktüel tarihe tarih/zaman ekleme ve çýkarma örneði.

using System;
namespace Çeþitli {
    class TarihZamanB {
        static void Main() {
            Console.Write ("tarih.Add(ay) ve tarih.Subtract(ay) ile verili tarihe 1 ay (30 gün) eklenir ve çýkarýlýr. Ayrýca tarih.AddYears(2), tarih.AddDays(12), tarih.AddHours(4.25), tarih.AddMinutes(15), tarih.AddSeconds(45), tarih.AddMilliseconds(200), tarih.AddTicks(5000) metodlarý da kullanýlabilir. Çýkarma metodu olmadýðýndan ya farklý tarihli DateTime yada TimeSapan nesnesi yaratýp ilkine Subtract yapar veya - iþlemciyi kullanabiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = DateTime.Now;
            var ay = new System.TimeSpan (30, 0, 0, 0); //gün, saat, dakika, saniye
            Console.WriteLine ("Güncel tarih ve zaman: [{0}]", tarih);
            Console.WriteLine ("Add ile 30 gün sonrasý: [{0}]", tarih.Add (ay));
            Console.WriteLine ("+ ile 30 gün sonrasý: [{0}]", (tarih + ay));
            Console.WriteLine ("Subtract ile 30 gün öncesi: [{0}]", tarih.Subtract (ay));
            Console.WriteLine ("- ile 30 gün öncesi: [{0}]", (tarih - ay));

            DateTime tarih1 = new DateTime (2023, 10, 20, 12, 15, 45);
            DateTime tarih2 = new DateTime (2023, 2, 6, 13, 5, 15);
            TimeSpan fark = new TimeSpan (10, 2, 30, 45, 985);
            Console.WriteLine ("\n[{0}] - [{1}] = [{2}] gün ve zaman", tarih1, tarih2, tarih1.Subtract (tarih2).ToString());
            Console.WriteLine ("[{0}] - [{1}] = [{2}]", tarih1, fark, tarih1.Subtract (fark).ToString());
            Console.WriteLine ("[{0}]'den 15 gün öncesi = [{1}]", tarih1, new DateTime (tarih1.Year, tarih1.Month, tarih1.Day - 15, tarih1.Hour, tarih1.Minute, tarih1.Second).ToString());
            Console.WriteLine ("[{0}]'den 1 yýl, 2 ay, 3 gün, 4 saat, 5 dakika, 6 saniye öncesi = [{1}]", tarih1, new DateTime (tarih1.Year-1, tarih1.Month-2, tarih1.Day-3, tarih1.Hour-4, tarih1.Minute-5, tarih1.Second-6).ToString());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}