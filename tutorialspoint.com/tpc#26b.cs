// tpc#26b.cs: Verilen dizgedeki m-e harflerle ba�lay�p-biten kelimeler �rne�i.

using System;
using System.Text.RegularExpressions;
namespace D�zenliTabirler {
    class meKelimeler {
        private static void uyanlar�G�ster (string dizge, string d�zTab) {
            Console.WriteLine ("Ara�t�r�lan dizge: " + dizge);
            Console.WriteLine ("Regexp kal�b�: " + d�zTab);
            MatchCollection uyanlar = Regex.Matches (dizge, d�zTab);
            foreach (Match uyan in uyanlar) {Console.WriteLine (uyan);}
        }
        static void Main() {
            Console.Write ("Kullan�lan Regex s�n�f metodu: Regex.Matches (dizge, d�zTab)\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string metin1 = "Bu muayene mazide hi� mesele ��karmad�.";
            string metin2 = "Bu elim ve �u eklemim bana �ok elem veriyor.";
            Console.WriteLine ("K���k 'm' harfiyle ba�lay�p 'e'yle biten kelimeler:"); uyanlar�G�ster (metin1,  @"\bm\S*e\b");
            Console.WriteLine ("\nK���k 'e' harfiyle ba�lay�p 'm'yle biten kelimeler:"); uyanlar�G�ster (metin2,  @"\be\S*m\b");

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}