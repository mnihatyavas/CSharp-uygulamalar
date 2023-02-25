// jtpc#1508.cs: Koleksiyon soysal aduzamlý sözlük sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class Sözlük {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý Dictionary<TipAnahtar, TipDeðer>, HashSet gibi yegane anahtarlý (çoklu deðerli olabilir) fakat SortedList gibi AnahtarDeðer sýrasýz çiftlerinden oluþur. Anahtarý vasýtasýyla kolayca silebilir, araþtýrabiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adSözlüðü = new Dictionary<string, string>();
            adSözlüðü.Add ("K7", "Hatice (Yavaþ) Kaçar");
            adSözlüðü.Add ("K6", "Süheyla (Yavaþ) Özbay");
            adSözlüðü.Add ("K5", "Zeliha (Yavaþ) Candan");
            adSözlüðü.Add ("K4b", "M.Nihat Yavaþ");
            adSözlüðü.Add ("K4a", "M.Nihat Yavaþ");
            adSözlüðü.Add ("K3", "Songül (Yavaþ) Göktürk");
            adSözlüðü.Add ("K2", "M.Nedim Yavaþ");
            adSözlüðü.Add ("K1b", "Sevim Yavaþ");
            adSözlüðü.Add ("K1a", "Sevim Yavaþ");
            Console.WriteLine ("Dictionary ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in adSözlüðü) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in adSözlüðü) {Console.WriteLine (++i + ".nci Kardeþ: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}