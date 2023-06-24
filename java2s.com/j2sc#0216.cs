// j2sc#0216.cs: Tüm ESC kontrol karakterleri, ascii/hex=unicode deðerleri ve etkinlikleri örneði.

using System;
namespace VeriTipleri {
    class EscDizisi {
        static void Main() {
            Console.Write ("ESC'nin geribölü-karakter etkinliðini deðil görünmesi isteniyorsa çift-geriyebölü kullanýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ESC'li karakter ve ASCII=HEX/Unicode no'su:");
            Console.WriteLine ("Tek týrnak: \\': {0} ({1}=0x{2:X4})", '\'', (int)'\'', (int)'\'');
            Console.WriteLine ("Çift týrnak: \\\": {0} ({1}=0x{2:X4})", '\"', (int)'\"', (int)'\"');
            Console.WriteLine ("Geribölü: \\\\: {0} ({1}=0x{2:X4})", '\\', (int)'\\', (int)'\\');
            Console.WriteLine ("Unicode null: \\0: {0} ({1}=0x{2:X4})", '\0', (int)'\0', (int)'\0');
            Console.WriteLine ("Dikkat zili: \\a: {0} ({1}=0x{2:X4})", '\a', (int)'\a', (int)'\a');
            Console.WriteLine ("Geriyisil: \\b: {0} ({1}=0x{2:X4})", '\b', (int)'\b', (int)'\b');
            Console.WriteLine ("Yatay sekme: \\t: {0} ({1}=0x{2:X4})", '\t', (int)'\t', (int)'\t');
            Console.WriteLine ("Dikey sekme: \\v: {0} ({1}=0x{2:X4})", '\v', (int)'\v', (int)'\v');
            Console.WriteLine ("Yeni satýr: \\n: {0} ({1}=0x{2:X4})", '\n', (int)'\n', (int)'\n');
            Console.WriteLine ("Enter \\r: {0} ({1}=0x{2:X4})", '\r', (int)'\r', (int)'\r');
            Console.WriteLine ("Form besle: \\f: {0} ({1}=0x{2:X4})", '\f', (int)'\f', (int)'\f');

            Console.WriteLine ("\n\\n ile dizge içinde yeni satýrbaþý yapma:");
            Console.WriteLine ("Ýlk satýr.\nÝkinci satýr.\nÜçüncü satýr.");

            Console.WriteLine ("\nYatay sekmelerle tablosal düzenleme:");
            Console.WriteLine ("Bir\tÝki\tÜç");
            Console.WriteLine ("Dört\tBeþ\tAltý");
            Console.WriteLine ("Yedi\tSekiz\tDokuz");

            Console.WriteLine ("\nTek-çift týrnaklarýn pasif karakterleþtirilmesi:");
            Console.WriteLine ("Dönüp, \"Neden?\", diye sordu.");
            Console.WriteLine ("\"N'abersin can\'kom?\", diye sordu.");

            char k1 = '\0';
            Console.WriteLine ("\nNull/Hiç karekterin hiçliði:");
            Console.WriteLine ("Null karakter [{0}=ascii({1})] ve görseli: [{2}]", "\\0", (int) k1, k1);

            Console.WriteLine ("\n@ karakteri dizin tek ESC\\'yi hatasýzlar. Çoklu satýr dizgelerini onaylar:"); 
            Console.WriteLine (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\iþli");
            //Console.WriteLine ("C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\iþli"); //Derleme hatasý
            string dzg1 = @"Bu cümle
                 çok 
                      çok 
                           uzundur.";
            /*string dzg2 = "Bu cümle
                 çok 
                      çok 
                           uzundur.";*/ //Derleme hatasý
            Console.WriteLine (dzg1);
            //Console.WriteLine (dzg2);

            Console.WriteLine ("\nHerkes 3-bip'li \"Selam Dünya!\"\a\a\a sloganýný sever.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}