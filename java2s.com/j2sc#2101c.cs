// j2sc#2101c.cs: Çoklu kültürlerle gün, ay tarih, para ve sayý biçimleme örneði.

using System;
using System.Globalization;
using System.IO; //TextWriter için
using System.Threading;
namespace Kültürler {
    class FormatB {
        static void Main() {
            Console.Write ("'CultureInfo ci=new CultureInfo(\"xy-XY\")' ve 'deðer.ToString(\"F\", ci.NumberFormat)' ile istenilen kültürün formatýyla çýktý alýnýr. 'Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(\"xy-XY\")' ile tüm iþlemler tanýmlý kültürden biçimlenir. 'double.Parse(dzg, CultureInfo.InvariantCulture)' ile duble çözümleme varsayýlý kültürle yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string[] kültürler = new string[] {"en-US", "en-GB", "es-MX", "de-DE", "fr-FR", "ja-JP", "ar-SA", "ru-RU", "tr-TR"};
            Console.WriteLine ("{0} kültürde haftanýn gün  ve yýlýn ay adlarý, kýsa/uzun-tarih, sayý ve para sunumu:", kültürler.Length);
            CultureInfo ci=null; DateTime tarih=DateTime.Now; var r=new Random(); double ds;
            using (TextWriter tw = Console.Out) {
                foreach (string k in kültürler) {
                    ci = new CultureInfo (k);
                    tw.Write ("-->{0} Günler: ", ci.EnglishName);
                    foreach (string gün in ci.DateTimeFormat.DayNames) tw.Write ("{0} ", gün);
                    tw.WriteLine();
                    tw.Write ("Aylar: ");
                    foreach (string ay in ci.DateTimeFormat.MonthNames) tw.Write ("{0} ", ay);
                    tw.WriteLine();
                    tw.WriteLine ("Kýsa tarih: {0}\tUzun tarih: {1}", tarih.ToString (ci.DateTimeFormat.ShortDatePattern, ci.DateTimeFormat), tarih.ToString (ci.DateTimeFormat.LongDatePattern, ci.DateTimeFormat));
                    ds=r.Next(-20241110,20241110)+r.Next(0,0228)/1000D;
                    tw.WriteLine ("Sayý: {0}\tPara: {1}", ds.ToString (ci), ds.ToString ("C", ci.NumberFormat));
                }
            }

            Console.WriteLine ("\nNumberFormatInfo.PositiveSign/NegativeSign ile istenilen sembol +- yerine kullanýlabilir:");
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.PositiveSign = "artý ";
            nfi.NegativeSign = "eksi ";
            int i, j, t, ts;
            for(i=0;i<10;i++) {
                ts=r.Next(0,int.MaxValue);
                try {Console.WriteLine ("Int32 artý: {0}\teksi: {1}", Convert.ToInt32 ("artý "+ts, nfi), Convert.ToInt32 ("eksi "+ts, nfi)); //Ýþaretli Int32 pozitif ve negatif tamsayýlarý kapsar
                    Console.Write ("UInt32 artý: {0}", Convert.ToUInt32 ("artý "+ts, nfi));
                    Console.WriteLine ("UInt32 eksi: {0}\teksi: {0}", Convert.ToUInt32 ("eksi "+ts, nfi)); //Ýþaretsiz UInt32 negatif tamsayýlarý kapsamaz
                }catch (Exception ht) {Console.WriteLine ("\n\tHATA: [{0}]", ht.Message);}
            }

            Console.WriteLine ("\nDuble sayý gruplama ',' ve küsürat '.' ayracýyla US, TR ve varsayýlý kültürler:");
            CultureInfo türk=CultureInfo.CurrentCulture;
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
                    Console.WriteLine ("Dizge: {0}\tUS'a çözümlenen: {1}", dzg2, ds);
                }catch (Exception ht) {Console.WriteLine ("'en-US' için HATA: [{0}]", ht.Message);
                }finally {Thread.CurrentThread.CurrentCulture = türk;}
            }
            try {ds = double.Parse (dzg2); Console.WriteLine ("Dizge: {0}\tTR'ye çözümlenen: {1}", dzg2, ds);}catch (Exception ht) {Console.WriteLine ("'tr-TR'({0}) HATA: [{1}]", dzg2, ht.Message);}
            try {ds = double.Parse (dzg2, CultureInfo.InvariantCulture); Console.WriteLine ("Dizge: {0}\tInvariantCulture'a çözümlenen: {1}", dzg2, ds);}catch (Exception ht) {Console.WriteLine ("'InvariantCulture' için HATA: [{0}]", ht.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}