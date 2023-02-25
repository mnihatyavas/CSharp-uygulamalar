// jtpc#2005.cs: Çoklu görevlemenin araya baþkalarý girmeden tamamlanmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public void Sicim1() {Thread.Sleep (1000); for (int i = 0; i < 10; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i); Thread.Sleep (200);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class Birleþtir {
        static void Main() {
            Console.Write ("ip.Join() metoduyla sicimin tüm iþlevini, araya baþka görevler girmeden tamamlamasý saðlanýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            ip1.Start(); ip1.Join(); ip2.Start(); ip3.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}