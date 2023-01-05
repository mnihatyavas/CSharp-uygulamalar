// tpc#39d.cs: Yavru sicimin uyutulurken sonland�r�lmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class YavruSicim�mhas� {
        public static void YavruSicime�a�r�() {
            try {
                Console.WriteLine ("Ba��ms�z �al��an yavru sicim ba�lat�l�yor");
                for (int saya� = 0; saya� <= 10; saya�++) {// Si�im toplam 10 sn i� yap�yor
                    Thread.Sleep (1000);
                    Console.WriteLine (saya� + " sn");
                }
                Console.WriteLine ("Yavru sicim toplam 10 sn'lik i�ini tamamlad�");
            } catch (Exception hata) {Console.WriteLine ("Sicimin Sonland�r�lmas� �stisnas�: [{0}]", hata);
            } finally {Console.WriteLine ("Sicim �stisnas� yakaland�ktan sonra try-catch-finally sonland�");}
        }
        static void Main() {
            Console.Write ("Yavru sicim Thread.sleep(10000) metoduyla 10 sn uyutulurken abort() metoduyla sonland�r�lacak. Abort metodu try-catch i�inde y�netilirse f�rlat�lan ThreadAbortException/SicimSonland�rma�stisnas� yakalanabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicime�a�r�);
            Console.WriteLine ("Main metodu: Yavru sicim yarat�l�yor");
            Thread ip = new Thread (ipRef);
            ip.Start();
            Thread.Sleep (8000); // Uyku, sicimin 10 sn'lik i� s�resini a�arsa istisna yakalanmaz
            Console.WriteLine ("Main metodu: 8 sn uyku sonras� sicim k�r�l�yor");
            try {ip.Abort();}catch (ThreadAbortException hata) {Console.WriteLine ("Main metodu: [{0}]", hata);} // Bu istisna burada hi� yakalanmaz

            Console.WriteLine ("\nTu�..."); Console.ReadKey();
        }
    }
}