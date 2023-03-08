// jtpc#2405.cs: Say� hanelerinin k�plerinin toplam� say�yla ayn� olan Armstrong tamsay� �rne�i.

using System;
namespace �rnekler {
    class ArmstrongSay� {
        static void Main() {
            Console.Write ("Armstrong tamsay�n�n herbir hanelerinin k�plerinin toplam� say�n�n kendisine (0, 1, 153, 370, 371 ve 407) e�ittir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, arac�, toplam, n;
            Gir: toplam=0;
            Console.Write ("Bir +tamsay� [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            arac�=ts;
            while (ts > 0) {
                n=ts%10;
                toplam=toplam+(n*n*n);
                ts=ts/10;
            }
            if (arac�==toplam) Console.WriteLine ("Girdi�iniz {0} bir ARMSTRON say�d�r.", arac�);
            else Console.WriteLine ("Girdi�iniz {0} bir armstrong say� DE��LD�R.", arac�);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}