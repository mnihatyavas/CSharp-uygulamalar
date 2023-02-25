// jtpc#1505.cs: Koleksiyon soysal aduzaml� s�ral�-k�me s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class S�ral�K�me {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� SortedSet<T> yegane anahtarl� (k�me �zelli�i) oldu�undan ilkinden sonraki benzer �oklu elemanlar� i�ermezler ve artan s�ral�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi1 = new SortedSet<string>();
            adListesi1.Add ("Hatice (Yava�) Ka�ar");
            adListesi1.Add ("S�heyla (Yava�) �zbay");
            adListesi1.Add ("Zeliha (Yava�) Candan");
            adListesi1.Add ("M.Nihat Yava�");
            adListesi1.Add ("M.Nihat Yava�");
            adListesi1.Add ("Song�l (Yava�) G�kt�rk");
            adListesi1.Add ("M.Nedim Yava�");
            adListesi1.Add ("Sevim Yava�");
            adListesi1.Add ("Sevim Yava�");
            Console.WriteLine ("SortedSet ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adListesi1) {Console.WriteLine (++i + ": " + ad);}

            var adListesi2 = new SortedSet<string>() {"Hatice (Yava�) Ka�ar", "S�heyla (Yava�) �zbay", "Zeliha (Yava�) Candan", "M.Nihat Yava�", "M.Nihat Yava�", "Song�l (Yava�) G�kt�rk",  "M.Nedim Yava�", "Sevim Yava�",  "Sevim Yava�"};
            Console.WriteLine ("\n�lkde�erli SortedSet yegane artan s�ral� ad listesi d�k�mleniyor:"); i=0;
            foreach (var ad in adListesi2) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}