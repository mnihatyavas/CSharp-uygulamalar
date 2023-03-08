// jtpc#2402.cs: Sadece 1 ve kendisiyle bölünebilen asal tamsayýlar örneði.

using System;
namespace Örnekler {
    class AsalSayýlar {
        static void Main() {
            Console.Write ("Asal tamsayýlar sadece 1'e ve kendilerine bölünebilirler.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n; bool bayrak;
            Gir: n=0; bayrak=false;
            Console.Write ("Bir +tamsayý girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            n = ts / 2;
            for (int i = 2; i <= n; i++) {
                if (ts % i == 0) {
                    Console.WriteLine ("Girdiðiniz {0} bir asalsayý DEÐÝLDÝR.", ts);
                    bayrak=true;
                    break;
                }
            }
            if (!bayrak) Console.WriteLine ("Girdiðiniz {0} bir ASALSAYIDIR.", ts);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}