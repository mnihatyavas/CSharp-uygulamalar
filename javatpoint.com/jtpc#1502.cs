// jtpc#1502.cs: Koleksiyon soysal aduzamlý sýralý liste sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class SýralýListe {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý SortedList<TipAnahtar,TipDeðer>, SortedDictionary<TipAnahtar,TipDeðer> gibi karýþýk girilen anahtar-deðer çiftli elemanlarý yegane TipAnahtar'la artan sýralar; ancak ilki daha az bellek yerken, ikinci sok-sil sonuç taramalarda daha hýzlýdýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adListesi = new SortedList<string, string>();
            adListesi.Add ("K1", "Sevim Yavaþ");
            adListesi.Add ("K7", "Hatice (Yavaþ) Kaçar");
            adListesi.Add ("K6", "Süheyla (Yavaþ) Özbay");
            adListesi.Add ("K5", "Zeliha (Yavaþ) Candan");
            adListesi.Add ("K4", "M.Nihat Yavaþ");
            adListesi.Add ("K3", "Songül (Yavaþ) Göktürk");
            adListesi.Add ("K2", "M.Nedim Yavaþ");
            //adListesi.Add ("K4", "M.Nihat Yavaþ"); //Ayný anahtarlý çoklu kayýt çalýþmazamanlý hata verir
            //adListesi.Add ("K1", "Sevim Yavaþ");
            Console.WriteLine ("SortedList ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adListesi) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in adListesi) {Console.WriteLine (++i + ".nci Kardeþ: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}