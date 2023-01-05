// tpc#35a.cs: Koleksiyonlardan List ve SortedList verigiri� ve d�k�m �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    class S�ral�Liste {
        static void Main() {
            Console.Write ("Koleksiyonlar veri depolama ve alma konusunda �zelle�en s�n�flard�r. Birka��: ArrayList (Dizi gibidir, elemanlara endeks'le eri�ilir, elemanlar eklenebilir ve silinebiir), Hashtable (Elemanlara anahtar'la eri�ilir), SortedList (Elemanlara hem endeks hem de s�ral� anahtarla eri�ilir), Stack (Y���n'a elemanlar son-giren -push-, ilk-��kar -pop-), Queue (Kuyru�a ilk-giren -engueue-, ilk-��kar -dequeue-), BitArray (Farkl� ebatl� veriler bitvari -01- yaz�l�r ve integ-index'le eri�ilir), Dictionary (S�zl�k), Set (K�me).\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            SortedList<string, string> isimler1 = new SortedList<string, string>();
            isimler1.Add ("Nine","Fatma Yava�");
            isimler1.Add ("Dede","Bekir Yava�");
            isimler1.Add ("Anne","Han�m Yava�");
            isimler1.Add ("Baba","Memet Yava�");
            isimler1.Add ("Abla-1","Hatice Yava� (Ka�ar)");
            isimler1.Add ("Abla-2","S�heyla Yava� (�zbay)");
            isimler1.Add ("Abla-3","Z.Nihal Yava� (Candan)");
            isimler1.Add ("Ben","M.Nihat Yava�");
            isimler1.Add ("Karde�-1","Song�l Yava� (G�kt�rk)");
            isimler1.Add ("Karde�-2","M.Nedim Yava�");
            isimler1.Add ("Karde�-3","Sevim Yava�");
            try {isimler1.Add ("Ben","M.Nihat Yava�");}catch{} // Ayn� anahtarla kaydolmaz

            var isimler2 = new List<string>();
            isimler2.Add ("Fatma Yava�");
            isimler2.Add ("Bekir Yava�");
            isimler2.Add ("Han�m Yava�");
            isimler2.Add ("Memet Yava�");
            isimler2.Add ("Hatice Yava� (Ka�ar)");
            isimler2.Add ("S�heyla Yava� (�zbay)");
            isimler2.Add ("Z.Nihal Yava� (Candan)");
            isimler2.Add ("M.Nihat Yava�");
            isimler2.Add ("Song�l Yava� (G�kt�rk)");
            isimler2.Add ("M.Nedim Yava�");
            isimler2.Add ("Sevim Yava�");
            isimler2.Add ("M.Nihat Yava�"); // Ayn� kay�t kaydolur

            foreach (KeyValuePair<string, string> isim in isimler1) {Console.WriteLine (isim.Key + ": [" + isim.Value + "]");} Console.WriteLine();
            int i=0; foreach (var isim in isimler2) {Console.WriteLine ("{0}: {1}", ++i, isim);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}