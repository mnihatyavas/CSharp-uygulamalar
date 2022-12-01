// tpc#07b.cs: Deðiþken tanýmlama ve ilkdeðer atama örneði.

using System;
namespace Deðiþkenler {
    class DeðiþkenTanýmýÝlkdeðeri {
        static void Main (string[] args) {
            Console.Write ("Tip deðiþken-ler [=ilkdeðer|. Örnek:\n-------------------------------------\nint i, j, k;\nchar c, krk;\nfloat f, maaþ;\ndouble d;\n\nint d = 3, f = 5;\nbyte z = 22;\ndouble pi = 3.14159;\nchar x = 'x';\nTuþ...");
            Console.ReadKey();

            short a;
            int b;
            long c;
            // Ýlkdeðer atamalarý:
            a = 1957;
            b = 2022;
            c = b - a;
            Console.Write ("\n\nDoðum yýlý: {0}\nAktüel yýl: {1}\nYaþýnýz: {2}\nTuþ...", a, b, c);
            Console.ReadKey();
        }
    }
}