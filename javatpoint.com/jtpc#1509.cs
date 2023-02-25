// jtpc#1509.cs: Koleksiyon soysal aduzaml� s�ral� s�zl�k s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class S�ral�S�zl�k {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� SortedDictionary<TipAnahtar, TipDe�er>, SortedList gibi AnahtarDe�er artan s�ral� �iftlerinden olu�ur. Yegane anahtar� vas�tas�yla kolayca silebilir, ara�t�rabiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var s�ral�AdS�zl��� = new SortedDictionary<string, string>();
            s�ral�AdS�zl���.Add ("K7", "Hatice (Yava�) Ka�ar");
            s�ral�AdS�zl���.Add ("K6", "S�heyla (Yava�) �zbay");
            s�ral�AdS�zl���.Add ("K5", "Zeliha (Yava�) Candan");
            s�ral�AdS�zl���.Add ("K4b", "M.Nihat Yava�");
            s�ral�AdS�zl���.Add ("K4a", "M.Nihat Yava�");
            s�ral�AdS�zl���.Add ("K3", "Song�l (Yava�) G�kt�rk");
            s�ral�AdS�zl���.Add ("K2", "M.Nedim Yava�");
            s�ral�AdS�zl���.Add ("K1b", "Sevim Yava�");
            s�ral�AdS�zl���.Add ("K1a", "Sevim Yava�");
            Console.WriteLine ("Dictionary ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in s�ral�AdS�zl���) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in s�ral�AdS�zl���) {Console.WriteLine (++i + ".nci Karde�: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}