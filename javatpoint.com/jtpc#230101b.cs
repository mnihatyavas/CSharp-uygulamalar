// jtpc#230101b.cs: Müþterinin son çektiði tutar ve güncel bakiye alt örneði.

using System;
namespace YeniÖzellikler {
    partial class Müþteri {
        private int tutar;
        public int Tutar {get {return tutar;} set {tutar = value;}}
        public void çek (int t) {
            tutar -=t;
            Console.WriteLine ("Son çekilen tutar: {0}.00 TL", t);
            Console.WriteLine ("Güncel bakiye: {0}.00 TL", tutar);
        }
    }
}