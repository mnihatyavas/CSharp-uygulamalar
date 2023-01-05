// tpc#38c.cs: Göstergeç deðiþken-lerin metoda parametrik gönderilmesi örneði.

using System;
namespace GüvenilmezKodlamalar {
    class GöstergeçliParametre {
        unsafe public void takas (int* a, int *b) {int ara = *a; *a = *b; *b = ara;}
        unsafe static void Main() {
            Console.Write ("Göstergeç deðiþken-ler metoda argümanlý aktarýlýrken ilgili metod parametre-leri göstergeçli tanýmlanmalýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int tsayý1 = 2022, tsayý2 = 2023;
            int *x = &tsayý1; int *y = &tsayý2;
            Console.WriteLine ("Takas öncesi deðer(adres)ler: tsayý1:{0}({1}), tsayý2: {2}({3})", tsayý1, (int)&tsayý1, tsayý2, (int)&tsayý2);
            GöstergeçliParametre tipleme = new GöstergeçliParametre();
            tipleme.takas (x, y);
            Console.WriteLine ("Takas sonrasý deðer(adres)ler: tsayý1:{0}({1}), tsayý2: {2}({3})", tsayý1, (int)&tsayý1, tsayý2, (int)&tsayý2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}