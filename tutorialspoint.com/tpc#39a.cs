// tpc#39a.cs: Ana sicimin yaratýlmasý ve adlandýrýlmasý örneði.

using System;
using System.Threading;
namespace ÇokluGörevleme {
    class AnaSicim {
        static void Main() {
            Console.Write ("Çoklugörev/sicim CPU/MÝB paylaþýmýyla, bir program içinde ayný anda birden fazla görevin icrasýdýr. Herbir görev thread/ip-sicim olarak adlandýrýlýr. Bir sicimin çeþitli durumlarý: baþlamadý, hazýr, koþturulamaz (uyku, bekleme, blokeli), ölü (sonlandý, kýrýldý). Ýlk çalýþan ana sicim olup, Thread'le yaratýlanlar çocuk sicimler, aktüel sicimi tespitleyen ise CurrentThread özelliðidir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Thread ip1 = Thread.CurrentThread;
            ip1.Name = "AnaSicim";
            Console.WriteLine ("Aküel çalýþan sicim adý: {0}", ip1.Name);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}