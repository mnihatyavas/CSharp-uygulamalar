// j2sc#0227b.cs: Sayý biçimlemede '#0.00#' tercihi-#/mecburi-0 tamsayý ve küsürat kapsamlarý örneði.

using System;
namespace VeriTipleri {
    class SayýBiçimleme2 {
        static void Main() {
            Console.Write ("'arg,en:#0.00#' biçimlemede, argNo: 0,1,2... argüman endeksini, en: toplam ayrýlan alaný, #.# ise tamsayý ve küsürat mecburi (0) veya tercihi (#) kapsamlarýný tanýmlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var r=new Random();
            double ds1=(double)r.Next (int.MinValue, int.MaxValue) + r.Next (10000, 100000) / 100000D;
            Console.WriteLine ("Sayý biçimlemede tamsayý/küsürat mecburi-0 ve tercihi-# haneler gösterimi:");
            Console.WriteLine ("\"0:#####.000\" ile biçimleme: {0:#####.000}", ds1);
            Console.WriteLine ("\"0:#.00\" ile biçimleme: {0:#.00}", ds1);
            Console.WriteLine ("\"0,20:#.#####0\" ile biçimleme: {0,20:#.#####0}", ds1);
            Console.WriteLine ("\"0,20:0.00#####\" ile biçimleme: {0,20:0.00#####}\t\"{1,20:0.00#####}\"", ds1, 0);
            Console.WriteLine ("\"0,20:#.##\" ile biçimleme: {0,20:#.##}\t\"{1,20:#.##}\"", ds1, 0);

            Console.WriteLine ("\nSayý biçimleyen #0% sembollerinin aynen yansýtýlan gösterimi:");
            Console.WriteLine ("\"0:#.#####\" ile biçimleme: {0:#.#####}", ds1);
            Console.WriteLine ("\"0:#.#####\\#\" ile biçimleme: {0:#.#####\\#}", ds1);
            Console.WriteLine (@"(0:#.#####\#) ile biçimleme: {0:#.#####\#}", ds1);
            Console.WriteLine ("\"0:#.#####'#0%\" ile biçimleme: {0:#.#####'#0%}", ds1);

            Console.WriteLine ("\nSayý biçimleyen tamsayý noktalama ayracý gösterimi:");
            Console.WriteLine ("\"0:#,###.#####\" ile biçimleme: {0:#,###.#####}", ds1);
            Console.WriteLine ("\"0:#,000.00\" ile biçimleme: {0:#,000.00}", ds1);
            Console.WriteLine ("\"0:#,#.#####\" ile biçimleme: {0:#,#.##}", ds1);

            Console.WriteLine ("\n'000,.#' ile tamsayý kýsmýný (,)3, (,,)6, (,,,)9 basamak saða kaydýrma:");
            Console.WriteLine ("\"0:000,.##\" ile biçimleme: {0:000,.##}", ds1);
            Console.WriteLine ("\"0:000,,.0000\" ile biçimleme: {0:000,,.0000}", ds1);
            Console.WriteLine ("\"0:000,,,.###\" ile biçimleme: {0:000,,,.###}", ds1);

            Console.WriteLine ("\n'0:0.0%' ile küsüratlý/küsüratsýz sayýyý 100'e çarpýp %'li biçimleme:");
            Console.WriteLine ("\"0:##.000%\" ile biçimleme: {0:##.000%}", ds1);
            Console.WriteLine ("\"0:00%\" ile biçimleme: {0:00%}", ds1);
            Console.WriteLine ("\"0:#,#.00%\" ile biçimleme: {0:#,#.00%}", ds1);
            Console.WriteLine ("\"0:0,0%\" ile biçimleme: {0:0,0%}", ds1);

            Console.WriteLine ("\n'0:###.00;0;(###.00)' ile +-0 sayýyý farklý biçimleme:");
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile biçimleme: {0:###.00;0;(###.00)}", ds1);
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile biçimleme: {0:###.00;0;(###.00)}", (-1*ds1));
            Console.WriteLine ("\"0:###.00;0;(###.00)\" ile biçimleme: {0:###.00;0;(###.00)}", (0*ds1));
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile biçimleme: {0:#,#.00;(#,#.00);0.00}", ds1);
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile biçimleme: {0:#,#.00;(#,#.00);0.00}", (-1*ds1));
            Console.WriteLine ("\"0:#,#.00;(#,#.00);0.00\" ile biçimleme: {0:#,#.00;(#,#.00);0.00}", (0*ds1));

            Console.WriteLine ("\n'0:#.000E-00' ile tek hane tamsayý, 3 hane küsürat ve 2 hane üslü gösterim:");
            Console.WriteLine ("\"0:###.000E-00\" ile biçimleme: {0:###.000E-00}", ds1);
            Console.WriteLine ("\"0:#.0000000E+000\" ile biçimleme: {0:#.0000000E+000}", ds1);
            Console.WriteLine ("\"0:0.000e-0\" ile biçimleme: {0:0.000e-0}", ds1);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}