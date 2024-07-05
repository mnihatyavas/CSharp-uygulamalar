// j2sc#1701a.cs: Regex'le Split, Replace, IsMatch ve Match örneði.

using System;
using System.Text.RegularExpressions; //Regex için
using System.Text; //StringBuilder için
namespace DüzenliÝfade {
    class RegexA {
        static string IPTersi (Match eþleþtir) {
            StringBuilder sb = new StringBuilder();
            sb.Append (eþleþtir.Groups ["parça4"] + ".");
            sb.Append (eþleþtir.Groups ["parça3"] + ".");
            sb.Append (eþleþtir.Groups ["parça2"] + ".");
            sb.Append (eþleþtir.Groups ["parça1"]);
            return sb.ToString();
        }
        static void Main() {
            Console.Write ("Tümceyi ayrýþtýran Regex düzenli ifade new Regex(@\"kalýp\")'la tanýmlanýr. Araþtýrma çeþitleri: düzif.Split(tümce), düzif.Replace(tümce1,tümce2), düzif.IsMatch(kelime), düzif.Match(kelime).Value.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Tümce'deki herbir kelimeyi ayrýþtýran Regex:");
            string tümce = "M. Nihat Yavaþ Toroslar - Mersin / TR";
            int i=0;
            Regex düzif = new Regex (@" | ");
            foreach (string kelime in düzif.Split (tümce)) Console.WriteLine ("{0}.kelime: {1}", ++i, kelime);
            tümce = "Bir,Ýki,Üç, Ltd.Þti., A.Þ."; string kalýp = " |, |,"; düzif = new Regex (kalýp);
            StringBuilder sb = new StringBuilder();
            i = 1;
            foreach (string ibare in düzif.Split (tümce)) sb.AppendFormat ("{0}: {1}\n", i++, ibare);
            Console.WriteLine ("{0}", sb);

            Console.WriteLine ("IP adres kalýbýný sorgulayan Regex:");
            tümce = "192.168.199.1";
            kalýp = @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])";
            düzif = new Regex (kalýp);
            Console.WriteLine ("Verilen IP --> {0}", düzif.Replace (tümce, "xxx.xxx.xxx.xxx"));

            Console.WriteLine ("\nIP adres kalýbýný tersleyen Regex:");
            kalýp = @"(?<parça1>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça2>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça3>[01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"(?<parça4>[01]?\d\d?|2[0-4]\d|25[0-5])";
            düzif = new Regex (kalýp);
            string tümce1 = @"${parça4}.${parça3}.${parça2}.${parça1}";
            Console.WriteLine ("Verilen IP={0}\tTersi={1}", tümce, düzif.Replace (tümce, tümce1));
            //Diðer bir yöntem
            MatchEvaluator tümce2 = new MatchEvaluator (IPTersi);
            Console.WriteLine ("Verilen IP={0}\tTersi={1}", tümce, düzif.Replace (tümce, tümce2));

            Console.WriteLine ("\nÝlk krk sayý, sonrakiler farketmezle eþleþen Regex:");
            düzif = new Regex ("^\\d+"); //Ýlk krk sayý, sonrakiler farketmez
            string[] kelimeler = new string[] {"123abc", "abc123", "123", "abc", "a123bc"};
            i=0;
            foreach (string kelime in kelimeler) Console.WriteLine ("{0}.kelime ({1}) eþleþiyor mu? {2}", ++i, kelime, düzif.IsMatch (kelime));
            //Diðer bir yöntem
            düzif = new Regex (@"\d+$"); //Sonu sayýyla bitmeli
            i=0;
            Console.WriteLine ("\t==>Sonu sayýyla bitmeli");
            foreach (string kelime in kelimeler) Console.WriteLine ("\t{0}.kelime ({1}) eþleþiyor mu? {2}", ++i, kelime, düzif.IsMatch (kelime));
            //Diðer bir yöntem
            düzif = new Regex ("^\\d+$"); //Sonu sayýyla bitmeli
            i=0;
            Console.WriteLine ("==>Ýlki ve sonu sayýyla bitmeli");
            foreach (string kelime in kelimeler) Console.WriteLine ("{0}.kelime ({1}) eþleþiyor mu? {2}", ++i, kelime, düzif.IsMatch (kelime));

            Console.WriteLine ("\nBaþýnda abc veya xyz üçlü'den biri bulunanla eþleþen Regex:");
            düzif = new Regex ("(abc)|(xyz)*");
            tümce = "M.Nihat Yavaþ"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce));
            tümce = "xyzM.Nihat Yavaþ"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce));
            tümce = "M.Nihat Yavaþxyzabc"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce));
            tümce = "xyzabcM.Nihat Yavaþ"; Console.WriteLine ("'{0}' eþleþiyor mu? {1}", tümce, düzif.IsMatch (tümce)); //Match doðru fakat IsMatch her tümce'ye True demekte
            tümce = ""; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce));
            tümce = "abcM.Nihat Yavaþxyz"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce).Value);
            tümce = "xyzabcxyz"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce).Value);
            tümce = "M.Nihat Yavaþxyz"; Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce).Value);
            düzif = new Regex ("((?:abc)|(?:xyz))*"); tümce = "abcabcMNYxyzabc";
            Console.WriteLine ("'{0}' eþleþiyor mu? {1}", tümce, düzif.IsMatch (tümce));
            Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce).Value);
            tümce = "abcabcxyzabc"; Console.WriteLine ("'{0}' eþleþiyor mu? {1}", tümce, düzif.IsMatch (tümce));
            Console.WriteLine ("'{0}' ile eþleþen: [{1}]", tümce, düzif.Match (tümce).Value);

            Console.WriteLine ("\nÇeþitli kalýp, düzif, tümce'li IsMatch ve Match sonuçlarý:");
            kalýp = "((?:abc)|(?:xyz))*"; düzif = new Regex (kalýp); tümce = "abcabcxyzabc";
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce, kalýp, düzif.IsMatch (tümce));
            kalýp = @"(?(^\d)^\d+$|^\D+$)"; düzif = new Regex (kalýp); tümce = "kedi de";
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce, kalýp, düzif.IsMatch (tümce));
            tümce = "5 kedi de";
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce, kalýp, düzif.IsMatch (tümce));
            kalýp = @"<[^>]+>[^<]*</[^>]+>"; düzif = new Regex (kalýp); tümce = "<M>S</M>";
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce, kalýp, düzif.IsMatch (tümce));
            tümce1 = "<M>S</I>"; Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce1, kalýp, düzif.IsMatch (tümce1));
            kalýp = @"<([^>]+)>[^<]*</(\1)>";
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce, kalýp, düzif.IsMatch (tümce));
            Console.WriteLine ("'{0}' tümce, '{1}' kalýplý Regex'le eþleþiyor mu? {2}", tümce1, kalýp, düzif.IsMatch (tümce1)); //Hatalý, False olmalýydý
            kalýp = @"((abc)*)x(\1)"; düzif = new Regex (kalýp); tümce = "abcabcabcxabc";
            Console.WriteLine ("'{0}' tümcede, '{1}' kalýplý Regex'le eþleþen dðr: {2}", tümce, kalýp, düzif.Match (tümce).Value);
            kalýp = @"(^\d+$\n)+"; düzif = new Regex (kalýp, RegexOptions.Multiline); tümce = "987987\n129821\n20241806";
            Console.WriteLine ("'{0}' çoklusatýr tümcede, '{1}' kalýplý Regex'le eþleþen ilk deðer: {2}", tümce, kalýp, düzif.Match (tümce).Value);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    } 
}