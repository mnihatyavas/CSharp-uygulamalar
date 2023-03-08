// jtpc#2301a1.cs: Müþterinin son yatýrdýðý tutar ve güncel bakiye alt örneði.

using System;
namespace YeniÖzellikler {
    partial class Müþteri {
        public void yatýr (int t) {
            tutar +=t;
            Console.WriteLine ("Son yatýrýlan tutar: {0}.00 TL", t);
            Console.WriteLine ("Güncel bakiye: {0}.00 TL", tutar);
        }
    }
}