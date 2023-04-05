// j2sc#0105i.cs: 'using aduzam' ile yegane sýnýf adlarýnýn yalnýz kullanýlabilmesi örneði.

using System;
using Sayaç1;
using Sayaç2;
using Sayaç3;
namespace Sayaç1 {
    class Sayacým1 {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç1: {0}", --sayaç);}
    }
}
namespace Sayaç2 {
    class Sayacým2 {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç2: {0}", ++sayaç);}
    }
}
namespace Sayaç3 {
    class Sayacým3 {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("Sayaç3: {0}", ++sayaç);}
    }
}
namespace DilTemelleri {
    class Aduzam9 {
        static void Main() {
            Console.Write ("Farklý aduzam sýnýf adlarý yegane farklýlarsa 'using aduzam' tanýmý sonrasý yegane sýnýfadý önüne noktalý aduzam adlarýnýn getirilmesini getektirmez.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Sayacým1();
            var say2 = new Sayacým2();
            var say3 = new Sayacým3();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}