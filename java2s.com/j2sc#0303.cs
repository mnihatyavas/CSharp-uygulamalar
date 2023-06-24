// j2sc#0303.cs: Birart�r ve bireksilt i�lemcilerin �nekli ve sonekli �rne�i.

using System;
namespace ��lemciler {
   public class Arabam {
        private static int h�z = 0;
        private const int azamiH�z = 200;
        public bool H�z�De�i�tir (int yeniH�z) {
            if (yeniH�z > azamiH�z) h�z = azamiH�z;
            else h�z = yeniH�z;
            return true;
        }
        public static Arabam operator ++(Arabam araba) {
            araba.H�z�De�i�tir (++h�z);
            return araba;
        }
        public static implicit operator Arabam (int ilkH�z) {
            Arabam araba = new Arabam();
            araba.H�z�De�i�tir (ilkH�z);
            return araba;
        }
        public int H�z�Al() {return h�z;}
    }
    class �nekSonek��lemci {
        static void Main() {
            Console.Write ("Birart�r ++ ve bireksilt -- i�lemcileri de�i�ken �n�ndeyse i�lem biti� �ncesi sonu� yans�r, arkas�ndaysa i�lemden sonra.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("x++, ++x, x-- ve --x etkileri:");
            int x, y, i;
            Console.WriteLine ("x: {0}, x++: {1}, x: {2}", (x=2023), (x++), x);
            Console.WriteLine ("x: {0}, ++x: {1}, x: {2}", (x=2023), (++x), x);
            Console.WriteLine ("x: {0}, x--: {1}, x: {2}", (x=2023), (x--), x);
            Console.WriteLine ("x: {0}, --x: {1}, x: {2}", (x=2023), (--x), x);

            Console.WriteLine ("\nx++ ve ++x ile yarat�lan seriler:"); 
            x = 1; for (i = 0; i < 10; i++) {y = x + x++; Console.Write (y + " ");} Console.WriteLine();
            x = 1; for (i = 0; i < 10; i++) {y = x + ++x; Console.Write (y + " ");} Console.WriteLine();

            Console.WriteLine ("\nSon ve �nceki x++, ++x, x-- ve --x de�erleri:");
            Console.WriteLine ("x={0}, y=x++, y={1}", (x=2023), (y=x++));
            Console.WriteLine ("x={0}, y=++x, y={1}", (x=2023), (y=++x));
            Console.WriteLine ("x={0}, y=x--, y={1}", (x=2023), (y=x--));
            Console.WriteLine ("x={0}, y=--x, y={1}", (x=2023), (y=--x));

            Console.WriteLine ("\n��lemlerin biti�i sonras�ndaki ayn� x++, ++x, x-- ve --x de�erleri:");
            x=2023; y=x++; Console.WriteLine ("(x=2023): {0}, y=x++, y={1}", x, y);
            x=2023; y=++x; Console.WriteLine ("(x=2023): {0}, y=++x, y={1}", x, y);
            x=2023; y=x--; Console.WriteLine ("(x=2023): {0}, y=x--, y={1}", x, y);
            x=2023; y=--x; Console.WriteLine ("(x=2023): {0}, y=--x, y={1}", x, y);

            Console.WriteLine ("\nAraban�n ilk h�zdan azami 200 km/s h�za 20 kademeli art���:");
            Arabam araba = 5; Console.Write ("Araban�n h�zlanmas�: ");
            for(i = 0; i < 20; i++ ) {araba++; Console.Write ("{0} ", araba.H�z�Al());} Console.WriteLine();
            araba = 185; Console.Write ("Araban�n h�zlanmas�: ");
            for(i = 0; i < 20; i++ ) {araba++; Console.Write ("{0} ", araba.H�z�Al());} Console.WriteLine();
            araba = 163; Console.Write ("Araban�n h�zlanmas�: ");
            for(i = 0; i < 20; i++ ) {araba++; ++araba; Console.Write ("{0} ", araba.H�z�Al());} Console.WriteLine();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}