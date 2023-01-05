// tpc#39d.cs: Yavru sicimin uyutulurken sonlandýrýlmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class YavruSicimÝmhasý {
        public static void YavruSicimeÇaðrý() {
            try {
                Console.WriteLine ("Baðýmsýz çalýþan yavru sicim baþlatýlýyor");
                for (int sayaç = 0; sayaç <= 10; sayaç++) {// Siçim toplam 10 sn iþ yapýyor
                    Thread.Sleep (1000);
                    Console.WriteLine (sayaç + " sn");
                }
                Console.WriteLine ("Yavru sicim toplam 10 sn'lik iþini tamamladý");
            } catch (Exception hata) {Console.WriteLine ("Sicimin Sonlandýrýlmasý Ýstisnasý: [{0}]", hata);
            } finally {Console.WriteLine ("Sicim Ýstisnasý yakalandýktan sonra try-catch-finally sonlandý");}
        }
        static void Main() {
            Console.Write ("Yavru sicim Thread.sleep(10000) metoduyla 10 sn uyutulurken abort() metoduyla sonlandýrýlacak. Abort metodu try-catch içinde yönetilirse fýrlatýlan ThreadAbortException/SicimSonlandýrmaÝstisnasý yakalanabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ThreadStart ipRef = new ThreadStart (YavruSicimeÇaðrý);
            Console.WriteLine ("Main metodu: Yavru sicim yaratýlýyor");
            Thread ip = new Thread (ipRef);
            ip.Start();
            Thread.Sleep (8000); // Uyku, sicimin 10 sn'lik iþ süresini aþarsa istisna yakalanmaz
            Console.WriteLine ("Main metodu: 8 sn uyku sonrasý sicim kýrýlýyor");
            try {ip.Abort();}catch (ThreadAbortException hata) {Console.WriteLine ("Main metodu: [{0}]", hata);} // Bu istisna burada hiç yakalanmaz

            Console.WriteLine ("\nTuþ..."); Console.ReadKey();
        }
    }
}