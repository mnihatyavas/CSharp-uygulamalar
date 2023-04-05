// j2sc#0104b.cs: Main metod çeþitlemeleri örneði.

using System;
namespace DilTemelleri {
    class MainMetodu2 {
        public static void Main (string[] argDizi) {
            Console.Write ("Main() metod satýrýnda kullanýlan anahtarkelimeler: public, static, void, int. Ayrýca argümansýz yada argüman algýlamalý olabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");
/*
static void Main() {...}
static int Main() {...}
static void Main (string[] argümanlarDizisi){...}
static int Main (string[] args){...}
public static int Main() {return (0);}
*/
            switch (argDizi.Length) {
                case (0): Console.WriteLine ("Komut satýrýndan argüman girilmemiþ"); break;
                case (1): if (argDizi [0][0] == '-') Console.WriteLine ("Ýlk argüman '-' ile baþlýyor."); break;
                case (2): if (argDizi [1][0] == '-') Console.WriteLine ("Ýkinci argüman '-' ile baþlýyor."); break;
                default: Console.WriteLine ("Komut satýrýndan 2'den fazla argüman girilmiþ"); break;
            }
            int i=0; foreach (string a in argDizi) Console.WriteLine ("{0}.nci argüman = {1}", ++i, a);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}