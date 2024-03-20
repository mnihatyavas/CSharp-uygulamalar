// j2sc#1303.cs: DateTime.Parse(dizge) �evrimi ve TimeSpan(g,S,d,s,ms) zamanaral��� �rne�i.

using System;
using System.Threading; //Thread.Sleep i�in
using System.Diagnostics; //Stopwatch i�in
namespace Tarih {
    class Tarih�evrimi {
        static void Main() {
            Console.Write ("ParseExact �al��t�r�lamad�. TimeSpan tiktak s�resini 'g.SS:dd:ss.msstikt'a �evirir; ilk g�n �ok haneli, son 3 hane ms ve sonraki 4 hane tiktak i�indir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Parse/Exact ile �e�itli dizgeleri tarihe �evirme:");
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

            Console.WriteLine ("\nFarkl� arg�manl� ZamanAral���, -+ ve Subtract/Add sonu�lar�:");
            TimeSpan za1 = new TimeSpan (2, 12, 0, 0); Console.WriteLine ("2.5 g�n = "+za1);
            TimeSpan za2 = new TimeSpan (4, 12, 0, 0); Console.WriteLine ("4.5 g�n = "+za2);
            Console.WriteLine ("7 g�n = "+(za1+za2));
            tz1 = DateTime.Now; Console.WriteLine ("{0:hh:mm:ss tt}", tz1);
            Thread.Sleep (1000);
            var tz2 = DateTime.Now; Console.WriteLine ("{0:hh:mm:ss tt}", tz2);
            Console.WriteLine ("Beklenen zaman: {0}", (tz2-tz1));
            Console.WriteLine ("�imdi: {0}", tz2);
            Console.WriteLine ("-ile 1 hafta �nce: {0}", (tz2-(za1+za2)));
            Console.WriteLine ("+ile 1 hafta sonra: {0}", (tz2+(za1+za2)));
            Console.WriteLine ("Subtract ile 1 hafta �nce: {0}", tz2.Subtract (za1+za2));
            Console.WriteLine ("Add ile 1 hafta sonra: {0}", tz2.Add (za1+za2));
            Console.WriteLine ("1 arg�manl� zaman aral���: " + new TimeSpan (9876)); //ms son 4/7 hane
            Console.WriteLine ("3 arg�manl� zaman aral���: " + new TimeSpan (3, 4, 5)); //hh, mm, ss
            Console.WriteLine ("4 arg�manl� zaman aral���: " + new TimeSpan (2, 3, 4, 5)); //dd, hh, mm, ss
            Console.WriteLine ("5 arg�manl� zaman aral���: " + new TimeSpan (2, 3, 4, 5, 571)); //dd, hh, mm, ss, msn
            Console.WriteLine ("5 arg�manl� zaman aral���: " + new TimeSpan (2, 3, 4, 5, 5719876)); //dd, hh, mm, ss, msn
            Console.WriteLine ("5 arg�manl� zaman aral���: " + (new TimeSpan (2, 3, 4, 5, 571) + new TimeSpan (9876))); //dd, hh, mm, ss, msn

            Console.WriteLine ("\nZamanAral���'n�n, g�n, saat, dakika, saniye, ms ve tiktak verileri:");
            long tiktak = long.MaxValue; Console.WriteLine ("Azami long say� = {0:#,#}", tiktak);
            za1 = new TimeSpan (tiktak);
            Console.WriteLine ("\tTam zamanlar:");
            Console.WriteLine ("za1.Days = {0:#,#}", za1.Days);
            Console.WriteLine ("za1.Hours = {0:#,#}", za1.Hours);
            Console.WriteLine ("za1.Minutes = {0:#,#}", za1.Minutes);
            Console.WriteLine ("za1.Seconds = {0:#,#}", za1.Seconds);
            Console.WriteLine ("za1.Milliseconds = {0:#,#}", za1.Milliseconds);
            Console.WriteLine ("za1.Ticks = {0:#,#}", za1.Ticks);
            Console.WriteLine ("\tK�s�ratl� zamanlar:");
            Console.WriteLine ("za1.TotalDays = {0:#,#.#######}", za1.TotalDays);
            Console.WriteLine ("za1.TotalHours = {0:#,#.######}", za1.TotalHours);
            Console.WriteLine ("za1.TotalMinutes = {0:#,#.####}", za1.TotalMinutes);
            Console.WriteLine ("za1.TotalSeconds = {0:#,#.###}", za1.TotalSeconds);
            Console.WriteLine ("za1.TotalMilliseconds = {0:#,#.#}", za1.TotalMilliseconds);
            Console.WriteLine ("za1.Ticks % za1.TotalMilliseconds = {0:#,#}", (za1.Ticks % za1.TotalMilliseconds -1));
            Console.WriteLine ("\tD�ng�l� toplama i�leminin zaman aral���:");
            tz1 = DateTime.Now;
            tiktak = 0;
            for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            za1 = DateTime.Now - tz1;
            Console.WriteLine ("[0-->{0:#,#}] toplam�= {1:#,#}", int.MaxValue, tiktak);
            Console.WriteLine ("Toplama i�leminin s�resi = {0}sn:{1}ms", za1.Seconds, za1.Milliseconds);
            Console.WriteLine ("\tTimeSapan.From... [g.SS:dd:ss.msstikt] zaman aral�klar�:");
            double ds1; var r=new Random();
            ds1=r.Next(1,365)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromDays ({0}) = {1}", ds1, TimeSpan.FromDays (ds1));
            ds1=r.Next(1,24)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromHours ({0}) = {1}", ds1, TimeSpan.FromHours (ds1));
            ds1=r.Next(1,60)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromMinutes ({0}) = {1}", ds1, TimeSpan.FromMinutes (ds1));
            ds1=r.Next(1,60)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromSeconds ({0}) = {1}", ds1, TimeSpan.FromSeconds (ds1));
            ds1=r.Next(1,999)+r.Next(100000,1000000)/1000000D; Console.WriteLine ("TimeSpan.FromMilliseconds ({0}) = {1}", ds1, TimeSpan.FromMilliseconds (ds1));
            tiktak = long.MaxValue; Console.WriteLine ("TimeSpan.FromTicks ({0}) = {1}", tiktak, TimeSpan.FromTicks (tiktak));
            Console.WriteLine ("\t2 ZamanAral���'n� toplama, ��karma, s�releme, negatifleme:");
            ds1=r.Next(0,24)+r.Next(100000,1000000)/1000000D; za1=TimeSpan.FromHours (ds1);
            ds1=r.Next(0,24)+r.Next(100000,1000000)/1000000D; za2=TimeSpan.FromHours (ds1);
            Console.WriteLine ("za1[{0}].Add (za2[{1}]) = {2}", za1, za2, za1.Add (za2));
            Console.WriteLine ("za1.Subtract (za2) = {0}", za1.Subtract (za2));
            Console.WriteLine ("(za1.Subtract (za2)).Duration() = {0}", (za1.Subtract (za2)).Duration());
            Console.WriteLine ("(za1.Subtract (za2)).Negate() = {0}", (za1.Subtract (za2)).Negate());

            Console.WriteLine ("\nZamanAral���'n�n dizgesel veriden �evrimi:");
            za1 = TimeSpan.Parse ("23:59:59"); Console.WriteLine ("TimeSpan.Parse (\"23:59:59\") = " + za1);
            za1 = TimeSpan.Parse ("365.23:59:59.9870123"); Console.WriteLine ("TimeSpan.Parse (\"365.23:59:59.9870123\") = " + za1);

            Console.WriteLine ("\nD�ng�l� toplama i�leminin kronometre/Stopwatch'la s�re �l��mleri:");
            tiktak = 0;
            Stopwatch kronometre = new Stopwatch();
            kronometre.Start();
            for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop();
            Console.WriteLine ("Toplama i�leminin kronometre s�resi-1 = {0}ms", kronometre.ElapsedMilliseconds);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama i�leminin kronometre s�resi-2 = {0}ms", kronometre.ElapsedMilliseconds);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama i�leminin kronometre s�resi-3 = {0}sn:{1}ms", (int)kronometre.ElapsedMilliseconds/1000, kronometre.ElapsedMilliseconds%1000);
            tiktak = 0; kronometre.Reset(); kronometre.Start(); for(int i=0;i<int.MaxValue;i++) tiktak+=i;
            kronometre.Stop(); Console.WriteLine ("Toplama i�leminin kronometre s�resi-4 = {0}sn:{1}ms", (int)kronometre.ElapsedMilliseconds/1000, kronometre.ElapsedMilliseconds%1000);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}