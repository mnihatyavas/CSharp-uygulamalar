// j2sc#0106a.cs: Aduzams�z global armal� s�n�f tipleme �rne�i.

using System;
using Sy�1 = Saya�;
using Sy�2 = DilTemelleri;
namespace Saya� {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace Saya�: {0}", ++saya�);}
    }
}  
class Sayac�m {// Aduzams�z global s�n�f
    private int saya� = 1957;
    public void Saya�() {Console.WriteLine ("namespace global: {0}", --saya�);}
}
namespace DilTemelleri {
    class Sayac�m {
        private int saya� = 2023;
        public void Saya�() {Console.WriteLine ("namespace DilTemelleri: {0}", --saya�);}
    }
    class Arma1 {
        static void Main() {
            Console.Write ("Aduzams�z ve arma tan�mlanmam�� s�n�f tiplemesi 'global::' armal� yap�labilmektedir. Aduzam belirtmeksizin yap�lan 'typeof' varsay�l� olarak aduzams�z s�n�f� de�il Main()'li aduzam�n s�n�f�n� farzeder.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Saya�.Sayac�m tipi: {0}, {1}", typeof (Saya�.Sayac�m), typeof (global::Saya�.Sayac�m));
            Console.WriteLine ("Aduzams�z Sayac�m tipi: {0}, {1}", typeof (Sayac�m), typeof (global::Sayac�m));
            Console.WriteLine ("DilTemelleri.Sayac�m tipi: {0}, {1}\n", typeof (DilTemelleri.Sayac�m), typeof (global::DilTemelleri.Sayac�m));

            var say1 = new Sy�1::Sayac�m();
            var say2 = new Sy�2::Sayac�m();
            var say3 = new global::Sayac�m();
            for (int i=0; i < 5; i++) {say1.Saya�(); say2.Saya�(); say3.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}