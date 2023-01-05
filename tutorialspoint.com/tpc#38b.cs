// tpc#38b.cs: Göstergeç deðiþkenli unsafe kodlama bloðu örneði.

using System;
namespace GüvenilmezKodlamalar {
    class GüvenilmezBlok {
        static void Main() {
            Console.Write ("Göstergeç tüm metodda deðilse, sadece göstergeçli kodlama-lar unsafe{...} bloðuna alýnmalýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int td = 2023;
            unsafe {
                int *tg = &td;
                Console.WriteLine ("Deðiþkenli ve göstergeçli tamsayý veri: {0} ve {1}={2}", td, *tg, tg->ToString());
                Console.WriteLine ("Tamsayý deðiþkenin bellek adresi: {0}", (int)tg);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}