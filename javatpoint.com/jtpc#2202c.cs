// jtpc#2202c.cs: D�zenliTabir kal�pla e�le�en karakterin bo�lukla de�i�tirilmesi �rne�i.

using System;
using System.Text.RegularExpressions;
namespace �e�itli {
    class D�zenliTabirC {
        static void Main() {
            Console.Write ("En�nemli RegExp metodlar�: IsMatch, Matches, Replace, Split\n�rnekte b�y�k/k���k-harf, rakam, �, _, ?, . ve @ harici karakterler yerine ' ' tek-bo�luk konulmaktad�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kal�p = "[^a-zA-Z0-9�_?.@]+";
            string t�mce = "Selam,ho�geldin@JavaTPoint.com,iyi_misin?"; Console.WriteLine ("[{0}] ==> [{1}]", t�mce, Regex.Replace (t�mce, kal�p, " "));
            t�mce = "Merhaba!2023:senesi,ho�geldiniz&mny@gmail.com,iyi=misin?"; Console.WriteLine ("[{0}] ==> [{1}]", t�mce, Regex.Replace (t�mce, kal�p, " "));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}