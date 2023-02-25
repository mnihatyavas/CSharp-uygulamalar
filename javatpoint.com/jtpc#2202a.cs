// jtpc#2202a.cs: D�zenliTabir kal�pla e�le�en dizge de�erleri �rne�i.

using System;
using System.Text.RegularExpressions;
namespace �e�itli {
    class D�zenliTabirA {
        static void Main() {
            Console.Write ("RegExp ile verilen dizgenin tan�mlanan kal�pla uyumu kontrol edilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kal�p = @"\b[m]\w+"; //"m" harfiyle ba�layan kelimeler
            Regex dt1 = new Regex (kal�p);
            string k�nye = "M.Mithat Nemrut; mezitler - MERS�N";
            MatchCollection e�le�en1 = dt1.Matches (k�nye);
            Console.WriteLine ("[{0}] dizgesindeki ilkharf k���k-m'li kelimeler:", k�nye);
            for (int i = 0; i < e�le�en1.Count; i++) Console.Write (e�le�en1 [i].Value + " ");

            Regex dt2 = new Regex (kal�p, RegexOptions.IgnoreCase);
            MatchCollection e�le�en2 = dt2.Matches (k�nye);
            Console.WriteLine ("\n\n[{0}] dizgesindeki b�y�k/k���k-m'li kelimeler:", k�nye);
            for (int i = 0; i < e�le�en2.Count; i++) Console.Write (e�le�en2 [i].Value + " ");

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    }
}