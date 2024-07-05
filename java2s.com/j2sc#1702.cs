// j2sc#1702.cs: 'Group grup in eþleþen.Groups' örneði.

using System;
using System.Text.RegularExpressions;
namespace DüzenliÝfade {
    class Düzif {
        static void Main() {
            Console.Write ("Grup eþleþenlerine endeks no veya atamalý adla eriþilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Regex'le xhtml etiket ve içeriðin ikili gruplanmasý:");
            string kalýp = @"<([^>]+)>([^<]*)</(\1)>", tümce = "<blockquote>M.Nihat Yavaþ, Toroslar / Mersin</blockquote>";
            Regex düzif = new Regex (kalýp);
            Match uyan = düzif.Match (tümce);
            Console.WriteLine ("Uyumlu sonuç: {0}\nEtiket grubu: {1}\nAlýntý grubu: {2}", uyan.Groups [0].Value, uyan.Groups [1].Value, uyan.Groups [2].Value);

            Console.WriteLine ("\nUyumlu üçlü IP adresin endeksli gruplardaki deðerleri:");
            int i;
            kalýp = @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])";
            tümce = "192.168.169.1 172.0.0.1 127.0.0.01";
            düzif = new Regex (kalýp);
            uyan = düzif.Match (tümce);
            while (uyan.Success) {
                Console.WriteLine ("==>{0}.endeksteki uyumlu IP adres: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("Uyumlu IP adresteki gruplar:" );
                i=0;
                foreach (Group gr in uyan.Groups) Console.WriteLine ("\t{0}.grup) {1}.endekste: {2}", i++, gr.Index, gr.Value);
                uyan = uyan.NextMatch();
            }

            Console.WriteLine ("\nEþleþen beþli gsm'lerin alankod ve tlfno'lu grup detaylarý:");
            tümce = "(800) 888-1211\n" +
                    "(212) 555-1212\n" +
                    "(506) 777-1213\n" +
                    "(650) 222-1214\n" +
                    "(888) 111-1215\n";
            string alankodkalýp = @"(?<akodGrup>\(\d\d\d\))",
            tlfKalýp = @"(?<tlfGrup>\d\d\d\-\d\d\d\d)";
            MatchCollection eþleþenler = Regex.Matches (tümce, alankodkalýp + " " + tlfKalýp);
            Console.WriteLine ("Verili 5 çoksatýrlý tümce:[\n{0}]", tümce);
            foreach (Match eþleþen in eþleþenler) {
                Console.WriteLine ("==>Alan kodu = " + eþleþen.Groups ["akodGrup"]);
                Console.WriteLine ("Telefon no = " + eþleþen.Groups ["tlfGrup"]);
                i=0; foreach (Group gr in eþleþen.Groups) foreach (Capture kap in gr.Captures) Console.WriteLine ("{0}.grup = {1}", i++, kap.Value);
            }

            Console.WriteLine ("\nEþleþen ikili tarih, zaman, ip, site gruplu sunumlar:");
            tümce = "2024/06/25 22:11:07 127.0.0.01 mnihatyavas.com" + " " +
                    "2024/06/25 22:23:47 1.0.0.172 hkacaryavas.com";
            kalýp = @"(?<tarih>(\d|\/)+)\s" +
                    @"(?<zaman>(\d|\:)+)\s" +
                    @"(?<ip>(\d|\.)+)\s" +
                    @"(?<site>\S+)";
            düzif = new Regex (kalýp);
            eþleþenler = düzif.Matches (tümce);
            foreach (Match eþleþen in eþleþenler) {
                if (eþleþen.Length != 0) {
                    Console.WriteLine ("==>Eþleþen: {0}", eþleþen.ToString());
                    Console.WriteLine ("\tTarih: {0}", eþleþen.Groups ["tarih"]);
                    Console.WriteLine ("\tZaman: {0}", eþleþen.Groups ["zaman"]);
                    Console.WriteLine ("\tIP adres: {0}", eþleþen.Groups ["ip"]);
                    Console.WriteLine ("\tSite: {0}", eþleþen.Groups ["site"]);
                }
            }

            Console.WriteLine ("\nTek Regex.Match uyan grup endeks ve deðerleri:");
            tümce = "AA";
            kalýp = @"(\d+)*(\w)\2";
            uyan = Regex.Match (tümce, kalýp);
            i=0;
            while (uyan.Groups [i].Value != "") {
                Console.WriteLine ("Grup[{0}].Value = {1}", i, uyan.Groups [i].Success ? uyan.Groups [i].Value : "Boþ");
                i++;
            }
            Group grup0 = uyan.Groups [0]; Console.WriteLine ("0.grup deðeri: {0}", grup0.Success ? grup0.Value : "Boþ");
            Group grup1 = uyan.Groups [1]; Console.WriteLine ("1.grup deðeri: {0}", grup1.Success ? grup1.Value : "Boþ");
            Group grup2 = uyan.Groups [2]; Console.WriteLine ("2.grup deðeri: {0}", grup2.Success ? grup2.Value : "Boþ");
            Group grup3 = uyan.Groups [3]; Console.WriteLine ("3.grup deðeri: {0}", grup3.Success ? grup3.Value : "Boþ");
            Group grup4 = uyan.Groups [4]; Console.WriteLine ("4.grup deðeri: {0}", grup4.Success ? grup4.Value : "Boþ");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}