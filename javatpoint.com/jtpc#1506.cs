// jtpc#1506.cs: Koleksiyon soysal aduzaml� y���n s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class y���n {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� Stack<Tip>, ad� gibi LIFO/SG��/SonGiren�lk��kar prensipli �st�ste y���lan y���n� temsil eder. Push ile y���l�r, Pop ile taran�r. Ayn� �oklu elemanlar olabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adY���n� = new Stack<string>();
            adY���n�.Push ("Hatice (Yava�) Ka�ar");
            adY���n�.Push ("S�heyla (Yava�) �zbay");
            adY���n�.Push ("Zeliha (Yava�) Candan");
            adY���n�.Push ("M.Nihat Yava�");
            adY���n�.Push ("M.Nihat Yava�");
            adY���n�.Push ("Song�l (Yava�) G�kt�rk");
            adY���n�.Push ("M.Nedim Yava�");
            adY���n�.Push ("Sevim Yava�");
            adY���n�.Push ("Sevim Yava�");
            Console.WriteLine ("Stack ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adY���n�) {Console.WriteLine (++i + ": " + ad);}

            Console.WriteLine ("\n3 ard���k Peek: {0}, {1}, {2}", adY���n�.Peek(), adY���n�.Peek(), adY���n�.Peek());
            Console.WriteLine ("3 ard���k Pop: {0}, {1}, {2}", adY���n�.Pop(), adY���n�.Pop(), adY���n�.Pop());
            Console.WriteLine ("3 ard���k Peek: {0}, {1}, {2}", adY���n�.Peek(), adY���n�.Peek(), adY���n�.Peek());
            Console.WriteLine ("3 ard���k Pop: {0}, {1}, {2}", adY���n�.Pop(), adY���n�.Pop(), adY���n�.Pop());
            Console.WriteLine ("3 ard���k Peek: {0}, {1}, {2}", adY���n�.Peek(), adY���n�.Peek(), adY���n�.Peek());
            Console.WriteLine ("3 ard���k Pop: {0}, {1}, {2}", adY���n�.Pop(), adY���n�.Pop(), adY���n�.Pop());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}