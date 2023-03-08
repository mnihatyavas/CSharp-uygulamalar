// jtpc#2406.cs: Say� hanelerinin toplam�n�n hesaplanmas� �rne�i.

using System;
namespace �rnekler {
    class HanelerToplam� {
        static void Main() {
            Console.Write ("Girilen tamsay�n�n s�f�ra de�in 10'a b�l�me devamla her 10'a b�l�m kalan�n�n toplam� bize tamsay� hanelerinin toplam�n� verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, toplam, n, arac�;
            Gir: toplam=0;
            Console.Write ("Bir +tamsay� [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            arac�=ts;
            while (ts > 0) {
                n=ts%10;
                toplam+=n;
                ts=ts/10;
            }
            Console.WriteLine ("Girdi�iniz {0} say� hanelerinin toplam�: {1}", arac�, toplam);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}