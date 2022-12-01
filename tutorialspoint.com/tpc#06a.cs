// tpc#06a.cs: Veri tipleri arasýnda çevrimler örneði.

using System;
namespace TipÇevrimi {
    class DoubleInt {
        static void Main (string[] args) {
            Console.WriteLine ("Ýçsel çevrimler programýn güvenliði bakýmýndan otomatikmen yapýlýr.\nDýþsal çevrimlerse iþlemci/metod kullanýlarak kullanýcýnýn gerçekleþtirdiði çevrimlerdir.\nÖrnek:\n");
            double d = 5673.74;
            int i;
            i = (int) d;
            Console.Write ("double d deðeri: {0} ve ebatý: {1} byte\nint i deðeri: {2} ve ebatý: {3} byte\n\nTuþ...", d, sizeof (double), i, sizeof (int));
            Console.ReadKey();
        }
    }
}