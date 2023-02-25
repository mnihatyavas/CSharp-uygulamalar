// jtpc#1502.cs: Koleksiyon soysal aduzaml� s�ral� liste s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class S�ral�Liste {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� SortedList<TipAnahtar,TipDe�er>, SortedDictionary<TipAnahtar,TipDe�er> gibi kar���k girilen anahtar-de�er �iftli elemanlar� yegane TipAnahtar'la artan s�ralar; ancak ilki daha az bellek yerken, ikinci sok-sil sonu� taramalarda daha h�zl�d�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new SortedList<string, string>();
            adListesi.Add ("K1", "Sevim Yava�");
            adListesi.Add ("K7", "Hatice (Yava�) Ka�ar");
            adListesi.Add ("K6", "S�heyla (Yava�) �zbay");
            adListesi.Add ("K5", "Zeliha (Yava�) Candan");
            adListesi.Add ("K4", "M.Nihat Yava�");
            adListesi.Add ("K3", "Song�l (Yava�) G�kt�rk");
            adListesi.Add ("K2", "M.Nedim Yava�");
            //adListesi.Add ("K4", "M.Nihat Yava�"); //Ayn� anahtarl� �oklu kay�t �al��mazamanl� hata verir
            //adListesi.Add ("K1", "Sevim Yava�");
            Console.WriteLine ("SortedList ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in adListesi) {Console.WriteLine (++i + ".nci Karde�: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}