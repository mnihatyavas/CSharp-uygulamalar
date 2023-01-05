// tpc#38a.cs: Göstergeç deðiþkenli unsafe Main metod örneði.

using System;
namespace GüvenilmezKodlamalar {
    class GüvenilmezMain {
        static unsafe void Main() {
            Console.Write ("Ýçinde göstergeç deðiþken kullanýlan metod C veya C++'da deðil C#'da unsafe/güvenilmez deðiþtireciyle iþaretlenmeli ve [>csc /unsafe tpc#38a.cs] olarak derlenmelidir. Göstergeç *deðiþken (int *ig, double *dg, float *fg, char *cg, string *sg vb), baþka bir deðiþkenin deðerini deðil bellek adresini tutar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int td = 2023;
            int *tg = &td;
            Console.WriteLine ("Deðiþkenli ve göstergeçli tamsayý veri: {0} ve {1}={2}", td, *tg, tg->ToString());
            Console.WriteLine ("Tamsayý deðiþkenin bellek adresi: {0}", (int)tg);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}