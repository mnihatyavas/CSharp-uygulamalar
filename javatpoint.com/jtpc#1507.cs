// jtpc#1507.cs: Koleksiyon soysal aduzamlý kuyruk sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Kuyruk {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý Queue<Tip>, adý gibi FIFO/ÝGÝÇ/ÝlkGirenÝlkÇýkar prensipli arkaarkaya dizilen kuyruðu temsil eder. Enqueue ile kuyruklanýr, Dequeue ile kuyruksuzlanarak taranýr. Ayný çoklu elemanlar olabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adKuyruðu = new Queue<string>();
            adKuyruðu.Enqueue ("Hatice (Yavaþ) Kaçar");
            adKuyruðu.Enqueue ("Süheyla (Yavaþ) Özbay");
            adKuyruðu.Enqueue ("Zeliha (Yavaþ) Candan");
            adKuyruðu.Enqueue ("M.Nihat Yavaþ");
            adKuyruðu.Enqueue ("M.Nihat Yavaþ");
            adKuyruðu.Enqueue ("Songül (Yavaþ) Göktürk");
            adKuyruðu.Enqueue ("M.Nedim Yavaþ");
            adKuyruðu.Enqueue ("Sevim Yavaþ");
            adKuyruðu.Enqueue ("Sevim Yavaþ");
            Console.WriteLine ("Queue ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adKuyruðu) {Console.WriteLine (++i + ": " + ad);}

            Console.WriteLine ("\n3 ardýþýk Peek: {0}, {1}, {2}", adKuyruðu.Peek(), adKuyruðu.Peek(), adKuyruðu.Peek());
            Console.WriteLine ("3 ardýþýk Dequeue: {0}, {1}, {2}", adKuyruðu.Dequeue(), adKuyruðu.Dequeue(), adKuyruðu.Dequeue());
            Console.WriteLine ("3 ardýþýk Peek: {0}, {1}, {2}", adKuyruðu.Peek(), adKuyruðu.Peek(), adKuyruðu.Peek());
            Console.WriteLine ("3 ardýþýk Dequeue: {0}, {1}, {2}", adKuyruðu.Dequeue(), adKuyruðu.Dequeue(), adKuyruðu.Dequeue());
            Console.WriteLine ("3 ardýþýk Peek: {0}, {1}, {2}", adKuyruðu.Peek(), adKuyruðu.Peek(), adKuyruðu.Peek());
            Console.WriteLine ("3 ardýþýk Dequeue: {0}, {1}, {2}", adKuyruðu.Dequeue(), adKuyruðu.Dequeue(), adKuyruðu.Dequeue());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}