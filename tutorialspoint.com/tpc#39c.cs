// tpc#39c.cs: Yavru sicimin uyutulup tekrar çalýþtýrýlmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class UyutulanYavruSicim {
        public static void YavruSicimeÇaðrý() {
            Console.WriteLine ("Baðýmsýz çalýþan yavru sicim baþlatýlýyor");
            int uyku = 10000; //mS
            Console.WriteLine ("Yavru sicim {0} saniye uyutuluyor", (uyku / 1000));
            Thread.Sleep (uyku);
            Console.WriteLine ("Yavru sicim uyandý, çalýþmasýný sürdürüyor");
        }
        static void Main() {
            Console.Write ("Yavru sicim Thread.sleep(10000) metoduyla 10 sn uyutulup tekrar sürdürülecek.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicimeÇaðrý);
            Console.WriteLine ("Main metodu: Yavru sicim yaratýlýyor");
            Thread ip = new Thread (ipRef);
            ip.Start();

            Console.WriteLine ("\nTuþ..."); Console.ReadKey();
        }
    }
}