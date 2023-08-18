// j2sc#0505.cs: Concat metoduyla her tür veriyi dizgesel ekleme örneði.

using System;
namespace Dizgeler {
    class DizgeselEkleme {
        static void Main() {
            Console.Write ("Concat içi argümanlar virgüllü veya +'lý dizgesel veya sayýsal eklenebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Concat içi virgüllerle dizgeler ekleme:");
            string dizge1 = String.Concat ("Bu ", "bir ", "Concat ", "ekleme ","denemesi") + "dir." + " " + String.Concat ("Ardýþýk ", "eklemeler ", "mümkündür") + "."; 
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat içi +'larla dizgeler ekleme:");
            dizge1 = String.Concat ("M." + "Nihat " + "Yavas, " + "Yaþ: " + (2023 - 1957));
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat ile dizge, sayý, bool ekleme:");
            dizge1 = String.Concat ("Merhaba ", 23, " Nisan ", 2023D, " ", false, " ",  20.00F, " ", 3.45M, " ", true); //M: decimal
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat ile sayýyý ardýþýk dizgesel yada toplama sayýsal ekleme:");
            int ts1 = 2023 - 2005;
            dizge1 = "Yaþýn " + ts1 + " ha?";
            dizge1 += " Müthiþsin!..";
            Console.WriteLine ("Monolog: {0}", dizge1);
            dizge1  = 10 + 5 + " = 10 + 5\t2 + 3 = " + 2 + 3;
            Console.WriteLine ("Sayýsal ve dizgesel toplama : {0}", dizge1);
            dizge1 = 10 + 5 + " = 10 + 5\t2 + 3 = " + (2 + 3);
            Console.WriteLine ("Sayýsal ve sayýsal toplama : {0}", dizge1);

            Console.WriteLine ("\nConcat ile dizgesel dizi elemanlarýný doðrudan ekleme:");
            string[] dzgDizi = {"Merhaba ", "ve ", "hoþgeldin ", "bu ", "tümce ", "örneðine! "};
            Console.WriteLine ("Orijinal tümce dizisi: \"{0}\"", string.Concat (dzgDizi));
            Array.Sort (dzgDizi);
            Console.WriteLine ("Sýralý tümce dizisi: \"{0}\"", string.Concat (dzgDizi));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}