// tpc#39c.cs: Yavru sicimin uyutulup tekrar �al��t�r�lmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class UyutulanYavruSicim {
        public static void YavruSicime�a�r�() {
            Console.WriteLine ("Ba��ms�z �al��an yavru sicim ba�lat�l�yor");
            int uyku = 10000; //mS
            Console.WriteLine ("Yavru sicim {0} saniye uyutuluyor", (uyku / 1000));
            Thread.Sleep (uyku);
            Console.WriteLine ("Yavru sicim uyand�, �al��mas�n� s�rd�r�yor");
        }
        static void Main() {
            Console.Write ("Yavru sicim Thread.sleep(10000) metoduyla 10 sn uyutulup tekrar s�rd�r�lecek.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicime�a�r�);
            Console.WriteLine ("Main metodu: Yavru sicim yarat�l�yor");
            Thread ip = new Thread (ipRef);
            ip.Start();

            Console.WriteLine ("\nTu�..."); Console.ReadKey();
        }
    }
}