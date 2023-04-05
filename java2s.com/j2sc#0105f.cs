// j2sc#0105f.cs: Ýçiçe aduzam sýnýf tiplemeleri örneði.

using System;
namespace DýþAduzam {
    class Sayacým {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç1: {0}", --sayaç);}
    }
    namespace ÝçAduzam {
        class Sayacým {
            private int sayaç = 2023;
            public void Sayaç() {Console.WriteLine ("Sayaç2: {0}", ++sayaç);}
        }
    }
}
namespace DilTemelleri {
    class Aduzam6 {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("Sayaç3: {0}", ++sayaç);}
        static void Main() {
            Console.Write ("Ýçiçe aduzam sýnýf tiplemesi yapýlýrken aduzamlar arasýndaki noktalama unutulmamalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new DýþAduzam.Sayacým();
            var say2 = new DýþAduzam.ÝçAduzam.Sayacým();
            var say3 = new DilTemelleri.Aduzam6();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}