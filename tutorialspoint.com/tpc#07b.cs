// tpc#07b.cs: De�i�ken tan�mlama ve ilkde�er atama �rne�i.

using System;
namespace De�i�kenler {
    class De�i�kenTan�m��lkde�eri {
        static void Main (string[] args) {
            Console.Write ("Tip de�i�ken-ler [=ilkde�er|. �rnek:\n-------------------------------------\nint i, j, k;\nchar c, krk;\nfloat f, maa�;\ndouble d;\n\nint d = 3, f = 5;\nbyte z = 22;\ndouble pi = 3.14159;\nchar x = 'x';\nTu�...");
            Console.ReadKey();

            short a;
            int b;
            long c;
            // �lkde�er atamalar�:
            a = 1957;
            b = 2022;
            c = b - a;
            Console.Write ("\n\nDo�um y�l�: {0}\nAkt�el y�l: {1}\nYa��n�z: {2}\nTu�...", a, b, c);
            Console.ReadKey();
        }
    }
}