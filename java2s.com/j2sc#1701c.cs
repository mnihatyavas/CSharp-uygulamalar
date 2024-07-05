// j2sc#1701c.cs: Matches, Replace ve Split'le Regex eþleþenleri örneði.

using System;
using System.Text.RegularExpressions; //Regex için
using System.Text; //StringBuilder için
namespace DüzenliÝfade {
    class RegexC {
        static void ManüelGüvenliGöster() {
            Console.WriteLine ("Geçerli kredi kart numarasýnýn sadece ilk ve son dörtlüsü görülmelidir:");
            Regex düzif = new Regex (@"\d{4}");
            string kartNo = "1203-8215-6410-3279";
            if (düzif.Matches (kartNo).Count < 4 ) {
                Console.WriteLine ("Geçersiz kredi kart numarasý");
                return;
            }
            foreach (Match uyan in düzif.Matches (kartNo)) {
                if (uyan.Success == false ) {
                    Console.WriteLine ("Geçersiz kredi kart numarasý");
                    return;
                }
                if (uyan.Index == 5 || uyan.Index == 10) Console.WriteLine ("-xxxx-");
                else Console.WriteLine (uyan.Value);
            }
        }
        static void Main() {
            Console.Write ("'foreach(Match eþleþen in Regex.Matches(tümce,kalýp))'la tümcede kalýba uyanlarýn koleksiyonu tek tek sergilenebilmektedir. Uyumlu tümce1 'düzif.Replace(tümce1,tümce2)'le tümce2 olur. Uyumlu tümce 'düzif.Split(tümce,kalýp)'la kelimelerine ayrýþtýrýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("'MatchCollection eþleþenler = Regex.Matches(tümce,kalýp)'la uyan koleksiyonu:");
            Console.WriteLine ("==>Çoklusatýrlý tümcede kalýba uyan kelimeler:");
            string kalýp = @"^\G\d+$\n?", tümce = "1881\n1919\n1923\n1938"; int i=0;
            Regex düzif = new Regex (kalýp, RegexOptions.Multiline);
            Match uyanlar = düzif.Match (tümce);
            do {Console.Write ("{0}.eþleþen: {1}", ++i, uyanlar.Value);
            }while ((uyanlar = uyanlar.NextMatch()).Success);
            Console.WriteLine ("\n==>Verili tümcedeki kelimelerin listesi:");
            tümce = "M.Nihat Yavaþ Toroslar - Mersin / TR "; i=0;
            kalýp = @"(\S+)\s";
            düzif = new Regex (kalýp);
            MatchCollection eþleþenler = düzif.Matches (tümce);
            foreach (Match eþleþen in eþleþenler) {
                if (eþleþen.Length != 0) Console.WriteLine ("{0}.kelime: {1}", ++i, eþleþen.ToString());
            }
            Console.WriteLine ("==>Çevrimiçi tavla oyun eþleþenleri:");
            tümce = "03:15:27 nihat 127.0.0.1 sabri";
            düzif = new Regex (
                @"(?<zaman>(\d|\:)+)\s" +
                @"(?<oyuncu>\S+)\s" +
                @"(?<ip>(\d|\.)+)\s" +
                @"(?<oyuncu>\S+)");
            eþleþenler = düzif.Matches (tümce);
            foreach (Match eþleþen in eþleþenler) {
                if (eþleþen.Length != 0) {
                    Console.WriteLine ("Eþleþen: {0}", eþleþen.ToString());
                    Console.WriteLine ("Zaman: {0}", eþleþen.Groups ["zaman"]);
                    Console.WriteLine ("IP: {0}", eþleþen.Groups ["ip"]);
                    Console.WriteLine ("Oyuncular:");
                    i=0;
                    foreach (Capture kiþi in eþleþen.Groups ["oyuncu"].Captures) Console.WriteLine ("\t{0}.oyuncu: {1}", ++i, kiþi.ToString());
                }
            }
            Console.WriteLine (@"==>'[ae]t\s\S+?[\s|\p{P}]' kalýpla eþleþenler:");
            kalýp = @"[ae]t\s\S+?[\s|\p{P}]";
            tümce = "Mahmut Nihat Yavaþ, Toroslar - Mersin / TR "; i=0;
            eþleþenler = Regex.Matches (tümce, kalýp);
            foreach (Match eþleþen in eþleþenler) Console.WriteLine ("{0}.eþleþen: {1}", ++i, eþleþen.Value);
            Console.WriteLine (@"==>'\b[A-Z]\w*\b' kalýpla eþleþenler:");
            kalýp = @"\b[A-Z]\w*\b";
            i=0;
            eþleþenler = Regex.Matches (tümce, kalýp);
            foreach (Match eþleþen in eþleþenler) Console.WriteLine ("{0}.eþleþen: {1}", ++i, eþleþen.Value);
            Console.WriteLine (@"==>'\bth[^o]\w+\b' kalýpla eþleþenler:");
            kalýp = @"\bTo[^o]\w+\b";
            i=0;
            foreach (Match eþleþen in Regex.Matches (tümce, kalýp)) Console.WriteLine ("{0}.eþleþen: {1}", ++i, eþleþen.Value);

            Console.WriteLine ("\nKredi kart no'sunun Regex.Replace'le güvenli gösterimi:");
            kalýp = @"(\d{4})-(\d{4})-(\d{4})-(\d{4})";
            düzif = new Regex (kalýp);
            string güvenliKartno = "$1-xxxx-xxxx-$4", kartNo = "1203-8215-6410-3279";
            Console.WriteLine ("Regex: '{0}', kartno: '{1}'yla uyumlu mu? {2}", düzif, kartNo, düzif.IsMatch (kartNo));
            Console.WriteLine ("Güvenli kartno görüntüsü = {0}", düzif.Replace (kartNo, güvenliKartno));
            ManüelGüvenliGöster();

            Console.WriteLine ("\nTümce'nin Regex.Split'le kelimelerine ayrýlmasý:");
            tümce = "Bir, Ýki, Üç, M.Nihat Yavaþ, Ltd.Þti.";
            StringBuilder sb = new StringBuilder();
            i=0;
            foreach (string ibare in Regex.Split (tümce, " |, ")) sb.AppendFormat ("{0}.ayrým: {1}\n", ++i, ibare);
            Console.WriteLine (sb);

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    } 
}