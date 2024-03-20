// j2sc#1403a.cs: Console.Write/WriteLine/Error/SetIn/SetOut konsol çýktýlarý örneði.

using System;
using System.IO; //StremReader/Writer için
namespace Geliþimler {
    class KonsolA {
        static void Main (string[] arglar) {
            Console.Write ("Konsol girdi/çýktýlarý: Console.In (TextReader, Read(), ReadLine()), Console.Out ile Console.Error (TextWriter, FileStream, Stream).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine (":");
            int i, j, ts1; var r=new Random();
            for(i=1;i<=5;i++) Console.WriteLine ("Bu " + i + ".nci ekran çýktýsýdýr.");
            for(i=1;i<=5;i++) Console.Write ("Bu " + i + ".nci ekran çýktýsýdýr. "); Console.WriteLine();
            Console.WriteLine ("{0} ve {1}.", 1881, 1938);
            Console.WriteLine ("{0}, {1}, {1} ve {0}.", 1881, 1938);
            Console.Out.WriteLine ("\tÝstisna yakalanacak:");
            i=r.Next(2000,2025); j=0;
            try {ts1 = i / j;}catch (Exception ht) {Console.Error.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.Out.WriteLine ("Merhaba " + "Dünya! " + "PI = " + Math.PI);
            Console.WriteLine ("{0:F2}  {0:f3}  {0:e}  {1:E}", Math.PI, Math.PI*1e4);
            Console.WriteLine ("{2:d} {1:d} {0:d}", 1938, 1923, 1881);
            ts1 = r.Next(1881,1939);
            string ad = "Kemal";
            Console.WriteLine (String.Format ("{0} {1} yaþýndadýr.", ad, ts1-1881));
            ad = "Mustafa Kemal";
            Console.WriteLine (String.Format ("{0} Selanik'te. {0} Çanakkale'de. {0} Samsun'da. {0} bugün Anýt Kabir'de.", ad));
            Console.WriteLine ("Ýþte sana bir adet ters bölü: \\");
            Console.WriteLine ("Ýþlem tamam...\n\n\a"); //a bipletir.
            Console.Write (@"Üçgen çizimine baþladým: //@ \'yü normal karakter sayar
             /\
            /  \
           /    \
          /      \
         /________\
ve bitirdim."); Console.WriteLine();
            StreamWriter yazýcý = new StreamWriter (arglar[0]+".txt"); //"c#\j2sc#1403a mahmut" olarak koþtur
            Console.SetOut (yazýcý);
            ad+=" Atatürk"; Console.WriteLine (ad); //mahmut.txt'ye yazar
            yazýcý.Close();
            Console.SetIn (new StreamReader ("mny.txt")); //mny.txt yarat
            StreamWriter akýþYazýcý = new StreamWriter (Console.OpenStandardOutput());
            akýþYazýcý.AutoFlush = true;
            Console.SetOut (akýþYazýcý);
            Console.WriteLine ("Standart ekran çýktýsý'na yazmaktayým...");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}