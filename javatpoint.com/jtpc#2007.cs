// jtpc#2007.cs: �oklu g�revlenen sicimlere i�lemlerini tamamlamada �ncelik dereceleri atama �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    public class Sicimim {
        public void Sicim() {
            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Ko�an sicim ad�: " + ip.Name);
            for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
        }
    }
    class Sicim�nceli�i {
        static void Main() {
            Console.Write ("Sicimlere �ncelik dereceleri atayarak, i�lemlerini daha �nce tamamlama ihtimalleri art�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim));
            ip1.Name="�lk g�rev"; ip2.Name="�kinci g�rev"; ip3.Name="���nc� g�rev";
            ip3.Priority = ThreadPriority.Highest;
            //ip1.Priority = ThreadPriority.Normal;
            ip1.Priority = (ThreadPriority)1;
            ip2.Priority = ThreadPriority.Lowest;
            ip1.Start(); ip2.Start(); ip3.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}