// j2sc#1403c.cs: Read(), ReadLine(), ReadKey(), TextWriter ve StreamWriter �rne�i.

using System;
using System.IO; //StreamWriter i�in
namespace Geli�imler {
    class KosolC {
        static void Main() {
            Console.Write ("TextReader tiplemesi Consol.In'in iki metodu Read() tek karaktet, ReadLine() ise Enter'layana de�in dizge okur. ReadKey() Enter gerektirmez, bir tu�a bas�lmas� yeterlidir. Console.Write/Line StreamWriter'la disk dosyas� yada ekrana y�neltilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ReadLine() ve Read() ile dizge ve karakter giri�i:");
            char krk; string dzg;
            Console.Write ("�oklu tu� [Ent] bas: "); dzg = Console.ReadLine();
            Console.WriteLine ("Girdi�iniz dizge: " + dzg);
            Console.Write ("Tek tu� [Ent] bas: "); krk = (char)Console.Read();
            Console.WriteLine ("Bast���n�z (ilk) karakter: " + krk);

            Console.WriteLine ("\nEnter's�z tek tu�u alg�layan 'char ReadKey()' metodu:");
            ConsoleKeyInfo tu�;
            Console.WriteLine ("Tu�, Alt, Ctrl, Shift bas [Q=��k]: ");
            do {tu� = Console.ReadKey();
                Console.WriteLine ("==> Bast���n�z tu�: " + tu�.KeyChar);
                // �zel tu� kontrollar�
                if ((ConsoleModifiers.Alt & tu�.Modifiers) != 0) Console.WriteLine ("Alt'a bas�ld�.");
                if ((ConsoleModifiers.Control & tu�.Modifiers) != 0) Console.WriteLine ("Ctrl'a bas�ld�.");
                if ((ConsoleModifiers.Shift & tu�.Modifiers) != 0) Console.WriteLine ("Shift'e bas�ld�.");
            }while ((tu�.KeyChar).ToString().ToUpper() != "Q");

            Console.WriteLine ("\nMetinYaz�c�'y� ekrana y�neltip �e�itli veriler yazma:");
            using (TextWriter tw = Console.Out) {
                tw.Write (302.30m);
                tw.Write (" M.Nihat Yava�, ");
                tw.Write (true); 
                tw.WriteLine (", "+(char)65+'.');
            }

            Console.WriteLine ("\nDisk dosyas� yarat�p, 2 kay�t ekleyip, tekrar ekrana y�neltme:");
            StreamWriter dosya;
            try {dosya = new StreamWriter ("mny.txt");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);return;}
            Console.SetOut (dosya);
            Console.WriteLine ("B�ylece, i�lem i�in verili dosya haz�rd�r.");
            Console.WriteLine ("Her Console.Write/Line art�k varsay�l� olarak a��k dosyaya eklenecektir.");
            dosya.Close();
            dosya=new StreamWriter (Console.OpenStandardOutput());
            Console.SetOut (dosya); //Tekrar ekrana yazar
            dosya.AutoFlush = true; //Dosya ak�� tampondaki veriler ekrana beslenecek

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}