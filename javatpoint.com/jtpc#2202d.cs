// jtpc#2202d.cs: D�zenliTabir kal�pla ard���k duble kelimelerin tespiti �rne�i.

using System;
using System.Text.RegularExpressions;
namespace �e�itli {
    class D�zenliTabirD {
        static void Main() {
            Console.Write ("Regex.Matches metoduyla dizgedeki ard���k duble kelime ve konumu tespit edilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kal�p = @"\b(\w+?)\s\1\b";
            string t�mce1 = "Welcome To to to JavaTPoint too. Here we can learn C# easily EASiLY easily way. Bu t�mceyi yava� yava� ve USul usul uzatal�m.";
            MatchCollection koleksiyon = Regex.Matches (t�mce1, kal�p, RegexOptions.IgnoreCase);
            int i=0; foreach (Match e� in koleksiyon) Console.WriteLine ("{0}) {1} (tekrarl� '{2}'); ilk endeksi: {3}", ++i, e�.Value, e�.Groups [1].Value, e�.Index);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}