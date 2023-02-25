// jtpc#2206.cs: -+i�lemci ve Equals a��r�y�kleme �rne�i.

using System;
namespace �e�itli {
    class Kompleks1 {
        private int x;
        private int y;
        public Kompleks1(){}
        public Kompleks1 (int i, int j) {x = i; y = j;}
        public void g�sterXY() {Console.WriteLine ("(x, y) = ({0}, {1})", x, y);}
        public static Kompleks1 operator -(Kompleks1 k) {// -Tekli i�lemci
            Kompleks1 arac� = new Kompleks1();
            arac�.x = -k.x;
            arac�.y = -k.y;
            return arac�;
        }
        public static Kompleks1 operator +(Kompleks1 k1, Kompleks1 k2) {// +�kili i�lemci
            var arac� = new Kompleks1();
            arac�.x = k1.x + k2.x;
            arac�.y = k1.y + k2.y;
            return arac�;
        }
    }
    class Kompleks2: Kompleks1 {
        private double x;
        private double y;
        public Kompleks2(){}
        public Kompleks2 (double x, double y) {this.x = x; this.y = y;}
        public new void g�sterXY() {Console.WriteLine ("(x, y) = ({0}, {1})", x, y);}
        public static Kompleks2 operator +(Kompleks2 k1, Kompleks2 k2) {// +�kili i�lemci
            var arac� = new Kompleks2();
            arac�.x = k1.x + k2.x;
            arac�.y = k1.y + k2.y;
            return arac�;
        }
    }
    class Kompleks3: Kompleks1 {// �zel Equals/== i�lemci
        private int x, y;
        public Kompleks3 (int i, int j) {x = i; y = j;}
        public bool Equals (Kompleks3 k) {if (k.x == this.x && k.y == this.y) return true; else return false;}
    }
    class ��lemciA��r�y�kleme {
        static void Main() {
            Console.Write ("A��r�y�kleme yap�labilen i�lemciler: ikili (+, -, *, /, %, &, |, <<, >>), tekli (+, -, !, ~, ++, --, true, false), ba��nt�sal (==, !=, <, >, <=, >=), birle�ik atama (+=, -=, *=, /=, %=); yap�lamayan i�lemciler: &&, ||, [] dizi endeks i�lemci, () tip �evirme i�lemci, =, ., ?:, new, is, as, sizeof\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("-Tekli -(x, y) i�lemci:");
            var k1 = new Kompleks1 (1951, 2023); k1.g�sterXY();
            var k2 = new Kompleks1(); //k2.g�sterXY();
            k2 = -k1; k2.g�sterXY();

            Console.WriteLine ("\n+�kili (x1, y1)+(x2, y2) i�lemci:");
            k1.g�sterXY();
            var k3 = new Kompleks1 (72, -72); k3.g�sterXY();
            var k4 = new Kompleks1(); //k4.g�sterXY();
            k4 = k1 + k3;  k4.g�sterXY();

            Console.WriteLine ("\n+�kili duble t�rev (x1, y1)+(x2, y2) i�lemci:");
            var k5 = new Kompleks2 (Math.PI, Math.E); k5.g�sterXY();
            var k6 = new Kompleks2 (10.5, 5.5); k6.g�sterXY();
            var k7 = new Kompleks2(); //k7.g�sterXY();
            k7 = k5 + k6; k7.g�sterXY();

            Console.WriteLine ("\nAyn� bellek adresini g�rmeyen ve g�ren nesnelerin e�itli�i:");
            k1.g�sterXY();
            var k8 = new Kompleks1 (1951, 2023); k8.g�sterXY();
            var k9 = k1; k9.g�sterXY();
            if (k1.Equals (k8)) Console.WriteLine ("E��T"); else Console.WriteLine ("E��T DE��L");
            if (k1.Equals (k9)) Console.WriteLine ("E��T"); else Console.WriteLine ("E��T DE��L");

            Console.WriteLine ("\nAyn� bellek adresini g�rmeyen �zel 'Equals' nesnelerin e�itli�i:");
            var k10 = new Kompleks3 (1951, 2023); k10.g�sterXY();
            var k11 = new Kompleks3 (1951, 2023); k11.g�sterXY();
            var k12 = k10; k12.g�sterXY();
            if (k10.Equals (k11)) Console.WriteLine ("E��T"); else Console.WriteLine ("E��T DE��L");
            if (k10.Equals (k12)) Console.WriteLine ("E��T"); else Console.WriteLine ("E��T DE��L");

            Console.Write ("\nTu�...");Console.ReadKey();
        }
    }
}