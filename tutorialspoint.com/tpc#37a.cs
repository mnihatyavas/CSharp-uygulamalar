// tpc#37a.cs: Adlý ve adsýz anonim metodlarýn delegeli çaðrýlmasý örneði.

using System;
delegate void Hesapcý (int n);
namespace AnonimMetodlar {
    class DelegeliMetodlar {
        static int sayý = 10;
        public static void Topla (int n) {Console.WriteLine ("Topla adlý metod: {0}", (sayý +=n));}
        public static void Çarp (int n) {Console.WriteLine ("Çarp adlý metod: {0}", (sayý *=n));}
        public static void Böl (int n) {Console.WriteLine ("Böl adlý metod: {0}", (sayý /=(n-3)));}

        static void Main() {
            Console.Write ("Metodlar doðrudan yada referanslý delegesiyle çaðrýlabilmektedir. Anonim metod isimsiz kodlama gövdesi olup parametreli veri alýr. Hem adsýz hem de adlý metodlar delegeli çaðrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesapcý h = delegate (int x) {Console.WriteLine ("Adsýz delegeli anonim metod: {0}", x-1957);};
            h (2023); // Adsýz anonim metodun delegeli çaðrýlmasý
            h = new Hesapcý (Topla);
            h (5); // Topla Adlý metodun delegeli çaðrýlmasý
            h = new Hesapcý (Çarp);
            h (3); // Çarp Adlý metodun delegeli çaðrýlmasý
            h = new Hesapcý (Böl);
            h (12); // Böl Adlý metodun delegeli çaðrýlmasý

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}