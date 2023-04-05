// j2sc#0105e.cs: Ayný adlý aduzam üyelerinin tek bir aduzammýþcasýma eklemlenmesi örneði.

using System;
namespace DilTemelleri {
    class Sayacým1 {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç1: {0}", --sayaç);}
    }
}
namespace DilTemelleri {
    class Sayacým2 {
        private int sayaç = 2023;
        public void Sayaç() {Console.WriteLine ("Sayaç2: {0}", ++sayaç);}
    }
}
namespace DilTemelleri {
    class Aduzam5 {
        private int sayaç = 1957;
        public void Sayaç() {Console.WriteLine ("Sayaç3: {0}", ++sayaç);}
        static void Main() {
            Console.Write ("Ayný adlý çoklu aduzam üyeleri derleme esnasýnda teke eklemlenirler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new DilTemelleri.Sayacým1();
            var say2 = new DilTemelleri.Sayacým2();
            var say3 = new DilTemelleri.Aduzam5();
            for (int i=0; i < 5; i++) {say1.Sayaç(); say2.Sayaç(); say3.Sayaç();}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}