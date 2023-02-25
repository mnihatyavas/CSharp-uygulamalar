// jtpc#2008b.cs: �oklu g�revlemenin lock ile m�dahelelerden korunmas� �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class E�zamanlama {
        public void Yaz() {// Lock'lu senkron metod
            lock (this) {
                Thread ip = Thread.CurrentThread;
                Console.WriteLine ("Ko�an sicim ad�: " + ip.Name);
                for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
            }
        }
    }
    class E�zamanl� {
        static void Main() {
            Console.Write ("Asenkron hatalar�nda ��z�m, senkron/e�zamanl� y�ntemle, g�revlerin herbirinin kayna��, t�m i�lemlerini tamamlay�p, sonra di�erine s�ra vermektir. Sicim metodunu lock(this) anahtarkelimesiyle kilitlemek, tamamlan�ncaya de�in ba�ka g�rev m�dahelesini engeller.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            E�zamanlama tipleme = new E�zamanlama();
            Thread ip1 = new Thread (new ThreadStart (tipleme.Yaz));
            Thread ip2 = new Thread (new ThreadStart (tipleme.Yaz));
            Thread ip3 = new Thread (new ThreadStart (tipleme.Yaz));
            ip1.Name="�lk g�rev"; ip2.Name="�kinci g�rev"; ip3.Name="���nc� g�rev";
            ip1.Start(); ip3.Start(); ip2.Start();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}