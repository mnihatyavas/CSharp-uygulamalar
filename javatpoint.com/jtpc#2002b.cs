// jtpc#2002b.cs: Çoklu görevlemenin statik olmayan metodlar çaðýrmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public void Sicim1() {for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class SicimB {
        static void Main() {
            Console.Write ("Statik olmayan ayný veya farklý metodlarýn çaðrýlmasý, sýnýfýnýn tiplemesiyle yapýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            Thread ip4 = new Thread (new ThreadStart (tipleme.Sicim1));
            ip3.Start(); ip1.Start(); ip2.Start(); ip4.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}