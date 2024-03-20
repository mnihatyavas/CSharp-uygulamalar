// j2sc#1403a.cs: Console.Write/WriteLine/Error/SetIn/SetOut konsol ��kt�lar� �rne�i.

using System;
using System.IO; //StremReader/Writer i�in
namespace Geli�imler {
    class KonsolA {
        static void Main (string[] arglar) {
            Console.Write ("Konsol girdi/��kt�lar�: Console.In (TextReader, Read(), ReadLine()), Console.Out ile Console.Error (TextWriter, FileStream, Stream).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine (":");
            int i, j, ts1; var r=new Random();
            for(i=1;i<=5;i++) Console.WriteLine ("Bu " + i + ".nci ekran ��kt�s�d�r.");
            for(i=1;i<=5;i++) Console.Write ("Bu " + i + ".nci ekran ��kt�s�d�r. "); Console.WriteLine();
            Console.WriteLine ("{0} ve {1}.", 1881, 1938);
            Console.WriteLine ("{0}, {1}, {1} ve {0}.", 1881, 1938);
            Console.Out.WriteLine ("\t�stisna yakalanacak:");
            i=r.Next(2000,2025); j=0;
            try {ts1 = i / j;}catch (Exception ht) {Console.Error.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.Out.WriteLine ("Merhaba " + "D�nya! " + "PI = " + Math.PI);
            Console.WriteLine ("{0:F2}  {0:f3}  {0:e}  {1:E}", Math.PI, Math.PI*1e4);
            Console.WriteLine ("{2:d} {1:d} {0:d}", 1938, 1923, 1881);
            ts1 = r.Next(1881,1939);
            string ad = "Kemal";
            Console.WriteLine (String.Format ("{0} {1} ya��ndad�r.", ad, ts1-1881));
            ad = "Mustafa Kemal";
            Console.WriteLine (String.Format ("{0} Selanik'te. {0} �anakkale'de. {0} Samsun'da. {0} bug�n An�t Kabir'de.", ad));
            Console.WriteLine ("��te sana bir adet ters b�l�: \\");
            Console.WriteLine ("��lem tamam...\n\n\a"); //a bipletir.
            Console.Write (@"��gen �izimine ba�lad�m: //@ \'y� normal karakter sayar
             /\
            /  \
           /    \
          /      \
         /________\
ve bitirdim."); Console.WriteLine();
            StreamWriter yaz�c� = new StreamWriter (arglar[0]+".txt"); //"c#\j2sc#1403a mahmut" olarak ko�tur
            Console.SetOut (yaz�c�);
            ad+=" Atat�rk"; Console.WriteLine (ad); //mahmut.txt'ye yazar
            yaz�c�.Close();
            Console.SetIn (new StreamReader ("mny.txt")); //mny.txt yarat
            StreamWriter ak��Yaz�c� = new StreamWriter (Console.OpenStandardOutput());
            ak��Yaz�c�.AutoFlush = true;
            Console.SetOut (ak��Yaz�c�);
            Console.WriteLine ("Standart ekran ��kt�s�'na yazmaktay�m...");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}