// jtpc#0204c.cs: "using System" ve "public Main" yöntemiyle "Merhaba C# Dünyasý!" örneði.

using System;
class ÝlkÖrnek3 {
    public static void Main (string[] argümanlar) {
        Console.Write ("'using System' ve dýþardan eriþilebilir 'public Main()' kullanarak MS-DOS ekranýndan çýktý alma yöntemi.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

        Console.WriteLine ("Merhaba C#3 Dünyasý!");

        Console.Write ("\nTuþ.."); Console.ReadKey();
    }
}