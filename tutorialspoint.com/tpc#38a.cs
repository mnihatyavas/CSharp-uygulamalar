// tpc#38a.cs: G�sterge� de�i�kenli unsafe Main metod �rne�i.

using System;
namespace G�venilmezKodlamalar {
    class G�venilmezMain {
        static unsafe void Main() {
            Console.Write ("��inde g�sterge� de�i�ken kullan�lan metod C veya C++'da de�il C#'da unsafe/g�venilmez de�i�tireciyle i�aretlenmeli ve [>csc /unsafe tpc#38a.cs] olarak derlenmelidir. G�sterge� *de�i�ken (int *ig, double *dg, float *fg, char *cg, string *sg vb), ba�ka bir de�i�kenin de�erini de�il bellek adresini tutar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int td = 2023;
            int *tg = &td;
            Console.WriteLine ("De�i�kenli ve g�sterge�li tamsay� veri: {0} ve {1}={2}", td, *tg, tg->ToString());
            Console.WriteLine ("Tamsay� de�i�kenin bellek adresi: {0}", (int)tg);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}