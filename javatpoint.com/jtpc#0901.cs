// jtpc#0901.cs: Ayný adlý fakat farklý sayýlý veya tipli argümanlarla toplama örneði.

using System;
namespace Çoklubiçim {
    public class Toplama {
        public static int topla (int a, int b){return a + b;} // Farklý sayýlý argüman aþýrýyüklemesi
        public static int topla (int a, int b, int c) {return a + b + c;}
        public static int topla (int a, int b, int c, int d) {return a + b + c + d;}
        public static float topla (float a, float b){return a + b;} // Farklý tipli argüman aþýrýyüklemesi
        public static double topla (double a, double b){return a + b;}
        public static long topla (long a, long b){return a + b;}
    }
    class MetodAþýrýyükleme {
        static void Main() {
            Console.Write ("Parametre bulunduran iki veya daha fazla ayný adlý metod, kurucu yada endeksli özelliðin parametre sayý veya tip farklýlýðýna (metod) üye aþýrýyükleme denir. Metod aþýrýyükleme argüman sayýsýnda veya tipinde farklýlýkla yapýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("Integer: 12+23+15+8 = {0}", Toplama.topla (12, 23, 15, 8));
            Console.WriteLine ("Integer: 12+8 = {0}", Toplama.topla (12, 8));
            Console.WriteLine ("Integer: 12+23+15 = {0}", Toplama.topla (12, 23, 15));

            Console.WriteLine ("\nFloat: 3.141592653589793f + 2.718281828459045f = {0}", Toplama.topla (3.141592653589793f, 2.718281828459045f));
            Console.WriteLine ("Double: 2*3.141592653589793d + 3*2.718281828459045d = {0}", Toplama.topla (2 * 3.141592653589793d, 3 * 2.718281828459045d));
            Console.WriteLine ("Long: 9223372036854775807L + -9223372036854775808L = {0}", Toplama.topla (9223372036854775807L, -9223372036854775808L));

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}