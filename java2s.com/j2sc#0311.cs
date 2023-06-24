// j2sc#0311.cs: Kýsadevre AND=&& ve OR=||'da ilk false ve true'nun sonucu imasý örneði.

using System;
namespace Ýþlemciler {
    class ÝmasalÝþlemci {
        static void Main() {
            Console.Write ("Çoklu AND=&& için ilk þartýnýn false olmasý tüm þartlar sonucunun false imasýna, çoklu OR'da ise ilkinin true olmasý tümün true imasýna yeterlidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            bool b1=false, b2=false, b3=false, b4=false; 
            if (!b1 || b2 || b3 || b4) Console.WriteLine ("Kýsadevre OR=|| için ilk !b1={0} olmasý tüm if þartýný={1} imaya yeterlidir.", !b1, true);
            if (!(b1 && !b2 && !b3 && !b4)) Console.WriteLine ("Kýsadevre AND=&& için ilk b1={0} olmasý tüm if þartýný={1} imaya yeterlidir.", b1, false);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}