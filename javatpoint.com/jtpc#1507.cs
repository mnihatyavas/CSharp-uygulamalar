// jtpc#1507.cs: Koleksiyon soysal aduzaml� kuyruk s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Kuyruk {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� Queue<Tip>, ad� gibi FIFO/�G��/�lkGiren�lk��kar prensipli arkaarkaya dizilen kuyru�u temsil eder. Enqueue ile kuyruklan�r, Dequeue ile kuyruksuzlanarak taran�r. Ayn� �oklu elemanlar olabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adKuyru�u = new Queue<string>();
            adKuyru�u.Enqueue ("Hatice (Yava�) Ka�ar");
            adKuyru�u.Enqueue ("S�heyla (Yava�) �zbay");
            adKuyru�u.Enqueue ("Zeliha (Yava�) Candan");
            adKuyru�u.Enqueue ("M.Nihat Yava�");
            adKuyru�u.Enqueue ("M.Nihat Yava�");
            adKuyru�u.Enqueue ("Song�l (Yava�) G�kt�rk");
            adKuyru�u.Enqueue ("M.Nedim Yava�");
            adKuyru�u.Enqueue ("Sevim Yava�");
            adKuyru�u.Enqueue ("Sevim Yava�");
            Console.WriteLine ("Queue ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adKuyru�u) {Console.WriteLine (++i + ": " + ad);}

            Console.WriteLine ("\n3 ard���k Peek: {0}, {1}, {2}", adKuyru�u.Peek(), adKuyru�u.Peek(), adKuyru�u.Peek());
            Console.WriteLine ("3 ard���k Dequeue: {0}, {1}, {2}", adKuyru�u.Dequeue(), adKuyru�u.Dequeue(), adKuyru�u.Dequeue());
            Console.WriteLine ("3 ard���k Peek: {0}, {1}, {2}", adKuyru�u.Peek(), adKuyru�u.Peek(), adKuyru�u.Peek());
            Console.WriteLine ("3 ard���k Dequeue: {0}, {1}, {2}", adKuyru�u.Dequeue(), adKuyru�u.Dequeue(), adKuyru�u.Dequeue());
            Console.WriteLine ("3 ard���k Peek: {0}, {1}, {2}", adKuyru�u.Peek(), adKuyru�u.Peek(), adKuyru�u.Peek());
            Console.WriteLine ("3 ard���k Dequeue: {0}, {1}, {2}", adKuyru�u.Dequeue(), adKuyru�u.Dequeue(), adKuyru�u.Dequeue());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}