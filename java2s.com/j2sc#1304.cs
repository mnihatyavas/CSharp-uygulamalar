// j2sc#1304.cs: �e�itli k�lt�r ve takvim �zelliklerinin kar��la�t�r�lmalar� �rne�i.

using System;
using System.Globalization; //CultureInfo, Calendar ve CalendarWeekRule i�in
namespace Tarih {
    class Takvim {
        static void Main() {
            Console.Write ("�e�itli takvimlerdeki GetType, GetYear, GetMonthsInYear, GetDaysInYear, GetDaysInMonth, IsLeapDay, IsLeapMonth, IsLeapYear metotlar� k�yaslanmaktad�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Farkl� k�lt�rlerde haftan�n ilk g�n�:");
            int ts1, i, j; var r=new Random();
            CultureInfo k�lt�r = new CultureInfo ("en-US");
            Calendar takvim1 = k�lt�r.Calendar;
            CalendarWeekRule thk = k�lt�r.DateTimeFormat.CalendarWeekRule;
            DayOfWeek hig = k�lt�r.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tABD i�in haftal�k takvim kural�: {0}.", thk);
            Console.WriteLine ("ABD i�in haftan�n ilk g�n�: {0}.", hig);
            Console.WriteLine ("Y�l�n ka��nc� haftas�nday�z? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            DateTime tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} y�l�nda {1}/{2} hafta vard�r.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));
            k�lt�r = new CultureInfo ("tr-TR");
            takvim1 = k�lt�r.Calendar;
            thk = k�lt�r.DateTimeFormat.CalendarWeekRule;
            hig = k�lt�r.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tT�rkiye i�in haftal�k takvim kural�: {0}.", thk);
            Console.WriteLine ("T�rkiye i�in haftan�n ilk g�n�: {0}.", hig);
            Console.WriteLine ("Y�l�n ka��nc� haftas�nday�z? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} y�l�nda {1}/{2} hafta vard�r.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));
            k�lt�r = new CultureInfo ("de-DE");
            takvim1 = k�lt�r.Calendar;
            thk = k�lt�r.DateTimeFormat.CalendarWeekRule;
            hig = k�lt�r.DateTimeFormat.FirstDayOfWeek;
            Console.WriteLine ("\tAlmanya i�in haftal�k takvim kural�: {0}.", thk);
            Console.WriteLine ("T�rkiye i�in haftan�n ilk g�n�: {0}.", hig);
            Console.WriteLine ("Y�l�n ka��nc� haftas�nday�z? {0}", takvim1.GetWeekOfYear (DateTime.Now, thk, hig));
            ts1=r.Next(2000,2050);
            tz1 = new DateTime (ts1, 12, 31);
            Console.WriteLine ("{0} y�l�nda {1}/{2} hafta vard�r.", tz1.Year, (DateTime.IsLeapYear(ts1)?366:365)/7D, takvim1.GetWeekOfYear (tz1, thk, hig));

            Console.WriteLine ("\n�e�itli takvimlerdeki akt�el_y�l, ay_say�s�, 2.ay_art�kM�?, y�l_art�kM�?:");
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

            Console.WriteLine ("\n�e�itli k�lt�rlerde dizgeden tarihe �evrimler:");
            Console.WriteLine ("\tJulian [1881,1938] aras�ndaki art�k y�llar:");
            for(i=1881;i<=1938;i++) Console.Write ("{0}:{1} ", i, takvim2.IsLeapYear(i,JulianCalendar.CurrentEra)?"EVET":"Hay�r"); Console.WriteLine();
            Console.WriteLine ("\tDizge'den tarih'e �evrim:");
            string dizge = "3/9/2024 2:50:42 AM"; DateTime tarih;
            try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] �evrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            dizge = "3/9/2024 2:50:42 PM"; try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] �evrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            dizge = "3/9/2024 2:50:42 XM"; try {tarih = DateTime.Parse (dizge); Console.WriteLine ("Dizge[{0}] tarih'e[{1}] �evrildi.", dizge, tarih);}catch (Exception ht) {Console.WriteLine ("HATA({0}): [{1}]", dizge, ht.Message);}
            Console.WriteLine ("\tGregorian [1881,1938] aras�ndaki �ubat ay� g�n say�lar�:");
            for(i=1881;i<=1938;i++) Console.Write ("{0}/{1}/{2} ", i, 2, takvim4.GetDaysInMonth (i, 2, GregorianCalendar.CurrentEra)); Console.WriteLine();
            Console.WriteLine ("\tThaiBuddhist [1881=2425,1938=2482] aras�ndaki y�llar�n g�n say�lar�:");
            for(i=2425;i<=2482;i++) Console.Write ("{0}:{1} ", i, takvim5.GetDaysInYear (i, ThaiBuddhistCalendar.CurrentEra)); Console.WriteLine();
            Console.WriteLine ("\tFarkl� k�lt�rlerin tarih �evrimleri:");
            k�lt�r = new CultureInfo ("de-DE"); dizge= "9 Juni 2024 3:35:51"; tarih = DateTime.Parse (dizge, k�lt�r); Console.WriteLine ("de-DE "+tarih);
            k�lt�r = new CultureInfo ("en-GB"); dizge= "9 June 2024 3:35:51"; tarih = DateTime.Parse (dizge, k�lt�r); Console.WriteLine ("en-EN "+tarih.ToString ("r"));
            k�lt�r = new CultureInfo ("en-Us"); dizge= "9 June 2024 3:35:51"; tarih = DateTime.Parse (dizge, k�lt�r); Console.WriteLine ("en-US "+tarih.ToString ("u"));
            k�lt�r = new CultureInfo ("tr-TR"); dizge= "9 Haziran 2024 3:35:51"; tarih = DateTime.Parse (dizge, k�lt�r); Console.WriteLine ("tr-TR "+tarih.ToString ("U"));

            Console.WriteLine ("\n8 farkl� takvimin t�m �zelliklerinin sunulmas�:");
            Calendar[] tkDizi = new Calendar[8]{new GregorianCalendar(), new HebrewCalendar(), new HijriCalendar(), new JapaneseCalendar(), new JulianCalendar(), new KoreanCalendar(), new TaiwanCalendar(), new ThaiBuddhistCalendar()};
            int y�l, ay, g�n;
            tarih = DateTime.Now;
            for(i=0;i<tkDizi.Length;i++) {
                y�l = tkDizi [i].GetYear (tarih);
                Console.WriteLine ("{0}, Y�l: {1}", tkDizi [i].GetType(), tkDizi [i].GetYear (tarih));
                Console.WriteLine ("   Y�ldakiAySay�s�: {0}", tkDizi [i].GetMonthsInYear (y�l));
                Console.WriteLine ("   Y�ldakiG�nSay�s�: {0}", tkDizi [i].GetDaysInYear (y�l));
                Console.Write ("   AylardakiG�nSay�lar�: " );
                for(j=1;j<=tkDizi [i].GetMonthsInYear (y�l);j++) Console.Write ("{0} ", tkDizi [i].GetDaysInMonth (y�l, j)); Console.WriteLine();
                ay = tkDizi [i].GetMonth (tarih);
                g�n = tkDizi [i].GetDayOfMonth (tarih);
                Console.WriteLine ("   Art�kG�nM�: {0}", tkDizi [i].IsLeapDay (y�l, ay, g�n));
                Console.WriteLine ("   Art�kAyM�:  {0}", tkDizi [i].IsLeapMonth (y�l, ay));
                Console.WriteLine ("   Art�kY�lM�: {0}", tkDizi [i].IsLeapYear (y�l));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}