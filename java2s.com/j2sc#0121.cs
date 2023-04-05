// j2sc#0121.cs: Çaðrýlan metotta oluþan bir istisnanýn yönetilmesi örneði.

using System;
namespace DilTemelleri {
    class MetottakiÝstisna {
        public static void istisnalýMetot1() {
            var tsDizi = new int [4];
            for (int i=0; i < 10; i++) {
                tsDizi [i] = i*i;
                Console.WriteLine ("tsDizi[{0}]: {1}", i, tsDizi [i]);
            } 
            Console.WriteLine ("Bu açýklamaya ulaþýlmaz.");
        }
        public static void istisnalýMetot2() {
            var tsDizi = new int [4];
            Console.WriteLine ("\nTry-catch'den önce...");
            try {
                for (int i=0; i < 10; i++) {
                    tsDizi [i] = i*i;
                    Console.WriteLine ("tsDizi[{0}]: {1}", i, tsDizi [i]);
                }
            }catch (IndexOutOfRangeException) {Console.WriteLine ("(Alt metotta fýrlatýlan) dizi endeks taþma istisnasý (alt metotta) yakalandý!");}
            Console.WriteLine ("Try-catch'den sonra...");
            Console.WriteLine ("Bu açýklamaya ulaþýlýr.\n");
        }
        static void Main() {
            Console.Write ("Çaðrýlan metotta oluþan bir istisna ya yine ayný yerdeki try-catch ile yada çaðýran metottaki try-catch tarafýndan yönetilebilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Try-catch'den önce...");
            try {istisnalýMetot1();
            }catch (IndexOutOfRangeException) {Console.WriteLine ("(Çaðrýlan metotta fýrlatýlan) dizi endeks taþma istisnasý (çaðýran metotta) yakalandý!");}
            Console.WriteLine ("Try-catch'den sonra...");

            istisnalýMetot2();

            try {int x = 1, y = 0;
                x /= y; //Ýstisna oluþur
            }catch (Exception h) {
                if (h is SystemException) {Console.WriteLine ("Ýstisna çalýþmazamanlý fýrlatýlmýþtýr.\nSebebi: [{0}]", h.Message);
                }else {Console.WriteLine ("Ýstisna uygulamaca fýrlatýlmýþtýr.");}
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}