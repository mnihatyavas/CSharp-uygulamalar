// jtpc#2406.cs: Sayý hanelerinin toplamýnýn hesaplanmasý örneði.

using System;
namespace Örnekler {
    class HanelerToplamý {
        static void Main() {
            Console.Write ("Girilen tamsayýnýn sýfýra deðin 10'a bölüme devamla her 10'a bölüm kalanýnýn toplamý bize tamsayý hanelerinin toplamýný verir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, toplam, n, aracý;
            Gir: toplam=0;
            Console.Write ("Bir +tamsayý [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            aracý=ts;
            while (ts > 0) {
                n=ts%10;
                toplam+=n;
                ts=ts/10;
            }
            Console.WriteLine ("Girdiðiniz {0} sayý hanelerinin toplamý: {1}", aracý, toplam);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}