// j2sc#0516.cs: StringReader ve StringWriter ile dizge okuma/yazma örneði.

using System;
using System.IO;
namespace Dizgeler {
    class DizgeOkurYazar {
        static void Main() {
            Console.Write ("StringReader dizge verilerini satýrlý veya karakterli okurken, StringWriter kendisine sunulan dizgeyi içeriðini yazar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StringReader ile dizge'den krkDizi'ye veri okutma:");
            String dizge1 = "Nihat'tan herkese merhabalar!";
            char[] kDizi1 = new char[18];
            StringReader sr1 = new StringReader (dizge1);
            sr1.Read (kDizi1, 0, 18);
            Console.WriteLine ("dizge1 = '{0}'", dizge1);
            Console.WriteLine (kDizi1);
            sr1.Close();

            Console.WriteLine ("\nStringReader ile okunan dizge krk ve ascii-kod'larýný sunma:");
            int i;
            using (sr1 = new StringReader (dizge1)) {while ((i = sr1.Read()) != -1) Console.Write ("{0}={1} ", (char)i, i);}
            sr1.Close();

            Console.WriteLine ("\n\nStringReader ile çoklu satýrlý dizgeyi satýr-satýr okutma ve sunma:");
            dizge1 +="\r\nBu, çok satýrlý bir dizgedir.\r\nToplamda 4 satýr içermektedir.\r\nDizge verileri satýrlý okunup gösterilecektir.";
            i=0; string satýr;
            using (sr1 = new StringReader (dizge1)) {while ((satýr = sr1.ReadLine()) != null) Console.WriteLine ("Satýr#{0}: {1}", ++i, satýr);} sr1.Close();

            Console.WriteLine ("\nStringReader ile çoklu satýrlý dizgeyi satýr-satýr okutma ve sunma:");
            dizge1 +="\r\nBu, çok satýrlý bir dizgedir.\r\nToplamda 4 satýr içermektedir.\r\nDizge verileri satýrlý okunup gösterilecektir.";
            i=0;
            using (sr1 = new StringReader (@"j2sc#0516.cs")) {while ((satýr = sr1.ReadLine()) != null) Console.WriteLine ("Satýr#{0}: {1}", ++i, satýr);} sr1.Close();

            Console.WriteLine ("\nStreamReader ile FileStream dosya satýrlarýný okuyup neþretme:");
            FileStream fs1 = new FileStream ("j2sc#0516.cs", FileMode.OpenOrCreate);
            StreamReader sr2 = new StreamReader (fs1);
            i=0;
            while ((satýr = sr2.ReadLine()) != null) {Console.WriteLine ("Satýr#{0}: {1}", ++i, satýr); if (i >= 10) break;} sr2.Close(); fs1.Close();

            Console.WriteLine ("\nStringWriter ile yazdýrýlan verileri dizgeleþtirip yansýtma:");
            StringWriter sw1 = new StringWriter();
            sw1.Write ("Ýsim: {0}, Yaþ: {1}, Ýkamet: {2}", "Canan Candan", 2023-1976, "Antalya");
            Console.WriteLine ("sw1 = [{0}]", sw1.ToString());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}