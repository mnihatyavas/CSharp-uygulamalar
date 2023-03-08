// jtpc#2405.cs: Sayý hanelerinin küplerinin toplamý sayýyla ayný olan Armstrong tamsayý örneði.

using System;
namespace Örnekler {
    class ArmstrongSayý {
        static void Main() {
            Console.Write ("Armstrong tamsayýnýn herbir hanelerinin küplerinin toplamý sayýnýn kendisine (0, 1, 153, 370, 371 ve 407) eþittir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, aracý, toplam, n;
            Gir: toplam=0;
            Console.Write ("Bir +tamsayý [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            aracý=ts;
            while (ts > 0) {
                n=ts%10;
                toplam=toplam+(n*n*n);
                ts=ts/10;
            }
            if (aracý==toplam) Console.WriteLine ("Girdiðiniz {0} bir ARMSTRON sayýdýr.", aracý);
            else Console.WriteLine ("Girdiðiniz {0} bir armstrong sayý DEÐÝLDÝR.", aracý);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}