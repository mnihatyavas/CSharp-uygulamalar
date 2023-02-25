// jtpc#2202d.cs: DüzenliTabir kalýpla ardýþýk duble kelimelerin tespiti örneði.

using System;
using System.Text.RegularExpressions;
namespace Çeþitli {
    class DüzenliTabirD {
        static void Main() {
            Console.Write ("Regex.Matches metoduyla dizgedeki ardýþýk duble kelime ve konumu tespit edilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kalýp = @"\b(\w+?)\s\1\b";
            string tümce1 = "Welcome To to to JavaTPoint too. Here we can learn C# easily EASiLY easily way. Bu tümceyi yavaþ yavaþ ve USul usul uzatalým.";
            MatchCollection koleksiyon = Regex.Matches (tümce1, kalýp, RegexOptions.IgnoreCase);
            int i=0; foreach (Match eþ in koleksiyon) Console.WriteLine ("{0}) {1} (tekrarlý '{2}'); ilk endeksi: {3}", ++i, eþ.Value, eþ.Groups [1].Value, eþ.Index);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}