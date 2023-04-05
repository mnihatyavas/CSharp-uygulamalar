// j2sc#0106a.cs: Aduzamsýz global armalý sýnýf tipleme örneði.

using System;
using Syç1 = Sayaç;
using Syç2 = DilTemelleri;
namespace Sayaç {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace Sayaç: {0}", ++sayaç);}
    }
}  
class Sayacým {// Aduzamsýz global sýnýf
    private int sayaç = 1957;
    public void Sayaç() {Console.WriteLine ("namespace global: {0}", --sayaç);}
}
namespace DilTemelleri {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace DilTemelleri: {0}", --sayaç);}
    }
    class Arma1 {
        static void Main() {
            Console.Write ("Aduzamsýz ve arma tanýmlanmamýþ sýnýf tiplemesi 'global::' armalý yapýlabilmektedir. Aduzam belirtmeksizin yapýlan 'typeof' varsayýlý olarak aduzamsýz sýnýfý deðil Main()'li aduzamýn sýnýfýný farzeder.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Sayaç.Sayacým tipi: {0}, {1}", typeof (Sayaç.Sayacým), typeof (global::Sayaç.Sayacým));
            Console.WriteLine ("Aduzamsýz Sayacým tipi: {0}, {1}", typeof (Sayacým), typeof (global::Sayacým));
            Console.WriteLine ("DilTemelleri.Sayacým tipi: {0}, {1}\n", typeof (DilTemelleri.Sayacým), typeof (global::DilTemelleri.Sayacým));

            var say1 = new Syç1::Sayacým();
            var say2 = new Syç2::Sayacým();
            var say3 = new global::Sayacým();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}