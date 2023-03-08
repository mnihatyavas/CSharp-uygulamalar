// jtpc#2402.cs: Sadece 1 ve kendisiyle b�l�nebilen asal tamsay�lar �rne�i.

using System;
namespace �rnekler {
    class AsalSay�lar {
        static void Main() {
            Console.Write ("Asal tamsay�lar sadece 1'e ve kendilerine b�l�nebilirler.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n; bool bayrak;
            Gir: n=0; bayrak=false;
            Console.Write ("Bir +tamsay� girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            n = ts / 2;
            for (int i = 2; i <= n; i++) {
                if (ts % i == 0) {
                    Console.WriteLine ("Girdi�iniz {0} bir asalsay� DE��LD�R.", ts);
                    bayrak=true;
                    break;
                }
            }
            if (!bayrak) Console.WriteLine ("Girdi�iniz {0} bir ASALSAYIDIR.", ts);
            Console.WriteLine(); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}