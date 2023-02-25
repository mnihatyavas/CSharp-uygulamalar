// jtpc#1501.cs: Koleksiyon soysal aduzamlý liste sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Liste {
        static void Main() {
            Console.Write ("Koleksiyonlar, dizi gibi sabit ebatlý olmayýp dinamik uzar veya kýsalýrlar. Nesneleri depolar, günceller, siler, ekler, eriþir, araþtýrýr ve sýralarlar.\nSystem.Collections.Generic sýnýflarý: List, Stack, Queue, LinkedList, HashSet, SortedSet, Dictionary, SortedDictionary, SortedList\nSystem.Collections (demode) sýnýflarý: ArrayList, Stack, Queue, Hashtable\nSystem.Collections.Concurrent sýnýflarý: BlockingCollection, ConcurrentBag, ConcurrentStack, ConcurrentQueue, ConcurrentDictionary, Partitioner, OrderablePartitioner\nSystem.Collections.Generic aduzamlý List<T> yegane anahtarsýz olduðundan benzer çoklu eleman içerebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new List<string>();
            adListesi.Add ("Hatice (Yavaþ) Kaçar");
            adListesi.Add ("Süheyla (Yavaþ) Özbay");
            adListesi.Add ("Zeliha (Yavaþ) Candan");
            adListesi.Add ("M.Nihat Yavaþ");
            adListesi.Add ("M.Nihat Yavaþ");
            adListesi.Add ("Songül (Yavaþ) Göktürk");
            adListesi.Add ("M.Nedim Yavaþ");
            adListesi.Add ("Sevim Yavaþ");
            adListesi.Add ("Sevim Yavaþ");
            Console.WriteLine ("List ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}