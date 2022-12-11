// tpc#19e.cs: Sýnýfýn kurucu yanýsýra yýkýcý fonksiyonu örneði.

using System;
namespace Sýnýflar {
    class Çember {
        private double yarýçap;

        public Çember() {Console.WriteLine ("\n\nÇember sýnýf nesnesi yaratýlýyor...");}
        ~Çember() {Console.WriteLine ("\nÇember sýnýf nesnesi yýkýlýyor/siliniyor...");}
        public void yarýçapKoy (double yç) {yarýçap = yç;}
        public double çevreyiAl() {return 2 * 3.141592653589793 * yarýçap;}
    }
    class ÇemberinÇevresi3 {
        static void Main (string[] args) {
            Console.Write ("Sýnýf nesnesi ilk yaratýlýrken, ayný adlý kurucu fonksiyon çaðrýldýðý gibi, program sonlandýðýnda veya sýnýf nesnesi bellekten silindiðinde de, ~Sýnýf ayný adlý (parametresiz, dönen deðersiz, eriþim belirteçsiz) yýkýcý fonksiyon otomatikmen çaðrýlýr.\nTuþ..."); Console.ReadKey();

            Çember çember = new Çember(); // Kurucu fonksiyon çaðrýlýr
            çember.yarýçapKoy (15.87); Console.WriteLine ("Ýlk çemberin çevresi = [{0}] birim.", çember.çevreyiAl());
            çember.yarýçapKoy (7.17); Console.WriteLine ("Ýkinci çemberin çevresi = [{0}] birim.", çember.çevreyiAl());
            Console.Write ("Tuþ..."); Console.ReadKey(); // Yýkýcý fonksiyon çaðrýlýr

        }
    }
}