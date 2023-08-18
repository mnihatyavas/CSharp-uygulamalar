// j2sc#0314.cs: �zelle�tirilen & i�lemciyle �iftboyutlu AND'leme �rne�i.

using System;
namespace ��lemciler {
    class �iftBoyut {
        int x, y;
        public �iftBoyut() {x = y = 0;}
        public �iftBoyut (int i, int j) {x = i; y = j;}
        public static bool operator & (�iftBoyut n1, �iftBoyut n2) {
            if( ((n1.x != 0) && (n1.y != 0)) && ((n2.x != 0) && (n2.y != 0) ) ) return true;
            else return false;
        }
        public void g�ster() {Console.WriteLine ("(" + x + ", " + y + ")");}
    }
    class AND_��lemci {
        static void Main() {
            Console.Write ("Normal bool &, &&, |, || i�lemcileri, a��r�y�kleme y�ntemiyle istedi�imizce �zelle�tirebiliriz.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("�zel �ift-boyutlu & i�lemcisi:");
            �iftBoyut a = new �iftBoyut (1951, 2023);
            �iftBoyut b = new �iftBoyut (1881, 1938);
            �iftBoyut c = new �iftBoyut (0, 0);
            �iftBoyut d = new �iftBoyut (1955, 0);
            �iftBoyut e = new �iftBoyut (2023, -68);
            Console.Write ("�iftboyutlu a = "); a.g�ster();
            Console.Write ("�iftboyutlu b = "); b.g�ster();
            Console.Write ("�iftboyutlu c = "); c.g�ster();
            Console.Write ("�iftboyutlu d = "); d.g�ster();
            Console.Write ("�iftboyutlu e = "); e.g�ster();
            if (a & b) Console.WriteLine ("a & b = True: Do�ru."); else Console.WriteLine ("a & b = False: Yanl��.");
            if (a & c) Console.WriteLine ("a & c = True: Do�ru."); else Console.WriteLine ("a & c = False: Yanl��.");
            if (b & d) Console.WriteLine ("b & d = True: Do�ru."); else Console.WriteLine ("b & d = False: Yanl��.");
            if (d & c) Console.WriteLine ("d & c = True: Do�ru."); else Console.WriteLine ("d & c = False: Yanl��.");
            if (e & b) Console.WriteLine ("e & b = True: Do�ru."); else Console.WriteLine ("e & b = False: Yanl��.");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}