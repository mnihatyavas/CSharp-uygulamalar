// j2sc#0222c.cs: Bitsel ^:XOR'la karakterleri kodlama ve dekodlama örneði.

using System;
namespace VeriTipleri {
    class Bitler3 {
        static void Main() {
            Console.Write ("Bitsel ^=XOR karþýlýk gelen bitler farklýysa (0-1, 1-0) 1, aynýysa (00, 11) 0'dýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            char krk1 = 'A', krk2 = 'B', krk3 = 'C'; // 65, 66, 67
            int ts1 = 88; // 0101 1000 
            Console.WriteLine ("Orijinal mesaj: ({0}{1}{2}): ({3}, {4}, {5})", krk1, krk2, krk3, (int)krk1, (int)krk2, (int)krk3);
            krk1 = (char) (krk1 ^ ts1); // (0100 0001) ^:XOR:FARKLIYSA (0101 1000) = 0001 1001=25
            krk2 = (char) (krk2 ^ ts1); // 26
            krk3 = (char) (krk3 ^ ts1); // 27
            Console.WriteLine ("Bitsel XOR'la Kodlanan mesaj: ({0}{1}{2}): ({3}, {4}, {5})", krk1, krk2, krk3, (int)krk1, (int)krk2, (int)krk3);
            krk1 = (char) (krk1 ^ ts1); // 0100 0001=65=A
            krk2 = (char) (krk2 ^ ts1); // B
            krk3 = (char) (krk3 ^ ts1); // C
            Console.WriteLine ("Bitsel XOR'la Dekodlanan mesaj: ({0}{1}{2}): ({3}, {4}, {5})", krk1, krk2, krk3, (int)krk1, (int)krk2, (int)krk3);

            string cümle1="44-M.Nihat Yavaþ'ýn kodlama dekodlama cümlesi.", cümle2="";
            Console.WriteLine ("\nOrijinal mesaj: \"{0}\"", cümle1);
            for (int i=0; i < cümle1.Length; i++) cümle2 +=(char)((char)cümle1 [i] ^ ts1);
            Console.WriteLine ("Kodlanan mesaj: \"{0}\"", cümle2); cümle1="";
            for (int i=0; i < cümle2.Length; i++) cümle1 +=(char)((char)cümle2 [i] ^ ts1);
            Console.WriteLine ("Dekodlanan mesaj: \"{0}\"", cümle1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}