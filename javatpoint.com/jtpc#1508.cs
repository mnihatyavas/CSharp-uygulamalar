// jtpc#1508.cs: Koleksiyon soysal aduzaml� s�zl�k s�n�f� �rne�i.

using System;
using System.Collections.Generic;
namespace Koleksiyonlar {
    public class S�zl�k {
        static void Main() {
            Console.Write ("System.Collections.Generic aduzaml� Dictionary<TipAnahtar, TipDe�er>, HashSet gibi yegane anahtarl� (�oklu de�erli olabilir) fakat SortedList gibi AnahtarDe�er s�ras�z �iftlerinden olu�ur. Anahtar� vas�tas�yla kolayca silebilir, ara�t�rabiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            var adS�zl��� = new Dictionary<string, string>();
            adS�zl���.Add ("K7", "Hatice (Yava�) Ka�ar");
            adS�zl���.Add ("K6", "S�heyla (Yava�) �zbay");
            adS�zl���.Add ("K5", "Zeliha (Yava�) Candan");
            adS�zl���.Add ("K4b", "M.Nihat Yava�");
            adS�zl���.Add ("K4a", "M.Nihat Yava�");
            adS�zl���.Add ("K3", "Song�l (Yava�) G�kt�rk");
            adS�zl���.Add ("K2", "M.Nedim Yava�");
            adS�zl���.Add ("K1b", "Sevim Yava�");
            adS�zl���.Add ("K1a", "Sevim Yava�");
            Console.WriteLine ("Dictionary ad listesi d�k�mleniyor:"); int i=0;
            foreach (var ad in adS�zl���) {Console.WriteLine (++i + ": " + ad);}
            Console.WriteLine(); i=0;
            foreach (KeyValuePair<string, string> ad in adS�zl���) {Console.WriteLine (++i + ".nci Karde�: " + ad.Key + "=" + ad.Value);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}