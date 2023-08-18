// j2sc#0509b.cs: Substring ve Remove ile istenilen ibareyi alma ve eksiltme �rne�i.

using System;
namespace Dizgeler {
    class De�i�tirme2 {
        static void Main() {
            Console.Write ("Substring ilk endeksten belirtilen adet ibareyi kopyalar. Remove ise belirtilen ibareyi ��kar�p, kalan� sunar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Substring ile bir dizgeden istenilen ibareyi kopyalama:");
            string dizge1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine ("dizge1({0})'in son yar�s�: {1}", dizge1, dizge1.Substring (dizge1.Length/2) );
            Console.WriteLine ("dizge1'in ilk yar�s�: {0}", dizge1.Substring (0, dizge1.Length/2) );
            Console.WriteLine ("dizge1'in orta yar�s�: {0}", dizge1.Substring (dizge1.Length/2-dizge1.Length/4, dizge1.Length/2));

            Console.WriteLine ("\nRemove ile bir dizgeden istenilen ibareyi ��karma:");
            Console.WriteLine ("dizge1'in son yar�s�n� ��karma : {0}", dizge1.Remove (dizge1.Length/2) );
            Console.WriteLine ("dizge1'in ilk yar�s�n� ��karma: {0}", dizge1.Remove (0, dizge1.Length/2) );
            Console.WriteLine ("dizge1'in orta yar�s�n� ��karma: {0}", dizge1.Remove (dizge1.Length/2-dizge1.Length/4, dizge1.Length/2));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}