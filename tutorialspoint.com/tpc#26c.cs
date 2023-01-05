// tpc#26c.cs: Verilen dizgedeki ard���k birden fazla bo�luklar�n silinmesi �rne�i.

using System;
using System.Text.RegularExpressions;
namespace D�zenliTabirler {
    class Bo�lukSilme {
        static void Main() {
            Console.Write ("Birden fazla bo�luklar� silen Regex metodu: new Regex('kal�p').Replace(dizge, 'krk')\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string c�mle = "  Merhaba   d�nyal�lar!..    ";
            Console.WriteLine ("Orijinal c�mle: [{0}]", c�mle);
            Console.WriteLine ("Bo�luksuz c�mle-1: [{0}]", new Regex ("\\s?").Replace (c�mle, " "));
            Console.WriteLine ("Bo�luksuz c�mle-2: [{0}]", new Regex ("\\s+").Replace (c�mle, " "));
            Console.WriteLine ("Bo�luksuz c�mle-3: [{0}]", new Regex ("\\s*").Replace (c�mle, " "));
            Console.WriteLine ("Bo�luksuz c�mle-4: [{0}]", new Regex ("\\s*").Replace (c�mle, ""));
            Console.WriteLine ("Bo�luksuz c�mle-5: [{0}]", new Regex ("\\s*").Replace (c�mle, "_"));

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}