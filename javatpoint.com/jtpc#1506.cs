// jtpc#1506.cs: Koleksiyon soysal aduzamlý yýðýn sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class yýðýn {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý Stack<Tip>, adý gibi LIFO/SGÝÇ/SonGirenÝlkÇýkar prensipli üstüste yýðýlan yýðýný temsil eder. Push ile yýðýlýr, Pop ile taranýr. Ayný çoklu elemanlar olabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adYýðýný = new Stack<string>();
            adYýðýný.Push ("Hatice (Yavaþ) Kaçar");
            adYýðýný.Push ("Süheyla (Yavaþ) Özbay");
            adYýðýný.Push ("Zeliha (Yavaþ) Candan");
            adYýðýný.Push ("M.Nihat Yavaþ");
            adYýðýný.Push ("M.Nihat Yavaþ");
            adYýðýný.Push ("Songül (Yavaþ) Göktürk");
            adYýðýný.Push ("M.Nedim Yavaþ");
            adYýðýný.Push ("Sevim Yavaþ");
            adYýðýný.Push ("Sevim Yavaþ");
            Console.WriteLine ("Stack ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adYýðýný) {Console.WriteLine (++i + ": " + ad);}

            Console.WriteLine ("\n3 ardýþýk Peek: {0}, {1}, {2}", adYýðýný.Peek(), adYýðýný.Peek(), adYýðýný.Peek());
            Console.WriteLine ("3 ardýþýk Pop: {0}, {1}, {2}", adYýðýný.Pop(), adYýðýný.Pop(), adYýðýný.Pop());
            Console.WriteLine ("3 ardýþýk Peek: {0}, {1}, {2}", adYýðýný.Peek(), adYýðýný.Peek(), adYýðýný.Peek());
            Console.WriteLine ("3 ardýþýk Pop: {0}, {1}, {2}", adYýðýný.Pop(), adYýðýný.Pop(), adYýðýný.Pop());
            Console.WriteLine ("3 ardýþýk Peek: {0}, {1}, {2}", adYýðýný.Peek(), adYýðýný.Peek(), adYýðýný.Peek());
            Console.WriteLine ("3 ardýþýk Pop: {0}, {1}, {2}", adYýðýný.Pop(), adYýðýný.Pop(), adYýðýný.Pop());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}