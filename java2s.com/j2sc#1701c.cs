// j2sc#1701c.cs: Matches, Replace ve Split'le Regex e�le�enleri �rne�i.

using System;
using System.Text.RegularExpressions; //Regex i�in
using System.Text; //StringBuilder i�in
namespace D�zenli�fade {
    class RegexC {
        static void Man�elG�venliG�ster() {
            Console.WriteLine ("Ge�erli kredi kart numaras�n�n sadece ilk ve son d�rtl�s� g�r�lmelidir:");
            Regex d�zif = new Regex (@"\d{4}");
            string kartNo = "1203-8215-6410-3279";
            if (d�zif.Matches (kartNo).Count < 4 ) {
                Console.WriteLine ("Ge�ersiz kredi kart numaras�");
                return;
            }
            foreach (Match uyan in d�zif.Matches (kartNo)) {
                if (uyan.Success == false ) {
                    Console.WriteLine ("Ge�ersiz kredi kart numaras�");
                    return;
                }
                if (uyan.Index == 5 || uyan.Index == 10) Console.WriteLine ("-xxxx-");
                else Console.WriteLine (uyan.Value);
            }
        }
        static void Main() {
            Console.Write ("'foreach(Match e�le�en in Regex.Matches(t�mce,kal�p))'la t�mcede kal�ba uyanlar�n koleksiyonu tek tek sergilenebilmektedir. Uyumlu t�mce1 'd�zif.Replace(t�mce1,t�mce2)'le t�mce2 olur. Uyumlu t�mce 'd�zif.Split(t�mce,kal�p)'la kelimelerine ayr��t�r�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'MatchCollection e�le�enler = Regex.Matches(t�mce,kal�p)'la uyan koleksiyonu:");
            Console.WriteLine ("==>�oklusat�rl� t�mcede kal�ba uyan kelimeler:");
            string kal�p = @"^\G\d+$\n?", t�mce = "1881\n1919\n1923\n1938"; int i=0;
            Regex d�zif = new Regex (kal�p, RegexOptions.Multiline);
            Match uyanlar = d�zif.Match (t�mce);
            do {Console.Write ("{0}.e�le�en: {1}", ++i, uyanlar.Value);
            }while ((uyanlar = uyanlar.NextMatch()).Success);
            Console.WriteLine ("\n==>Verili t�mcedeki kelimelerin listesi:");
            t�mce = "M.Nihat Yava� Toroslar - Mersin / TR "; i=0;
            kal�p = @"(\S+)\s";
            d�zif = new Regex (kal�p);
            MatchCollection e�le�enler = d�zif.Matches (t�mce);
            foreach (Match e�le�en in e�le�enler) {
                if (e�le�en.Length != 0) Console.WriteLine ("{0}.kelime: {1}", ++i, e�le�en.ToString());
            }
            Console.WriteLine ("==>�evrimi�i tavla oyun e�le�enleri:");
            t�mce = "03:15:27 nihat 127.0.0.1 sabri";
            d�zif = new Regex (
                @"(?<zaman>(\d|\:)+)\s" +
                @"(?<oyuncu>\S+)\s" +
                @"(?<ip>(\d|\.)+)\s" +
                @"(?<oyuncu>\S+)");
            e�le�enler = d�zif.Matches (t�mce);
            foreach (Match e�le�en in e�le�enler) {
                if (e�le�en.Length != 0) {
                    Console.WriteLine ("E�le�en: {0}", e�le�en.ToString());
                    Console.WriteLine ("Zaman: {0}", e�le�en.Groups ["zaman"]);
                    Console.WriteLine ("IP: {0}", e�le�en.Groups ["ip"]);
                    Console.WriteLine ("Oyuncular:");
                    i=0;
                    foreach (Capture ki�i in e�le�en.Groups ["oyuncu"].Captures) Console.WriteLine ("\t{0}.oyuncu: {1}", ++i, ki�i.ToString());
                }
            }
            Console.WriteLine (@"==>'[ae]t\s\S+?[\s|\p{P}]' kal�pla e�le�enler:");
            kal�p = @"[ae]t\s\S+?[\s|\p{P}]";
            t�mce = "Mahmut Nihat Yava�, Toroslar - Mersin / TR "; i=0;
            e�le�enler = Regex.Matches (t�mce, kal�p);
            foreach (Match e�le�en in e�le�enler) Console.WriteLine ("{0}.e�le�en: {1}", ++i, e�le�en.Value);
            Console.WriteLine (@"==>'\b[A-Z]\w*\b' kal�pla e�le�enler:");
            kal�p = @"\b[A-Z]\w*\b";
            i=0;
            e�le�enler = Regex.Matches (t�mce, kal�p);
            foreach (Match e�le�en in e�le�enler) Console.WriteLine ("{0}.e�le�en: {1}", ++i, e�le�en.Value);
            Console.WriteLine (@"==>'\bth[^o]\w+\b' kal�pla e�le�enler:");
            kal�p = @"\bTo[^o]\w+\b";
            i=0;
            foreach (Match e�le�en in Regex.Matches (t�mce, kal�p)) Console.WriteLine ("{0}.e�le�en: {1}", ++i, e�le�en.Value);

            Console.WriteLine ("\nKredi kart no'sunun Regex.Replace'le g�venli g�sterimi:");
            kal�p = @"(\d{4})-(\d{4})-(\d{4})-(\d{4})";
            d�zif = new Regex (kal�p);
            string g�venliKartno = "$1-xxxx-xxxx-$4", kartNo = "1203-8215-6410-3279";
            Console.WriteLine ("Regex: '{0}', kartno: '{1}'yla uyumlu mu? {2}", d�zif, kartNo, d�zif.IsMatch (kartNo));
            Console.WriteLine ("G�venli kartno g�r�nt�s� = {0}", d�zif.Replace (kartNo, g�venliKartno));
            Man�elG�venliG�ster();

            Console.WriteLine ("\nT�mce'nin Regex.Split'le kelimelerine ayr�lmas�:");
            t�mce = "Bir, �ki, ��, M.Nihat Yava�, Ltd.�ti.";
            StringBuilder sb = new StringBuilder();
            i=0;
            foreach (string ibare in Regex.Split (t�mce, " |, ")) sb.AppendFormat ("{0}.ayr�m: {1}\n", ++i, ibare);
            Console.WriteLine (sb);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    } 
}