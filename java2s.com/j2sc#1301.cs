// j2sc#1301.cs: DateTime ve detaylarýyla çeþitli TarihZaman hesaplarý örneði.

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
        public static void TarihZamanýGöster (string þimdi, DateTime tz) {
            Console.WriteLine ("\t"+þimdi + " = " + tz);
            Console.WriteLine (þimdi + ".Year = " + tz.Year);
            Console.WriteLine (þimdi + ".Month = " + tz.Month);
            Console.WriteLine (þimdi + ".Day = " + tz.Day);
            Console.WriteLine (þimdi + ".Hour = " + tz.Hour);
            Console.WriteLine (þimdi + ".Minute = " + tz.Minute);
            Console.WriteLine (þimdi + ".Second = " + tz.Second);
            Console.WriteLine (þimdi + ".Millisecond = " + tz.Millisecond);
            Console.WriteLine (þimdi + ".Ticks = " + tz.Ticks);
        }
        static void Main() {
            Console.Write ("DateTime(yyyy,aa,gg,SS,dd,ss,mmm) giriþi kabul eder, çýktýda mmm/milisaniye hariç diðerlerini (girilmemiþse 00) gösterir. DateTime.Now bilgisarda mevcut anýn zamanýný sunar. TimeSpan(gg,SS,dd,ss) sýfýrdan verili deðere olan zaman aralýðýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'new DateTime()' ve 'DateTime.Now' ile TarihZaman:");
            DateTime tz1 = new DateTime (2024, 02, 28); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = new DateTime (2024, 2, 28, 2, 43, 55); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = new DateTime (2024, 2, 28, 2, 43, 55, 982); Console.WriteLine ("tz1: [{0}]", tz1);
            tz1 = DateTime.Now; Console.WriteLine ("Þimdi: [{0}]", tz1);

            Console.WriteLine ("\nTimeSapan ile zaman aralýðý sürelerini alma:");
            TimeSpan birHafta = new TimeSpan (3, 12, 0, 0) + new TimeSpan (2, 10, 0, 0) + new TimeSpan (1, 2, 0, 0); //(3gün+12saat) + (2gün+10saat) + (1gün+2saat) = 6gün+24saat=7gün
            DateTime geçenHafta = tz1 - birHafta; Console.WriteLine ("1 hafta öncesi: [{0}]", geçenHafta);
            DateTime gelecekHafta = tz1 + birHafta; Console.WriteLine ("1 hafta sonrasý: [{0}]", gelecekHafta);
            DateTime geçen2Hafta = tz1 - new TimeSpan (14,0,0,0); Console.WriteLine ("2 hafta öncesi: [{0}]", geçen2Hafta);
            DateTime gelecek3Hafta = tz1 + new TimeSpan (21,0,0,0); Console.WriteLine ("3 hafta sonrasý: [{0}]", gelecek3Hafta);

            Console.WriteLine ("\nAddSeconds()'la tek mikrosn ve sadece sn deðiþimlerini yansýtma:");
            DateTime son = DateTime.Now.AddSeconds (0.0005);
            while (DateTime.Now < son) Console.Write (DateTime.Now.TimeOfDay.ToString()+" "); Console.WriteLine();
            son = DateTime.Now.AddSeconds (5);
            while (DateTime.Now < son) {Console.WriteLine ("\t"+DateTime.Now.TimeOfDay.ToString()); Thread.Sleep (1000);}

            Console.WriteLine ("\nDateTime.Now'ýn detay (yýl,ay,gün,saat,dakika,sn,msn) ve 1970'den ms:");
            TarihZamanýGöster ("tz1", tz1);
            System.Globalization.JulianCalendar jülyenTakvim = new System.Globalization.JulianCalendar();
            tz1 = new DateTime (tz1.Year, tz1.Month, tz1.Day, tz1.Hour, tz1.Minute, tz1.Second, tz1.Millisecond, jülyenTakvim);
            TarihZamanýGöster ("tz1", tz1);
            DateTime tz2 = new DateTime (0);
            TarihZamanýGöster ("tz2", tz2);

            Console.WriteLine ("\nNow/UtcNow, gün çeþitleri, zaman kýyaslarý:");
            Console.WriteLine ("DateTime.Now = " + (tz1=DateTime.Now));
            Console.WriteLine ("DateTime.UtcNow = " + DateTime.UtcNow);
            Console.WriteLine ("þimdi.Date = " + tz1.Date);
            Console.WriteLine ("þimdi.Day = " + tz1.Day);
            Console.WriteLine ("þimdi.DayOfWeek = " + tz1.DayOfWeek);
            Console.WriteLine ("þimdi.DayOfYear = " + tz1.DayOfYear);
            Console.WriteLine ("þimdi.TimeOfDay = " + tz1.TimeOfDay);
            Console.WriteLine ("DateTime.Compare (tz1, tz2) = " + DateTime.Compare (tz1, tz2));
            Console.WriteLine ("tz1 < tz2? " + (tz1<tz2?"Evet":"Hayýr"));
            Console.WriteLine ("tz1.Equals (tz2)? " + (tz1.Equals (tz2)?"Evet":"Hayýr"));
            Console.WriteLine ("tz1 == tz1? " + (tz1==tz1?"Evet":"Hayýr"));

            Console.WriteLine ("\nYýl ay günleri, tarih çözümleme, Ticks ve ToFileTime() çevrimleri:");
            var r=new Random(); int i, ts1=r.Next(1923,2025), ts2; long ls1, ls2;
            Console.Write ("{0} yýlýndaki her ayýn gün sayýsý: ", ts1);
            for(i=1;i<=12;i++) Console.Write (DateTime.DaysInMonth (ts1, i) + " "); Console.WriteLine();
            Console.WriteLine ("{0} artýk yýl mý? {1}", ts1, (DateTime.IsLeapYear (ts1)?"Evet":"Hayýr"));
            tz2 = DateTime.Parse ("28/2/2024 21:22:58");
            Console.WriteLine ("Çözümlenen tz2 = " + tz2);
            Console.WriteLine ("tz2 + birHafta = {1}", tz2, (tz2 + birHafta));
            Console.WriteLine ("tz2 - birHafta = " + (tz2 - birHafta));
            Console.WriteLine ("tz2 + (1y, 5a, 3g, 2S, 45d, 5s) = " + tz2.AddYears(1).AddMonths(5).AddDays(3).AddHours(2).AddMinutes(45).AddSeconds(5));
            Console.WriteLine ("þimdi.Ticks = " + (ls1=tz1.Ticks));
            Console.WriteLine ("þimdi.ToFileTime() = " + (ls2=tz1.ToFileTime()));
            Console.WriteLine ("new DateTime (ls1) = " + new DateTime (ls1));
            Console.WriteLine ("DateTime.FromFileTime (ls2) = " + DateTime.FromFileTime (ls2));

            Console.WriteLine ("\nÝki ayrý döngüsel hesaplamanýn uzun ve kýsa sürelerinin kýyasý:");
            ts1 = r.Next(20, 2024);  
            ts2 = r.Next(1000000,10000000);
            int tpl=0;
            Toplamlar top12 = new Toplamlar();
            DateTime ilk = DateTime.Now;
            for (i = 0; i < ts2; i++) tpl = top12.Toplam1 (ts1);
            TimeSpan süre = (DateTime.Now - ilk);
            Console.WriteLine ("[1-->{0:#,0}] toplamý = {1:#,0}", ts1, tpl);
            Console.WriteLine ("{0:#,0} kere tekrarlanan Toplam1() süresi = {0:#,0} msn", ts2, süre.TotalMilliseconds.ToString());
            ilk = DateTime.Now;
            for (i = 0; i < ts2; i++) tpl = top12.Toplam2();
            süre = DateTime.Now - ilk;
            Console.WriteLine ("Sadece (1881+57) toplamý = {0}", tpl);
            Console.WriteLine ("{0:#,0} kere tekrarlanan Toplam2() süresi = {1} msn", ts2, süre.TotalMilliseconds.ToString());

            Console.WriteLine ("\nNow/UtcNow farký ve azami 60sn sayaç sýfýrlama döngüsü:");
            Console.WriteLine ("{0} - {1} ({2})", tz1, tz1.Kind, TimeZone.CurrentTimeZone.StandardName);
            tz2 = DateTime.UtcNow;
            Console.WriteLine ("{0} - {1}", tz2, tz2.Kind);
            Console.WriteLine (DateTime.Now.ToString ("T")); 
            i = -1;
            while (DateTime.Now.Second != 0) {
                if (i != DateTime.Now.Second) {//Thread.Sleep(1000) yerine saniye sayaç deðiþimiyle sunum kontrolu
                    i = DateTime.Now.Second;
                    Console.Write ("...{0}", 60-DateTime.Now.Second);
                }
            } Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}