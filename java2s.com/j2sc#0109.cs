// j2sc#0109.cs: De�i�ken kimlikleyici kurallar �rne�i.

using System;
namespace DilTemelleri {
    class De�i�kenKimlikleyici {
        static void Main() {
            Console.Write ("De�i�kenin ilk karakteri (k���k/b�y�k-harfe duyarl�) harf (_ ve @ olabilir), sonrakiler ise harf, rakam ve _ olabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int @k1, k3_4; double _k2;
            for (@k1 = 0; @k1 < 10; @k1++) {
                _k2 = Math.Sqrt (@k1); 
                k3_4 = @k1 * @k1;
                Console.WriteLine ("{0}'in karesi: {1}, ve karek�k�: {2:0.0000}", @k1, k3_4, _k2);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}