// j2sc#0512.cs: PadLeft/Right ve Trim-Start/End ile dizge �n/arkaya bo�luk/krk doldurma/k�rpma �rne�i.

using System;
namespace Dizgeler {
    class K�rpDoldur {
        static void Main() {
            Console.Write ("PadLeft/Right dizge uzunlu�unu ta�an bo�luklar� ba�a/sona tamponlar, ta�mazsa etkisizdir; bo�luk yerine tan�ml� krk'le de (dizge de�il) doldurabilir. Trim-Start/End varsay�l� (heriki u�taki - aralardaki de�il) bo�luklar� (yada tan�ml� krk'i) k�rpar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgenin sol ve sa��n� bo�luklarla doldurma:");
            string dizge1 = "M.Nihat Yava�";
            Console.WriteLine ("Orijinal dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.PadLeft (dizge1.Length+10);
            Console.WriteLine ("dizge1.PadLeft (uzn+10): \"{0}\"", dizge1);
            dizge1=dizge1.PadRight (dizge1.Length+15);
            Console.WriteLine ("dizge1.PadRight (uzn+15): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve sa��ndaki bo�luklar� k�rpma:");
            dizge1=dizge1.Trim();
            Console.WriteLine ("dizge1.Trim(): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve sa��n� krk'le doldurma:");
            dizge1=dizge1.PadLeft (dizge1.Length+10, '#');
            Console.WriteLine ("dizge1.PadLeft (uzn+10,'#'): \"{0}\"", dizge1);
            dizge1=dizge1.PadRight (dizge1.Length+15, '.');
            Console.WriteLine ("dizge1.PadRight (uzn+15,'.'): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve sa��ndaki krk'leri k�rpma:");
            dizge1=dizge1.Trim ('.');
            Console.WriteLine ("dizge1.Trim ('.'): \"{0}\"", dizge1);
            dizge1=dizge1.Trim ('#');
            Console.WriteLine ("dizge1.Trim ('#'): \"{0}\"", dizge1);

            Console.WriteLine ("\nTrim'le dizgenin sol ve sa��ndaki �oklu se�enekli krk'leri k�rpma:");
            dizge1 = "aa--||<<...M.Nihat Yava�,,,>>^^__��";
            Console.WriteLine ("dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.Trim ("^>�,_".ToCharArray());
            Console.WriteLine ("dizge1.Trim (\"^>�,\".ToCharArray()): \"{0}\"", dizge1);
            dizge1=dizge1.Trim (new char[]{'.', 'a', '<', '-', '|'});
            Console.WriteLine (@"dizge1.Trim (new char[]{{'.', 'a', '<', '-', '|'}}): ""{0}""", dizge1);

            Console.WriteLine ("\nTrimStart/End'le dizgenin sol ve sa��ndaki �oklu se�enekli krk'leri k�rpma:");
            dizge1 = "aa--||<<...M.Nihat Yava�,,,>>^^__��";
            Console.WriteLine ("dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.TrimEnd ("^>�,_".ToCharArray());
            Console.WriteLine ("dizge1.TrimEnd (\"^>�,\".ToCharArray()): \"{0}\"", dizge1);
            dizge1=dizge1.TrimStart (new char[]{'.', 'a', '<', '-', '|'});
            Console.WriteLine (@"dizge1.TrimStart (new char[]{{'.', 'a', '<', '-', '|'}}): ""{0}""", dizge1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}