// j2sc#0501c.cs: Dizgelerde toupper, tolower, contains, isinterned, normalize metotlarý örneði.

using System;
using System.Text;
namespace Dizgeler {
    class String3 {
        private static void Göster (string dizgeAdý, string dizge) {
            Console.Write ("{0} dizgesindeki \\uX4 karakterler = ", dizgeAdý);
            foreach (short x in dizge.ToCharArray()) {Console.Write ("{0:X4} ", x);}
        }
        static void IsInternedTesti (string dzg) {
            if (String.IsInterned (dzg) != null) Console.WriteLine ("\"{0}\" dizgesi enterne'dir.", dzg);
            else Console.WriteLine ("\"{0}\" dizgesi enterne deðildir.", dzg);
        }
        static void Main() {
            Console.Write ("Replace, ReplaceAll gibidir. Contains bool true/false döndürür. IsInterned testinde dizge kendi veya baþka deðiþkenle ön yada arkasýna ibare eklenmiþse artýk özellikle Intern uygulanmamýþsa enterne deðildir. Normalize, 'using System.Text' gerektirir ve 4 formu vardýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgenin ToUpper ve ToLower ile hepten büyükharfe/küçükharfe çevrilmesi:");
            Console.Write ("Ad ve soyadýnýzý girin: ");
            var dizge1 = Console.ReadLine();
            if (dizge1=="") dizge1="M.Nihat Yavaþ";
            Console.WriteLine ("Girilen = {0}", dizge1);
            Console.WriteLine ("Büyük harfle = {0}", dizge1.ToUpper());
            Console.WriteLine ("Küçük harfle = {0}", dizge1.ToLower());

            Console.WriteLine ("\nDizgeye Length, Contains, Replace metotlarýný uygulama:");
            Console.WriteLine ("Girdiðiniz dizgede {0} karakter mevcut.", dizge1.Length);
            bool cevap=(dizge1.ToLower()).Contains ("a");
            Console.WriteLine ("Girdiðiniz dizgede \"{0}\" karakteri mevcut mu? {1}", "a", cevap);
            if (cevap) Console.WriteLine ("Mevcut \"{0}\"'larý \"{1}\"'yle deðiþtir: {2}", "a", "0", dizge1.Replace ("a", "0"));

            Console.WriteLine ("\nDizgeye IsInterned ile eklemlilik testi uygulama:");
            dizge1 = "Otomatkmen Enternedir";
            string dizge2 = "==>" + dizge1;
            IsInternedTesti (dizge1);
            IsInternedTesti (dizge2);
            String.Intern (dizge2); IsInternedTesti (dizge2);
            dizge1 += "M." + "Nihat" + " " + "Yavaþ"; IsInternedTesti (dizge1);
            string dizge3 = ""; string dizge4 = "." + dizge3; IsInternedTesti (dizge3); IsInternedTesti (dizge4);
            dizge3 = " "; dizge4 = dizge3 + "."; IsInternedTesti (dizge3); IsInternedTesti (dizge4);
            dizge3 = "Nihat"; dizge4 = "M." + dizge3; IsInternedTesti (dizge3); IsInternedTesti (dizge4);

            Console.WriteLine ("\nDizgeye yalýn ve FormC-D-KC-KD Normalize normalleþtirme uygulama:");
            string dzg1 = new String ( new char[] {'\u0063', '\u0301', '\u0327', '\u00BE'});
            string dzg2 = null;
            Göster ("dzg1", dzg1); Console.WriteLine ("\n\t==>Normalize mi? {0}; dzg1 = {1}", dzg1.IsNormalized(), dzg1);
            try {
                dzg2 = dzg1.Normalize(); Göster ("dzg2", dzg2); Console.WriteLine ("\n\t==>Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized(), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormC); Göster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormC Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormC), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormD); Göster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormD Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormD), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormKC); Göster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormKC Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormKC), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormKD); Göster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormKD Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormKD), dzg2);
            }catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}