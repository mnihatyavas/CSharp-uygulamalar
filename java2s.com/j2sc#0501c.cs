// j2sc#0501c.cs: Dizgelerde toupper, tolower, contains, isinterned, normalize metotlar� �rne�i.

using System;
using System.Text;
namespace Dizgeler {
    class String3 {
        private static void G�ster (string dizgeAd�, string dizge) {
            Console.Write ("{0} dizgesindeki \\uX4 karakterler = ", dizgeAd�);
            foreach (short x in dizge.ToCharArray()) {Console.Write ("{0:X4} ", x);}
        }
        static void IsInternedTesti (string dzg) {
            if (String.IsInterned (dzg) != null) Console.WriteLine ("\"{0}\" dizgesi enterne'dir.", dzg);
            else Console.WriteLine ("\"{0}\" dizgesi enterne de�ildir.", dzg);
        }
        static void Main() {
            Console.Write ("Replace, ReplaceAll gibidir. Contains bool true/false d�nd�r�r. IsInterned testinde dizge kendi veya ba�ka de�i�kenle �n yada arkas�na ibare eklenmi�se art�k �zellikle Intern uygulanmam��sa enterne de�ildir. Normalize, 'using System.Text' gerektirir ve 4 formu vard�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgenin ToUpper ve ToLower ile hepten b�y�kharfe/k���kharfe �evrilmesi:");
            Console.Write ("Ad ve soyad�n�z� girin: ");
            var dizge1 = Console.ReadLine();
            if (dizge1=="") dizge1="M.Nihat Yava�";
            Console.WriteLine ("Girilen = {0}", dizge1);
            Console.WriteLine ("B�y�k harfle = {0}", dizge1.ToUpper());
            Console.WriteLine ("K���k harfle = {0}", dizge1.ToLower());

            Console.WriteLine ("\nDizgeye Length, Contains, Replace metotlar�n� uygulama:");
            Console.WriteLine ("Girdi�iniz dizgede {0} karakter mevcut.", dizge1.Length);
            bool cevap=(dizge1.ToLower()).Contains ("a");
            Console.WriteLine ("Girdi�iniz dizgede \"{0}\" karakteri mevcut mu? {1}", "a", cevap);
            if (cevap) Console.WriteLine ("Mevcut \"{0}\"'lar� \"{1}\"'yle de�i�tir: {2}", "a", "0", dizge1.Replace ("a", "0"));

            Console.WriteLine ("\nDizgeye IsInterned ile eklemlilik testi uygulama:");
            dizge1 = "Otomatkmen Enternedir";
            string dizge2 = "==>" + dizge1;
            IsInternedTesti (dizge1);
            IsInternedTesti (dizge2);
            String.Intern (dizge2); IsInternedTesti (dizge2);
            dizge1 += "M." + "Nihat" + " " + "Yava�"; IsInternedTesti (dizge1);
            string dizge3 = ""; string dizge4 = "." + dizge3; IsInternedTesti (dizge3); IsInternedTesti (dizge4);
            dizge3 = " "; dizge4 = dizge3 + "."; IsInternedTesti (dizge3); IsInternedTesti (dizge4);
            dizge3 = "Nihat"; dizge4 = "M." + dizge3; IsInternedTesti (dizge3); IsInternedTesti (dizge4);

            Console.WriteLine ("\nDizgeye yal�n ve FormC-D-KC-KD Normalize normalle�tirme uygulama:");
            string dzg1 = new String ( new char[] {'\u0063', '\u0301', '\u0327', '\u00BE'});
            string dzg2 = null;
            G�ster ("dzg1", dzg1); Console.WriteLine ("\n\t==>Normalize mi? {0}; dzg1 = {1}", dzg1.IsNormalized(), dzg1);
            try {
                dzg2 = dzg1.Normalize(); G�ster ("dzg2", dzg2); Console.WriteLine ("\n\t==>Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized(), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormC); G�ster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormC Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormC), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormD); G�ster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormD Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormD), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormKC); G�ster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormKC Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormKC), dzg2);
                dzg2 = dzg1.Normalize (NormalizationForm.FormKD); G�ster ("dzg2", dzg2); Console.WriteLine ("\n\t==>FormKD Normalize mi? {0}; dzg2 = {1}", dzg2.IsNormalized (NormalizationForm.FormKD), dzg2);
            }catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}