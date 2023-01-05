// tpc#36b.cs: Soysal metod tiplemesiyle tamsayý, krk ve dizge verileri takaslama örneði.

using System;
using System.Collections.Generic;
namespace Soysallar {
    class SoysalMetod {
        static void DeðiþTokuþ<Tip> (ref Tip bu, ref Tip þu) {// "ref" anahtarkelime zorunlu
            Tip aracý;
            aracý = bu;
            bu = þu;
            þu = aracý;
        }
        static void Main() {
            Console.Write ("Arþiv koleksiyon sýnýflarý yanýsýra kendi özel koleksiyon sýnýf, metod, arayüz, olay ve delegelerinizi de tanýmlayabilir, tip ve ebatlarýný yansýmayla çalýþma-zamanýnda saptarsýnýz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int a = 1957, b = 2023;
            char c = 'M', d = 'N';
            string e = "Mahmut", f = "Nihat";
            Console.WriteLine ("Deðiþtokuþ öncesi tamsayý: a = {0}, b = {1}", a, b);
            Console.WriteLine ("Deðiþtokuþ öncesi krk: c = {0}, d = {1}", c, d);
            Console.WriteLine ("Deðiþtokuþ öncesi dizge: e = {0}, f = {1}", e, f);
            DeðiþTokuþ<int> (ref a, ref b);
            DeðiþTokuþ<char> (ref c, ref d);
            DeðiþTokuþ<string> (ref e, ref f);
            Console.WriteLine ("\nDeðiþtokuþ sonrasý tamsayý: a = {0}, b = {1}", a, b);
            Console.WriteLine ("Deðiþtokuþ sonrasý krk: c = {0}, d = {1}", c, d);
            Console.WriteLine ("Deðiþtokuþ sonrasý dizge: e = {0}, f = {1}", e, f);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}