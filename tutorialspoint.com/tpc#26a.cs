// tpc#26a.cs: Verilen dizgedeki S/s harfle ba�layan kelimeler �rne�i.

using System;
using System.Text.RegularExpressions;
namespace D�zenliTabirler {
    class SsKelimeler {
        private static void uyanlar�G�ster (string dizge, string d�zTab) {
            Console.WriteLine ("Ara�t�r�lan dizge: " + dizge);
            Console.WriteLine ("Regexp kal�b�: " + d�zTab);
            MatchCollection uyanlar = Regex.Matches (dizge, d�zTab);
            foreach (Match uyan in uyanlar) {Console.WriteLine (uyan);}
        }
        static void Main() {
            Console.Write ("D�zenli-tabirlerin tan�mlanabilen �e�itli karakter, s�n�f ve yap� katagorileri mevcuttur. C# Regex s�n�f� Matches/e�le�en, Replace/yerde�i�tir ve Split/diziye-par�ala vb metodlar i�erir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string metin = "Semada binlerce say�da S�per Samanyolu g�ne�ler say�lm��t�r.";
            Console.WriteLine ("B�y�k 'S' harfiyle ba�layan kelimeler:"); uyanlar�G�ster (metin, @"\bS\S*");
            Console.WriteLine ("\nK���k 's' harfiyle ba�layan kelimeler:"); uyanlar�G�ster (metin, @"\bs\S*");

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}