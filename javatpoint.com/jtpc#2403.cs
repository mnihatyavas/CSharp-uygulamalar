// jtpc#2403.cs: Tersiyle d�z� ayn� olan palindrom tamsay� �rne�i.

using System;
namespace �rnekler {
    class PalindromSay� {
        static void Main() {
            Console.Write ("Palindrom tamsay�lar�n soldan-sa�a ve sa�dan-sola okunu�lar� ayn�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n, arac�, toplam;
            Gir: toplam=0;
            Console.Write ("Bir +tamsay� girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            arac�=ts;
            while (ts > 0) {
               n=ts%10;
               toplam=(toplam*10)+n;
               ts=ts/10;
            }
            if (arac�==toplam) Console.WriteLine ("Girdi�iniz {0} bir PAL�NDROM say�d�r.", arac�);
            else  Console.WriteLine ("Girdi�iniz {0} bir palindrom say� DE��LD�R.", arac�);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}