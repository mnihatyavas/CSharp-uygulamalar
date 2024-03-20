// j2sc#1303.cs: DateTime.Parse(dizge) çevrimi ve TimeSpan(g,S,d,s,ms) zamanaralýðý örneði.

using System;
using System.Threading; //Thread.Sleep için
using System.Diagnostics; //Stopwatch için
namespace Tarih {
    class TarihÇevrimi {
        static void Main() {
            Console.Write ("ParseExact çalýþtýrýlamadý. TimeSpan tiktak süresini 'g.SS:dd:ss.msstikt'a çevirir; ilk gün çok haneli, son 3 hane ms ve sonraki 4 hane tiktak içindir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Parse/Exact ile çeþitli dizgeleri tarihe çevirme:");
            DateTime tz1 = DateTime.Parse ("Mar 2024"); Console.WriteLine (tz1);
            tz1 = DateTime.Parse ("Saturday 2 March 2024 3:21:38"); Console.WriteLine (tz1);
            tz1 = DateTime.Parse ("2,3,24"); Console.WriteLine (tz1);
            tz1 = DateTime.Parse ("2/3/2024 19:44:32"); Console.WriteLine (tz1);
            tz1 = DateTime.Parse ("7:46 PM"); Console.WriteLine (tz1);
            try {tz1 = DateTime.ParseExact ("7:48:30 PM", "h:mm:ss tt", null); Console.WriteLine (tz1);}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {tz1 = DateTime.ParseExact ("Sat, 02 Mar 2024 20:00:37 GMT", "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'", null); Console.WriteLine (tz1);}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            try {tz1 = DateTime.ParseExact ("March 02", "MMMM dd", null); Console.WriteLine (tz1);}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            tz1 = DateTime.Parse ("2/3/2024"); Console.WriteLine (tz1);
            tz1 = DateTime.Parse ("2/3/2024 20:07:56"); Console.WriteLine (tz1);
            string[] tzDizi = {"2024-03-02T20:12:42-18:00", "1955-08-07 9:34:42Z", "Thu, 29 Feb 2024 19:54:42 GMT"};
            foreach (string tz in tzDizi) {
                tz1 = DateTime.Parse (tz);
                Console.WriteLine ("\t"+tz1.Kind.ToString());
                Console.WriteLine (tz1);
            }
            string tarih = "2/3/2024 20:23:15";
            try {tz1 = DateTime.Parse (tarih); Console.WriteLine ("\t'{0}'-->{1}.", tarih, tz1);}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}  

            Console.WriteLine ("\nFarklý argümanlý ZamanAralýðý, -+ ve Subtract/Add sonuçlarý:");
            TimeSpan za1 = new TimeSpan (2, 12, 0, 0); Console.WriteLine ("2.5 gün = "+za1);
            TimeSpan za2 = new TimeSpan (4, 12, 0, 0); Console.WriteLine ("4.5 gün = "+za2);
            Console.WriteLine ("7 gün = "+(za1+za2));
            tz1 = DateTime.Now; Console.WriteLine ("{0:hh:mm:ss tt}", tz1);
            Thread.Sleep (1000);
            var tz2 = DateTime.Now; Console.WriteLine ("{0:hh:mm:ss tt}", tz2);
            Console.WriteLine ("Beklenen zaman: {0}", (tz2-tz1));
            Console.WriteLine ("Þimdi: {0}", tz2);
            Console.WriteLine ("-ile 1 hafta önce: {0}", (tz2-(za1+za2)));
            Console.WriteLine ("+ile 1 hafta sonra: {0}", (tz2+(za1+za2)));
            Console.WriteLine ("Subtract ile 1 hafta önce: {0}", tz2.Subtract (za1+za2));
            Console.WriteLine ("Add ile 1 hafta sonra: {0}", tz2.Add (za1+za2));
            Console.WriteLine ("1 argümanlý zaman aralýðý: " + new TimeSpan (9876)); //ms son 4/7 hane
            Console.WriteLine ("3 argümanlý zaman aralýðý: " + new TimeSpan (3, 4, 5)); //hh, mm, ss
            Console.WriteLine ("4 argümanlý zaman aralýðý: " + new TimeSpan (2, 3, 4, 5)); //dd, hh, mm, ss
            Console.WriteLine ("5 argümanlý zaman aralýðý: " + new TimeSpan (2, 3, 4, 5, 571)); //dd, hh, mm, ss, msn
            Console.WriteLine ("5 argümanlý zaman aralýðý: " + new TimeSpan (2, 3, 4, 5, 5719876)); //dd, hh, mm, ss, msn
            Console.WriteLine ("5 argümanlý zaman aralýðý: " + (new TimeSpan (2, 3, 4, 5, 571) + new TimeSpan (9876))); //dd, hh, mm, ss, msn

            Console.WriteLine ("\nZamanAralýðý'nýn, gün, saat, dakika, saniye, ms ve tiktak verileri:");
            long tiktak = long.MaxValue; Console.WriteLine ("Azami long sayý = {0:#,#}", tiktak);
            za1 = new TimeSpan (tiktak);
            Console.WriteLine ("\tTam zamanlar:");
            Console.WriteLine ("za1.Days = {0:#,#}", za1.Days);
            Console.WriteLine ("za1.Hours = {0:#,#}", za1.Hours);
            Console.WriteLine ("za1.Minutes = {0:#,#}", za1.Minutes);
            Console.WriteLine ("za1.Seconds = {0:#,#}", za1.Seconds);
            Console.WriteLine ("za1.Milliseconds = {0:#,#}", za1.Milliseconds);
            Console.WriteLine ("za1.Ticks = {0:#,#}", za1.Ticks);
            Console.WriteLine ("\tKüsüratlý zamanlar:");
            Console.WriteLine ("za1.TotalDays = {0:#,#.#######}", za1.TotalDays);
            Console.WriteLine ("za1.TotalHours = {0:#,#.######}", za1.TotalHours);
            Console.WriteLine ("za1.TotalMinutes = {0:#,#.####}", za1.TotalMinutes);
            Console.WriteLine ("za1.TotalSeconds = {0:#,#.###}", za1.TotalSeconds);
            Console.WriteLine ("za1.TotalMilliseconds = {0:#,#.#}", za1.TotalMilliseconds);
            Console.WriteLine ("za1.Ticks % za1.TotalMilliseconds = {0:#,#}", (za1.Ticks % za1.TotalMilliseconds -1));
            Console.WriteLine ("\tDöngülü toplama iþleminin zaman aralýðý:");
            tz1 = DateTime.Now;
            tiktak = 0;
            for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            za1 = DateTime.Now - tz1;
            Console.WriteLine ("[0-->{0:#,#}] toplamý= {1:#,#}", int.MaxValue, tiktak);
            Console.WriteLine ("Toplama iþleminin süresi = {0}sn:{1}ms", za1.Seconds, za1.Milliseconds);
            Console.WriteLine ("\tTimeSapan.From... [g.SS:dd:ss.msstikt] zaman aralýklarý:");
            double ds1; var r=new Random();
            ds1=r.Next(1,365)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromDays ({0}) = {1}", ds1, TimeSpan.FromDays (ds1));
            ds1=r.Next(1,24)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromHours ({0}) = {1}", ds1, TimeSpan.FromHours (ds1));
            ds1=r.Next(1,60)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromMinutes ({0}) = {1}", ds1, TimeSpan.FromMinutes (ds1));
            ds1=r.Next(1,60)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromSeconds ({0}) = {1}", ds1, TimeSpan.FromSeconds (ds1));
            ds1=r.Next(1,999)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromMilliseconds ({0}) = {1}", ds1, TimeSpan.FromMilliseconds (ds1));
            tiktak = long.MaxValue; Console.WriteLine ("TimeSpan.FromTicks ({0}) = {1}", tiktak, TimeSpan.FromTicks (tiktak));
            Console.WriteLine ("\t2 ZamanAralýðý'ný toplama, çýkarma, süreleme, negatifleme:");
            ds1=r.Next(0,24)+r.Next(100000,1000000)/1000000D; za1=TimeSpan.FromHours (ds1);
            ds1=r.Next(0,24)+r.Next(100000,1000000)/1000000D; za2=TimeSpan.FromHours (ds1);
            Console.WriteLine ("za1[{0}].Add (za2[{1}]) = {2}", za1, za2, za1.Add (za2));
            Console.WriteLine ("za1.Subtract (za2) = {0}", za1.Subtract (za2));
            Console.WriteLine ("(za1.Subtract (za2)).Duration() = {0}", (za1.Subtract (za2)).Duration());
            Console.WriteLine ("(za1.Subtract (za2)).Negate() = {0}", (za1.Subtract (za2)).Negate());

            Console.WriteLine ("\nZamanAralýðý'nýn dizgesel veriden çevrimi:");
            za1 = TimeSpan.Parse ("23:59:59"); Console.WriteLine ("TimeSpan.Parse (\"23:59:59\") = " + za1);
            za1 = TimeSpan.Parse ("365.23:59:59.9870123"); Console.WriteLine ("TimeSpan.Parse (\"365.23:59:59.9870123\") = " + za1);

            Console.WriteLine ("\nDöngülü toplama iþleminin kronometre/Stopwatch'la süre ölçümleri:");
            tiktak = 0;
            Stopwatch kronometre = new Stopwatch();
            kronometre.Start();
            for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop();
            Console.WriteLine ("Toplama iþleminin kronometre süresi-1 = {0}ms", kronometre.ElapsedMilliseconds);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama iþleminin kronometre süresi-2 = {0}ms", kronometre.ElapsedMilliseconds);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama iþleminin kronometre süresi-3 = {0}sn:{1}ms", (int)kronometre.ElapsedMilliseconds/1000, kronometre.ElapsedMilliseconds%1000);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama iþleminin kronometre süresi-4 = {0}sn:{1}ms", (int)kronometre.ElapsedMilliseconds/1000, kronometre.ElapsedMilliseconds%1000);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}