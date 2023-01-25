// jtpc#0901.cs: Ayn� adl� fakat farkl� say�l� veya tipli arg�manlarla toplama �rne�i.

using System;
namespace �oklubi�im {
    public class Toplama {
        public static int topla (int a, int b){return a + b;} // Farkl� say�l� arg�man a��r�y�klemesi
        public static int topla (int a, int b, int c) {return a + b + c;}
        public static int topla (int a, int b, int c, int d) {return a + b + c + d;}
        public static float topla (float a, float b){return a + b;} // Farkl� tipli arg�man a��r�y�klemesi
        public static double topla (double a, double b){return a + b;}
        public static long topla (long a, long b){return a + b;}
    }
    class MetodA��r�y�kleme {
        static void Main() {
            Console.Write ("Parametre bulunduran iki veya daha fazla ayn� adl� metod, kurucu yada endeksli �zelli�in parametre say� veya tip farkl�l���na (metod) �ye a��r�y�kleme denir. Metod a��r�y�kleme arg�man say�s�nda veya tipinde farkl�l�kla yap�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("Integer: 12+23+15+8 = {0}", Toplama.topla (12, 23, 15, 8));
            Console.WriteLine ("Integer: 12+8 = {0}", Toplama.topla (12, 8));
            Console.WriteLine ("Integer: 12+23+15 = {0}", Toplama.topla (12, 23, 15));

            Console.WriteLine ("\nFloat: 3.141592653589793f + 2.718281828459045f = {0}", Toplama.topla (3.141592653589793f, 2.718281828459045f));
            Console.WriteLine ("Double: 2*3.141592653589793d + 3*2.718281828459045d = {0}", Toplama.topla (2 * 3.141592653589793d, 3 * 2.718281828459045d));
            Console.WriteLine ("Long: 9223372036854775807L + -9223372036854775808L = {0}", Toplama.topla (9223372036854775807L, -9223372036854775808L));

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}