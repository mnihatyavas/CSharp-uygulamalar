// j2sc#0222c.cs: Bitsel ^:XOR'la karakterleri kodlama ve dekodlama �rne�i.

using System;
namespace VeriTipleri {
    class Bitler3 {
        static void Main() {
            Console.Write ("Bitsel ^=XOR kar��l�k gelen bitler farkl�ysa (0-1, 1-0) 1, ayn�ysa (00, 11) 0'd�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

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

            string c�mle1="44-M.Nihat Yava�'�n kodlama dekodlama c�mlesi.", c�mle2="";
            Console.WriteLine ("\nOrijinal mesaj: \"{0}\"", c�mle1);
            for (int i=0; i < c�mle1.Length; i++) c�mle2 +=(char)((char)c�mle1 [i] ^ ts1);
            Console.WriteLine ("Kodlanan mesaj: \"{0}\"", c�mle2); c�mle1="";
            for (int i=0; i < c�mle2.Length; i++) c�mle1 +=(char)((char)c�mle2 [i] ^ ts1);
            Console.WriteLine ("Dekodlanan mesaj: \"{0}\"", c�mle1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}