// j2sc#0105g.cs: Aduzamlar� armalar� tiplemesinde :: sembol� �rne�i.

using System;
using Saya�1;
using Saya�2;
using S1 = Saya�1;
using S2 = Saya�2;
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
namespace Saya�3 {
    class Sayac�m {
        private int saya� = 1957;
        public void Saya�() {Console.WriteLine ("Saya�3: {0}", ++saya�);}
    }
}
namespace DilTemelleri {
    class Aduzam7 {
        static void Main() {
            Console.Write ("Aduzamlar� �ok uzunsa ve de program i�inde �ok s�k kullan�l�yorsa daha k�sa ve pratik bir arma/alias ad� kullan�labilir. Ancak armal� tiplemenin '.' yan�s�ra '::' sembolle de yap�labilece�i bilinmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say1 = new S1::Sayac�m();
            var say2 = new S2.Sayac�m();
            var say3 = new Saya�3.Sayac�m();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}