// j2sc#0303.cs: Birartýr ve bireksilt iþlemcilerin önekli ve sonekli örneði.

using System;
namespace Ýþlemciler {
   public class Arabam {
        private static int hýz = 0;
        private const int azamiHýz = 200;
        public bool HýzýDeðiþtir (int yeniHýz) {
            if (yeniHýz > azamiHýz) hýz = azamiHýz;
            else hýz = yeniHýz;
            return true;
        }
        public static Arabam operator ++(Arabam araba) {
            araba.HýzýDeðiþtir (++hýz);
            return araba;
        }
        public static implicit operator Arabam (int ilkHýz) {
            Arabam araba = new Arabam();
            araba.HýzýDeðiþtir (ilkHýz);
            return araba;
        }
        public int HýzýAl() {return hýz;}
    }
    class ÖnekSonekÝþlemci {
        static void Main() {
            Console.Write ("Birartýr ++ ve bireksilt -- iþlemcileri deðiþken önündeyse iþlem bitiþ öncesi sonuç yansýr, arkasýndaysa iþlemden sonra.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("x++, ++x, x-- ve --x etkileri:");
            int x, y, i;
            Console.WriteLine ("x: {0}, x++: {1}, x: {2}", (x=2023), (x++), x);
            Console.WriteLine ("x: {0}, ++x: {1}, x: {2}", (x=2023), (++x), x);
            Console.WriteLine ("x: {0}, x--: {1}, x: {2}", (x=2023), (x--), x);
            Console.WriteLine ("x: {0}, --x: {1}, x: {2}", (x=2023), (--x), x);

            Console.WriteLine ("\nx++ ve ++x ile yaratýlan seriler:"); 
            x = 1; for (i = 0; i < 10; i++) {y = x + x++; Console.Write (y + " ");} Console.WriteLine();
            x = 1; for (i = 0; i < 10; i++) {y = x + ++x; Console.Write (y + " ");} Console.WriteLine();

            Console.WriteLine ("\nSon ve önceki x++, ++x, x-- ve --x deðerleri:");
            Console.WriteLine ("x={0}, y=x++, y={1}", (x=2023), (y=x++));
            Console.WriteLine ("x={0}, y=++x, y={1}", (x=2023), (y=++x));
            Console.WriteLine ("x={0}, y=x--, y={1}", (x=2023), (y=x--));
            Console.WriteLine ("x={0}, y=--x, y={1}", (x=2023), (y=--x));

            Console.WriteLine ("\nÝþlemlerin bitiþi sonrasýndaki ayný x++, ++x, x-- ve --x deðerleri:");
            x=2023; y=x++; Console.WriteLine ("(x=2023): {0}, y=x++, y={1}", x, y);
            x=2023; y=++x; Console.WriteLine ("(x=2023): {0}, y=++x, y={1}", x, y);
            x=2023; y=x--; Console.WriteLine ("(x=2023): {0}, y=x--, y={1}", x, y);
            x=2023; y=--x; Console.WriteLine ("(x=2023): {0}, y=--x, y={1}", x, y);

            Console.WriteLine ("\nArabanýn ilk hýzdan azami 200 km/s hýza 20 kademeli artýþý:");
            Arabam araba = 5; Console.Write ("Arabanýn hýzlanmasý: ");
            for(i = 0; i < 20; i++ ) {araba++; Console.Write ("{0} ", araba.HýzýAl());} Console.WriteLine();
            araba = 185; Console.Write ("Arabanýn hýzlanmasý: ");
            for(i = 0; i < 20; i++ ) {araba++; Console.Write ("{0} ", araba.HýzýAl());} Console.WriteLine();
            araba = 163; Console.Write ("Arabanýn hýzlanmasý: ");
            for(i = 0; i < 20; i++ ) {araba++; ++araba; Console.Write ("{0} ", araba.HýzýAl());} Console.WriteLine();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}