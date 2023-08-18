// j2sc#0509b.cs: Substring ve Remove ile istenilen ibareyi alma ve eksiltme örneði.

using System;
namespace Dizgeler {
    class Deðiþtirme2 {
        static void Main() {
            Console.Write ("Substring ilk endeksten belirtilen adet ibareyi kopyalar. Remove ise belirtilen ibareyi çýkarýp, kalaný sunar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Substring ile bir dizgeden istenilen ibareyi kopyalama:");
            string dizge1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine ("dizge1({0})'in son yarýsý: {1}", dizge1, dizge1.Substring (dizge1.Length/2) );
            Console.WriteLine ("dizge1'in ilk yarýsý: {0}", dizge1.Substring (0, dizge1.Length/2) );
            Console.WriteLine ("dizge1'in orta yarýsý: {0}", dizge1.Substring (dizge1.Length/2-dizge1.Length/4, dizge1.Length/2));

            Console.WriteLine ("\nRemove ile bir dizgeden istenilen ibareyi çýkarma:");
            Console.WriteLine ("dizge1'in son yarýsýný çýkarma : {0}", dizge1.Remove (dizge1.Length/2) );
            Console.WriteLine ("dizge1'in ilk yarýsýný çýkarma: {0}", dizge1.Remove (0, dizge1.Length/2) );
            Console.WriteLine ("dizge1'in orta yarýsýný çýkarma: {0}", dizge1.Remove (dizge1.Length/2-dizge1.Length/4, dizge1.Length/2));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}