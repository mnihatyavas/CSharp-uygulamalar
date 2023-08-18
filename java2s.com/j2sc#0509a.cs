// j2sc#0509a.cs: Replace, Insert, Append ile dizgeyi de�i�tirme �rne�i.

using System;
using System.Text;
namespace Dizgeler {
    class De�i�tirme1 {
        static string Tersten1 (string dzg) {
            StringBuilder sb = new StringBuilder (dzg.Length);
            for (int i = 1; i <= dzg.Length; i++) sb.Append (dzg [(dzg.Length)-i]);
            return sb.ToString();
        }
        static string Tersten2 (string dzg) {
            StringBuilder sb = new StringBuilder (dzg.Length);
            foreach (char krk in dzg) sb.Insert (0, krk);
            return sb.ToString();
        }
        static void Main() {
            Console.Write ("CopyTo endeks ta�mas�z mevcudun �zerine yazarken, Insert araya yeni ibare girerek uzunlu�u art�r�r. Replace ise mevcut bulunan ibareyi yenisiyle de�i�tirip uzunlu�u -+de�i�tirebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Insert ile araya dizgesel veri girme:");
            string dizge1 = "Zafer Candan";
            Console.WriteLine ("Original dizge1: {0},\tUzunlu�u = {1}", dizge1, dizge1.Length);
            dizge1 = dizge1.Insert (6, "Nihat ");
            Console.WriteLine ("Insert sonras� dizge1: {0},\tUzunlu�u = {1}", dizge1, dizge1.Length);

            Console.WriteLine ("\nReplace ile bulunan�n t�m�n� yenisiyle de�i�tirme:");
            dizge1 = "Canan Eskio�lu";
            Console.WriteLine ("Original dizge1: {0},\tUzunlu�u = {1}", dizge1, dizge1.Length);
            dizge1 = dizge1.Replace ("Eskio�lu", "Candan");
            Console.WriteLine ("Replace sonras� dizge1: {0},\tUzunlu�u = {1}", dizge1, dizge1.Length);
            Console.WriteLine ("Ge�ici Replace sonras� dizge1: {0},\tUzunlu�u = {1}", dizge1.Replace ("a", "oi"), dizge1.Length);
            string dizge2 = "QXW";
            Console.WriteLine ("Ge�ici Replace sonras� dizge1: {0},\tUzunlu�u = {1}", dizge1.Replace ("a", dizge2), dizge1.Length);

            Console.WriteLine ("\nBo� StringBuilder'e Append ve Insert ile dizge tersletme:");
            dizge1 = "abc�defg�h�ijklmno�prs�tu�vyz1234567890";
            dizge1 = Tersten1 (dizge1); Console.WriteLine ("StringBuilder ve Append ile tersleme: " + dizge1);
            dizge1 = Tersten2 (dizge1); Console.WriteLine ("SB ve Insert ile tersi tersleme: " + dizge1);

            Console.WriteLine ("\n'Array.Reverse(kDizi)'yle terslenen d�z�yle e�se palindrom'dur:");
            char[] ge�ici;
       gir: Console.Write ("Bir tersd�ze� girin [son]: "); dizge1 = Console.ReadLine();
            dizge2 = dizge1.Replace (" ", "").ToLower();
            if (dizge2 == "son") goto son; if (dizge2.Length < 3) goto gir;
            ge�ici = dizge2.ToCharArray();
            Array.Reverse (ge�ici);
            if (dizge2 == new string (ge�ici)) Console.WriteLine ("\"{0}\" bir Tersd�ze� Palindrom'dur.", dizge1);
            else Console.WriteLine ("\"{0}\" bir Tersd�ze� Palindrom DE��LD�R.", dizge1);
            goto gir;

       son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}