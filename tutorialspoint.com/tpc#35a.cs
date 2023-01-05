// tpc#35a.cs: Koleksiyonlardan List ve SortedList verigiriþ ve döküm örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    class SýralýListe {
        static void Main() {
            Console.Write ("Koleksiyonlar veri depolama ve alma konusunda özelleþen sýnýflardýr. Birkaçý: ArrayList (Dizi gibidir, elemanlara endeks'le eriþilir, elemanlar eklenebilir ve silinebiir), Hashtable (Elemanlara anahtar'la eriþilir), SortedList (Elemanlara hem endeks hem de sýralý anahtarla eriþilir), Stack (Yýðýn'a elemanlar son-giren -push-, ilk-çýkar -pop-), Queue (Kuyruða ilk-giren -engueue-, ilk-çýkar -dequeue-), BitArray (Farklý ebatlý veriler bitvari -01- yazýlýr ve integ-index'le eriþilir), Dictionary (Sözlük), Set (Küme).\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            SortedList<string, string> isimler1 = new SortedList<string, string>();
            isimler1.Add ("Nine","Fatma Yavaþ");
            isimler1.Add ("Dede","Bekir Yavaþ");
            isimler1.Add ("Anne","Haným Yavaþ");
            isimler1.Add ("Baba","Memet Yavaþ");
            isimler1.Add ("Abla-1","Hatice Yavaþ (Kaçar)");
            isimler1.Add ("Abla-2","Süheyla Yavaþ (Özbay)");
            isimler1.Add ("Abla-3","Z.Nihal Yavaþ (Candan)");
            isimler1.Add ("Ben","M.Nihat Yavaþ");
            isimler1.Add ("Kardeþ-1","Songül Yavaþ (Göktürk)");
            isimler1.Add ("Kardeþ-2","M.Nedim Yavaþ");
            isimler1.Add ("Kardeþ-3","Sevim Yavaþ");
            try {isimler1.Add ("Ben","M.Nihat Yavaþ");}catch{} // Ayný anahtarla kaydolmaz

            var isimler2 = new List<string>();
            isimler2.Add ("Fatma Yavaþ");
            isimler2.Add ("Bekir Yavaþ");
            isimler2.Add ("Haným Yavaþ");
            isimler2.Add ("Memet Yavaþ");
            isimler2.Add ("Hatice Yavaþ (Kaçar)");
            isimler2.Add ("Süheyla Yavaþ (Özbay)");
            isimler2.Add ("Z.Nihal Yavaþ (Candan)");
            isimler2.Add ("M.Nihat Yavaþ");
            isimler2.Add ("Songül Yavaþ (Göktürk)");
            isimler2.Add ("M.Nedim Yavaþ");
            isimler2.Add ("Sevim Yavaþ");
            isimler2.Add ("M.Nihat Yavaþ"); // Ayný kayýt kaydolur

            foreach (KeyValuePair<string, string> isim in isimler1) {Console.WriteLine (isim.Key + ": [" + isim.Value + "]");} Console.WriteLine();
            int i=0; foreach (var isim in isimler2) {Console.WriteLine ("{0}: {1}", ++i, isim);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}