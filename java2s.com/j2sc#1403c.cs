// j2sc#1403c.cs: Read(), ReadLine(), ReadKey(), TextWriter ve StreamWriter örneði.

using System;
using System.IO; //StreamWriter için
namespace Geliþimler {
    class KosolC {
        static void Main() {
            Console.Write ("TextReader tiplemesi Consol.In'in iki metodu Read() tek karaktet, ReadLine() ise Enter'layana deðin dizge okur. ReadKey() Enter gerektirmez, bir tuþa basýlmasý yeterlidir. Console.Write/Line StreamWriter'la disk dosyasý yada ekrana yöneltilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ReadLine() ve Read() ile dizge ve karakter giriþi:");
            char krk; string dzg;
            Console.Write ("Çoklu tuþ [Ent] bas: "); dzg = Console.ReadLine();
            Console.WriteLine ("Girdiðiniz dizge: " + dzg);
            Console.Write ("Tek tuþ [Ent] bas: "); krk = (char)Console.Read();
            Console.WriteLine ("Bastýðýnýz (ilk) karakter: " + krk);

            Console.WriteLine ("\nEnter'sýz tek tuþu algýlayan 'char ReadKey()' metodu:");
            ConsoleKeyInfo tuþ;
            Console.WriteLine ("Tuþ, Alt, Ctrl, Shift bas [Q=Çýk]: ");
            do {tuþ = Console.ReadKey();
                Console.WriteLine ("==> Bastýðýnýz tuþ: " + tuþ.KeyChar);
                // Özel tuþ kontrollarý
                if ((ConsoleModifiers.Alt & tuþ.Modifiers) != 0) Console.WriteLine ("Alt'a basýldý.");
                if ((ConsoleModifiers.Control & tuþ.Modifiers) != 0) Console.WriteLine ("Ctrl'a basýldý.");
                if ((ConsoleModifiers.Shift & tuþ.Modifiers) != 0) Console.WriteLine ("Shift'e basýldý.");
            }while ((tuþ.KeyChar).ToString().ToUpper() != "Q");

            Console.WriteLine ("\nMetinYazýcý'yý ekrana yöneltip çeþitli veriler yazma:");
            using (TextWriter tw = Console.Out) {
                tw.Write (302.30m);
                tw.Write (" M.Nihat Yavaþ, ");
                tw.Write (true); 
                tw.WriteLine (", "+(char)65+'.');
            }

            Console.WriteLine ("\nDisk dosyasý yaratýp, 2 kayýt ekleyip, tekrar ekrana yöneltme:");
            StreamWriter dosya;
            try {dosya = new StreamWriter ("mny.txt");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);return;}
            Console.SetOut (dosya);
            Console.WriteLine ("Böylece, iþlem için verili dosya hazýrdýr.");
            Console.WriteLine ("Her Console.Write/Line artýk varsayýlý olarak açýk dosyaya eklenecektir.");
            dosya.Close();
            dosya=new StreamWriter (Console.OpenStandardOutput());
            Console.SetOut (dosya); //Tekrar ekrana yazar
            dosya.AutoFlush = true; //Dosya akýþ tampondaki veriler ekrana beslenecek

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}