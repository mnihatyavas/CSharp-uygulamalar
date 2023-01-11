// jtpc#0205.cs: Deðiþkenler ve kurallarý örneði.

using System;
namespace CSEðitimi {
    class Deðiþkenler {
        static void Main () {
            Console.Write ("Deðiþken, içine deðer yüklenen bellek konumu sembolüdür.\nDeðiþken çeþitleri: decimal/ondalýk, boolean/ikili (true, false), tamsayý (int, char, byte, short, long), kayannokta (float, double), hiçlenebilen.\nÖrn1: int i, j; double d; float f; char krk;\nÖrn2: int i=2023, j=1957; float f=3.14; char krk='A';\nKurallarý: Deðiþken adý harf ve altçizgiyle baþlayabilir, sonrasýnda sayý da olabilir. Anahtarkelimeler (int, class, fixed, for gibi) ve boþluk kullanýlmaz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
        }
    }
}