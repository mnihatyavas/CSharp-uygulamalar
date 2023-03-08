// jtpc#2401.cs: �nceki iki say�n�n toplam�yla fibonaki serisi �rne�i.

using System;
namespace �rnekler {
    class FibonakiSerisi {
        static void Main() {
            Console.Write ("0-1'den itibaren �nceki iki say�n�n toplam�yla ilerleyen serinin basamak say�s� girilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts; long n1, n2, n3;
            Gir: n1=0; n2=1;
            Console.Write ("Bir +tamsay� [0, 93] girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir; if (ts > 93) ts=93;
            Console.Write (n1+" "+n2+" ");
            for (int i=2;i < ts; i++) {
                n3 = n1+n2;
                Console.Write (n3+" ");
                n1=n2; n2=n3;
            } Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}