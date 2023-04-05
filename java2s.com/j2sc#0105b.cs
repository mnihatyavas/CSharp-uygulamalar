// j2sc#0105b.cs: Aduzam i�i s�n�f �yelerine tiplemeyle eri�im �rne�i.

using System;
namespace DilTemelleri {
    class Sayac�m {
        private int saya� = 0;
        public void Saya�() {Console.WriteLine ("Saya�: {0}", ++saya�);}
    }
    class Aduzam2 {
        static void Main() {
            Console.Write ("Bir aduzam i�inde (statik olmayan) �oklu s�n�f tan�mlar� mevcutsa, s�n�f ve �yeleri 'new' anahtarkelimeli tiplenerek kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var say = new DilTemelleri.Sayac�m();
            for (int i=0; i < 5; i++) {say.Saya�();}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}