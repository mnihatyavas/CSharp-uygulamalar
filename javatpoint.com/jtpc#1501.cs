// jtpc#1501.cs: Koleksiyon soysal aduzaml� liste s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Liste {
        static void Main() {
            Console.Write ("Koleksiyonlar, dizi gibi sabit ebatl� olmay�p dinamik uzar veya k�sal�rlar. Nesneleri depolar, g�nceller, siler, ekler, eri�ir, ara�t�r�r ve s�ralarlar.\nSystem.Collections.Generic s�n�flar�: List, Stack, Queue, LinkedList, HashSet, SortedSet, Dictionary, SortedDictionary, SortedList\nSystem.Collections (demode) s�n�flar�: ArrayList, Stack, Queue, Hashtable\nSystem.Collections.Concurrent s�n�flar�: BlockingCollection, ConcurrentBag, ConcurrentStack, ConcurrentQueue, ConcurrentDictionary, Partitioner, OrderablePartitioner\nSystem.Collections.Generic aduzaml� List<T> yegane anahtars�z oldu�undan benzer �oklu eleman i�erebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new List<string>();
            adListesi.Add ("Hatice (Yava�) Ka�ar");
            adListesi.Add ("S�heyla (Yava�) �zbay");
            adListesi.Add ("Zeliha (Yava�) Candan");
            adListesi.Add ("M.Nihat Yava�");
            adListesi.Add ("M.Nihat Yava�");
            adListesi.Add ("Song�l (Yava�) G�kt�rk");
            adListesi.Add ("M.Nedim Yava�");
            adListesi.Add ("Sevim Yava�");
            adListesi.Add ("Sevim Yava�");
            Console.WriteLine ("List ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}