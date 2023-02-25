// jtpc#2002a.cs: �oklu g�revlemenin statik metodlar �a��rmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    public class Sicimim {
        public static void Sicim1() {for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i);} }
        public static void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class SicimA {
        static void Main() {
            Console.Write ("Thread ve ThreadStart s�n�f tiplemeleriyle yarat�lan �oklug�revlerin herbiri statik olan/olmayan metodlar �a��rabilir. Statik metod, s�n�f�n�n tiplemesiz S�n�f.Metod'la do�rudan �a�r�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip1 = new Thread (new ThreadStart (Sicimim.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (Sicimim.Sicim3));
            //Thread ip4 = new Thread (new ThreadStart (Sicimim.Sicim1));
            /*ip4.Start();*/ ip3.Start(); ip1.Start(); ip2.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}