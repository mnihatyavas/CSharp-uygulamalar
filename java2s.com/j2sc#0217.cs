// j2sc#0217.cs: Karakter diziye ilkdeðerli veya atamalý deðer atama örneði.

using System;
namespace VeriTipleri {
    class CharDizisi {
        static void Main() {
            Console.Write ("Karakter dizisi 'new char[n]' ile yaratýldýðý gibi doðrudan 'char[] kDizi={}' ile de ilkdeðer atamalý yaratýlabilir. Karakter deðeri (char)ascii no'yla da atanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var krkDizi1 = new char [7];
            Console.WriteLine ("krkDizi1.Length = " + krkDizi1.Length + "\nkrkDizi1[0] = " + krkDizi1 [0]);
            krkDizi1 [1] = 'S';
            krkDizi1 [2] = 'e';
            krkDizi1 [3] = 'l';
            krkDizi1 [4] = 'a';
            krkDizi1 [5] = 'm';
            krkDizi1 [6] = '\0';
            for (int i = 1; i < krkDizi1.Length; i++) Console.WriteLine ("krkDizi1[" + i + "] = " + krkDizi1 [i]);
            Console.WriteLine ("krkDizi1 = " + krkDizi1);
            Console.WriteLine ("krkDizi1 = [{0}]", krkDizi1);
            Console.WriteLine (krkDizi1);

            var krkDizi2 = new char[] {'S', 'e', 'l', 'a', 'm'};
            Console.WriteLine ("\nkrkDizi2.Length = " + krkDizi2.Length);
            for (int i = 0; i < krkDizi2.Length; i++) Console.WriteLine ("krkDizi2[" + i + "] = " + krkDizi2 [i]);
            Console.WriteLine (krkDizi2);

            char[] krkDizi3 = {(char)9, 'S', 'e', 'l', (char)97, 'm', (char)0, 'h', 'e', 'r', 'k', 'e', 's', 'e'}; //ascii:0=tekboþluk, 9=sekme, 97=a
            Console.WriteLine ("\nkrkDizi3.Length = " + krkDizi3.Length);
            Console.WriteLine (krkDizi3);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}