// j2sc#0512.cs: PadLeft/Right ve Trim-Start/End ile dizge ön/arkaya boþluk/krk doldurma/kýrpma örneði.

using System;
namespace Dizgeler {
    class KýrpDoldur {
        static void Main() {
            Console.Write ("PadLeft/Right dizge uzunluðunu taþan boþluklarý baþa/sona tamponlar, taþmazsa etkisizdir; boþluk yerine tanýmlý krk'le de (dizge deðil) doldurabilir. Trim-Start/End varsayýlý (heriki uçtaki - aralardaki deðil) boþluklarý (yada tanýmlý krk'i) kýrpar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Dizgenin sol ve saðýný boþluklarla doldurma:");
            string dizge1 = "M.Nihat Yavaþ";
            Console.WriteLine ("Orijinal dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.PadLeft (dizge1.Length+10);
            Console.WriteLine ("dizge1.PadLeft (uzn+10): \"{0}\"", dizge1);
            dizge1=dizge1.PadRight (dizge1.Length+15);
            Console.WriteLine ("dizge1.PadRight (uzn+15): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve saðýndaki boþluklarý kýrpma:");
            dizge1=dizge1.Trim();
            Console.WriteLine ("dizge1.Trim(): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve saðýný krk'le doldurma:");
            dizge1=dizge1.PadLeft (dizge1.Length+10, '#');
            Console.WriteLine ("dizge1.PadLeft (uzn+10,'#'): \"{0}\"", dizge1);
            dizge1=dizge1.PadRight (dizge1.Length+15, '.');
            Console.WriteLine ("dizge1.PadRight (uzn+15,'.'): \"{0}\"", dizge1);

            Console.WriteLine ("\nDizgenin sol ve saðýndaki krk'leri kýrpma:");
            dizge1=dizge1.Trim ('.');
            Console.WriteLine ("dizge1.Trim ('.'): \"{0}\"", dizge1);
            dizge1=dizge1.Trim ('#');
            Console.WriteLine ("dizge1.Trim ('#'): \"{0}\"", dizge1);

            Console.WriteLine ("\nTrim'le dizgenin sol ve saðýndaki çoklu seçenekli krk'leri kýrpma:");
            dizge1 = "aa--||<<...M.Nihat Yavaþ,,,>>^^__üü";
            Console.WriteLine ("dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.Trim ("^>ü,_".ToCharArray());
            Console.WriteLine ("dizge1.Trim (\"^>ü,\".ToCharArray()): \"{0}\"", dizge1);
            dizge1=dizge1.Trim (new char[]{'.', 'a', '<', '-', '|'});
            Console.WriteLine (@"dizge1.Trim (new char[]{{'.', 'a', '<', '-', '|'}}): ""{0}""", dizge1);

            Console.WriteLine ("\nTrimStart/End'le dizgenin sol ve saðýndaki çoklu seçenekli krk'leri kýrpma:");
            dizge1 = "aa--||<<...M.Nihat Yavaþ,,,>>^^__üü";
            Console.WriteLine ("dizge1: \"{0}\"", dizge1);
            dizge1=dizge1.TrimEnd ("^>ü,_".ToCharArray());
            Console.WriteLine ("dizge1.TrimEnd (\"^>ü,\".ToCharArray()): \"{0}\"", dizge1);
            dizge1=dizge1.TrimStart (new char[]{'.', 'a', '<', '-', '|'});
            Console.WriteLine (@"dizge1.TrimStart (new char[]{{'.', 'a', '<', '-', '|'}}): ""{0}""", dizge1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}