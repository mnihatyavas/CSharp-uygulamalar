// jtpc#2007.cs: Çoklu görevlenen sicimlere iþlemlerini tamamlamada öncelik dereceleri atama örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    public class Sicimim {
        public void Sicim() {
            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Koþan sicim adý: " + ip.Name);
            for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
        }
    }
    class SicimÖnceliði {
        static void Main() {
            Console.Write ("Sicimlere öncelik dereceleri atayarak, iþlemlerini daha önce tamamlama ihtimalleri artýrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim));
            ip1.Name="Ýlk görev"; ip2.Name="Ýkinci görev"; ip3.Name="Üçüncü görev";
            ip3.Priority = ThreadPriority.Highest;
            //ip1.Priority = ThreadPriority.Normal;
            ip1.Priority = (ThreadPriority)1;
            ip2.Priority = ThreadPriority.Lowest;
            ip1.Start(); ip2.Start(); ip3.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}