// jtpc#2005.cs: �oklu g�revlemenin araya ba�kalar� girmeden tamamlanmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    public class Sicimim {
        public void Sicim1() {Thread.Sleep (1000); for (int i = 0; i < 10; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i); Thread.Sleep (200);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class Birle�tir {
        static void Main() {
            Console.Write ("ip.Join() metoduyla sicimin t�m i�levini, araya ba�ka g�revler girmeden tamamlamas� sa�lan�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            ip1.Start(); ip1.Join(); ip2.Start(); ip3.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}