// j2sc#0603a.cs: Varsay�l�/tan�ml� parametresiz/parametreli kurucular �rne�i.

using System;
namespace Yap�lar {
    public struct Yap�1 {//Varsay�l� parametresiz kurucu
        public  int i;
        private string s;
        public string S {get {return s;}}
        public void ba�lat() {i = 20230908; s = "Merhaba";}
  
    }
    struct Nokta3D {
        public int x;
        public int y;
        public int z;
        public Nokta3D (int x, int y, int z) {//3 parametreli kurucu
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString() {return (String.Format ("Nokta3D = ({0}, {1}, {2})", x, y, z));}
    }
    public struct Aritmetik��lem {
        private double i�lemci1;
        private double i�lemci2;
        public Aritmetik��lem (double _i�lemci1, double _i�lemci2) {i�lemci1 = _i�lemci1; i�lemci2 = _i�lemci2;}
        public double topla {get {return i�lemci1 + i�lemci2;}}
        public double ��kar {get {return i�lemci1 - i�lemci2;}}
        public double �arp {get {return i�lemci1 * i�lemci2;}}
        public double b�l {get {return i�lemci1 / i�lemci2;}}
        public double kalan {get {return i�lemci1 % i�lemci2;}}
    }
    class Kurucu1 {
        static void Main() {
            Console.Write ("Private yap� alanlar� get/set ile koyulup/al�nabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Varsay�l� yap� kurucusu parametresizdir:");
            Yap�1 y1 = new Yap�1(); //Varsay�l� kuruculu
            y1.ba�lat( );
            Console.WriteLine ("y1.i = {0}\ty1.s = {1}", y1.i, y1.S);

            Console.WriteLine ("\n3D yap� verilerinin, �zel 'public override string ToString()'le ne�ri:");
            var r=new Random();
            Nokta3D n3D1 = new Nokta3D(); Console.WriteLine ("Nokta3D1 = {0}", n3D1);
            n3D1 = new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)); Console.WriteLine ("Nokta3D1 = {0}", n3D1);
            Nokta3D[] n3D2 = new Nokta3D [3] {new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50))};
            Console.WriteLine ("{0}\t{1}\t{2}", n3D2 [0], n3D2 [1], n3D2 [2]);
            n3D2 = new Nokta3D [3] {new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50))};
            Console.WriteLine ("{0}\t{1}\t{2}", n3D2 [0], n3D2 [1], n3D2 [2]);

            double a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D, b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\nRasgele (double) de�erli yap�sal 5 i�lem (+-*/%) sonu�lar�.");
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            Aritmetik��lem i�lem1 = new Aritmetik��lem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", i�lem1.topla, i�lem1.��kar, i�lem1.�arp, i�lem1.b�l, i�lem1.kalan);
            a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D; b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            i�lem1 = new Aritmetik��lem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", i�lem1.topla, i�lem1.��kar, i�lem1.�arp, i�lem1.b�l, i�lem1.kalan);
            a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D; b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            i�lem1 = new Aritmetik��lem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", i�lem1.topla, i�lem1.��kar, i�lem1.�arp, i�lem1.b�l, i�lem1.kalan);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}