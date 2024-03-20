// j2sc#1302.cs: Tüm büyük/küçük-harf tarih-zaman biçimleme harfleri örneði.

using System;
using System.Globalization; //DateTimeFormatInfo için
namespace Tarih {
    class TarihBiçimleme {
        static void Main() {
            Console.Write ("Biçimleme karakterleri: D(ate)=MM/dd/yyyy veya dddd, MMMM dd, yyyy; F(ull)=dddd, MMMM dd, yyyy HH:mm(:ss); G(eneral)=MM/dd/yyyy HH:mm(:ss); M(onth)=MMMM dd; r/R=ddd, dd MMM yyyy 'HH':'mm':'ss' 'GMT'; S(ortable)=yyyy-MM-dd HH:mm:ss; T(ime)=HH:mm(:ss); U(niversal-sort)=yyyy-MM-dd HH:mm:ss veya dddd, MMMM dd, yyyy HH:mm:ss; Y/y(ear)=MMMM, yyyy.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Çeþitli küçük/büyük-harfli tarih-zaman biçimleme harfleri:");
            DateTime tz1 = DateTime.Now;
            Console.WriteLine ("12'lik zaman = [{0:hh:mm:ss tt}]", tz1); //tt, sabah [0,12], öðlen [0,12 PM]
            Console.WriteLine ("24'lük zaman = [{0:HH:mm}]", tz1);
            Console.WriteLine ("24'lük zaman = [{0:HH:mm:ss tt}]", tz1);
            Console.WriteLine ("'ddd MMM dd, yyyy' biçimli tarih = [{0:ddd MMM dd, yyyy}]", tz1);
            Console.WriteLine ("Çað: {0:gg}", tz1);
            Console.WriteLine ("Rakam ve adlý ay: [{0:m}]", tz1);
            Console.WriteLine ("\td biçim: {0:d}", tz1);
            Console.WriteLine ("D biçim: {0:D}", tz1);
            Console.WriteLine ("\tt biçim: {0:t}", tz1);
            Console.WriteLine ("T biçim: {0:T}", tz1); 
            Console.WriteLine ("\tf biçim: {0:f}", tz1);
            Console.WriteLine ("F biçim: {0:F}", tz1);
            Console.WriteLine ("\tg biçim: {0:g}", tz1);
            Console.WriteLine ("G biçim: {0:G}", tz1);
            Console.WriteLine ("\tm biçim: {0:m}", tz1);
            Console.WriteLine ("M biçim: {0:M}", tz1);
            Console.WriteLine ("\tr biçim: {0:r}", tz1);
            Console.WriteLine ("R biçim: {0:R}", tz1);
            Console.WriteLine ("\ts biçim: {0:s}", tz1);
            Console.WriteLine ("\tu biçim: {0:u}", tz1);
            Console.WriteLine ("U biçim: {0:U}", tz1);
            Console.WriteLine ("\ty biçim: {0:y}", tz1);
            Console.WriteLine ("Y biçim: {0:Y}", tz1);
            Console.WriteLine ("==>Biçemsiz tarih ve zaman = [{0}]", tz1);
            Console.WriteLine ("Uzun tarih = [{0}]", tz1.ToLongDateString());
            Console.WriteLine ("Kýsa tarih = [{0}]", tz1.ToShortDateString());
            Console.WriteLine ("==>tz1.ToString() = [{0}]", tz1.ToString());
            Console.WriteLine ("tz1.ToString (\"MMMM dd, yyyy\") = [{0}]", tz1.ToString("MMMM dd, yyyy"));
            Console.WriteLine ("tz1.ToString (\"d\") = [{0}]", tz1.ToString ("d"));
            Console.WriteLine ("tz1.ToString (\"D\") = [{0}]", tz1.ToString ("D"));
            Console.WriteLine ("tz1.ToString (\"f\") = [{0}]", tz1.ToString ("f"));
            Console.WriteLine ("tz1.ToString (\"F\") = [{0}]", tz1.ToString ("F"));
            Console.WriteLine ("tz1.ToString (\"g\") = [{0}]", tz1.ToString ("g"));
            Console.WriteLine ("tz1.ToString (\"G\") = [{0}]", tz1.ToString ("G"));
            Console.WriteLine ("tz1.ToString (\"m\") = [{0}]", tz1.ToString ("m"));
            Console.WriteLine ("tz1.ToString (\"r\") = [{0}]", tz1.ToString ("r"));
            Console.WriteLine ("tz1.ToString (\"s\") = [{0}]", tz1.ToString ("s"));
            Console.WriteLine ("tz1.ToString (\"t\") = [{0}]", tz1.ToString ("t"));
            Console.WriteLine ("tz1.ToString (\"T\") = [{0}]", tz1.ToString ("T"));
            Console.WriteLine ("tz1.ToString (\"u\") = [{0}]", tz1.ToString ("u"));
            Console.WriteLine ("tz1.ToString (\"U\") = [{0}]", tz1.ToString ("U"));
            Console.WriteLine ("tz1.ToString (\"y\") = [{0}]", tz1.ToString ("y"));
            Console.Write ("\nTuþ..."); Console.ReadKey();

            Console.WriteLine ("\n[a,z] ve [A,Z] tüm mevcut/namevcut tarih biçimleme harferinin denenmesi:");
            DateTimeFormatInfo biçimler = new DateTimeFormatInfo();
            for (char harf = 'a'; harf <= 'z'; harf++) {
                try {
                    foreach (string biçim in biçimler.GetAllDateTimePatterns (harf)) {Console.WriteLine ("\t'{0}': {1} = [{2}] / [{3}]", harf, biçim, tz1.ToString (harf.ToString()), tz1.ToString (biçim));}
                    char büyükHarf = Char.ToUpper (harf);
                    foreach (string biçim in biçimler.GetAllDateTimePatterns (büyükHarf)) {Console.WriteLine ("\t'{0}': {1} = [{2}] / [{3}]", büyükHarf, biçim, tz1.ToString (büyükHarf.ToString()), tz1.ToString (biçim));}
                }catch (Exception ht) {Console.WriteLine ("==>HATA ({0}/{1}): [{2}]", harf, Char.ToUpper (harf), ht.Message);}
            }

            Console.WriteLine ("\n5 ayrý kültürde, tarih ve rakam biçimleri:");
            string[] kültürler = {"en-US", "fr-FR", "de-DE", "es-ES", "tr-TR"};
            double ds = 20240302.024457983;
            foreach (string kültür in kültürler) {
                CultureInfo biçim = new CultureInfo (kültür);
                Console.WriteLine (String.Format (biçim, "{0,-11} {1,-35:D} {2:N}", biçim.Name, tz1, ds));
            }

            Console.WriteLine ("\nÇeþitli hazýr, özel tarih ve gün biçimleri:");
            Console.WriteLine ("D biçimleyici: [{0:D}]", tz1);
            string uzunKalýp = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
            Console.WriteLine ("'{0}' uzun kalýp biçimi: [{1}]", uzunKalýp, tz1.ToString (uzunKalýp));
            Console.WriteLine ("%M biçimi: [{0}]", tz1.ToString ("%M"));
            string özelBiçim = "MMMM dd, yyyy (dddd)";
            Console.WriteLine ("'MMMM dd, yyyy (dddd)' özel biçim: [{0}]", tz1.ToString (özelBiçim));
            DayOfWeek haftanýnGünü = DayOfWeek.Saturday;
            string[] biçimHarleri = {"G", "F", "D", "X"};
            foreach (string biçimHarfi in biçimHarleri) Console.WriteLine ("{0} biçimli hatanýn günü: [{1}]", biçimHarfi, haftanýnGünü.ToString (biçimHarfi));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}