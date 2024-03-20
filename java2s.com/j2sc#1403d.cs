// j2sc#1403d.cs: DOS veya windows pencere renk/ebat ayarlar� �rne�i.

using System;
namespace Geli�imler {
    class KonsolD {
        static void Main() {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetWindowSize (100, 25);
            Console.Clear(); //Ekran tamamen temizlenir
            Console.Write ("DOS ekran yaz�/zemin renkleri ve (en,boy) ebatlar� ayarlanabilir. T�m yal�n/bile�ik/�zel tu� bas�mlar� ReadKey()'le alg�lanabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("DOS penceresiin ebat ve renklerinin de�i�im ayarlar�:");
            Console.Title = "Standart Konsol"; //Windows.Menu olsayd� ba�l�k okunurdu
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine ("M.Nihat Yava� - Toroslar/Mersin\n");
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Write ("\nTu�..."); Console.ReadKey();
            //Console.ResetColor(); //Tekrar ye�ertir
            Console.BufferHeight = 500;
            Console.BufferWidth = 100;
            Console.CursorLeft = 50;
            Console.CursorSize = 5;
            Console.CursorTop = 50;
            Console.CursorVisible = false;
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.Clear();
            Console.CursorVisible = true;
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.Write ("\nTu�..."); Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.WriteLine ("\nT�m �zel/genel tu�lara bas�mlar�n alg�lanmas�:");
            ConsoleKeyInfo tu�;
            Console.WriteLine ("Bir tu�a bas [�IK=Alt-X]: ");
            do {
                tu� = Console.ReadKey (true);
                //Console.WriteLine (tu�);
                Console.WriteLine (" ==>Bas�lan tu�: " + tu�.KeyChar);
                // Bile�ik tu� bas�m kontrolu
                if ((ConsoleModifiers.Alt & tu�.Modifiers) != 0) Console.WriteLine ("Alt tu�una bas�ld�.");
                if ((ConsoleModifiers.Control & tu�.Modifiers) != 0) Console.WriteLine ("Ctrl tu�una bas�ld�.");
                if ((ConsoleModifiers.Shift & tu�.Modifiers) != 0) Console.WriteLine ("Shift tu�una bas�ld�.");
                // �zel bir konsol tu�una bas�m kontrolu
                if (tu�.Key == ConsoleKey.F1) Console.WriteLine ("F1 tu�una bas�ld�.");
                if (tu�.Key == ConsoleKey.F3) Console.WriteLine ("F3 tu�una bas�ld�.");
                if (tu�.Key == ConsoleKey.Backspace) Console.WriteLine ("<-- tu�una bas�ld�.");
                if (tu�.Key == ConsoleKey.Escape) Console.WriteLine ("Esc tu�una bas�ld�.");
                if (tu�.Key >= ConsoleKey.A && tu�.Key <= ConsoleKey.Z) Console.WriteLine ("A<=Tu�<=Z");
            }while (tu�.Key != ConsoleKey.X || tu�.Modifiers != ConsoleModifiers.Alt);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}