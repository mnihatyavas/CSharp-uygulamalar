// jtpc#2204.cs: Ýçsel, dýþsal ve kullanýcý-tanýmlý tip çevrimleri örneði.

using System;
namespace Çeþitli {
    class TipÇevrimi {
       public struct Feet {
            public float ayak;
            public Feet (float n) {this.ayak = n;}
            public static explicit operator Feet (int m) {
                float sonuç = 3.28f * m;
                Feet ara = new Feet (sonuç);
                return ara;
            }
        }
       public struct Ýnç {
            public float inç;
            public Ýnç (float n) {this.inç = n;}
            public static explicit operator Ýnç (int m) {
                float sonuç = 3.28f * 12 * m;
                Ýnç ara = new Ýnç (sonuç);
                return ara;
            }
        }
        static void Main() {
            Console.Write ("Bir veri tipli deðiþkenin baþka veri tipine dönüþtürülmesine Tip Çevrimi/(Explicit)TypeCasting denir. Tip çevrimi içsel (küçük tamsayýdan büyüðe, türevden temel sýnýfa), dýþsal (görünür () sembollü büyük tamsayýdan küçüðe, temelden türev sýnýfa), kullanýcý-tanýmlý (özel metodla içsel veya dýþsal) veya uyumsuz tipleri yardýmcý sýnýflarla (tamsayýdan DateTime nesnesine) yapýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tamsayý1 = 1951;
            int tamsayý2 = 72;
            long uzunsayý;
            uzunsayý = tamsayý1 + tamsayý2; //Ýçsel tip çevrimi
            Console.WriteLine ("Ýçsel tipçevrimi: [int {0}] + [int {1}] = [long {2}]", tamsayý1, tamsayý2, uzunsayý);

            double duble1 = 1951.25;
            double duble2 = 72.75;
            int tamsayý3;
            tamsayý3 = (int)duble1 + (int)duble2; //Dýþsal tip çevrimi
            Console.WriteLine ("Dýþsal tipçevrimi: (int)[double {0}] + (int)[double {1}] = [int {2}]", duble1, duble2, tamsayý3);

            int metre;
            gir: Console.Write ("\nTamsayý metre gir [Çýk: 0]: ");
            try {metre = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            if (metre == 0) goto son;
            Feet fit = (Feet)metre; //Kullanýcý-tanýmlý tip çevrimi
            var inc = (Ýnç)metre; //Kullanýcý-tanýmlý tip çevrimi
            Console.WriteLine ("Girilen {0} metre = {1} feet veya {2} inç.", metre, fit.ayak, inc.inç);
            goto gir;

            son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}