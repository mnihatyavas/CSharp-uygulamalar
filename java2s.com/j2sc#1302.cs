// j2sc#1302.cs: T�m b�y�k/k���k-harf tarih-zaman bi�imleme harfleri �rne�i.

using System;
using System.Globalization; //DateTimeFormatInfo i�in
namespace Tarih {
    class TarihBi�imleme {
        static void Main() {
            Console.Write ("Bi�imleme karakterleri: D(ate)=MM/dd/yyyy veya dddd, MMMM dd, yyyy; F(ull)=dddd, MMMM dd, yyyy HH:mm(:ss); G(eneral)=MM/dd/yyyy HH:mm(:ss); M(onth)=MMMM dd; r/R=ddd, dd MMM yyyy 'HH':'mm':'ss' 'GMT'; S(ortable)=yyyy-MM-dd HH:mm:ss; T(ime)=HH:mm(:ss); U(niversal-sort)=yyyy-MM-dd HH:mm:ss veya dddd, MMMM dd, yyyy HH:mm:ss; Y/y(ear)=MMMM, yyyy.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�e�itli k���k/b�y�k-harfli tarih-zaman bi�imleme harfleri:");
            DateTime tz1 = DateTime.Now;
            Console.WriteLine ("12'lik zaman = [{0:hh:mm:ss tt}]", tz1); //tt, sabah [0,12], ��len [0,12 PM]
            Console.WriteLine ("24'l�k zaman = [{0:HH:mm}]", tz1);
            Console.WriteLine ("24'l�k zaman = [{0:HH:mm:ss tt}]", tz1);
            Console.WriteLine ("'ddd MMM dd, yyyy' bi�imli tarih = [{0:ddd MMM dd, yyyy}]", tz1);
            Console.WriteLine ("�a�: {0:gg}", tz1);
            Console.WriteLine ("Rakam ve adl� ay: [{0:m}]", tz1);
            Console.WriteLine ("\td bi�im: {0:d}", tz1);
            Console.WriteLine ("D bi�im: {0:D}", tz1);
            Console.WriteLine ("\tt bi�im: {0:t}", tz1);
            Console.WriteLine ("T bi�im: {0:T}", tz1); 
            Console.WriteLine ("\tf bi�im: {0:f}", tz1);
            Console.WriteLine ("F bi�im: {0:F}", tz1);
            Console.WriteLine ("\tg bi�im: {0:g}", tz1);
            Console.WriteLine ("G bi�im: {0:G}", tz1);
            Console.WriteLine ("\tm bi�im: {0:m}", tz1);
            Console.WriteLine ("M bi�im: {0:M}", tz1);
            Console.WriteLine ("\tr bi�im: {0:r}", tz1);
            Console.WriteLine ("R bi�im: {0:R}", tz1);
            Console.WriteLine ("\ts bi�im: {0:s}", tz1);
            Console.WriteLine ("\tu bi�im: {0:u}", tz1);
            Console.WriteLine ("U bi�im: {0:U}", tz1);
            Console.WriteLine ("\ty bi�im: {0:y}", tz1);
            Console.WriteLine ("Y bi�im: {0:Y}", tz1);
            Console.WriteLine ("==>Bi�emsiz tarih ve zaman = [{0}]", tz1);
            Console.WriteLine ("Uzun tarih = [{0}]", tz1.ToLongDateString());
            Console.WriteLine ("K�sa tarih = [{0}]", tz1.ToShortDateString());
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
            Console.Write ("\nTu�..."); Console.ReadKey();

            Console.WriteLine ("\n[a,z] ve [A,Z] t�m mevcut/namevcut tarih bi�imleme harferinin denenmesi:");
            DateTimeFormatInfo bi�imler = new DateTimeFormatInfo();
            for (char harf = 'a'; harf <= 'z'; harf++) {
                try {
                    foreach (string bi�im in bi�imler.GetAllDateTimePatterns (harf)) {Console.WriteLine ("\t'{0}': {1} = [{2}] / [{3}]", harf, bi�im, tz1.ToString (harf.ToString()), tz1.ToString (bi�im));}
                    char b�y�kHarf = Char.ToUpper (harf);
                    foreach (string bi�im in bi�imler.GetAllDateTimePatterns (b�y�kHarf)) {Console.WriteLine ("\t'{0}': {1} = [{2}] / [{3}]", b�y�kHarf, bi�im, tz1.ToString (b�y�kHarf.ToString()), tz1.ToString (bi�im));}
                }catch (Exception ht) {Console.WriteLine ("==>HATA ({0}/{1}): [{2}]", harf, Char.ToUpper (harf), ht.Message);}
            }

            Console.WriteLine ("\n5 ayr� k�lt�rde, tarih ve rakam bi�imleri:");
            string[] k�lt�rler = {"en-US", "fr-FR", "de-DE", "es-ES", "tr-TR"};
            double ds = 20240302.024457983;
            foreach (string k�lt�r in k�lt�rler) {
                CultureInfo bi�im = new CultureInfo (k�lt�r);
                Console.WriteLine (String.Format (bi�im, "{0,-11} {1,-35:D} {2:N}", bi�im.Name, tz1, ds));
            }

            Console.WriteLine ("\n�e�itli haz�r, �zel tarih ve g�n bi�imleri:");
            Console.WriteLine ("D bi�imleyici: [{0:D}]", tz1);
            string uzunKal�p = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
            Console.WriteLine ("'{0}' uzun kal�p bi�imi: [{1}]", uzunKal�p, tz1.ToString (uzunKal�p));
            Console.WriteLine ("%M bi�imi: [{0}]", tz1.ToString ("%M"));
            string �zelBi�im = "MMMM dd, yyyy (dddd)";
            Console.WriteLine ("'MMMM dd, yyyy (dddd)' �zel bi�im: [{0}]", tz1.ToString (�zelBi�im));
            DayOfWeek haftan�nG�n� = DayOfWeek.Saturday;
            string[] bi�imHarleri = {"G", "F", "D", "X"};
            foreach (string bi�imHarfi in bi�imHarleri) Console.WriteLine ("{0} bi�imli hatan�n g�n�: [{1}]", bi�imHarfi, haftan�nG�n�.ToString (bi�imHarfi));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}