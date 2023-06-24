// j2sc#0215.cs: Karakter unicode 2 byte 65535 harf sembolleri örneði.

using System;
namespace VeriTipleri {
    class Karakter {
        static void Main() {
            Console.Write ("Karakter tipi 2 byte'lýk (tüm dünya dillerindeki 65535 harf sembollerini kapsayan) unicode'dur.\nMetotlarý: CompareTo(), Equals(), GetHashCode(), GetNumericValue(), GetTypeCode(), GetUnicodeCategory(), IsControl(), IsDigit(), IsLetter(), IsLetterOrDigit(), IsLower(), IsNumber(), IsPunctuation(), IsSeparator(), IsSurrogate(), IsSymbol(), IsUpper(), IsWhiteSpace(), Parse(), ToLower(), ToUpper(), ToString().\nESC karakterler: \\a (alert), \\b (backspace), \\f (form-feed), \\n (new-line), \\r (enter), \\t (tab-yatay), \\v (tab-dikey), \\0 (null), \\' (tek-týrnak), \\\" (çift-týrnak), \\\\(geri-bölü).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            char krk1 = 'A';
            Console.WriteLine ("char krk1 = {0}-->{1}\nTipi: {2}\nEnküçük ve enbüyük = [{3}, {4}]", krk1, (int) krk1, krk1.GetType(), (int)char.MinValue, (int)char.MaxValue);

            string cümle1 = "Bu bir, kontrol denemesidir. $23", cümle2="";
            Console.WriteLine ("\nOrijinal cümle: [{0}]", cümle1);
            for (int i=0; i < cümle1.Length; i++) {
                Console.Write ((krk1 = cümle1 [i]) + " bir ");
                if (Char.IsLetter (krk1)) Console.Write (" harf'dir.");
                else if (Char.IsWhiteSpace (krk1)) Console.Write (" boþluk'tur."); //veya "IsSeparator()"
                else if (Char.IsPunctuation (krk1)) Console.Write (" noktalama'dýr.");
                else if (Char.IsSymbol (krk1)) Console.Write (" sembol'dür.");
                else if (Char.IsDigit (krk1)) Console.Write (" rakam'dýr.");
                Console.WriteLine();
                cümle2 +=Char.ToUpper (krk1);
            } Console.WriteLine ("Büyükharfli cümle: [{0}]", cümle2);

            Console.Write ("\nA-Z büyük-harfler: ");
            for (krk1='A'; krk1 <= 'Z'; krk1++) Console.Write (krk1 + " ");
            Console.Write ("\na-z küçük-harfler: ");
            for (krk1='a'; krk1 <= 'z'; krk1++) Console.Write (krk1 + " ");

            int ts1 = '3' + '4', ts2 = 'Z' - 'A'; //ASCII (51 + 52 = 103, ve 90 - 65 = 25)
            krk1 = (char) ts1;
            Console.WriteLine ("\n\nint ts1 ('3'=51 + '4'=52): {0} = char krk1: {1}", ts1, krk1);
            Console.WriteLine ("int ts2 ('Z'=90 - 'A'=65): {0} = (char) ts2: {1}", ts2, (char) ts2);

            krk1 = 'a';
            Console.WriteLine ("\nchar.IsDigit ('a'): Rakam mýdýr? {0}", char.IsDigit (krk1));
            Console.WriteLine ("char.IsLetter ('a'): Harf midir? {0}", char.IsLetter (krk1));
            Console.WriteLine ("char.IsWhiteSpace ('Herkese Merhabalar', 7): Boþluk mudur? {0}", char.IsWhiteSpace ("Herkese Merhabalar", 7));
            Console.WriteLine ("char.IsWhiteSpace ('Herkese Merhabalar', 8): Boþluk mudur? {0}", char.IsWhiteSpace ("Herkese Merhabalar", 8));
            Console.WriteLine ("char.IsPunctuation ('?'): Noktalama mýdýr? {0}", char.IsPunctuation ('?'));
            Console.WriteLine ("char.IsPunctuation ('$'): Noktalama mýdýr? {0}", char.IsPunctuation ('$'));

            krk1='z'; Console.WriteLine ("\nz-a karekter ve ascii rakamlarý:");
            do {
                ts1 = krk1;
                Console.Write ("{0}={1}\t", ts1, krk1);
                krk1--;
            } while (krk1 >= 'a');

            Console.WriteLine ("\n\nUnicode \\u0041 = {0}: {1}", '\u0041', (int)'\u0041');
            Console.WriteLine ("Unicode \\u007A = {0}: {1}", '\u007A', (int) '\u007A');


            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}