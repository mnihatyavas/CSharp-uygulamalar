// jtpc#1504.cs: Koleksiyon soysal aduzaml� k�yma-k�me s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class K�ymaK�me {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� HashSet<T> yegane anahtarl� oldu�undan ilkinden sonraki benzer �oklu elemanlar� i�ermezler.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new HashSet<string>();
            adListesi.Add ("Hatice (Yava�) Ka�ar");
            adListesi.Add ("S�heyla (Yava�) �zbay");
            adListesi.Add ("Zeliha (Yava�) Candan");
            adListesi.Add ("M.Nihat Yava�");
            adListesi.Add ("M.Nihat Yava�");
            adListesi.Add ("Song�l (Yava�) G�kt�rk");
            adListesi.Add ("M.Nedim Yava�");
            adListesi.Add ("Sevim Yava�");
            adListesi.Add ("Sevim Yava�");
            Console.WriteLine ("HashSet ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}