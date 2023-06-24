// j2sc#0216.cs: T�m ESC kontrol karakterleri, ascii/hex=unicode de�erleri ve etkinlikleri �rne�i.

using System;
namespace VeriTipleri {
    class EscDizisi {
        static void Main() {
            Console.Write ("ESC'nin gerib�l�-karakter etkinli�ini de�il g�r�nmesi isteniyorsa �ift-geriyeb�l� kullan�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("ESC'li karakter ve ASCII=HEX/Unicode no'su:");
            Console.WriteLine ("Tek t�rnak: \\': {0} ({1}=0x{2:X4})", '\'', (int)'\'', (int)'\'');
            Console.WriteLine ("�ift t�rnak: \\\": {0} ({1}=0x{2:X4})", '\"', (int)'\"', (int)'\"');
            Console.WriteLine ("Gerib�l�: \\\\: {0} ({1}=0x{2:X4})", '\\', (int)'\\', (int)'\\');
            Console.WriteLine ("Unicode null: \\0: {0} ({1}=0x{2:X4})", '\0', (int)'\0', (int)'\0');
            Console.WriteLine ("Dikkat zili: \\a: {0} ({1}=0x{2:X4})", '\a', (int)'\a', (int)'\a');
            Console.WriteLine ("Geriyisil: \\b: {0} ({1}=0x{2:X4})", '\b', (int)'\b', (int)'\b');
            Console.WriteLine ("Yatay sekme: \\t: {0} ({1}=0x{2:X4})", '\t', (int)'\t', (int)'\t');
            Console.WriteLine ("Dikey sekme: \\v: {0} ({1}=0x{2:X4})", '\v', (int)'\v', (int)'\v');
            Console.WriteLine ("Yeni sat�r: \\n: {0} ({1}=0x{2:X4})", '\n', (int)'\n', (int)'\n');
            Console.WriteLine ("Enter \\r: {0} ({1}=0x{2:X4})", '\r', (int)'\r', (int)'\r');
            Console.WriteLine ("Form besle: \\f: {0} ({1}=0x{2:X4})", '\f', (int)'\f', (int)'\f');

            Console.WriteLine ("\n\\n ile dizge i�inde yeni sat�rba�� yapma:");
            Console.WriteLine ("�lk sat�r.\n�kinci sat�r.\n���nc� sat�r.");

            Console.WriteLine ("\nYatay sekmelerle tablosal d�zenleme:");
            Console.WriteLine ("Bir\t�ki\t��");
            Console.WriteLine ("D�rt\tBe�\tAlt�");
            Console.WriteLine ("Yedi\tSekiz\tDokuz");

            Console.WriteLine ("\nTek-�ift t�rnaklar�n pasif karakterle�tirilmesi:");
            Console.WriteLine ("D�n�p, \"Neden?\", diye sordu.");
            Console.WriteLine ("\"N'abersin can\'kom?\", diye sordu.");

            char k1 = '\0';
            Console.WriteLine ("\nNull/Hi� karekterin hi�li�i:");
            Console.WriteLine ("Null karakter [{0}=ascii({1})] ve g�rseli: [{2}]", "\\0", (int) k1, k1);

            Console.WriteLine ("\n@ karakteri dizin tek ESC\\'yi hatas�zlar. �oklu sat�r dizgelerini onaylar:"); 
            Console.WriteLine (@"C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\i�li");
            //Console.WriteLine ("C:\Users\nihet\Desktop\MyFiles\3. Dersler\c#\i�li"); //Derleme hatas�
            string dzg1 = @"Bu c�mle
                 �ok 
                      �ok 
                           uzundur.";
            /*string dzg2 = "Bu c�mle
                 �ok 
                      �ok 
                           uzundur.";*/ //Derleme hatas�
            Console.WriteLine (dzg1);
            //Console.WriteLine (dzg2);

            Console.WriteLine ("\nHerkes 3-bip'li \"Selam D�nya!\"\a\a\a slogan�n� sever.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}