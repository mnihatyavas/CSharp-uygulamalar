// tpc#26a.cs: Verilen dizgedeki S/s harfle baþlayan kelimeler örneði.

using System;
using System.Text.RegularExpressions;
namespace DüzenliTabirler {
    class SsKelimeler {
        private static void uyanlarýGöster (string dizge, string düzTab) {
            Console.WriteLine ("Araþtýrýlan dizge: " + dizge);
            Console.WriteLine ("Regexp kalýbý: " + düzTab);
            MatchCollection uyanlar = Regex.Matches (dizge, düzTab);
            foreach (Match uyan in uyanlar) {Console.WriteLine (uyan);}
        }
        static void Main() {
            Console.Write ("Düzenli-tabirlerin tanýmlanabilen çeþitli karakter, sýnýf ve yapý katagorileri mevcuttur. C# Regex sýnýfý Matches/eþleþen, Replace/yerdeðiþtir ve Split/diziye-parçala vb metodlar içerir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            string metin = "Semada binlerce sayýda Süper Samanyolu güneþler sayýlmýþtýr.";
            Console.WriteLine ("Büyük 'S' harfiyle baþlayan kelimeler:"); uyanlarýGöster (metin, @"\bS\S*");
            Console.WriteLine ("\nKüçük 's' harfiyle baþlayan kelimeler:"); uyanlarýGöster (metin, @"\bs\S*");

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}