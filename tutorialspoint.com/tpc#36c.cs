// tpc#36c.cs: Soysal delegeli tiplemeyle tamsayý ve ondalýk hesaplamalar örneði.

using System;
using System.Collections.Generic;
delegate Tip Hesaplayýcý<Tip>(Tip n);
namespace Soysallar {
    class SoysalDelege {
        static int sayý1 = 10;
        static double sayý2 = 10.0;

        public static int Topla (int n) {sayý1 += n; return sayý1;}
        public static int Çarp (int n) {sayý1 *= n; return sayý1;}
        public static int Böl (int n) {sayý1 /= n; return sayý1;}
        public static int sayýAl1() {return sayý1;}

        public static double Topla (double n) {sayý2 += n; return sayý2;}
        public static double Çarp (double n) {sayý2 *= n; return sayý2;}
        public static double Böl (double n) {sayý2 /= (n-1); return sayý2;}
        public static double sayýAl2() {return sayý2;}

        static void Main() {
            Console.Write ("Bir soysal delege tip parametreli tanýmlanýp, farklý tipli (tamsayý ve ondalýk) iþlemler yapabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplayýcý<int> h1 = new Hesaplayýcý<int> (Topla);
            Hesaplayýcý<int> h2 = new Hesaplayýcý<int> (Çarp);
            Hesaplayýcý<int> h3 = new Hesaplayýcý<int> (Böl);
            h1 (25); Console.WriteLine ("Tamsayý toplama: {0}", sayýAl1());
            h2 (5); Console.WriteLine ("Tamsayý çarpma: {0}", sayýAl1());
            h3 (25); Console.WriteLine ("Tamsayý bölme: {0}", sayýAl1());

            Hesaplayýcý<double> h4 = new Hesaplayýcý<double> (Topla);
            Hesaplayýcý<double> h5 = new Hesaplayýcý<double> (Çarp);
            Hesaplayýcý<double> h6 = new Hesaplayýcý<double> (Böl);
            h4 (25.5); Console.WriteLine ("\nOndalýk toplama: {0}", sayýAl2());
            h5 (5.4); Console.WriteLine ("Ondalýk çarpma: {0}", sayýAl2());
            h6 (3.14); Console.WriteLine ("Ondalýk bölme: {0}", sayýAl2());

            Hesaplayýcý<double> çoklu;
            çoklu = h4+h5+h6;
            çoklu (2.718); Console.WriteLine ("\nÇoklu topla+çarp+böl: {0}", sayýAl2());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}