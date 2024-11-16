// j2sc#2101b.cs: Say�lar�n gruplama, k�s�rat, para sembol� formatlanmas� �rne�i.

using System;
using System.Globalization;
using System.Windows.Forms; // MessageBox i�in
using System.IO; //FileStream, StreamWriter i�in
using System.Text.RegularExpressions; //Regex i�in
namespace K�lt�rler {
    public sealed class KompleksSay�: IFormattable {
        private readonly double ger�el;
        private readonly double sanal;
        public KompleksSay� (double g, double s) {ger�el = g; sanal = s;} //Kurucu
        public override string ToString() {return ToString ("G", null);} //Parametresizse
        public string ToString (string bi�im, IFormatProvider k�lt�r) {return "(" + ger�el.ToString (bi�im, k�lt�r) + " " + ger�el.ToString (bi�im, k�lt�r) + ")";} //�ift parametreliyse
    }
    class FormatA {
        static void Main() {
            Console.Write ("Parasal k�lt�r format� \"para.ToString('C', new CultureInfo('en-US'))\" ile sunuma haz�rlan�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("10 adet TR, GB, US k�lt�rl� double say� sunumu:");
            var r=new Random(); int i=0; double ds=0, ds2=0; string sonu�="";
            CultureInfo ingiliz = new CultureInfo ("en-GB");
            CultureInfo abd = new CultureInfo ("en-US");
            CultureInfo t�rk = new CultureInfo ("tr-TR");
            for(i=0;i<10;i++) {
                ds=r.Next(0,int.MaxValue)+r.Next(10,2024)/1000D;
                Console.WriteLine ("({0,18}), ({1,17}), ({2,17})", ds.ToString ("C", t�rk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
                sonu� +=String.Format ("({0,20}TL)\t({1,17})\t({2,17})\n", ds.ToString ("C", t�rk), ds.ToString ("C", ingiliz), ds.ToString ("C", abd));
            }
            MessageBox.Show (sonu�);

            Console.WriteLine ("\nRasgele 10 double say�larla kompleks say�lar�n t�rk, rus, abd sunumu:");
            KompleksSay� ks=null;
            for(i=0;i<10;i++) {
                ds=r.Next(0,100)+r.Next(0,20241010)/100000000D;
                ds2=r.Next(0,100)+r.Next(0,20241010)/100000000D;
                ks = new KompleksSay� (ds, ds2);
                Console.WriteLine ("{0,20}, {1,20}, {2,20}", ks.ToString ("F5", new CultureInfo ("tr-TR")), ks.ToString ("F5", new CultureInfo ("ru-RU")), ks.ToString ("F5", new CultureInfo ("en-US")));
            }
            Console.WriteLine ("\tK�lt�rs�z: {0}", ks.ToString());

            Console.WriteLine ("\nTarih ve parasal detaylar ekrana ve dosyaya yaz�lmakta:");
            CultureInfo ci = new CultureInfo ("en-GB");
            Console.WriteLine ("�ngilizce ad�: " + ci.EnglishName);
            Console.WriteLine ("Yereldil ad�: " + ci.NativeName);
            DateTimeFormatInfo dtfi = ci.DateTimeFormat;
            Console.WriteLine ("Uzun tarih kal�b�: " + dtfi.LongDatePattern);
            DateTime tarih = DateTime.Now;
            Console.WriteLine (tarih.ToString ("d", ci));
            NumberFormatInfo nfi = ci.NumberFormat;
            Console.WriteLine ("Para sembol�: " + nfi.CurrencySymbol);
            Console.WriteLine ("K�s�rat ayrac�: " + nfi.NumberDecimalSeparator);
            Console.WriteLine (ds.ToString ("c", ci));
            //Dosyaya yaz�lacak
            FileStream fs = File.Create ("k�lt�r.txt");
            StreamWriter sw = new StreamWriter (fs);
            sw.WriteLine ("�ngilizce ad�: " + ci.EnglishName);
            sw.WriteLine ("Yereldil ad�: " + ci.NativeName);
            sw.WriteLine ("Uzun tarih kal�b�: " + dtfi.LongDatePattern);
            sw.WriteLine (tarih.ToString ("d", ci));
            sw.WriteLine ("Para sembol�: " + nfi.CurrencySymbol);
            sw.WriteLine ("K�s�rat ayrac�: " + nfi.NumberDecimalSeparator);
            sw.WriteLine (ds.ToString ("c", ci));
            sw.Flush(); sw.Close();

            Console.WriteLine ("\nGB para gruplama(,) ve k�s�rat(.) ayra� kontroll� dizi testi:");
            string[] para = new string[] {"�0.99", "�0,99", "�1000000.00", "�10.25", "�90,000.00", "�90.000,00", "�1,000,000.00", "�1,000000.00"};
            Regex re = new Regex (String.Format (@"\{0}(\d{{1,3}}\{0})*\d+\{1}\d{{2}}", nfi.CurrencyGroupSeparator, nfi.CurrencyDecimalSeparator));
            foreach (string p in para) Console.WriteLine ("{0}: {1}", p, re.IsMatch (p));

            Console.WriteLine ("\n�e�itli k�lt�r ad, akronim, yerlidil ve takvimleri:");
            string[] k�lt�rler = new string[] {"en-US", "en-GB", "es-MX", "de-DE", "fr-FR", "ja-JP", "ar-SA", "ru-RU", "tr-TR"};
            using (TextWriter tw = Console.Out) {
                foreach (string k in k�lt�rler) {
                    CultureInfo c = new CultureInfo (k);
                    tw.WriteLine ("{0}: {1}", c.Name, c.DisplayName);
                    tw.WriteLine ("\t�ngilizce ad�: {0}", c.EnglishName);
                    tw.WriteLine ("\tYerlidil ad�: {0}", c.NativeName);
                    tw.WriteLine ("\tLCID: {0}", c.LCID);
                    tw.Write ("\t{0} (resmi)", c.Calendar.GetType().Name);
                    foreach (Calendar tkvm in c.OptionalCalendars) tw.Write (", {0}", tkvm.GetType().Name); tw.WriteLine();
                }
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}