// jtpc#2002a.cs: Çoklu görevlemenin statik metodlar çaðýrmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public static void Sicim1() {for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i);} }
        public static void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class SicimA {
        static void Main() {
            Console.Write ("Thread ve ThreadStart sýnýf tiplemeleriyle yaratýlan çoklugörevlerin herbiri statik olan/olmayan metodlar çaðýrabilir. Statik metod, sýnýfýnýn tiplemesiz Sýnýf.Metod'la doðrudan çaðrýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip1 = new Thread (new ThreadStart (Sicimim.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (Sicimim.Sicim3));
            //Thread ip4 = new Thread (new ThreadStart (Sicimim.Sicim1));
            /*ip4.Start();*/ ip3.Start(); ip1.Start(); ip2.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}