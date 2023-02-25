// jtpc#2003.cs: Çoklu görevlemenin metodlarýný uyutarak bekletme örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public void Sicim1() {Thread.Sleep (100); for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i); Thread.Sleep (50);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class Uyut {
        static void Main() {
            Console.Write ("Thread.Sleep(mS) metoduyla sicimler istenilen mS süresince bekletilebilir, böylece sonraki sicimleröncelikli iþletilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            ip1.Start(); ip2.Start(); ip3.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}