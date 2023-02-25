// jtpc#1509.cs: Koleksiyon soysal aduzamlý sýralý sözlük sýnýfý örneði.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class SýralýSözlük {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzamlý SortedDictionary<TipAnahtar, TipDeðer>, SortedList gibi AnahtarDeðer artan sýralý çiftlerinden oluþur. Yegane anahtarý vasýtasýyla kolayca silebilir, araþtýrabiliriz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            var sýralýAdSözlüðü = new SortedDictionary<string, string>();
            sýralýAdSözlüðü.Add ("K7", "Hatice (Yavaþ) Kaçar");
            sýralýAdSözlüðü.Add ("K6", "Süheyla (Yavaþ) Özbay");
            sýralýAdSözlüðü.Add ("K5", "Zeliha (Yavaþ) Candan");
            sýralýAdSözlüðü.Add ("K4b", "M.Nihat Yavaþ");
            sýralýAdSözlüðü.Add ("K4a", "M.Nihat Yavaþ");
            sýralýAdSözlüðü.Add ("K3", "Songül (Yavaþ) Göktürk");
            sýralýAdSözlüðü.Add ("K2", "M.Nedim Yavaþ");
            sýralýAdSözlüðü.Add ("K1b", "Sevim Yavaþ");
            sýralýAdSözlüðü.Add ("K1a", "Sevim Yavaþ");
            Console.WriteLine ("Dictionary ad listesi dökümleniyor:"); int i=0;
            foreach (var ad in sýralýAdSözlüðü) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in sýralýAdSözlüðü) {Console.WriteLine (++i + ".nci Kardeþ: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}