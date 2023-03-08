// jtpc#2409.cs: Girilen ondalýk tamsayýnýn ikiliye çevrilmesi örneði.

using System;
namespace Örnekler {
    class OndalýktanÝkiliye {
        static void Main() {
            Console.Write ("Bir tamsayýnýn modulus-2 (%2) ile ikiye bölümünün kalaný (0 veya 1) ardýþýk dizilip tamsayý da sýfýrlanýncaya deðin 2'ye bölünürse, sonuç dizilim ondalýðýn ikiliye çevrimidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i; int[] ikiliDizi=new int[100];
            Gir: Console.Write ("Ondalýk +tamsayýyý girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            Console.Write ("Girdiðiniz {0}'in ikili karþýlýðý = ", ts);
            for (i=0; ts > 0; i++) {ikiliDizi [i]=ts%2; ts=ts/2;}
            for (;i >= 0 ;i--) {Console.Write (ikiliDizi [i]);}
            Console.WriteLine("\n"); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}