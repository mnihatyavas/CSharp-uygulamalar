// tpc#33b.cs: Toplama, çarpma ve bölme fonksiyonlarýný çoða delegeli çaðýrma örneði.

using System;
delegate int Hesaplatýcý (int tamsayý);
namespace Delegeler {
    class ÇoðaDelege {
        static int sayý = 10;
        public static int Toplama (int n) {sayý += n; return sayý;}
        public static int Çarpma (int n) {sayý *= n; return sayý;}
        public static int Bölme (int n) {sayý /= (n - 2); return sayý;}
        public static int sayýAl() {return sayý;}
        static void Main() {
            Console.Write ("Ayný geridönüþ tipli farklý metodlu delege tiplemeleri '+' ile birleþtirilip, tekrar '-' ile çoða çaðýrma listesinden düþülebilir. Toplama+çarpma+bölme metodlarý tek bir çoða delegeyle çaðrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplatýcý çoðaHesap; // Delege tiplemeleri
            Hesaplatýcý h1 = new Hesaplatýcý (Toplama);
            Hesaplatýcý h2 = new Hesaplatýcý (Çarpma);
            Hesaplatýcý h3 = new Hesaplatýcý (Bölme);
            çoðaHesap = h1; çoðaHesap += h2; çoðaHesap += h3;
            çoðaHesap (5); Console.WriteLine ("1.çoklu toplama+çarpma+bölme sonucu: {0}", sayýAl()); // 10+5=15, 15*5=75, 75/3=25
            çoðaHesap (5); Console.WriteLine ("2.çoklu toplama+çarpma+bölme sonucu: {0}", sayýAl()); // 25+5=30, 30*5=150, 150/3=50
            çoðaHesap -= h3; // Bölme çoða-çaðýrma listesinden düþülür
            çoðaHesap (3); Console.WriteLine ("3.çoklu toplama+çarpma sonucu: {0}", sayýAl()); // 50+3=53, 53*3=159

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}