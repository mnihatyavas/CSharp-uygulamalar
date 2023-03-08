// jtpc#2407.cs: Say�n�n tersine �evrilmesi �rne�i.

using System;
namespace �rnekler {
    class Say�n�nTersi {
        static void Main() {
            Console.Write ("Girilen tamsay�n�n s�f�ra de�in 10'a b�l�me devamla her 10'a b�l�m kalan�n�n 10'la �arp�lan toplama ilavesi say�n�n tersini verir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, toplam, n, arac�;
            Gir: toplam=0;
            Console.Write ("Bir +tamsay� [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            arac�=ts;
            while (ts > 0) {
                n=ts%10;
                toplam=toplam*10+n;
                ts=ts/10;
            }
            Console.WriteLine ("Girdi�iniz {0} say�s�n�n tersi: {1}", arac�, toplam);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}