// jtpc#2403.cs: Tersiyle düzü ayný olan palindrom tamsayý örneði.

using System;
namespace Örnekler {
    class PalindromSayý {
        static void Main() {
            Console.Write ("Palindrom tamsayýlarýn soldan-saða ve saðdan-sola okunuþlarý aynýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n, aracý, toplam;
            Gir: toplam=0;
            Console.Write ("Bir +tamsayý girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            aracý=ts;
            while (ts > 0) {
               n=ts%10;
               toplam=(toplam*10)+n;
               ts=ts/10;
            }
            if (aracý==toplam) Console.WriteLine ("Girdiðiniz {0} bir PALÝNDROM sayýdýr.", aracý);
            else  Console.WriteLine ("Girdiðiniz {0} bir palindrom sayý DEÐÝLDÝR.", aracý);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}