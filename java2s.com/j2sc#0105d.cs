// j2sc#0105d.cs: Aduzamlarýn ayný adlý sýnýf ve üyelerin karýþmasýný önlemesi örneði.

using System;
namespace Sayaç1 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç1: {0}", --sayaç);}
    }
}
namespace Sayaç2 {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç2: {0}", ++sayaç);}
    }
}
namespace DilTemelleri {
    class Aduzam4 {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("Sayaç3: {0}", ++sayaç);}
        static void Main() {
            Console.Write ("Aduzam içi tüm sýnýf ve üyelerin adlarý ayný olsa da, farklý aduzam adlarý onlarýn karýþmasýný önler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Sayaç1.Sayacým();
            var say2 = new Sayaç2.Sayacým();
            var say3 = new DilTemelleri.Aduzam4();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}