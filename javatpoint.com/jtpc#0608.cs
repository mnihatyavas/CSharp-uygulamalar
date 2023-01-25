// jtpc#0608.cs: 'struct' yapý tiplemesiyle dikdörtgen alanýnýn hesaplanmasý örneði.

using System;
namespace NesneSýnýfý {
    public struct Dikdörtgen1 {public int en, boy;}
    public struct Dikdörtgen2 {
        public int en, boy;
        public Dikdörtgen2 (int en, int boy) {//Parametreli kurucu
            this.en = en;
            this.boy = boy;
        }
        public void Dikdörtgen2Alaný() {Console.WriteLine ("{0}x{1} ebatlý dikdörtgenin alaný = {2}", en, boy, (en * boy));}
    }
    class Yapýlar {
        static void Main() {
            Console.Write ("'struct' anahtarkelimeli yapýlarýn da sýnýf gibi alan, metod ve kurucusu vardýr ve tiplemeyle yaratýlýr, ancak sýnýf gibi referans deðil deðer tiplidir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Dikdörtgen1 d1 = new Dikdörtgen1();
            d1.en = 4; d1.boy = 5;
            Console.WriteLine ("{0}x{1} ebatlý dikdörtgenin alaný = {2}", d1.en, d1.boy, (d1.en * d1.boy));
            d1.en = 8; d1.boy = 4;
            Console.WriteLine ("{0}x{1} ebatlý dikdörtgenin alaný = {2}\n", d1.en, d1.boy, (d1.en * d1.boy));

            Dikdörtgen2 d2 = new Dikdörtgen2 (4, 5); d2.Dikdörtgen2Alaný();
            new Dikdörtgen2 (8, 4).Dikdörtgen2Alaný();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}