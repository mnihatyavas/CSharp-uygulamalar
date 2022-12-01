// tpc#11a.cs: Döngüler, kontrol ifadeleri ve sonsuz döngü örneði.

using System;
namespace Döngüler {
    class Döngüler {
        static void Main (string[] args) {
            Console.WriteLine ("Döngüler: for, while, do-while, içiçe-döngü");
            Console.WriteLine ("\nDöngü kontrollarý: break (döngüyü kýr, çýk), continue (kalaný atla, döngüye devam)");
            Console.WriteLine ("\nSonsuz döngü, hep true/doðru, döngüye devam þartýný saðlýyorsa sonsuz döngüdür (CTRL-C ile kýrýlabilir==>");
            Console.Write ("\n\nTuþ..."); Console.ReadKey();
            for (;;) {Console.WriteLine ("Hey! Ben takýldým... CTRL-C");}
        }
    }
}