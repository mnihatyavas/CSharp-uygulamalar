// j2sc#0105e.cs: Ayn� adl� aduzam �yelerinin tek bir aduzamm��cas�ma eklemlenmesi �rne�i.

using System;
namespace DilTemelleri {
    class Sayac�m1 {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�1: {0}", --saya�);}
    }
}
namespace DilTemelleri {
    class Sayac�m2 {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�2: {0}", ++saya�);}
    }
}
namespace DilTemelleri {
    class Aduzam5 {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
        static void Main() {
            Console.Write ("Ayn� adl� �oklu aduzam �yeleri derleme esnas�nda teke eklemlenirler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new DilTemelleri.Sayac�m1();
            var say2 = new DilTemelleri.Sayac�m2();
            var say3 = new DilTemelleri.Aduzam5();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}