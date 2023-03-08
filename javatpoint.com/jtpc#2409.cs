// jtpc#2409.cs: Girilen ondal�k tamsay�n�n ikiliye �evrilmesi �rne�i.

using System;
namespace �rnekler {
    class Ondal�ktan�kiliye {
        static void Main() {
            Console.Write ("Bir tamsay�n�n modulus-2 (%2) ile ikiye b�l�m�n�n kalan� (0 veya 1) ard���k dizilip tamsay� da s�f�rlan�ncaya de�in 2'ye b�l�n�rse, sonu� dizilim ondal���n ikiliye �evrimidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, i; int[] ikiliDizi=new int[100];
            Gir: Console.Write ("Ondal�k +tamsay�y� girin [-1: Son]: ");
            try {ts = int.Parse (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            Console.Write ("Girdi�iniz {0}'in ikili kar��l��� = ", ts);
            for (i=0; ts > 0; i++) {ikiliDizi [i]=ts%2; ts=ts/2;}
            for (;i >= 0 ;i--) {Console.Write (ikiliDizi [i]);}
            Console.WriteLine("\n"); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}