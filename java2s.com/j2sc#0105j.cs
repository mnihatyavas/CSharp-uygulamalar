// j2sc#0105j.cs: �yeleri birbirinin ayn� aduzamlar�n tiplemede zikredilmeleri �rne�i.

using System;
namespace Saya�1 {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace Saya�1: {0}", --saya�);}
    }
}
namespace Saya�2 {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace Saya�2: {0}", ++saya�);}
    }
}
namespace Saya�3 {
    class Sayac�m {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("namespace Saya�3: {0}", ++saya�);}
    }
}
namespace DilTemelleri {
    class Aduzam10 {
        static void Main() {
            Console.Write ("Farkl� aduzam �yeleri birbirleriyle ayn� isimlere sahipse, tiplemelerde mutlaka fark� vurgulayan aduzam ad� kullan�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new Saya�1.Sayac�m();
            var say2 = new Saya�2.Sayac�m();
            var say3 = new Saya�3.Sayac�m();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}