// tpc#19c.cs: Parametresiz sýnýf kurucu fonksiyonu örneði.

using System;
namespace Sýnýflar {
    class Çember {
        private double yarýçap;

        public Çember() {Console.WriteLine ("\n\nÇember sýnýf nesnesi yaratýlýyor...");}
        public void yarýçapKoy (double yç) {yarýçap = yç;}
        public double çevreyiAl() {return 2 * 3.141592653589793 * yarýçap;}
    }
    class ÇemberinÇevresi1 {
        static void Main (string[] args) {
            Console.Write ("Sýnýfla ayný adlý kurucu fonksiyona yazacaðýmýz açýklamalar, sýnýf tiplemesi yaratýlýrken beyan edilebilir.\nTuþ..."); Console.ReadKey();

            Çember çember = new Çember(); çember.yarýçapKoy (15.87);
            Console.WriteLine ("Çemberin çevresi = [{0}] birim.", çember.çevreyiAl());
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}