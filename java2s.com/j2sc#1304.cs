// j2sc#1304.cs: Çeþitli kültür ve takvim özelliklerinin karþýlaþtýrýlmalarý örneði.

using System;
using System.Globalization; //CultureInfo, Calendar ve CalendarWeekRule için
namespace Tarih {
    class Takvim {
        static void Main() {
            Console.Write ("Çeþitli takvimlerdeki GetType, GetYear, GetMonthsInYear, GetDaysInYear, GetDaysInMonth, IsLeapDay, IsLeapMonth, IsLeapYear metotlarý kýyaslanmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Farklý kültürlerde haftanýn ilk günü:");
            int ts1, i, j; var r=new Random();
            CultureInfo kültür = new CultureInfo ("en-US");
            Calendar takvim1 = kültür.Calendar;
            CalendarWeekRule thk = kültür.DateTimeFormat.CalendarWeekRule;
            DayOfWeek hig = kültür.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tABD için haftalýk takvim kuralý: {0}.", thk);
            Console.WriteLine ("ABD için haftanýn ilk günü: {0}.", hig);
            Console.WriteLine ("Yýlýn kaçýncý haftasýndayýz? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            DateTime tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} yýlýnda {1}/{2} hafta vardýr.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));
            kültür = new CultureInfo ("tr-TR");
            takvim1 = kültür.Calendar;
            thk = kültür.DateTimeFormat.CalendarWeekRule;
            hig = kültür.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tTürkiye için haftalýk takvim kuralý: {0}.", thk);
            Console.WriteLine ("Türkiye için haftanýn ilk günü: {0}.", hig);
            Console.WriteLine ("Yýlýn kaçýncý haftasýndayýz? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} yýlýnda {1}/{2} hafta vardýr.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));
            kültür = new CultureInfo ("de-DE");
            takvim1 = kültür.Calendar;
            thk = kültür.DateTimeFormat.CalendarWeekRule;
            hig = kültür.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tAlmanya için haftalýk takvim kuralý: {0}.", thk);
            Console.WriteLine ("Türkiye için haftanýn ilk günü: {0}.", hig);
            Console.WriteLine ("Yýlýn kaçýncý haftasýndayýz? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} yýlýnda {1}/{2} hafta vardýr.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));

            Console.WriteLine ("\nÇeþitli takvimlerdeki aktüel_yýl, ay_sayýsý, 2.ay_artýkMý?, yýl_artýkMý?:");
            JulianCalendar takvim2 = new JulianCalendar();
            Console.WriteLine ("JulianCalendar[{0},{1},2:{2},{3}]", 2024, takvim2.GetMonthsInYear (2024, JulianCalendar.CurrentEra), takvim2.IsLeapMonth(2024,2,JulianCalendar.CurrentEra), takvim2.IsLeapYear(2024,JulianCalendar.CurrentEra));
            for(i=1;i<=9999;i++) {
                ts1 = takvim2.GetMonthsInYear (i, JulianCalendar.CurrentEra);
                for (j=1;j<=ts1;j++) if (takvim2.IsLeapMonth(i,j,JulianCalendar.CurrentEra)) Console.WriteLine ("[{0},{1},{2}] ", i, j, takvim2.IsLeapMonth (i, j, JulianCalendar.CurrentEra));
            }
            KoreanCalendar takvim3 = new KoreanCalendar();
            Console.WriteLine ("KoreanCalendar[{0},{1},2:{2},{3}]", 4358, takvim3.GetMonthsInYear (4358, KoreanCalendar.CurrentEra), takvim3.IsLeapMonth(4358,2,KoreanCalendar.CurrentEra), takvim3.IsLeapYear(4358,KoreanCalendar.CurrentEra));
            for(i=2334;i<=12332;i++) {
                ts1 = takvim3.GetMonthsInYear (i, KoreanCalendar.CurrentEra);
                for (j=1;j<=ts1;j++) if (takvim3.IsLeapMonth(i,j,KoreanCalendar.CurrentEra)) Console.WriteLine ("[{0},{1},{2}] ", i, j, takvim3.IsLeapMonth (i, j, KoreanCalendar.CurrentEra));
            }
            GregorianCalendar takvim4 = new GregorianCalendar();
            Console.WriteLine ("GregorianCalendar[{0},{1},2:{2},{3}]", 2024, takvim4.GetMonthsInYear (2024, GregorianCalendar.CurrentEra), takvim4.IsLeapMonth(2024,2,GregorianCalendar.CurrentEra), takvim4.IsLeapYear(2024,GregorianCalendar.CurrentEra));
            for(i=1;i<=9999;i++) {
                ts1 = takvim4.GetMonthsInYear (i, GregorianCalendar.CurrentEra);
                for (j=1;j<=ts1;j++) if (takvim4.IsLeapMonth(i,j,GregorianCalendar.CurrentEra)) Console.WriteLine ("[{0},{1},{2}] ", i, j, takvim4.IsLeapMonth (i, j, GregorianCalendar.CurrentEra));
            }
            ThaiBuddhistCalendar takvim5 = new ThaiBuddhistCalendar();
            Console.WriteLine ("ThaiBuddhistCalendar[{0},{1},2:{2},{3}]", 2568, takvim5.GetMonthsInYear (2568, ThaiBuddhistCalendar.CurrentEra), takvim5.IsLeapMonth(2568,2,ThaiBuddhistCalendar.CurrentEra), takvim5.IsLeapYear(2568,ThaiBuddhistCalendar.CurrentEra));
            for(i=544;i<=10542;i++) {
                ts1 = takvim5.GetMonthsInYear (i, ThaiBuddhistCalendar.CurrentEra);
                for (j=1;j<=ts1;j++) if (takvim5.IsLeapMonth(i,j,ThaiBuddhistCalendar.CurrentEra)) Console.WriteLine ("[{0},{1},{2}] ", i, j, takvim5.IsLeapMonth (i, j, ThaiBuddhistCalendar.CurrentEra));
            }

            Console.WriteLine ("\nÇeþitli kültürlerde dizgeden tarihe çevrimler:");
            Console.WriteLine ("\tJulian [1881,1938] arasýndaki artýk yýllar:");
            for(i=1881;i<=1938;i++) Console.Write ("{0}:{1} ", i, takvim2.IsLeapYear(i,JulianCalendar.CurrentEra)?"EVET":"Hayýr"); Console.WriteLine();
            Console.WriteLine ("\tDizge'den tarih'e çevrim:");
            string dizge = "3/9/2024 2:50:42 AM"; DateTime tarih;
            try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] çevrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            dizge = "3/9/2024 2:50:42 PM"; try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] çevrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            dizge = "3/9/2024 2:50:42 XM"; try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] çevrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            Console.WriteLine ("\tGregorian [1881,1938] arasýndaki þubat ayý gün sayýlarý:");
            for(i=1881;i<=1938;i++) Console.Write ("{0}/{1}/{2} ", i, 2, takvim4.GetDaysInMonth (i, 2, GregorianCalendar.CurrentEra)); Console.WriteLine();
            Console.WriteLine ("\tThaiBuddhist [1881=2425,1938=2482] arasýndaki yýllarýn gün sayýlarý:");
            for(i=2425;i<=2482;i++) Console.Write ("{0}:{1} ", i, takvim5.GetDaysInYear (i, ThaiBuddhistCalendar.CurrentEra)); Console.WriteLine();
            Console.WriteLine ("\tFarklý kültürlerin tarih çevrimleri:");
            kültür = new CultureInfo ("de-DE"); dizge= "9 Juni 2024 3:35:51"; tarih = DateTime.Parse (dizge, kültür); Console.WriteLine ("de-DE "+tarih);
            kültür = new CultureInfo ("en-GB"); dizge= "9 June 2024 3:35:51"; tarih = DateTime.Parse (dizge, kültür); Console.WriteLine ("en-EN "+tarih.ToString ("r"));
            kültür = new CultureInfo ("en-Us"); dizge= "9 June 2024 3:35:51"; tarih = DateTime.Parse (dizge, kültür); Console.WriteLine ("en-US "+tarih.ToString ("u"));
            kültür = new CultureInfo ("tr-TR"); dizge= "9 Haziran 2024 3:35:51"; tarih = DateTime.Parse (dizge, kültür); Console.WriteLine ("tr-TR "+tarih.ToString ("U"));

            Console.WriteLine ("\n8 farklý takvimin tüm özelliklerinin sunulmasý:");
            Calendar[] tkDizi = new Calendar[8]{new GregorianCalendar(), new HebrewCalendar(), new HijriCalendar(), new JapaneseCalendar(), new JulianCalendar(), new KoreanCalendar(), new TaiwanCalendar(), new ThaiBuddhistCalendar()};
            int yýl, ay, gün;
            tarih = DateTime.Now;
            for(i=0;i<tkDizi.Length;i++) {
                yýl = tkDizi [i].GetYear (tarih);
                Console.WriteLine ("{0}, Yýl: {1}", tkDizi [i].GetType(), tkDizi [i].GetYear (tarih));
                Console.WriteLine ("   YýldakiAySayýsý: {0}", tkDizi [i].GetMonthsInYear (yýl));
                Console.WriteLine ("   YýldakiGünSayýsý: {0}", tkDizi [i].GetDaysInYear (yýl));
                Console.Write ("   AylardakiGünSayýlarý: " );
                for(j=1;j<=tkDizi [i].GetMonthsInYear (yýl);j++) Console.Write ("{0} ", tkDizi [i].GetDaysInMonth (yýl, j)); Console.WriteLine();
                ay = tkDizi [i].GetMonth (tarih);
                gün = tkDizi [i].GetDayOfMonth (tarih);
                Console.WriteLine ("   ArtýkGünMü: {0}", tkDizi [i].IsLeapDay (yýl, ay, gün));
                Console.WriteLine ("   ArtýkAyMý:  {0}", tkDizi [i].IsLeapMonth (yýl, ay));
                Console.WriteLine ("   ArtýkYýlMý: {0}", tkDizi [i].IsLeapYear (yýl));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}