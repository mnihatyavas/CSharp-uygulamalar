// j2sc#0227b.cs: Say� bi�imlemede '#0.00#' tercihi-#/mecburi-0 tamsay� ve k�s�rat kapsamlar� �rne�i.

using System;
namespace VeriTipleri {
    class Say�Bi�imleme2 {
        static void Main() {
            Console.Write ("'arg,en:#0.00#' bi�imlemede, argNo: 0,1,2... arg�man endeksini, en: toplam ayr�lan alan�, #.# ise tamsay� ve k�s�rat mecburi (0) veya tercihi (#) kapsamlar�n� tan�mlar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            double ds1=(double)r.Next (int.MinValue, int.MaxValue) + r.Next (10000, 100000) / 100000D;
            Console.WriteLine ("Say� bi�imlemede tamsay�/k�s�rat mecburi-0 ve tercihi-# haneler g�sterimi:");
            Console.WriteLine ("\"0:#####.000\" ile bi�imleme: {0:#####.000}", ds1);
            Console.WriteLine ("\"0:#.00\" ile bi�imleme: {0:#.00}", ds1);
            Console.WriteLine ("\"0,20:#.#####0\" ile bi�imleme: {0,20:#.#####0}", ds1);
            Console.WriteLine ("\"0,20:0.00#####\" ile bi�imleme: {0,20:0.00#####}\t\"{1,20:0.00#####}\"", ds1, 0);
            Console.WriteLine ("\"0,20:#.##\" ile bi�imleme: {0,20:#.##}\t\"{1,20:#.##}\"", ds1, 0);

            Console.WriteLine ("\nSay� bi�imleyen #0% sembollerinin aynen yans�t�lan g�sterimi:");
            Console.WriteLine ("\"0:#.#####\" ile bi�imleme: {0:#.#####}", ds1);
            Console.WriteLine ("\"0:#.#####\\#\" ile bi�imleme: {0:#.#####\\#}", ds1);
            Console.WriteLine (@"(0:#.#####\#) ile bi�imleme: {0:#.#####\#}", ds1);
            Console.WriteLine ("\"0:#.#####'#0%\" ile bi�imleme: {0:#.#####'#0%}", ds1);

            Console.WriteLine ("\nSay� bi�imleyen tamsay� noktalama ayrac� g�sterimi:");
            Console.WriteLine ("\"0:#,###.#####\" ile bi�imleme: {0:#,###.#####}", ds1);
            Console.WriteLine ("\"0:#,000.00\" ile bi�imleme: {0:#,000.00}", ds1);
            Console.WriteLine ("\"0:#,#.#####\" ile bi�imleme: {0:#,#.##}", ds1);

            Console.WriteLine ("\n'000,.#' ile tamsay� k�sm�n� (,)3, (,,)6, (,,,)9 basamak sa�a kayd�rma:");
            Console.WriteLine ("\"0:000,.##\" ile bi�imleme: {0:000,.##}", ds1);
            Console.WriteLine ("\"0:000,,.0000\" ile bi�imleme: {0:000,,.0000}", ds1);
            Console.WriteLine ("\"0:000,,,.###\" ile bi�imleme: {0:000,,,.###}", ds1);

            Console.WriteLine ("\n'0:0.0%' ile k�s�ratl�/k�s�rats�z say�y� 100'e �arp�p %'li bi�imleme:");
            Console.WriteLine ("\"0:##.000%\" ile bi�imleme: {0:##.000%}", ds1);
            Console.WriteLine ("\"0:00%\" ile bi�imleme: {0:00%}", ds1);
            Console.WriteLine ("\"0:#,#.00%\" ile bi�imleme: {0:#,#.00%}", ds1);
            Console.WriteLine ("\"0:0,0%\" ile bi�imleme: {0:0,0%}", ds1);

            Console.WriteLine ("\n'0:###.00;0;(###.00)' ile +-0 say�y� farkl� bi�imleme:");
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile bi�imleme: {0:###.00;0;(###.00)}", ds1);
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile bi�imleme: {0:###.00;0;(###.00)}", (-1*ds1));
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile bi�imleme: {0:###.00;0;(###.00)}", (0*ds1));
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile bi�imleme: {0:#,#.00;(#,#.00);0.00}", ds1);
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile bi�imleme: {0:#,#.00;(#,#.00);0.00}", (-1*ds1));
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile bi�imleme: {0:#,#.00;(#,#.00);0.00}", (0*ds1));

            Console.WriteLine ("\n'0:#.000E-00' ile tek hane tamsay�, 3 hane k�s�rat ve 2 hane �sl� g�sterim:");
            Console.WriteLine ("\"0:###.000E-00\" ile bi�imleme: {0:###.000E-00}", ds1);
            Console.WriteLine ("\"0:#.0000000E+000\" ile bi�imleme: {0:#.0000000E+000}", ds1);
            Console.WriteLine ("\"0:0.000e-0\" ile bi�imleme: {0:0.000e-0}", ds1);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}