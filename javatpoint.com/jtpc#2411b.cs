// jtpc#2411b.cs: 0-9 rakamlarla, girilen tamsayý basamaklý üçgen piramit kurma örneði.

using System;
namespace Örnekler {
    class RakamÜçgeni {
        static void Main() {
            Console.Write ("0-9 rakamlarla, girilen basamaklý üçgen piramit, her basamaktaki ardýþýk rakam sayýsý 1-3-5... artýrýlarak kurulmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i, j, k, m;
            Gir: Console.Write ("Üçgenin basamak +sayýsýný [1,10] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 1 ) ts=1; if (ts > 10) ts=10;
            for (i=0; i<ts; i++) {
                for (j=0; j<ts-i; j++) Console.Write (" ");
                for (k=0; k<i; k++) Console.Write (k);
                for (m=i; m>=0; m--) Console.Write (m);
                Console.Write ("\n");
            }
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}