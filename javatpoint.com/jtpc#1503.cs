// jtpc#1503.cs: Koleksiyon soysal aduzamlý baðlý liste sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class BaðlýListe {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý LinkedList<Tip> Add yerine AddFirst ve AddLast ile elemanlarý koleksiyon baþýna ve sonuna koyabilir. Benzer çoklu elemangirilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new LinkedList<string>();
            adListesi.AddLast ("Hatice (Yavaþ) Kaçar");
            adListesi.AddLast ("Süheyla (Yavaþ) Özbay");
            adListesi.AddLast ("Zeliha (Yavaþ) Candan");
            adListesi.AddFirst ("M.Nihat Yavaþ");
            adListesi.AddLast ("M.Nihat Yavaþ");
            adListesi.AddFirst ("Songül (Yavaþ) Göktürk");
            adListesi.AddFirst ("M.Nedim Yavaþ");
	    adListesi.AddFirst ("Sevim Yavaþ");
            Console.WriteLine ("LinkedList ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}