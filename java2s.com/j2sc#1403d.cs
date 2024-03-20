// j2sc#1403d.cs: DOS veya windows pencere renk/ebat ayarlarý örneði.

using System;
namespace Geliþimler {
    class KonsolD {
        static void Main() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize (100, 25);
            Console.Clear(); //Ekran tamamen temizlenir
            Console.Write ("DOS ekran yazý/zemin renkleri ve (en,boy) ebatlarý ayarlanabilir. Tüm yalýn/bileþik/özel tuþ basýmlarý ReadKey()'le algýlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DOS penceresiin ebat ve renklerinin deðiþim ayarlarý:");
            Console.Title = "Standart Konsol"; //Windows.Menu olsaydý baþlýk okunurdu
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine ("M.Nihat Yavaþ - Toroslar/Mersin\n");
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write ("\nTuþ..."); Console.ReadKey();
            //Console.ResetColor(); //Tekrar yeþertir
            Console.BufferHeight = 500;
            Console.BufferWidth = 100;
            Console.CursorLeft = 50;
            Console.CursorSize = 5;
            Console.CursorTop = 50;
            Console.CursorVisible = false;
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.Write ("\nTuþ..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine ("\nTüm özel/genel tuþlara basýmlarýn algýlanmasý:");
            ConsoleKeyInfo tuþ;
            Console.WriteLine ("Bir tuþa bas [ÇIK=Alt-X]: ");
            do {
                tuþ = Console.ReadKey (true);
                //Console.WriteLine (tuþ);
                Console.WriteLine (" ==>Basýlan tuþ: " + tuþ.KeyChar);
                // Bileþik tuþ basým kontrolu
                if ((ConsoleModifiers.Alt & tuþ.Modifiers) != 0) Console.WriteLine ("Alt tuþuna basýldý.");
                if ((ConsoleModifiers.Control & tuþ.Modifiers) != 0) Console.WriteLine ("Ctrl tuþuna basýldý.");
                if ((ConsoleModifiers.Shift & tuþ.Modifiers) != 0) Console.WriteLine ("Shift tuþuna basýldý.");
                // Özel bir konsol tuþuna basým kontrolu
                if (tuþ.Key == ConsoleKey.F1) Console.WriteLine ("F1 tuþuna basýldý.");
                if (tuþ.Key == ConsoleKey.F3) Console.WriteLine ("F3 tuþuna basýldý.");
                if (tuþ.Key == ConsoleKey.Backspace) Console.WriteLine ("<-- tuþuna basýldý.");
                if (tuþ.Key == ConsoleKey.Escape) Console.WriteLine ("Esc tuþuna basýldý.");
                if (tuþ.Key >= ConsoleKey.A && tuþ.Key <= ConsoleKey.Z) Console.WriteLine ("A<=Tuþ<=Z");
            }while (tuþ.Key != ConsoleKey.X || tuþ.Modifiers != ConsoleModifiers.Alt);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}