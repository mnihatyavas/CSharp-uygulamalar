// jtpc#2202c.cs: DüzenliTabir kalýpla eþleþen karakterin boþlukla deðiþtirilmesi örneði.

using System;
using System.Text.RegularExpressions;
namespace Çeþitli {
    class DüzenliTabirC {
        static void Main() {
            Console.Write ("Enönemli RegExp metodlarý: IsMatch, Matches, Replace, Split\nÖrnekte büyük/küçük-harf, rakam, þ, _, ?, . ve @ harici karakterler yerine ' ' tek-boþluk konulmaktadýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string kalýp = "[^a-zA-Z0-9þ_?.@]+";
            string tümce = "Selam,hoþgeldin@JavaTPoint.com,iyi_misin?"; Console.WriteLine ("[{0}] ==> [{1}]", tümce, Regex.Replace (tümce, kalýp, " "));
            tümce = "Merhaba!2023:senesi,hoþgeldiniz&mny@gmail.com,iyi=misin?"; Console.WriteLine ("[{0}] ==> [{1}]", tümce, Regex.Replace (tümce, kalýp, " "));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}