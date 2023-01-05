// tpc#26c.cs: Verilen dizgedeki ardýþýk birden fazla boþluklarýn silinmesi örneði.

using System;
using System.Text.RegularExpressions;
namespace DüzenliTabirler {
    class BoþlukSilme {
        static void Main() {
            Console.Write ("Birden fazla boþluklarý silen Regex metodu: new Regex('kalýp').Replace(dizge, 'krk')\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string cümle = "  Merhaba   dünyalýlar!..    ";
            Console.WriteLine ("Orijinal cümle: [{0}]", cümle);
            Console.WriteLine ("Boþluksuz cümle-1: [{0}]", new Regex ("\\s?").Replace (cümle, " "));
            Console.WriteLine ("Boþluksuz cümle-2: [{0}]", new Regex ("\\s+").Replace (cümle, " "));
            Console.WriteLine ("Boþluksuz cümle-3: [{0}]", new Regex ("\\s*").Replace (cümle, " "));
            Console.WriteLine ("Boþluksuz cümle-4: [{0}]", new Regex ("\\s*").Replace (cümle, ""));
            Console.WriteLine ("Boþluksuz cümle-5: [{0}]", new Regex ("\\s*").Replace (cümle, "_"));

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}