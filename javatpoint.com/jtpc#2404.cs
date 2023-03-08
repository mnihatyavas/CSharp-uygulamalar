// jtpc#2404.cs: Tamsayýnýn 1'e deðin azalarak öncekilerle çarpýnýmý olan faktöryel örneði.

using System;
namespace Örnekler {
    class ArdýþýkÇarpýným {
        static void Main() {
            Console.Write ("n! faktöryel n tamsayýsýn 1'e deðin azalarak öncekilerle çarpýmýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts; long f;
            Gir: f=1;
            Console.Write ("Bir +tamsayý [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir; if (ts>20) ts=20;
            for (int i=1; i <= ts; i++) f*=i;
            Console.WriteLine ("Girdiðiniz {0} sayýsýnýn faktöryeli = {1}", ts, f);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}