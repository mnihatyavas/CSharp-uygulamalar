// jtpc#2408.cs: �ki tamsay�n�n kar��l�kl� takas� �rne�i.

using System;
namespace �rnekler {
    class Say�Takas� {
        static void Main() {
            Console.Write ("�ki farkl� tamsay�, 3.arac� de�i�kenle, arac�s�z �arpma-b�lme-b�lme ve toplama-��karma-��karma olmak �zere 3 farkl� y�ntemle kar��l�kl� takas edilebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1, ts2, arac�;
            Gir1: Console.Write ("�lk +tamsay�y� girin [-1: Son]: ");
            try {ts1 = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir1;}
            if (ts1 == -1 ) goto Son; if (ts1 < 1 ) goto Gir1;
            Gir2: Console.Write ("�kinci +tamsay�y� girin: ");
            try {ts2 = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir2;}
            if (ts2 < 1 ) goto Gir2;
            Console.WriteLine ("Girdi�iniz 1.tamsay�={0} ve 2.tamsay�={1}", ts1, ts2);
            arac�=ts1; ts1=ts2; ts2=arac�;
            Console.WriteLine ("Arac�l� takas sonucu 1.tamsay�={0} ve 2.tamsay�={1}", ts1, ts2);
            ts1=ts1+ts2;
            ts2=ts1-ts2;
            ts1=ts1-ts2;
            Console.WriteLine ("Arac�s�z toplama-��karmal� takas sonucu 1.tamsay�={0} ve 2.tamsay�={1}", ts1, ts2);
            ts1=ts1*ts2;
            ts2=ts1/ts2;
            ts1=ts1/ts2;
            Console.WriteLine ("Arac�s�z �arpma-b�lmeli takas sonucu 1.tamsay�={0} ve 2.tamsay�={1}", ts1, ts2);
            Console.WriteLine(); goto Gir1;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}