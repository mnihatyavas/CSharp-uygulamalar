// tpc#26b.cs: Verilen dizgedeki m-e harflerle baþlayýp-biten kelimeler örneði.

using System;
using System.Text.RegularExpressions;
namespace DüzenliTabirler {
    class meKelimeler {
        private static void uyanlarýGöster (string dizge, string düzTab) {
            Console.WriteLine ("Araþtýrýlan dizge: " + dizge);
            Console.WriteLine ("Regexp kalýbý: " + düzTab);
            MatchCollection uyanlar = Regex.Matches (dizge, düzTab);
            foreach (Match uyan in uyanlar) {Console.WriteLine (uyan);}
        }
        static void Main() {
            Console.Write ("Kullanýlan Regex sýnýf metodu: Regex.Matches (dizge, düzTab)\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string metin1 = "Bu muayene mazide hiç mesele çýkarmadý.";
            string metin2 = "Bu elim ve þu eklemim bana çok elem veriyor.";
            Console.WriteLine ("Küçük 'm' harfiyle baþlayýp 'e'yle biten kelimeler:"); uyanlarýGöster (metin1,  @"\bm\S*e\b");
            Console.WriteLine ("\nKüçük 'e' harfiyle baþlayýp 'm'yle biten kelimeler:"); uyanlarýGöster (metin2,  @"\be\S*m\b");

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}