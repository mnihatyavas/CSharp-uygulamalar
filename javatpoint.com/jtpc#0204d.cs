// jtpc#0204d.cs: "using System", "public Main" ve aduzamlý yöntemle "Merhaba C# Dünyasý!" örneði.

using System;
namespace CSEðitimi {
    class ÝlkÖrnek4 {
        public static void Main (string[] argümanlar) {
            Console.Write ("'using System', dýþardan eriþilebilir 'public Main()' ve sýnýflarý katagorize edebilen aduzam kullanarak MS-DOS ekranýndan çýktý alma yöntemi.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("Merhaba C#4 Dünyasý!");

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}