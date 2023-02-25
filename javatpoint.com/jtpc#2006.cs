// jtpc#2006.cs: �oklu g�revlenen sicimlere ad koyma ve alma �rne�i.

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
    class SicimAd� {
        static void Main() {
            Console.Write ("Sicim adlar� ip.Name='ad' ile atan�p, akt�el i�leyenin anla��lmas� i�in istenildi�inde okunabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim));

            Console.WriteLine ("3 sicimin orijinal adlar�: [{0}, {1}, {2}]", ip1.Name, ip2.Name, ip3.Name);
            ip1.Name="�lk g�rev"; ip2.Name="�kinci g�rev"; ip3.Name="���nc� g�rev";
            Console.WriteLine ("3 sicimin atanan adlar�: [{0}, {1}, {2}]\n", ip1.Name, ip2.Name, ip3.Name);
            ip1.Start(); ip2.Start(); ip3.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}