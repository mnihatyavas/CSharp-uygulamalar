// jtpc#2301a1.cs: M��terinin son yat�rd��� tutar ve g�ncel bakiye alt �rne�i.

using System;
namespace Yeni�zellikler {
    partial class M��teri {
        public void yat�r (int t) {
            tutar +=t;
            Console.WriteLine ("Son yat�r�lan tutar: {0}.00 TL", t);
            Console.WriteLine ("G�ncel bakiye: {0}.00 TL", tutar);
        }
    }
}