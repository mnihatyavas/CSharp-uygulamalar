// tpc#39c.cs: Yavru sicimin uyutulup tekrar çalıştırılması örneği.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class UyutulanYavruSicim {
        public static void YavruSicimeÇağrı() {
            Console.WriteLine ("Bağımsız çalışan yavru sicim başlatılıyor");
            int uyku = 10000; //mS
            Console.WriteLine ("Yavru sicim {0} saniye uyutuluyor", (uyku / 1000));
            Thread.Sleep (uyku);
            Console.WriteLine ("Yavru sicim uyandı, çalışmasını sürdürüyor");
        }
        static void Main() {
            Console.Write ("Yavru sicim Thread.sleep(10000) metoduyla 10 sn uyutulup tekrar sürdürülecek.\nTuş..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicimeÇağrı);
            Console.WriteLine ("Main metodu: Yavru sicim yaratılıyor");
            Thread ip = new Thread (ipRef);
            ip.Start();

            Console.WriteLine ("\nTuş..."); Console.ReadKey();
        }
    }
}