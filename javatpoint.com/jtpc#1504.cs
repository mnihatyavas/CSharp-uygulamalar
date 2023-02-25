// jtpc#1504.cs: Koleksiyon soysal aduzamlý kýyma-küme sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class KýymaKüme {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý HashSet<T> yegane anahtarlý olduðundan ilkinden sonraki benzer çoklu elemanlarý içermezler.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new HashSet<string>();
            adListesi.Add ("Hatice (Yavaþ) Kaçar");
            adListesi.Add ("Süheyla (Yavaþ) Özbay");
            adListesi.Add ("Zeliha (Yavaþ) Candan");
            adListesi.Add ("M.Nihat Yavaþ");
            adListesi.Add ("M.Nihat Yavaþ");
            adListesi.Add ("Songül (Yavaþ) Göktürk");
            adListesi.Add ("M.Nedim Yavaþ");
            adListesi.Add ("Sevim Yavaþ");
            adListesi.Add ("Sevim Yavaþ");
            Console.WriteLine ("HashSet ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}