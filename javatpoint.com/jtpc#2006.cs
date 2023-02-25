// jtpc#2006.cs: Çoklu görevlenen sicimlere ad koyma ve alma örneði.

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
    class SicimAdý {
        static void Main() {
            Console.Write ("Sicim adlarý ip.Name='ad' ile atanýp, aktüel iþleyenin anlaþýlmasý için istenildiðinde okunabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Sicim));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim));

            Console.WriteLine ("3 sicimin orijinal adlarý: [{0}, {1}, {2}]", ip1.Name, ip2.Name, ip3.Name);
            ip1.Name="Ýlk görev"; ip2.Name="Ýkinci görev"; ip3.Name="Üçüncü görev";
            Console.WriteLine ("3 sicimin atanan adlarý: [{0}, {1}, {2}]\n", ip1.Name, ip2.Name, ip3.Name);
            ip1.Start(); ip2.Start(); ip3.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}