// jtpc#230106.cs: Statik sýnýf üyelerinin tiplemesiz kullanýmý örneði.

using System;
namespace YeniÖzellikler {
    public static class Mat {
        public static double pi = 3.141592653589793d;
        public static double e = 2.718281828459045d;
        public static long küp (long n) {return n*n*n;}
    }
    class StatikSýnýf {
        static void Main() {
            Console.Write ("Statik sýnýf da normali gibidir, ancak tiplenemez, kurucusuzdur ve sadece statik üyeleri vardýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Pi sayýsýnýn duble deðeri = [{0}]", Mat.pi);
            Console.WriteLine ("Exp sayýsýnýn duble deðeri = [{0}]", Mat.e);

            long n;
            gir: Console.Write ("\nBir (max.7 haneli) -+tamsayý girin: ");
            try {n = (long)Convert.ToInt64 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            Console.WriteLine ("Girdiðiniz {0} sayýsýnýn küpü = [{1}]", n, Mat.küp (n));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}