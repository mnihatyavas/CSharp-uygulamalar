// jtpc#230106.cs: Statik s�n�f �yelerinin tiplemesiz kullan�m� �rne�i.

using System;
namespace Yeni�zellikler {
    public static class Mat {
        public static double pi = 3.141592653589793d;
        public static double e = 2.718281828459045d;
        public static long k�p (long n) {return n*n*n;}
    }
    class StatikS�n�f {
        static void Main() {
            Console.Write ("Statik s�n�f da normali gibidir, ancak tiplenemez, kurucusuzdur ve sadece statik �yeleri vard�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Pi say�s�n�n duble de�eri = [{0}]", Mat.pi);
            Console.WriteLine ("Exp say�s�n�n duble de�eri = [{0}]", Mat.e);

            long n;
            gir: Console.Write ("\nBir (max.7 haneli) -+tamsay� girin: ");
            try {n = (long)Convert.ToInt64 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            Console.WriteLine ("Girdi�iniz {0} say�s�n�n k�p� = [{1}]", n, Mat.k�p (n));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}