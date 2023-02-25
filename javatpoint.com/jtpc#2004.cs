// jtpc#2004.cs: Çoklu görevlemenin metodlarýný yarýda-keserek sonlandýrma örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public void Sicim1() {Thread.Sleep (1); for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i); Thread.Sleep (5);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class YarýdaKes {
        static void Main() {
            Console.Write ("ip.Abort() metoduyla sicimler hayat-döngüsünü tamamlamadýysa, yarýda kesip sonlandýrýlýr. Abort yapýlamazsa hata fýrlatýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            ip1.Start(); ip2.Start(); ip3.Start();
            try {ip1.Abort(); ip2.Abort(); ip3.Abort();
            }catch (ThreadAbortException hata) {Console.WriteLine ("HATA: [{0}]", hata.ToString());}
            Console.WriteLine ("Program akýþýna devam");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}