// j2sc#0516.cs: StringReader ve StringWriter ile dizge okuma/yazma �rne�i.

using System;
using System.IO;
namespace Dizgeler {
    class DizgeOkurYazar {
        static void Main() {
            Console.Write ("StringReader dizge verilerini sat�rl� veya karakterli okurken, StringWriter kendisine sunulan dizgeyi i�eri�ini yazar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("StringReader ile dizge'den krkDizi'ye veri okutma:");
            String dizge1 = "Nihat'tan herkese merhabalar!";
            char[] kDizi1 = new char[18];
            StringReader sr1 = new StringReader (dizge1);
            sr1.Read (kDizi1, 0, 18);
            Console.WriteLine ("dizge1 = '{0}'", dizge1);
            Console.WriteLine (kDizi1);
            sr1.Close();

            Console.WriteLine ("\nStringReader ile okunan dizge krk ve ascii-kod'lar�n� sunma:");
            int i;
            using (sr1 = new StringReader (dizge1)) {while ((i = sr1.Read()) != -1) Console.Write ("{0}={1} ", (char)i, i);}
            sr1.Close();

            Console.WriteLine ("\n\nStringReader ile �oklu sat�rl� dizgeyi sat�r-sat�r okutma ve sunma:");
            dizge1 +="\r\nBu, �ok sat�rl� bir dizgedir.\r\nToplamda 4 sat�r i�ermektedir.\r\nDizge verileri sat�rl� okunup g�sterilecektir.";
            i=0; string sat�r;
            using (sr1 = new StringReader (dizge1)) {while ((sat�r = sr1.ReadLine()) != null) Console.WriteLine ("Sat�r#{0}: {1}", ++i, sat�r);} sr1.Close();

            Console.WriteLine ("\nStringReader ile �oklu sat�rl� dizgeyi sat�r-sat�r okutma ve sunma:");
            dizge1 +="\r\nBu, �ok sat�rl� bir dizgedir.\r\nToplamda 4 sat�r i�ermektedir.\r\nDizge verileri sat�rl� okunup g�sterilecektir.";
            i=0;
            using (sr1 = new StringReader (@"j2sc#0516.cs")) {while ((sat�r = sr1.ReadLine()) != null) Console.WriteLine ("Sat�r#{0}: {1}", ++i, sat�r);} sr1.Close();

            Console.WriteLine ("\nStreamReader ile FileStream dosya sat�rlar�n� okuyup ne�retme:");
            FileStream fs1 = new FileStream ("j2sc#0516.cs", FileMode.OpenOrCreate);
            StreamReader sr2 = new StreamReader (fs1);
            i=0;
            while ((sat�r = sr2.ReadLine()) != null) {Console.WriteLine ("Sat�r#{0}: {1}", ++i, sat�r); if (i >= 10) break;} sr2.Close(); fs1.Close();

            Console.WriteLine ("\nStringWriter ile yazd�r�lan verileri dizgele�tirip yans�tma:");
            StringWriter sw1 = new StringWriter();
            sw1.Write ("�sim: {0}, Ya�: {1}, �kamet: {2}", "Canan Candan", 2023-1976, "Antalya");
            Console.WriteLine ("sw1 = [{0}]", sw1.ToString());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}