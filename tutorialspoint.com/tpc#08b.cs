// tpc#08b.cs: Sabit tanýmlý pi ile dairenin alaný örneði.

using System;
namespace SabilerDuraðanlar {
    class DaireninAlaný {
        static void Main (string[] args) {
            const double pi = 3.14159; // Sabit pi tanýmý
            Console.Write ("Dairenin yarýçapýný girin [12,34] Ent: "); double yçap = Convert.ToDouble (Console.ReadLine());
            double alan = pi * yçap * yçap;
            Console.Write ("Yarýçapý {0} birim olan dairenin alaný {1} birim kare'dir.\nTuþ...", yçap, alan);
            Console.ReadKey();
        }
    }
}