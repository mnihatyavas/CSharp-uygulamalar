// jtpc#2404.cs: Tamsay�n�n 1'e de�in azalarak �ncekilerle �arp�n�m� olan fakt�ryel �rne�i.

using System;
namespace �rnekler {
    class Ard���k�arp�n�m {
        static void Main() {
            Console.Write ("n! fakt�ryel n tamsay�s�n 1'e de�in azalarak �ncekilerle �arp�m�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts; long f;
            Gir: f=1;
            Console.Write ("Bir +tamsay� [0,20] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir; if (ts>20) ts=20;
            for (int i=1; i <= ts; i++) f*=i;
            Console.WriteLine ("Girdi�iniz {0} say�s�n�n fakt�ryeli = {1}", ts, f);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}