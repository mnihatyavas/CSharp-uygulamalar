// tpc#33b.cs: Toplama, �arpma ve b�lme fonksiyonlar�n� �o�a delegeli �a��rma �rne�i.

using System;
delegate int Hesaplat�c� (int tamsay�);
namespace Delegeler {
    class �o�aDelege {
        static int say� = 10;
        public static int Toplama (int n) {say� += n; return say�;}
        public static int �arpma (int n) {say� *= n; return say�;}
        public static int B�lme (int n) {say� /= (n - 2); return say�;}
        public static int say�Al() {return say�;}
        static void Main() {
            Console.Write ("Ayn� gerid�n�� tipli farkl� metodlu delege tiplemeleri '+' ile birle�tirilip, tekrar '-' ile �o�a �a��rma listesinden d���lebilir. Toplama+�arpma+b�lme metodlar� tek bir �o�a delegeyle �a�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplat�c� �o�aHesap; // Delege tiplemeleri
            Hesaplat�c� h1 = new Hesaplat�c� (Toplama);
            Hesaplat�c� h2 = new Hesaplat�c� (�arpma);
            Hesaplat�c� h3 = new Hesaplat�c� (B�lme);
            �o�aHesap = h1; �o�aHesap += h2; �o�aHesap += h3;
            �o�aHesap (5); Console.WriteLine ("1.�oklu toplama+�arpma+b�lme sonucu: {0}", say�Al()); // 10+5=15, 15*5=75, 75/3=25
            �o�aHesap (5); Console.WriteLine ("2.�oklu toplama+�arpma+b�lme sonucu: {0}", say�Al()); // 25+5=30, 30*5=150, 150/3=50
            �o�aHesap -= h3; // B�lme �o�a-�a��rma listesinden d���l�r
            �o�aHesap (3); Console.WriteLine ("3.�oklu toplama+�arpma sonucu: {0}", say�Al()); // 50+3=53, 53*3=159

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}