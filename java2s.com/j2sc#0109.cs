// j2sc#0109.cs: Deðiþken kimlikleyici kurallar örneði.

using System;
namespace DilTemelleri {
    class DeðiþkenKimlikleyici {
        static void Main() {
            Console.Write ("Deðiþkenin ilk karakteri (küçük/büyük-harfe duyarlý) harf (_ ve @ olabilir), sonrakiler ise harf, rakam ve _ olabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int @k1, k3_4; double _k2;
            for (@k1 = 0; @k1 < 10; @k1++) {
                _k2 = Math.Sqrt (@k1); 
                k3_4 = @k1 * @k1;
                Console.WriteLine ("{0}'in karesi: {1}, ve karekökü: {2:0.0000}", @k1, k3_4, _k2);
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}