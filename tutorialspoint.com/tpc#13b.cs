// tpc#13b.cs: Ayrý sýnýf metoduyla iki tamsayýdan büyüðünün tespiti örneði.

using System;
namespace Metodlar {
    class BüyüðünTespiti {
        public int BüyüðüBul (int n1, int n2) {
            int sonuç; // Lokal deðiþken
            if (n1 > n2) sonuç = n1;
            else sonuç = n2;
            return sonuç;
        }
    }
    class AnaSýnýf {
        static void Main (string[] args) {
            Console.Write ("Bir metodun sözdizimi:\n<Eriþim Belirteci/private> <Döndürülenin Tipi/void> <Metod Adý>(Parametre Listesi/) {Metod Gövdesi}\nMetod tanýmlanýr ve çaðrýlýr.");
            Console.Write ("\nTuþ..."); Console.ReadKey();

            Console.Write ("\n\nÝlk tamsayýyý girin [10] Ent: "); int ilk = Convert.ToInt32 (Console.ReadLine());
            Console.Write ("Ýkinci tamsayýyý girin [7] Ent: "); int ikinci = Convert.ToInt32 (Console.ReadLine());
            BüyüðünTespiti b = new BüyüðünTespiti();// Metodu içeren sýnýfýn tiplemesi
            Console.Write ("Ýki sayýnýn büyüðü: {0}\nTuþ...", b.BüyüðüBul (ilk, ikinci));
            Console.ReadKey();            
        }
    }
}