// j2sc#0304.cs: % kalan'la b�l�nemeyen son art���n bulunmas� �rne�i.

using System;
namespace ��lemciler {
    class Kalan��lemci {
        static void Main() {
            Console.Write ("Tamsay� b�l�m kalanlar� at�l�r. x%y kalan i�lemi x kapsam�ndaki tekrarl� y'lerden sonraki art��� bulur.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1=10/3, ts2=10%3, i; 
            double ds1=10.0/3.0, ds2=10.0%3.0;
            Console.WriteLine ("Tamsay� ve dublesay� b�l�m ve kalan k�yas�:"); 
            Console.WriteLine ("Tamsay� (10/3={0}) ve (10%3={1})", ts1, ts2);
            Console.WriteLine ("Dublesay� (10.0/3.0={0}) ve (10.0%3.0={1})", ds1, ds2);

            Console.WriteLine ("\n[2, 20] say�lar�n enk���k b�lenleri:");
            for (i = 2; i <= 20; i++) {
                if ((i % 2) == 0) Console.WriteLine (i + "'nin enk���k b�leni: 2'dir.");
                else if ((i % 3) == 0) Console.WriteLine (i + "'nin enk���k b�leni: 3'dir.");
                else if ((i % 5) == 0) Console.WriteLine (i + "'nin enk���k b�leni: 5'dir.");
                else if ((i % 7) == 0) Console.WriteLine (i + "'nin enk���k b�leni: 7'dir.");
                else Console.WriteLine (i + " say�s� (2, 3, 5, 7)'ye b�l�nmez.");
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}