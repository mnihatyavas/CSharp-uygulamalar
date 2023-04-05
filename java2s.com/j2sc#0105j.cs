// j2sc#0105j.cs: Üyeleri birbirinin ayný aduzamlarýn tiplemede zikredilmeleri örneði.

using System;
namespace Sayaç1 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace Sayaç1: {0}", --sayaç);}
    }
}
namespace Sayaç2 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("namespace Sayaç2: {0}", ++sayaç);}
    }
}
namespace Sayaç3 {
    class Sayacým {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("namespace Sayaç3: {0}", ++sayaç);}
    }
}
namespace DilTemelleri {
    class Aduzam10 {
        static void Main() {
            Console.Write ("Farklý aduzam üyeleri birbirleriyle ayný isimlere sahipse, tiplemelerde mutlaka farký vurgulayan aduzam adý kullanýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Sayaç1.Sayacým();
            var say2 = new Sayaç2.Sayacým();
            var say3 = new Sayaç3.Sayacým();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}