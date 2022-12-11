// tpc#16c.cs: Dizgenin "kýyasla, içerir, altdizge ve birleþtir" metodlarý örneði.

using System;
namespace Dizgeler {
    class DizgeMetodlarý {
        static void Main (string[] args) {// Compare, Contains, Substring ve Join metodlarý
            string dizge1 = "Bu bir dizge testidir";
            string dizge2 = "Bu bir dizge testidir";
            if (String.Compare (dizge1, dizge2) == 0) {Console.WriteLine ("Dizge1: [{0}] ve dizge2: [{1}] birbirine eþittir.", dizge1, dizge2);
            }else {Console.WriteLine ("Dizge1: [{0}] ve dizge2: [{1}] birbirine eþit deðildir.", dizge1, dizge2);}

            if (dizge1.Contains ("test")) {Console.WriteLine ("\nDizge1 içinde 'test' ibaresi bulundu.");}

            string altdizge1 = dizge1.Substring (7);
            Console.WriteLine ("\nDizge1'in endeks 7 ve sonrasý: [{0}]", altdizge1);

            string[] dizgeDizisi = new string[] {
                "Dolunay gecelerinde yýldýzlar altýnda",
                "Ve güneþli günlerde daðlarýn üzerinde",
                "Uçan Zeplin kamarasýnda seyahat ettim",
                "Ve Jamaica'ya ulaþtýðýmýzda",
                "Birkaç günlük mola verdik"};
            string dizge3 = String.Join ("\n", dizgeDizisi);
            Console.WriteLine ("\nBirleþtirilen dizge:\n[{0}]", dizge3);

            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}