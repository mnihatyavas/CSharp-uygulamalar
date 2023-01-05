// tpc#33a.cs: Toplama ve çarpma fonksiyonlarýný delegeli çaðýrma örneði.

using System;
delegate int Hesaplatýcý (int tamsayý);
namespace Delegeler {
    class ToplamaÇarpma {
        static int sayý = 10;
        public static int Toplama (int n) {sayý += n; return sayý;}
        public static int Çarpma (int n) {sayý *= n; return sayý;}
        public static int sayýAl() {return sayý;}
        static void Main() {
            Console.Write ("Delege, fonksiyonlara iþaretçi gibi metod referansýný tutar ve referanslar çalýþma zamanlý deðiþebilir. Bilhassa olaylar ve geri-çaðýran fonksiyonlarda kullanýlýr. Delege argümaný yerine yalýn metod adý kullanýlýp, tiplenen delege deðeriyle fonksiyona iþlem yaptýrýp geri dönüþü yansýtýlacak.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplatýcý h1 = new Hesaplatýcý (Toplama); // Delege tiplemeleri
            Hesaplatýcý h2 = new Hesaplatýcý (Çarpma);
            h1 (25); Console.WriteLine ("Ýlk toplama sonucu: {0}", sayýAl()); // 10+25=35
            h1 (15); Console.WriteLine ("Ýkinci toplama sonucu: {0}", sayýAl()); // 35+15=50
            h2 (5); Console.WriteLine ("Ýlk çarpma sonucu: {0}", sayýAl()); // 50*5=250
            h2 (3); Console.WriteLine ("Ýkinci çarpma sonucu: {0}", sayýAl()); // 250*3=750

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}