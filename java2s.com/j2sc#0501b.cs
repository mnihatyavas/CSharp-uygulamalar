// j2sc#0501b.cs: Dizgelerde join, split, indexof, insert, padleft, trim, substring metotlarý örneði.

using System;
namespace Dizgeler {
    class String2 {
        static void Main() {
            Console.Write ("Join \".\" dizgesel, Split ise '.' karaktersel ayraç kullanýr. IndexOf dizgesel ibare, IndexOfAny ise karakter-ler gerektirir. PadLeft/Right dizge aþan tamponu soldan/saðdan boþlukla/karakterle tamamlar; aþansýz etkisizdir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("String.Join ile dizgeleri ayraçlý birleþtirme:");
            string[] dizi1 = {"Olmak", "yada", "olmamak", "bütün", "mesele", "bu"};
            string sonuç1 = String.Join (".", dizi1);
            string sonuç2 = String.Join (":;", dizi1);
            Console.WriteLine ("{0} boyutlu dizi elemanlarýnýn \"{1}\" ayraçla birleþik dizgesi:\n\t\"{2}\"", dizi1.Length, ".", sonuç1);
            Console.WriteLine ("Ayný dizi elemanlarýnýn \"{0}\" ayraçla birleþik dizgesi:\n\t\"{1}\"", ":;", sonuç2);

            Console.WriteLine ("\nString.Split ile ayraçla birleþik dizgeyi tekrar dizi elemanlarýna ayrýþtýrma:");
            string[] dizi2 = sonuç1.Split ('.'); string[] dizi3 = sonuç2.Split (':');
            Console.WriteLine ("Birleþik \"{0}\" dizgeden dizi elemanlarýna:", sonuç1);
            foreach (string dzg in dizi2) {Console.WriteLine (dzg);}
            Console.WriteLine ("Birleþik \"{0}\" dizgeden dizi elemanlarýna:", sonuç2);
            foreach (string dzg in dizi3) {Console.WriteLine (dzg);}

            Console.WriteLine ("\nLast/IndexOf ile dizge içindeki ilk/son ibare endekslerinin tespiti:");
            Console.WriteLine ("Birleþik \"{0}\" dizgede ÝLK \"{1}\" endeksi = {2}", sonuç1, "olma", (sonuç1.ToLower()).IndexOf ("olma"));
            Console.WriteLine ("Ayný dizgede SON \"{0}\" ibaresinin endeksi = {1}", "olma", (sonuç1.ToLower()).LastIndexOf ("olma"));
            Console.WriteLine ("Ayný dizgede ÝLK \"{0}\" ibaresinin endeksi = {1}", "nihat", sonuç1.IndexOf ("nihat"));
            char[] krk1 = {'u', 'l', 'm', 'a'};
            Console.WriteLine ("Herhangibir 'u' + 'l' +'m' + 'a' karakterden ÝLK endeks = {0}: {1}", sonuç1.IndexOfAny (krk1), sonuç1 [sonuç1.IndexOfAny (krk1)]);
            Console.WriteLine ("Herhangibir 'u' + 'l' +'m' + 'a' karakterden SON endeks = {0}: {1}", sonuç1.LastIndexOfAny (krk1), sonuç1 [sonuç1.LastIndexOfAny (krk1)]);

            Console.WriteLine ("\nInsert, Remove, Replace ise dizge içinde sokma, silme, deðiþtirme:");
            Console.WriteLine ("Birleþik \"{0}\" dizgede araya \"ÝÞTE \" girme:\n\t{1}", sonuç1, sonuç1.Insert (19, "ÝÞTE "));
            Console.WriteLine ("Ayný dizgede aradan \"yada\" silme: {0}", sonuç1.Remove (6, 4));
            Console.WriteLine ("Ayný dizgede \".\"larý \":\" ile deðiþtirme: {0}", sonuç1.Replace ('.', ':'));
            Console.WriteLine ("Dizgede \"olma\"larý \"ÖLME\" ile deðiþtirme: {0}", (sonuç1.ToLower()).Replace ("olma", "ÖLME"));

            Console.WriteLine ("\nPadLeft/Right ile tamponu aþan dizge baþýný/sonunu boþluk/karakterle tamamlama:");
            Console.WriteLine ("Birleþik \"{0}\" dizgede aþan tampon ebatýný sol boþlukla tamamlama:\n\t({1})", sonuç1, sonuç1.PadLeft (40));
            Console.WriteLine ("Ayný dizgede aþan tampon ebatýný sol noktayla tamamlama:\n\t({0})", sonuç1.PadLeft (40, '.'));
            Console.WriteLine ("Ayný dizgede aþan tampon ebatýný sað boþlukla tamamlama:\n\t({0})", sonuç1.PadRight (40));
            Console.WriteLine ("Ayný dizgede aþan tampon ebatýný sað noktayla tamamlama:\n\t({0})", sonuç1.PadRight (40, '.'));

            Console.WriteLine ("\nTrim, TrimStart, TrimEnd ile dizgenin baþ-son/baþ/son boþluklarýnýn kýrpýlmasý:");
            string dizge1 = "      M.Nihat Yavaþ   ";
            Console.WriteLine ("({0}) dizgede Trim() = ({1})", dizge1, dizge1.Trim());
            Console.WriteLine ("Ayný dizgede TrimStart() = ({0})", dizge1.TrimStart());
            Console.WriteLine ("Ayný dizgede TrimEnd() = ({0})", dizge1.TrimEnd());
            dizge1 = "...Herkese Merhabalar!..";
            Console.WriteLine ("({0}) dizgede Trim ('.') = ({1})", dizge1, dizge1.Trim ('.'));
            Console.WriteLine ("Ayný dizgede TrimStart ('.') = ({0})", dizge1.TrimStart ('.'));
            Console.WriteLine ("Ayný dizgede TrimEnd ('.') = ({0})", dizge1.TrimEnd ('.'));

            Console.WriteLine ("\nSubstring ile dizgenin istenilen parçasýný alma:");
            Console.WriteLine ("Birleþik \"{0}\" dizgede Substring (19) =\n\t({1})", sonuç1, sonuç1.Substring (19));
            Console.WriteLine ("Ayný dizgede Substring (25, 6) = ({0})", sonuç1.Substring (25, 6));
            Console.WriteLine ("Ayný dizgede Substring (11, 7) = ({0})", sonuç1.Substring (11, 7));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}