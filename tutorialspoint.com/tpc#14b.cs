// tpc#14b.cs: Null deðiþkeni ikinciyle birleþtiren ?? örneði.

using System;
namespace Hiçlenebilenler {
    class NullKoalisyonu {
        static void Main (string[] args) {
            Console.Write ("?? iþlemcisi normalen ilkini atar, ancak ilki null'sa ikinciyi.\nTuþ..."); Console.ReadKey();

            double? sayý1 = null;
            double? sayý2 = 3.141592653589793;
            double? sayý3 = null;
            double? sayý4 = 2.718281828459045;

            Console.WriteLine ("\n\nNull ve sayý: [{0}]", sayý1 ?? sayý2);
            Console.WriteLine ("Sayý ve sayý: [{0}]", sayý2 ?? sayý4);
            Console.WriteLine ("Null ve null: [{0}]", sayý1 ?? sayý3);
            Console.WriteLine ("Sayý ve null: [{0}]", sayý4 ?? sayý3);

            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}