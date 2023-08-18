// j2sc#0603a.cs: Varsayýlý/tanýmlý parametresiz/parametreli kurucular örneði.

using System;
namespace Yapýlar {
    public struct Yapý1 {//Varsayýlý parametresiz kurucu
        public  int i;
        private string s;
        public string S {get {return s;}}
        public void baþlat() {i = 20230908; s = "Merhaba";}
  
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
    public struct AritmetikÝþlem {
        private double iþlemci1;
        private double iþlemci2;
        public AritmetikÝþlem (double _iþlemci1, double _iþlemci2) {iþlemci1 = _iþlemci1; iþlemci2 = _iþlemci2;}
        public double topla {get {return iþlemci1 + iþlemci2;}}
        public double çýkar {get {return iþlemci1 - iþlemci2;}}
        public double çarp {get {return iþlemci1 * iþlemci2;}}
        public double böl {get {return iþlemci1 / iþlemci2;}}
        public double kalan {get {return iþlemci1 % iþlemci2;}}
    }
    class Kurucu1 {
        static void Main() {
            Console.Write ("Private yapý alanlarý get/set ile koyulup/alýnabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Varsayýlý yapý kurucusu parametresizdir:");
            Yapý1 y1 = new Yapý1(); //Varsayýlý kuruculu
            y1.baþlat( );
            Console.WriteLine ("y1.i = {0}\ty1.s = {1}", y1.i, y1.S);

            Console.WriteLine ("\n3D yapý verilerinin, özel 'public override string ToString()'le neþri:");
            var r=new Random();
            Nokta3D n3D1 = new Nokta3D(); Console.WriteLine ("Nokta3D1 = {0}", n3D1);
            n3D1 = new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)); Console.WriteLine ("Nokta3D1 = {0}", n3D1);
            Nokta3D[] n3D2 = new Nokta3D [3] {new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50))};
            Console.WriteLine ("{0}\t{1}\t{2}", n3D2 [0], n3D2 [1], n3D2 [2]);
            n3D2 = new Nokta3D [3] {new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50)), new Nokta3D (r.Next (-10, 50), r.Next (-10, 50), r.Next (-10, 50))};
            Console.WriteLine ("{0}\t{1}\t{2}", n3D2 [0], n3D2 [1], n3D2 [2]);

            double a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D, b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\nRasgele (double) deðerli yapýsal 5 iþlem (+-*/%) sonuçlarý.");
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            AritmetikÝþlem iþlem1 = new AritmetikÝþlem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", iþlem1.topla, iþlem1.çýkar, iþlem1.çarp, iþlem1.böl, iþlem1.kalan);
            a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D; b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            iþlem1 = new AritmetikÝþlem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", iþlem1.topla, iþlem1.çýkar, iþlem1.çarp, iþlem1.böl, iþlem1.kalan);
            a=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D; b=r.Next (-1000, 1000) + r.Next (0, 10000)/10000D;
            Console.WriteLine ("\t==> a = {0} ve\tb = {1} ise:", a, b);
            iþlem1 = new AritmetikÝþlem (a, b);
            Console.WriteLine ("s+b={0:F2}\ta-b={1:F2}\ta*b={2:F2}\ta/b={3:F2}\ta%b={4:F2}", iþlem1.topla, iþlem1.çýkar, iþlem1.çarp, iþlem1.böl, iþlem1.kalan);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}