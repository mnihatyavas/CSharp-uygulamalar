// j2sc#1702.cs: 'Group grup in e�le�en.Groups' �rne�i.

using System;
using System.Text.RegularExpressions;
namespace D�zenli�fade {
    class D�zif {
        static void Main() {
            Console.Write ("Grup e�le�enlerine endeks no veya atamal� adla eri�ilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Regex'le xhtml etiket ve i�eri�in ikili gruplanmas�:");
            string kal�p = @"<([^>]+)>([^<]*)</(\1)>", t�mce = "<blockquote>M.Nihat Yava�, Toroslar / Mersin</blockquote>";
            Regex d�zif = new Regex (kal�p);
            Match uyan = d�zif.Match (t�mce);
            Console.WriteLine ("Uyumlu sonu�: {0}\nEtiket grubu: {1}\nAl�nt� grubu: {2}", uyan.Groups [0].Value, uyan.Groups [1].Value, uyan.Groups [2].Value);

            Console.WriteLine ("\nUyumlu ��l� IP adresin endeksli gruplardaki de�erleri:");
            int i;
            kal�p = @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])\." +
                    @"([01]?\d\d?|2[0-4]\d|25[0-5])";
            t�mce = "192.168.169.1 172.0.0.1 127.0.0.01";
            d�zif = new Regex (kal�p);
            uyan = d�zif.Match (t�mce);
            while (uyan.Success) {
                Console.WriteLine ("==>{0}.endeksteki uyumlu IP adres: {1}", uyan.Index, uyan.Value);
                Console.WriteLine ("Uyumlu IP adresteki gruplar:" );
                i=0;
                foreach (Group gr in uyan.Groups) Console.WriteLine ("\t{0}.grup) {1}.endekste: {2}", i++, gr.Index, gr.Value);
                uyan = uyan.NextMatch();
            }

            Console.WriteLine ("\nE�le�en be�li gsm'lerin alankod ve tlfno'lu grup detaylar�:");
            t�mce = "(800) 888-1211\n" +
                    "(212) 555-1212\n" +
                    "(506) 777-1213\n" +
                    "(650) 222-1214\n" +
                    "(888) 111-1215\n";
            string alankodkal�p = @"(?<akodGrup>\(\d\d\d\))",
            tlfKal�p = @"(?<tlfGrup>\d\d\d\-\d\d\d\d)";
            MatchCollection e�le�enler = Regex.Matches (t�mce, alankodkal�p + " " + tlfKal�p);
            Console.WriteLine ("Verili 5 �oksat�rl� t�mce:[\n{0}]", t�mce);
            foreach (Match e�le�en in e�le�enler) {
                Console.WriteLine ("==>Alan kodu = " + e�le�en.Groups ["akodGrup"]);
                Console.WriteLine ("Telefon no = " + e�le�en.Groups ["tlfGrup"]);
                i=0; foreach (Group gr in e�le�en.Groups) foreach (Capture kap in gr.Captures) Console.WriteLine ("{0}.grup = {1}", i++, kap.Value);
            }

            Console.WriteLine ("\nE�le�en ikili tarih, zaman, ip, site gruplu sunumlar:");
            t�mce = "2024/06/25 22:11:07 127.0.0.01 mnihatyavas.com" + " " +
                    "2024/06/25 22:23:47 1.0.0.172 hkacaryavas.com";
            kal�p = @"(?<tarih>(\d|\/)+)\s" +
                    @"(?<zaman>(\d|\:)+)\s" +
                    @"(?<ip>(\d|\.)+)\s" +
                    @"(?<site>\S+)";
            d�zif = new Regex (kal�p);
            e�le�enler = d�zif.Matches (t�mce);
            foreach (Match e�le�en in e�le�enler) {
                if (e�le�en.Length != 0) {
                    Console.WriteLine ("==>E�le�en: {0}", e�le�en.ToString());
                    Console.WriteLine ("\tTarih: {0}", e�le�en.Groups ["tarih"]);
                    Console.WriteLine ("\tZaman: {0}", e�le�en.Groups ["zaman"]);
                    Console.WriteLine ("\tIP adres: {0}", e�le�en.Groups ["ip"]);
                    Console.WriteLine ("\tSite: {0}", e�le�en.Groups ["site"]);
                }
            }

            Console.WriteLine ("\nTek Regex.Match uyan grup endeks ve de�erleri:");
            t�mce = "AA";
            kal�p = @"(\d+)*(\w)\2";
            uyan = Regex.Match (t�mce, kal�p);
            i=0;
            while (uyan.Groups [i].Value != "") {
                Console.WriteLine ("Grup[{0}].Value = {1}", i, uyan.Groups [i].Success ? uyan.Groups [i].Value : "Bo�");
                i++;
            }
            Group grup0 = uyan.Groups [0]; Console.WriteLine ("0.grup de�eri: {0}", grup0.Success ? grup0.Value : "Bo�");
            Group grup1 = uyan.Groups [1]; Console.WriteLine ("1.grup de�eri: {0}", grup1.Success ? grup1.Value : "Bo�");
            Group grup2 = uyan.Groups [2]; Console.WriteLine ("2.grup de�eri: {0}", grup2.Success ? grup2.Value : "Bo�");
            Group grup3 = uyan.Groups [3]; Console.WriteLine ("3.grup de�eri: {0}", grup3.Success ? grup3.Value : "Bo�");
            Group grup4 = uyan.Groups [4]; Console.WriteLine ("4.grup de�eri: {0}", grup4.Success ? grup4.Value : "Bo�");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}