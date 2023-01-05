// tpc#36c.cs: Soysal delegeli tiplemeyle tamsay� ve ondal�k hesaplamalar �rne�i.

using System;
using System.Collections.Generic;
delegate Tip Hesaplay�c�<Tip>(Tip n);
namespace Soysallar {
    class SoysalDelege {
        static int say�1 = 10;
        static double say�2 = 10.0;

        public static int Topla (int n) {say�1 += n; return say�1;}
        public static int �arp (int n) {say�1 *= n; return say�1;}
        public static int B�l (int n) {say�1 /= n; return say�1;}
        public static int say�Al1() {return say�1;}

        public static double Topla (double n) {say�2 += n; return say�2;}
        public static double �arp (double n) {say�2 *= n; return say�2;}
        public static double B�l (double n) {say�2 /= (n-1); return say�2;}
        public static double say�Al2() {return say�2;}

        static void Main() {
            Console.Write ("Bir soysal delege tip parametreli tan�mlan�p, farkl� tipli (tamsay� ve ondal�k) i�lemler yapabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplay�c�<int> h1 = new Hesaplay�c�<int> (Topla);
            Hesaplay�c�<int> h2 = new Hesaplay�c�<int> (�arp);
            Hesaplay�c�<int> h3 = new Hesaplay�c�<int> (B�l);
            h1 (25); Console.WriteLine ("Tamsay� toplama: {0}", say�Al1());
            h2 (5); Console.WriteLine ("Tamsay� �arpma: {0}", say�Al1());
            h3 (25); Console.WriteLine ("Tamsay� b�lme: {0}", say�Al1());

            Hesaplay�c�<double> h4 = new Hesaplay�c�<double> (Topla);
            Hesaplay�c�<double> h5 = new Hesaplay�c�<double> (�arp);
            Hesaplay�c�<double> h6 = new Hesaplay�c�<double> (B�l);
            h4 (25.5); Console.WriteLine ("\nOndal�k toplama: {0}", say�Al2());
            h5 (5.4); Console.WriteLine ("Ondal�k �arpma: {0}", say�Al2());
            h6 (3.14); Console.WriteLine ("Ondal�k b�lme: {0}", say�Al2());

            Hesaplay�c�<double> �oklu;
            �oklu = h4+h5+h6;
            �oklu (2.718); Console.WriteLine ("\n�oklu topla+�arp+b�l: {0}", say�Al2());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}