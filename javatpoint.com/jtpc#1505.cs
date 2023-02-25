// jtpc#1505.cs: Koleksiyon soysal aduzamlý sýralý-küme sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class SýralýKüme {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý SortedSet<T> yegane anahtarlý (küme özelliði) olduðundan ilkinden sonraki benzer çoklu elemanlarý içermezler ve artan sýralýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi1 = new SortedSet<string>();
            adListesi1.Add ("Hatice (Yavaþ) Kaçar");
            adListesi1.Add ("Süheyla (Yavaþ) Özbay");
            adListesi1.Add ("Zeliha (Yavaþ) Candan");
            adListesi1.Add ("M.Nihat Yavaþ");
            adListesi1.Add ("M.Nihat Yavaþ");
            adListesi1.Add ("Songül (Yavaþ) Göktürk");
            adListesi1.Add ("M.Nedim Yavaþ");
            adListesi1.Add ("Sevim Yavaþ");
            adListesi1.Add ("Sevim Yavaþ");
            Console.WriteLine ("SortedSet ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adListesi1) {Console.WriteLine (++i + ": " + ad);}

            var adListesi2 = new SortedSet<string>() {"Hatice (Yavaþ) Kaçar", "Süheyla (Yavaþ) Özbay", "Zeliha (Yavaþ) Candan", "M.Nihat Yavaþ", "M.Nihat Yavaþ", "Songül (Yavaþ) Göktürk",  "M.Nedim Yavaþ", "Sevim Yavaþ",  "Sevim Yavaþ"};
            Console.WriteLine ("\nÝlkdeðerli SortedSet yegane artan sýralý ad listesi dökümleniyor:"); i=0;
            foreach (var ad in adListesi2) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}