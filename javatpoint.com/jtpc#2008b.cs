// jtpc#2008b.cs: Çoklu görevlemenin lock ile müdahelelerden korunmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class Eþzamanlama {
        public void Yaz() {// Lock'lu senkron metod
            lock (this) {
                Thread ip = Thread.CurrentThread;
                Console.WriteLine ("Koþan sicim adý: " + ip.Name);
                for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
            }
        }
    }
    class Eþzamanlý {
        static void Main() {
            Console.Write ("Asenkron hatalarýnda çözüm, senkron/eþzamanlý yöntemle, görevlerin herbirinin kaynaðý, tüm iþlemlerini tamamlayýp, sonra diðerine sýra vermektir. Sicim metodunu lock(this) anahtarkelimesiyle kilitlemek, tamamlanýncaya deðin baþka görev müdahelesini engeller.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Eþzamanlama tipleme = new Eþzamanlama();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Yaz));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Yaz));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Yaz));
            ip1.Name="Ýlk görev"; ip2.Name="Ýkinci görev"; ip3.Name="Üçüncü görev";
            ip1.Start(); ip3.Start(); ip2.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}