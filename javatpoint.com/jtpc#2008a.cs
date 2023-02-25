// jtpc#2008a.cs: Çoklu görevlemenin lock'suz müdaheleli örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class Eþzamanlama {
        public void Yaz() {// Lock'suz asenkron metod
            //lock (this) {
                Thread ip = Thread.CurrentThread;
                Console.WriteLine ("Koþan sicim adý: " + ip.Name);
                for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
            //}
        }
    }
    class Eþzamansýz {
        static void Main() {
            Console.Write ("Normalda çoklu görevler asenkron/eþzamansýz olup, hepsi ayný kaynaðý ayný zamanlý kullanýrlar Bu da bazan sistem týkanmasý veya para yatýrma/çekme hatalarý doðurabilir. Bu durumlarda çözüm, senkron/eþzamanlý yöntemle, görevlerin herbirinin kaynaðý, tüm iþlemlerini tamamlayýp, sonra diðerine sýra vermektir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

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