// jtpc#2411c.cs: Fibonaki serisiyle, girilen tamsayý basamaklý diküçgen piramit kurma örneði.

using System;
namespace Örnekler {
    class FibonakiÜçgeni {
        static void Main() {
            Console.Write ("Önceki iki rakam toplamlý fibonaki serisiyle, girilen basamaklý üçgen piramit, her basamaktaki ardýþýk rakam sayýsý 1-2-3-4... artýrýlarak kurulmaktadýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i, j, a, b, c;
            Gir: Console.Write ("Üçgenin basamak +sayýsýný [1,22] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 1 ) ts=1; if (ts > 22) ts=22;
            for (i=1; i<=ts; i++) {
                a=0;
                b=1;
                Console.Write (a+" ");
                for (j=1; j<i; j++) {
                    c=a+b;
                    Console.Write (b+" ");
                    a=b;
                    b=c;
                }
                Console.Write ("\n");
            }  
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}