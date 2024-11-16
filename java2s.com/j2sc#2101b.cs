// j2sc#2101b.cs: Sayýlarýn gruplama, küsürat, para sembolü formatlanmasý örneði.

using System;
using System.Globalization;
using System.Windows.Forms; // MessageBox için
using System.IO; //FileStream, StreamWriter için
using System.Text.RegularExpressions; //Regex için
namespace Kültürler {
    public sealed class KompleksSayý: IFormattable {
        private readonly double gerçel;
        private readonly double sanal;
        public KompleksSayý (double g, double s) {gerçel = g; sanal = s;} //Kurucu
        public override string ToString() {return ToString ("G", null);} //Parametresizse
        public string ToString (string biçim, IFormatProvider kültür) {return "(" + gerçel.ToString (biçim, kültür) + " " + gerçel.ToString (biçim, kültür) + ")";} //Çift parametreliyse
    }
    class FormatA {
        static void Main() {
            Console.Write ("Parasal kültür formatý \"para.ToString('C', new CultureInfo('en-US'))\" ile sunuma hazýrlanýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10 adet TR, GB, US kültürlü double sayý sunumu:");
            var r=new Random(); int i=0; double ds=0, ds2=0; string sonuç="";
            CultureInfo ingiliz = new CultureInfo ("en-GB");
            CultureInfo abd = new CultureInfo ("en-US");
            CultureInfo türk = new CultureInfo ("tr-TR");
            for(i=0;i<10;i++) {
                ds=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000D;
                Console.WriteLine ("({0,18}), ({1,17}), ({2,17})", ds.ToString ("C", türk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
                sonuç +=String.Format ("({0,20}TL)\t({1,17})\t({2,17})\n", ds.ToString ("C", türk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
            }
            MessageBox.Show (sonuç);

            Console.WriteLine ("\nRasgele 10 double sayýlarla kompleks sayýlarýn türk, rus, abd sunumu:");
            KompleksSayý ks=null;
            for(i=0;i<10;i++) {
                ds=r.Next(0,100)+r.Next(0,20241010)/100000000D;
                ds2=r.Next(0,100)+r.Next(0,20241010)/100000000D;
                ks = new KompleksSayý (ds, ds2);
                Console.WriteLine ("{0,20}, {1,20}, {2,20}", ks.ToString ("F5", new CultureInfo ("tr-TR")), ks.ToString ("F5", new CultureInfo ("ru-RU")), ks.ToString ("F5", new CultureInfo ("en-US")));
            }
            Console.WriteLine ("\tKültürsüz: {0}", ks.ToString());

            Console.WriteLine ("\nTarih ve parasal detaylar ekrana ve dosyaya yazýlmakta:");
            CultureInfo ci = new CultureInfo ("en-GB");
            Console.WriteLine ("Ýngilizce adý: " + ci.EnglishName);
            Console.WriteLine ("Yereldil adý: " + ci.NativeName);
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            Console.WriteLine ("Uzun tarih kalýbý: " + dtfi.LongDatePattern);
            DateTime tarih = DateTime.Now;
            Console.WriteLine (tarih.ToString ("d", ci));
            NumberFormatInfo nfi = ci.NumberFormat;
            Console.WriteLine ("Para sembolü: " + nfi.CurrencySymbol);
            Console.WriteLine ("Küsürat ayracý: " + nfi.NumberDecimalSeparator);
            Console.WriteLine (ds.ToString ("c", ci));
            //Dosyaya yazýlacak
            FileStream fs = File.Create ("kültür.txt");
            StreamWriter sw = new StreamWriter (fs);
            sw.WriteLine ("Ýngilizce adý: " + ci.EnglishName);
            sw.WriteLine ("Yereldil adý: " + ci.NativeName);
            sw.WriteLine ("Uzun tarih kalýbý: " + dtfi.LongDatePattern);
            sw.WriteLine (tarih.ToString ("d", ci));
            sw.WriteLine ("Para sembolü: " + nfi.CurrencySymbol);
            sw.WriteLine ("Küsürat ayracý: " + nfi.NumberDecimalSeparator);
            sw.WriteLine (ds.ToString ("c", ci));
            sw.Flush(); sw.Close();

            Console.WriteLine ("\nGB para gruplama(,) ve küsürat(.) ayraç kontrollü dizi testi:");
            string[] para = new string[] {"£0.99", "£0,99", "£1000000.00", "£10.25", "£90,000.00", "£90.000,00", "£1,000,000.00", "£1,000000.00"};
            Regex re = new Regex (String.Format (@"\{0}(\d{{1,3}}\{0})*\d+\{1}\d{{2}}", nfi.CurrencyGroupSeparator, nfi.CurrencyDecimalSeparator));
            foreach (string p in para) Console.WriteLine ("{0}: {1}", p, re.IsMatch (p));

            Console.WriteLine ("\nÇeþitli kültür ad, akronim, yerlidil ve takvimleri:");
            string[] kültürler = new string[] {"en-US", "en-GB", "es-MX", "de-DE", "fr-FR", "ja-JP", "ar-SA", "ru-RU", "tr-TR"};
            using (TextWriter tw = Console.Out) {
                foreach (string k in kültürler) {
                    CultureInfo c = new CultureInfo (k);
                    tw.WriteLine ("{0}: {1}", c.Name, c.DisplayName);
                    tw.WriteLine ("\tÝngilizce adý: {0}", c.EnglishName);
                    tw.WriteLine ("\tYerlidil adý: {0}", c.NativeName);
                    tw.WriteLine ("\tLCID: {0}", c.LCID);
                    tw.Write ("\t{0} (resmi)", c.Calendar.GetType().Name);
                    foreach (Calendar tkvm in c.OptionalCalendars) tw.Write (", {0}", tkvm.GetType().Name); tw.WriteLine();
                }
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}