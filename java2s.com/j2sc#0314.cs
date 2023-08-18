// j2sc#0314.cs: Özelleþtirilen & iþlemciyle çiftboyutlu AND'leme örneði.

using System;
namespace Ýþlemciler {
    class ÇiftBoyut {
        int x, y;
        public ÇiftBoyut() {x = y = 0;}
        public ÇiftBoyut (int i, int j) {x = i; y = j;}
        public static bool operator & (ÇiftBoyut n1, ÇiftBoyut n2) {
            if( ((n1.x != 0) && (n1.y != 0)) && ((n2.x != 0) && (n2.y != 0) ) ) return true;
            else return false;
        }
        public void göster() {Console.WriteLine ("(" + x + ", " + y + ")");}
    }
    class AND_Ýþlemci {
        static void Main() {
            Console.Write ("Normal bool &, &&, |, || iþlemcileri, aþýrýyükleme yöntemiyle istediðimizce özelleþtirebiliriz.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Özel çift-boyutlu & iþlemcisi:");
            ÇiftBoyut a = new ÇiftBoyut (1951, 2023);
            ÇiftBoyut b = new ÇiftBoyut (1881, 1938);
            ÇiftBoyut c = new ÇiftBoyut (0, 0);
            ÇiftBoyut d = new ÇiftBoyut (1955, 0);
            ÇiftBoyut e = new ÇiftBoyut (2023, -68);
            Console.Write ("Çiftboyutlu a = "); a.göster();
            Console.Write ("Çiftboyutlu b = "); b.göster();
            Console.Write ("Çiftboyutlu c = "); c.göster();
            Console.Write ("Çiftboyutlu d = "); d.göster();
            Console.Write ("Çiftboyutlu e = "); e.göster();
            if (a & b) Console.WriteLine ("a & b = True: Doðru."); else Console.WriteLine ("a & b = False: Yanlýþ.");
            if (a & c) Console.WriteLine ("a & c = True: Doðru."); else Console.WriteLine ("a & c = False: Yanlýþ.");
            if (b & d) Console.WriteLine ("b & d = True: Doðru."); else Console.WriteLine ("b & d = False: Yanlýþ.");
            if (d & c) Console.WriteLine ("d & c = True: Doðru."); else Console.WriteLine ("d & c = False: Yanlýþ.");
            if (e & b) Console.WriteLine ("e & b = True: Doðru."); else Console.WriteLine ("e & b = False: Yanlýþ.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}