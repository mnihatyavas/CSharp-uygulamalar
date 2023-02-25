// jtpc#1503.cs: Koleksiyon soysal aduzaml� ba�l� liste s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Ba�l�Liste {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� LinkedList<Tip> Add yerine AddFirst ve AddLast ile elemanlar� koleksiyon ba��na ve sonuna koyabilir. Benzer �oklu elemangirilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new LinkedList<string>();
            adListesi.AddLast ("Hatice (Yava�) Ka�ar");
            adListesi.AddLast ("S�heyla (Yava�) �zbay");
            adListesi.AddLast ("Zeliha (Yava�) Candan");
            adListesi.AddFirst ("M.Nihat Yava�");
            adListesi.AddLast ("M.Nihat Yava�");
            adListesi.AddFirst ("Song�l (Yava�) G�kt�rk");
            adListesi.AddFirst ("M.Nedim Yava�");
	    adListesi.AddFirst ("Sevim Yava�");
            Console.WriteLine ("LinkedList ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}