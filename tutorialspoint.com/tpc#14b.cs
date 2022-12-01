// tpc#14b.cs: Null de�i�keni ikinciyle birle�tiren ?? �rne�i.

using System;
namespace Hi�lenebilenler {
    class NullKoalisyonu {
        static void Main (string[] args) {
            Console.Write ("?? i�lemcisi normalen ilkini atar, ancak ilki null'sa ikinciyi.\nTu�..."); Console.ReadKey();

            double? say�1 = null;
            double? say�2 = 3.141592653589793;
            double? say�3 = null;
            double? say�4 = 2.718281828459045;

            Console.WriteLine ("\n\nNull ve say�: [{0}]", say�1 ?? say�2);
            Console.WriteLine ("Say� ve say�: [{0}]", say�2 ?? say�4);
            Console.WriteLine ("Null ve null: [{0}]", say�1 ?? say�3);
            Console.WriteLine ("Say� ve null: [{0}]", say�4 ?? say�3);

            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}