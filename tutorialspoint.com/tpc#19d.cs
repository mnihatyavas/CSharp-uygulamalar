// tpc#19d.cs: Parametreli sýnýf kurucu fonksiyonu örneði.

using System;
namespace Sýnýflar {
    class Çember {
        private double yarýçap;

        public Çember (double yç) {yarýçap = yç; Console.WriteLine ("\n\nÇember sýnýf nesnesi yaratýlýyor...\n1.Çemberin çevresi = [{0}] birim.", çevreyiAl());}
        public void yarýçapKoy (double yç) {yarýçap = yç;}
        public double çevreyiAl() {return 2 * 3.141592653589793 * yarýçap;}
    }
    class ÇemberinÇevresi2 {
        static void Main (string[] args) {
            Console.Write ("Sýnýfla ayný adlý kurucu fonksiyona göndereceðimis argüman, sýnýf tiplemesi yaratýlýrken ayný anda da çember çevre sonucunu sunabilir.\nTuþ..."); Console.ReadKey();

            Çember çember = new Çember (12.61);
            çember.yarýçapKoy (15.87); Console.WriteLine ("2.Çemberin çevresi = [{0}] birim.", çember.çevreyiAl());
            çember.yarýçapKoy (7.17); Console.WriteLine ("3.Çemberin çevresi = [{0}] birim.", çember.çevreyiAl());
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}