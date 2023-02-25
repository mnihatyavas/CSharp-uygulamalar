// jtpc#2008a.cs: �oklu g�revlemenin lock'suz m�daheleli �rne�i.

using System;
using System.Threading;
namespace �okluG�revleme {
    class E�zamanlama {
        public void Yaz() {// Lock'suz asenkron metod
            //lock (this) {
                Thread ip = Thread.CurrentThread;
                Console.WriteLine ("Ko�an sicim ad�: " + ip.Name);
                for (int i = 0; i <= 5; i++) {Console.WriteLine (i);}
            //}
        }
    }
    class E�zamans�z {
        static void Main() {
            Console.Write ("Normalda �oklu g�revler asenkron/e�zamans�z olup, hepsi ayn� kayna�� ayn� zamanl� kullan�rlar Bu da bazan sistem t�kanmas� veya para yat�rma/�ekme hatalar� do�urabilir. Bu durumlarda ��z�m, senkron/e�zamanl� y�ntemle, g�revlerin herbirinin kayna��, t�m i�lemlerini tamamlay�p, sonra di�erine s�ra vermektir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

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