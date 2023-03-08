// jtpc#2408.cs: Ýki tamsayýnýn karþýlýklý takasý örneði.

using System;
namespace Örnekler {
    class SayýTakasý {
        static void Main() {
            Console.Write ("Ýki farklý tamsayý, 3.aracý deðiþkenle, aracýsýz çarpma-bölme-bölme ve toplama-çýkarma-çýkarma olmak üzere 3 farklý yöntemle karþýlýklý takas edilebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts1, ts2, aracý;
            Gir1: Console.Write ("Ýlk +tamsayýyý girin [-1: Son]: ");
            try {ts1 = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir1;}
            if (ts1 == -1 ) goto Son; if (ts1 < 1 ) goto Gir1;
            Gir2: Console.Write ("Ýkinci +tamsayýyý girin: ");
            try {ts2 = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir2;}
            if (ts2 < 1 ) goto Gir2;
            Console.WriteLine ("Girdiðiniz 1.tamsayý={0} ve 2.tamsayý={1}", ts1, ts2);
            aracý=ts1; ts1=ts2; ts2=aracý;
            Console.WriteLine ("Aracýlý takas sonucu 1.tamsayý={0} ve 2.tamsayý={1}", ts1, ts2);
            ts1=ts1+ts2;
            ts2=ts1-ts2;
            ts1=ts1-ts2;
            Console.WriteLine ("Aracýsýz toplama-çýkarmalý takas sonucu 1.tamsayý={0} ve 2.tamsayý={1}", ts1, ts2);
            ts1=ts1*ts2;
            ts2=ts1/ts2;
            ts1=ts1/ts2;
            Console.WriteLine ("Aracýsýz çarpma-bölmeli takas sonucu 1.tamsayý={0} ve 2.tamsayý={1}", ts1, ts2);
            Console.WriteLine(); goto Gir1;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}