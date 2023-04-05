// j2sc#0105i.cs: 'using aduzam' ile yegane s�n�f adlar�n�n yaln�z kullan�labilmesi �rne�i.

using System;
using Saya�1;
using Saya�2;
using Saya�3;
namespace Saya�1 {
    class Sayac�m1 {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�1: {0}", --saya�);}
    }
}
namespace Saya�2 {
    class Sayac�m2 {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�2: {0}", ++saya�);}
    }
}
namespace Saya�3 {
    class Sayac�m3 {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
    }
}
namespace DilTemelleri {
    class Aduzam9 {
        static void Main() {
            Console.Write ("Farkl� aduzam s�n�f adlar� yegane farkl�larsa 'using aduzam' tan�m� sonras� yegane s�n�fad� �n�ne noktal� aduzam adlar�n�n getirilmesini getektirmez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Sayac�m1();
            var say2 = new Sayac�m2();
            var say3 = new Sayac�m3();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}