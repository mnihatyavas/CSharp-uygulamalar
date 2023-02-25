// jtpc#2203b.cs: Akt�el tarihe tarih/zaman ekleme ve ��karma �rne�i.

using System;
namespace �e�itli {
    class TarihZamanB {
        static void Main() {
            Console.Write ("tarih.Add(ay) ve tarih.Subtract(ay) ile verili tarihe 1 ay (30 g�n) eklenir ve ��kar�l�r. Ayr�ca tarih.AddYears(2), tarih.AddDays(12), tarih.AddHours(4.25), tarih.AddMinutes(15), tarih.AddSeconds(45), tarih.AddMilliseconds(200), tarih.AddTicks(5000) metodlar� da kullan�labilir. ��karma metodu olmad���ndan ya farkl� tarihli DateTime yada TimeSapan nesnesi yarat�p ilkine Subtract yapar veya - i�lemciyi kullanabiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var tarih = DateTime.Now;
            var ay = new System.TimeSpan (30, 0, 0, 0); //g�n, saat, dakika, saniye
            Console.WriteLine ("G�ncel tarih ve zaman: [{0}]", tarih);
            Console.WriteLine ("Add ile 30 g�n sonras�: [{0}]", tarih.Add (ay));
            Console.WriteLine ("+ ile 30 g�n sonras�: [{0}]", (tarih + ay));
            Console.WriteLine ("Subtract ile 30 g�n �ncesi: [{0}]", tarih.Subtract (ay));
            Console.WriteLine ("- ile 30 g�n �ncesi: [{0}]", (tarih - ay));

            DateTime tarih1 = new DateTime (2023, 10, 20, 12, 15, 45);
            DateTime tarih2 = new DateTime (2023, 2, 6, 13, 5, 15);
            TimeSpan fark = new TimeSpan (10, 2, 30, 45, 985);
            Console.WriteLine ("\n[{0}] - [{1}] = [{2}] g�n ve zaman", tarih1, tarih2, tarih1.Subtract (tarih2).ToString());
            Console.WriteLine ("[{0}] - [{1}] = [{2}]", tarih1, fark, tarih1.Subtract (fark).ToString());
            Console.WriteLine ("[{0}]'den 15 g�n �ncesi = [{1}]", tarih1, new DateTime (tarih1.Year, tarih1.Month, tarih1.Day - 15, tarih1.Hour, tarih1.Minute, tarih1.Second).ToString());
            Console.WriteLine ("[{0}]'den 1 y�l, 2 ay, 3 g�n, 4 saat, 5 dakika, 6 saniye �ncesi = [{1}]", tarih1, new DateTime (tarih1.Year-1, tarih1.Month-2, tarih1.Day-3, tarih1.Hour-4, tarih1.Minute-5, tarih1.Second-6).ToString());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}