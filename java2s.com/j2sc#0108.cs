// j2sc#0108.cs: Deðiþken tanýmý, ilk ve dinamik deðer atama örneði.

using System;
namespace DilTemelleri {
    class DeðiþkenTanýmý {
        static void Main() {
            Console.Write ("Deðiþken, 'tip deðAd' tanýmlý, deðer atanan bellek konumunun adýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int x;
            int y;
            x = 100;
            Console.WriteLine ("int x = " + x);
            y = x / 2;
            Console.WriteLine ("int y = x / 2 = " + y);

            double a = 12.3, b = 123.4, c = Math.PI, d = Math.E; 
            double hipotenüs = Math.Sqrt ((a * a) + (b * b));
            double çevre = 2 * c * d;
            double alan = c * (d * d);
            Console.WriteLine ("\nKomþu kenarý {0}, karþý kenarý {1} olan diküçgenin hipotenüsü {2:#.#####} birimdir.", b, a, hipotenüs);
            Console.WriteLine ("Yarýçapý {0:#.###} olan dairenin çevresi {1:#.###} birim ve alaný {2:#.###} birim-karedir.", d, çevre, alan);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}