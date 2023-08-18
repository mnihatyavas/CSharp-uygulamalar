// j2sc#0509a.cs: Replace, Insert, Append ile dizgeyi deðiþtirme örneði.

using System;
using System.Text;
namespace Dizgeler {
    class Deðiþtirme1 {
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
            Console.Write ("CopyTo endeks taþmasýz mevcudun üzerine yazarken, Insert araya yeni ibare girerek uzunluðu artýrýr. Replace ise mevcut bulunan ibareyi yenisiyle deðiþtirip uzunluðu -+deðiþtirebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Insert ile araya dizgesel veri girme:");
            string dizge1 = "Zafer Candan";
            Console.WriteLine ("Original dizge1: {0},\tUzunluðu = {1}", dizge1, dizge1.Length);
            dizge1 = dizge1.Insert (6, "Nihat ");
            Console.WriteLine ("Insert sonrasý dizge1: {0},\tUzunluðu = {1}", dizge1, dizge1.Length);

            Console.WriteLine ("\nReplace ile bulunanýn tümünü yenisiyle deðiþtirme:");
            dizge1 = "Canan Eskioðlu";
            Console.WriteLine ("Original dizge1: {0},\tUzunluðu = {1}", dizge1, dizge1.Length);
            dizge1 = dizge1.Replace ("Eskioðlu", "Candan");
            Console.WriteLine ("Replace sonrasý dizge1: {0},\tUzunluðu = {1}", dizge1, dizge1.Length);
            Console.WriteLine ("Geçici Replace sonrasý dizge1: {0},\tUzunluðu = {1}", dizge1.Replace ("a", "oi"), dizge1.Length);
            string dizge2 = "QXW";
            Console.WriteLine ("Geçici Replace sonrasý dizge1: {0},\tUzunluðu = {1}", dizge1.Replace ("a", dizge2), dizge1.Length);

            Console.WriteLine ("\nBoþ StringBuilder'e Append ve Insert ile dizge tersletme:");
            dizge1 = "abcçdefgðhýijklmnoöprsþtuüvyz1234567890";
            dizge1 = Tersten1 (dizge1); Console.WriteLine ("StringBuilder ve Append ile tersleme: " + dizge1);
            dizge1 = Tersten2 (dizge1); Console.WriteLine ("SB ve Insert ile tersi tersleme: " + dizge1);

            Console.WriteLine ("\n'Array.Reverse(kDizi)'yle terslenen düzüyle eþse palindrom'dur:");
            char[] geçici;
       gir: Console.Write ("Bir tersdüzeþ girin [son]: "); dizge1 = Console.ReadLine();
            dizge2 = dizge1.Replace (" ", "").ToLower();
            if (dizge2 == "son") goto son; if (dizge2.Length < 3) goto gir;
            geçici = dizge2.ToCharArray();
            Array.Reverse (geçici);
            if (dizge2 == new string (geçici)) Console.WriteLine ("\"{0}\" bir Tersdüzeþ Palindrom'dur.", dizge1);
            else Console.WriteLine ("\"{0}\" bir Tersdüzeþ Palindrom DEÐÝLDÝR.", dizge1);
            goto gir;

       son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}