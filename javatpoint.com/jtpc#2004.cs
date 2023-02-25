// jtpc#2004.cs: �oklu g�revlemenin metodlar�n� yar�da-keserek sonland�rma �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    public class Sicimim {
        public void Sicim1() {Thread.Sleep (1); for (int i = 0; i < 5; i++) {Console.WriteLine (i);} }
        public static void Sicim2() {for (int i = 100; i < 105; i++) {Console.WriteLine (i); Thread.Sleep (5);} }
        public void Sicim3() {for (int i = 1000; i < 1005; i++) {Console.WriteLine (i);} }
    }
    class Yar�daKes {
        static void Main() {
            Console.Write ("ip.Abort() metoduyla sicimler hayat-d�ng�s�n� tamamlamad�ysa, yar�da kesip sonland�r�l�r. Abort yap�lamazsa hata f�rlat�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Sicimim tipleme = new Sicimim();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Sicim1));
            Thread ip2 = new Thread (new ThreadStart (Sicimim.Sicim2));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Sicim3));
            ip1.Start(); ip2.Start(); ip3.Start();
            try {ip1.Abort(); ip2.Abort(); ip3.Abort();
            }catch (ThreadAbortException hata) {Console.WriteLine ("HATA: [{0}]", hata.ToString());}
            Console.WriteLine ("Program ak���na devam");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}