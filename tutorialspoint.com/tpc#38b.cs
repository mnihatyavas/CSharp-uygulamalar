// tpc#38b.cs: G�sterge� de�i�kenli unsafe kodlama blo�u �rne�i.

using System;
namespace G�venilmezKodlamalar {
    class G�venilmezBlok {
        static void Main() {
            Console.Write ("G�sterge� t�m metodda de�ilse, sadece g�sterge�li kodlama-lar unsafe{...} blo�una al�nmal�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int td = 2023;
            unsafe {
                int *tg = &td;
                Console.WriteLine ("De�i�kenli ve g�sterge�li tamsay� veri: {0} ve {1}={2}", td, *tg, tg->ToString());
                Console.WriteLine ("Tamsay� de�i�kenin bellek adresi: {0}", (int)tg);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}