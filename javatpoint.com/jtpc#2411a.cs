// jtpc#2411a.cs: A-Z harflerle, girilen tamsayý basamaklý üçgen piramit kurma örneði.

using System;
namespace Örnekler {
    class HarfÜçgeni {
        static void Main() {
            Console.Write ("A-Z harflerle, girilen basamaklý üçgen piramit, her basamaktaki ardýþýk harf sayýsý 1-3-5... artýrýlarak kurulmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i, j, k, m;
            char krk='A';
            Gir: Console.Write ("Üçgenin basamak +sayýsýný [1,26] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 1 ) ts=1; if (ts > 26) ts=26;
            for (i=1; i<=ts; i++) {
                for (j=ts; j>=i; j--) Console.Write (" ");
                for (k=1; k<=i; k++) Console.Write (krk++);
                krk--;
                for (m=1; m<i; m++) Console.Write (--krk);
                Console.Write ("\n");
                krk='A';
            }
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}