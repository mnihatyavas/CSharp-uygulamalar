// jtpc#230101b.cs: M��terinin son �ekti�i tutar ve g�ncel bakiye alt �rne�i.

using System;
namespace Yeni�zellikler {
    partial class M��teri {
        private int tutar;
        public int Tutar {get {return tutar;} set {tutar = value;}}
        public void �ek (int t) {
            tutar -=t;
            Console.WriteLine ("Son �ekilen tutar: {0}.00 TL", t);
            Console.WriteLine ("G�ncel bakiye: {0}.00 TL", tutar);
        }
    }
}