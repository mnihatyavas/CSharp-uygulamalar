// tpc#18a.cs: Sayýsallanan haftanýn günadý sabitleri örneði.

using System;
namespace Sayýsallananlar {
    class HaftanýnGünleri {
        enum Günler {Paz=1, Pzt, Sal, Çar, Per, Cum, Cmt}; // "Günler" tipli günadý sabitleri
        static void Main (string[] args) {
            Console.Write ("Genel tanýmý: enum <sayýsal-ad> {sayasallanan liste};\nSayýsallanan ad listesinin ilki varsayýlý o'da itibaren endekslenir.\nTuþ..."); Console.ReadKey();

            int[] haftaGünSýralamasý = new int [7] {(int)Günler.Paz, (int)Günler.Pzt, (int)Günler.Sal, (int)Günler.Çar, (int)Günler.Per, (int)Günler.Cum, (int)Günler.Cmt};
            Console.WriteLine ("\n\nHaftanýn günadlarý ve numaralarý:");
            byte i = 0;
            foreach (string gün in Enum.GetNames (typeof (Günler))) {Console.WriteLine ("Gün adý: [{0}], Gün no: [{1}]", gün, haftaGünSýralamasý [i++]);}
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}