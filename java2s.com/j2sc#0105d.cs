// j2sc#0105d.cs: Aduzamlar�n ayn� adl� s�n�f ve �yelerin kar��mas�n� �nlemesi �rne�i.

using System;
namespace Saya�1 {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�1: {0}", --saya�);}
    }
}
namespace Saya�2 {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("Saya�2: {0}", ++saya�);}
    }
}
namespace DilTemelleri {
    class Aduzam4 {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
        static void Main() {
            Console.Write ("Aduzam i�i t�m s�n�f ve �yelerin adlar� ayn� olsa da, farkl� aduzam adlar� onlar�n kar��mas�n� �nler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Saya�1.Sayac�m();
            var say2 = new Saya�2.Sayac�m();
            var say3 = new DilTemelleri.Aduzam4();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}