// j2sc#2101c.cs: �oklu k�lt�rlerle g�n, ay tarih, para ve say� bi�imleme �rne�i.

using System;
using System.Globalization;
using System.IO; //TextWriter i�in
using System.Threading;
namespace K�lt�rler {
    class FormatB {
        static void Main() {
            Console.Write ("'CultureInfo ci=new CultureInfo(\"xy-XY\")' ve 'de�er.ToString(\"F\", ci.NumberFormat)' ile istenilen k�lt�r�n format�yla ��kt� al�n�r. 'Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"xy-XY\")' ile t�m i�lemler tan�ml� k�lt�rden bi�imlenir. 'double.Parse(dzg, CultureInfo.InvariantCulture)' ile duble ��z�mleme varsay�l� k�lt�rle yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string[] k�lt�rler = new string[] {"en-US", "en-GB", "es-MX", "de-DE", "fr-FR", "ja-JP", "ar-SA", "ru-RU", "tr-TR"};
            Console.WriteLine ("{0} k�lt�rde haftan�n g�n  ve y�l�n ay adlar�, k�sa/uzun-tarih, say� ve para sunumu:", k�lt�rler.Length);
            CultureInfo ci=null; DateTime tarih=DateTime.Now; var r=new Random(); double ds;
            using (TextWriter tw = Console.Out) {
                foreach (string k in k�lt�rler) {
                    ci = new CultureInfo (k);
                    tw.Write ("-->{0} G�nler: ", ci.EnglishName);
                    foreach (string g�n in ci.DateTimeFormat.DayNames) tw.Write ("{0} ", g�n);
                    tw.WriteLine();
                    tw.Write ("Aylar: ");
                    foreach (string ay in ci.DateTimeFormat.MonthNames) tw.Write ("{0} ", ay);
                    tw.WriteLine();
                    tw.WriteLine ("K�sa tarih: {0}\tUzun tarih: {1}", tarih.ToString (ci.DateTimeFormat.ShortDatePattern, ci.DateTimeFormat), tarih.ToString (ci.DateTimeFormat.LongDatePattern, ci.DateTimeFormat));
                    ds=r.Next(-20241110,20241110)+r.Next(0,0228)/1000D;
                    tw.WriteLine ("Say�: {0}\tPara: {1}", ds.ToString (ci), ds.ToString ("C", ci.NumberFormat));
                }
            }

            Console.WriteLine ("\nNumberFormatInfo.PositiveSign/NegativeSign ile istenilen sembol +- yerine kullan�labilir:");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.PositiveSign = "art� ";
            nfi.NegativeSign = "eksi ";
            int i, j, t, ts;
            for(i=0;i<10;i++) {
                ts=r.Next(0,int.MaxValue);
                try {Console.WriteLine ("Int32 art�: {0}\teksi: {1}", Convert.ToInt32 ("art� "+ts, nfi), Convert.ToInt32 ("eksi "+ts, nfi)); //��aretli Int32 pozitif ve negatif tamsay�lar� kapsar
                    Console.Write ("UInt32 art�: {0}", Convert.ToUInt32 ("art� "+ts, nfi));
                    Console.WriteLine ("UInt32 eksi: {0}\teksi: {0}", Convert.ToUInt32 ("eksi "+ts, nfi)); //��aretsiz UInt32 negatif tamsay�lar� kapsamaz
                }catch (Exception ht) {Console.WriteLine ("\n\tHATA: [{0}]", ht.Message);}
            }

            Console.WriteLine ("\nDuble say� gruplama ',' ve k�s�rat '.' ayrac�yla US, TR ve varsay�l� k�lt�rler:");
            CultureInfo t�rk=CultureInfo.CurrentCulture;
            string dzg1, dzg2="";
            for(i=0;i<10;i++) {
                dzg2="";
                ts=r.Next(100,int.MaxValue); //Console.Write(ts+"\t");
                dzg1=ts.ToString();
                t=1;
                for(j=dzg1.Length-1;j>=0;j--) {
                    dzg2=dzg1[j]+dzg2;
                    if(t++%3==0 & j!=0) {dzg2=","+dzg2; t=1;}
                }
                ts=r.Next(1000,10000);
                dzg2+="."+ts; //Console.WriteLine (ts+"\t"+dzg2);
                try {Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo ("en-US");
                    ds = double.Parse (dzg2);
                    Console.WriteLine ("Dizge: {0}\tUS'a ��z�mlenen: {1}", dzg2, ds);
                }catch (Exception ht) {Console.WriteLine ("'en-US' i�in HATA: [{0}]", ht.Message);
                }finally {Thread.CurrentThread.CurrentCulture = t�rk;}
            }
            try {ds = double.Parse (dzg2); Console.WriteLine ("Dizge: {0}\tTR'ye ��z�mlenen: {1}", dzg2, ds);}catch (Exception ht) {Console.WriteLine ("'tr-TR'({0}) HATA: [{1}]", dzg2, ht.Message);}
            try {ds = double.Parse (dzg2, CultureInfo.InvariantCulture); Console.WriteLine ("Dizge: {0}\tInvariantCulture'a ��z�mlenen: {1}", dzg2, ds);}catch (Exception ht) {Console.WriteLine ("'InvariantCulture' i�in HATA: [{0}]", ht.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}