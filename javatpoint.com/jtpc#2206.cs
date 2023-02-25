// jtpc#2206.cs: -+iþlemci ve Equals aþýrýyükleme örneði.

using System;
namespace Çeþitli {
    class Kompleks1 {
        private int x;
        private int y;
        public Kompleks1(){}
        public Kompleks1 (int i, int j) {x = i; y = j;}
        public void gösterXY() {Console.WriteLine ("(x, y) = ({0}, {1})", x, y);}
        public static Kompleks1 operator -(Kompleks1 k) {// -Tekli iþlemci
            Kompleks1 aracý = new Kompleks1();
            aracý.x = -k.x;
            aracý.y = -k.y;
            return aracý;
        }
        public static Kompleks1 operator +(Kompleks1 k1, Kompleks1 k2) {// +Ýkili iþlemci
            var aracý = new Kompleks1();
            aracý.x = k1.x + k2.x;
            aracý.y = k1.y + k2.y;
            return aracý;
        }
    }
    class Kompleks2: Kompleks1 {
        private double x;
        private double y;
        public Kompleks2(){}
        public Kompleks2 (double x, double y) {this.x = x; this.y = y;}
        public new void gösterXY() {Console.WriteLine ("(x, y) = ({0}, {1})", x, y);}
        public static Kompleks2 operator +(Kompleks2 k1, Kompleks2 k2) {// +Ýkili iþlemci
            var aracý = new Kompleks2();
            aracý.x = k1.x + k2.x;
            aracý.y = k1.y + k2.y;
            return aracý;
        }
    }
    class Kompleks3: Kompleks1 {// Özel Equals/== iþlemci
        private int x, y;
        public Kompleks3 (int i, int j) {x = i; y = j;}
        public bool Equals (Kompleks3 k) {if (k.x == this.x && k.y == this.y) return true; else return false;}
    }
    class ÝþlemciAþýrýyükleme {
        static void Main() {
            Console.Write ("Aþýrýyükleme yapýlabilen iþlemciler: ikili (+, -, *, /, %, &, |, <<, >>), tekli (+, -, !, ~, ++, --, true, false), baðýntýsal (==, !=, <, >, <=, >=), birleþik atama (+=, -=, *=, /=, %=); yapýlamayan iþlemciler: &&, ||, [] dizi endeks iþlemci, () tip çevirme iþlemci, =, ., ?:, new, is, as, sizeof\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("-Tekli -(x, y) iþlemci:");
            var k1 = new Kompleks1 (1951, 2023); k1.gösterXY();
            var k2 = new Kompleks1(); //k2.gösterXY();
            k2 = -k1; k2.gösterXY();

            Console.WriteLine ("\n+Ýkili (x1, y1)+(x2, y2) iþlemci:");
            k1.gösterXY();
            var k3 = new Kompleks1 (72, -72); k3.gösterXY();
            var k4 = new Kompleks1(); //k4.gösterXY();
            k4 = k1 + k3;  k4.gösterXY();

            Console.WriteLine ("\n+Ýkili duble türev (x1, y1)+(x2, y2) iþlemci:");
            var k5 = new Kompleks2 (Math.PI, Math.E); k5.gösterXY();
            var k6 = new Kompleks2 (10.5, 5.5); k6.gösterXY();
            var k7 = new Kompleks2(); //k7.gösterXY();
            k7 = k5 + k6; k7.gösterXY();

            Console.WriteLine ("\nAyný bellek adresini görmeyen ve gören nesnelerin eþitliði:");
            k1.gösterXY();
            var k8 = new Kompleks1 (1951, 2023); k8.gösterXY();
            var k9 = k1; k9.gösterXY();
            if (k1.Equals (k8)) Console.WriteLine ("EÞÝT"); else Console.WriteLine ("EÞÝT DEÐÝL");
            if (k1.Equals (k9)) Console.WriteLine ("EÞÝT"); else Console.WriteLine ("EÞÝT DEÐÝL");

            Console.WriteLine ("\nAyný bellek adresini görmeyen özel 'Equals' nesnelerin eþitliði:");
            var k10 = new Kompleks3 (1951, 2023); k10.gösterXY();
            var k11 = new Kompleks3 (1951, 2023); k11.gösterXY();
            var k12 = k10; k12.gösterXY();
            if (k10.Equals (k11)) Console.WriteLine ("EÞÝT"); else Console.WriteLine ("EÞÝT DEÐÝL");
            if (k10.Equals (k12)) Console.WriteLine ("EÞÝT"); else Console.WriteLine ("EÞÝT DEÐÝL");

            Console.Write ("\nTuþ...");Console.ReadKey();
        }
    }
}