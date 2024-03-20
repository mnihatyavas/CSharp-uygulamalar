// j2sc#1301.cs: DateTime ve detaylar�yla �e�itli TarihZaman hesaplar� �rne�i.

using System;
using System.Threading;
namespace Tarih {
    public class Toplamlar {
        public int Toplam1 (int n) {
            int tpl = 0;
            for (int i = 1; i <= n; i++) tpl += i;
            return tpl;
        }
        public int Toplam2() {return 1881 + 57;}
    }
    class TarihZaman {
        public static void TarihZaman�G�ster (string �imdi, DateTime tz) {
            Console.WriteLine ("\t"+�imdi + " = " + tz);
            Console.WriteLine (�imdi + ".Year = " + tz.Year);
            Console.WriteLine (�imdi + ".Month = " + tz.Month);
            Console.WriteLine (�imdi + ".Day = " + tz.Day);
            Console.WriteLine (�imdi + ".Hour = " + tz.Hour);
            Console.WriteLine (�imdi + ".Minute = " + tz.Minute);
            Console.WriteLine (�imdi + ".Second = " + tz.Second);
            Console.WriteLine (�imdi + ".Millisecond = " + tz.Millisecond);
            Console.WriteLine (�imdi + ".Ticks = " + tz.Ticks);
        }
        static void Main() {
            Console.Write ("DateTime(yyyy,aa,gg,SS,dd,ss,mmm) giri�i kabul eder, ��kt�da mmm/milisaniye hari� di�erlerini (girilmemi�se 00) g�sterir. DateTime.Now bilgisarda mevcut an�n zaman�n� sunar. TimeSpan(gg,SS,dd,ss) s�f�rdan verili de�ere olan zaman aral���d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'new DateTime()' ve 'DateTime.Now' ile TarihZaman:");
            DateTime tz1 = new DateTime (2024, 02, 28); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = new DateTime (2024, 2, 28, 2, 43, 55); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = new DateTime (2024, 2, 28, 2, 43, 55, 982); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = DateTime.Now; Console.WriteLine ("�imdi: [{0}]", tz1);

            Console.WriteLine ("\nTimeSapan ile zaman aral��� s�relerini alma:");
            TimeSpan birHafta = new TimeSpan (3, 12, 0, 0) + new TimeSpan (2, 10, 0, 0) + new TimeSpan (1, 2, 0, 0); //(3g�n+12saat) + (2g�n+10saat) + (1g�n+2saat) = 6g�n+24saat=7g�n
            DateTime ge�enHafta = tz1 - birHafta; Console.WriteLine ("1 hafta �ncesi: [{0}]", ge�enHafta);
            DateTime gelecekHafta = tz1 + birHafta; Console.WriteLine ("1 hafta sonras�: [{0}]", gelecekHafta);
            DateTime ge�en2Hafta = tz1 - new TimeSpan (14,0,0,0); Console.WriteLine ("2 hafta �ncesi: [{0}]", ge�en2Hafta);
            DateTime gelecek3Hafta = tz1 + new TimeSpan (21,0,0,0); Console.WriteLine ("3 hafta sonras�: [{0}]", gelecek3Hafta);

            Console.WriteLine ("\nAddSeconds()'la tek mikrosn ve sadece sn de�i�imlerini yans�tma:");
            DateTime son = DateTime.Now.AddSeconds (0.0005);
            while (DateTime.Now < son) Console.Write (DateTime.Now.TimeOfDay.ToString()+" "); Console.WriteLine();
            son = DateTime.Now.AddSeconds (5);
            while (DateTime.Now < son) {Console.WriteLine ("\t"+DateTime.Now.TimeOfDay.ToString()); Thread.Sleep (1000);}

            Console.WriteLine ("\nDateTime.Now'�n detay (y�l,ay,g�n,saat,dakika,sn,msn) ve 1970'den ms:");
            TarihZaman�G�ster ("tz1", tz1);
            System.Globalization.JulianCalendar j�lyenTakvim = new System.Globalization.JulianCalendar();
            tz1 = new DateTime (tz1.Year, tz1.Month, tz1.Day, tz1.Hour, tz1.Minute, tz1.Second, tz1.Millisecond, j�lyenTakvim);
            TarihZaman�G�ster ("tz1", tz1);
            DateTime tz2 = new DateTime (0);
            TarihZaman�G�ster ("tz2", tz2);

            Console.WriteLine ("\nNow/UtcNow, g�n �e�itleri, zaman k�yaslar�:");
            Console.WriteLine ("DateTime.Now = " + (tz1=DateTime.Now));
            Console.WriteLine ("DateTime.UtcNow = " + DateTime.UtcNow);
            Console.WriteLine ("�imdi.Date = " + tz1.Date);
            Console.WriteLine ("�imdi.Day = " + tz1.Day);
            Console.WriteLine ("�imdi.DayOfWeek = " + tz1.DayOfWeek);
            Console.WriteLine ("�imdi.DayOfYear = " + tz1.DayOfYear);
            Console.WriteLine ("�imdi.TimeOfDay = " + tz1.TimeOfDay);
            Console.WriteLine ("DateTime.Compare (tz1, tz2) = " + DateTime.Compare (tz1, tz2));
            Console.WriteLine ("tz1 < tz2? " + (tz1<tz2?"Evet":"Hay�r"));
            Console.WriteLine ("tz1.Equals (tz2)? " + (tz1.Equals (tz2)?"Evet":"Hay�r"));
            Console.WriteLine ("tz1 == tz1? " + (tz1==tz1?"Evet":"Hay�r"));

            Console.WriteLine ("\nY�l ay g�nleri, tarih ��z�mleme, Ticks ve ToFileTime() �evrimleri:");
            var r=new Random(); int i, ts1=r.Next(1923,2025), ts2; long ls1, ls2;
            Console.Write ("{0} y�l�ndaki her ay�n g�n say�s�: ", ts1);
            for(i=1;i<=12;i++) Console.Write (DateTime.DaysInMonth (ts1, i) + " "); Console.WriteLine();
            Console.WriteLine ("{0} art�k y�l m�? {1}", ts1, (DateTime.IsLeapYear (ts1)?"Evet":"Hay�r"));
            tz2 = DateTime.Parse ("28/2/2024 21:22:58");
            Console.WriteLine ("��z�mlenen tz2 = " + tz2);
            Console.WriteLine ("tz2 + birHafta = {1}", tz2, (tz2 + birHafta));
            Console.WriteLine ("tz2 - birHafta = " + (tz2 - birHafta));
            Console.WriteLine ("tz2 + (1y, 5a, 3g, 2S, 45d, 5s) = " + tz2.AddYears(1).AddMonths(5).AddDays(3).AddHours(2).AddMinutes(45).AddSeconds(5));
            Console.WriteLine ("�imdi.Ticks = " + (ls1=tz1.Ticks));
            Console.WriteLine ("�imdi.ToFileTime() = " + (ls2=tz1.ToFileTime()));
            Console.WriteLine ("new DateTime (ls1) = " + new DateTime (ls1));
            Console.WriteLine ("DateTime.FromFileTime (ls2) = " + DateTime.FromFileTime (ls2));

            Console.WriteLine ("\n�ki ayr� d�ng�sel hesaplaman�n uzun ve k�sa s�relerinin k�yas�:");
            ts1 = r.Next(20, 2024);  
            ts2 = r.Next(1000000,10000000);
            int tpl=0;
            Toplamlar top12 = new Toplamlar();
            DateTime ilk = DateTime.Now;
            for (i = 0; i < ts2; i++) tpl = top12.Toplam1 (ts1);
            TimeSpan s�re = (DateTime.Now - ilk);
            Console.WriteLine ("[1-->{0:#,0}] toplam� = {1:#,0}", ts1, tpl);
            Console.WriteLine ("{0:#,0} kere tekrarlanan Toplam1() s�resi = {0:#,0} msn", ts2, s�re.TotalMilliseconds.ToString());
            ilk = DateTime.Now;
            for (i = 0; i < ts2; i++) tpl = top12.Toplam2();
            s�re = DateTime.Now - ilk;
            Console.WriteLine ("Sadece (1881+57) toplam� = {0}", tpl);
            Console.WriteLine ("{0:#,0} kere tekrarlanan Toplam2() s�resi = {1} msn", ts2, s�re.TotalMilliseconds.ToString());

            Console.WriteLine ("\nNow/UtcNow fark� ve azami 60sn saya� s�f�rlama d�ng�s�:");
            Console.WriteLine ("{0} - {1} ({2})", tz1, tz1.Kind, TimeZone.CurrentTimeZone.StandardName);
            tz2 = DateTime.UtcNow;
            Console.WriteLine ("{0} - {1}", tz2, tz2.Kind);
            Console.WriteLine (DateTime.Now.ToString ("T")); 
            i = -1;
            while (DateTime.Now.Second != 0) {
                if (i != DateTime.Now.Second) {//Thread.Sleep(1000) yerine saniye saya� de�i�imiyle sunum kontrolu
                    i = DateTime.Now.Second;
                    Console.Write ("...{0}", 60-DateTime.Now.Second);
                }
            } Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}