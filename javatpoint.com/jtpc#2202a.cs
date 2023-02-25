// jtpc#2202a.cs: DüzenliTabir kalýpla eþleþen dizge deðerleri örneði.

using System;
using System.Text.RegularExpressions;
namespace Çeþitli {
    class DüzenliTabirA {
        static void Main() {
            Console.Write ("RegExp ile verilen dizgenin tanýmlanan kalýpla uyumu kontrol edilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kalýp = @"\b[m]\w+"; //"m" harfiyle baþlayan kelimeler
            Regex dt1 = new Regex (kalýp);
            string künye = "M.Mithat Nemrut; mezitler - MERSÝN";
            MatchCollection eþleþen1 = dt1.Matches (künye);
            Console.WriteLine ("[{0}] dizgesindeki ilkharf küçük-m'li kelimeler:", künye);
            for (int i = 0; i < eþleþen1.Count; i++) Console.Write (eþleþen1 [i].Value + " ");

            Regex dt2 = new Regex (kalýp, RegexOptions.IgnoreCase);
            MatchCollection eþleþen2 = dt2.Matches (künye);
            Console.WriteLine ("\n\n[{0}] dizgesindeki büyük/küçük-m'li kelimeler:", künye);
            for (int i = 0; i < eþleþen2.Count; i++) Console.Write (eþleþen2 [i].Value + " ");

            Console.Write ("\n\nTuþ..."); Console.ReadKey();
        }
    }
}