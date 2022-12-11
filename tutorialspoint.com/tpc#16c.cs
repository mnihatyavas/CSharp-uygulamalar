// tpc#16c.cs: Dizgenin "k�yasla, i�erir, altdizge ve birle�tir" metodlar� �rne�i.

using System;
namespace Dizgeler {
    class DizgeMetodlar� {
        static void Main (string[] args) {// Compare, Contains, Substring ve Join metodlar�
            string dizge1 = "Bu bir dizge testidir";
            string dizge2 = "Bu bir dizge testidir";
            if (String.Compare (dizge1, dizge2) == 0) {Console.WriteLine ("Dizge1: [{0}] ve dizge2: [{1}] birbirine e�ittir.", dizge1, dizge2);
            }else {Console.WriteLine ("Dizge1: [{0}] ve dizge2: [{1}] birbirine e�it de�ildir.", dizge1, dizge2);}

            if (dizge1.Contains ("test")) {Console.WriteLine ("\nDizge1 i�inde 'test' ibaresi bulundu.");}

            string altdizge1 = dizge1.Substring (7);
            Console.WriteLine ("\nDizge1'in endeks 7 ve sonras�: [{0}]", altdizge1);

            string[] dizgeDizisi = new string[] {
                "Dolunay gecelerinde y�ld�zlar alt�nda",
                "Ve g�ne�li g�nlerde da�lar�n �zerinde",
                "U�an Zeplin kamaras�nda seyahat ettim",
                "Ve Jamaica'ya ula�t���m�zda",
                "Birka� g�nl�k mola verdik"};
            string dizge3 = String.Join ("\n", dizgeDizisi);
            Console.WriteLine ("\nBirle�tirilen dizge:\n[{0}]", dizge3);

            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}