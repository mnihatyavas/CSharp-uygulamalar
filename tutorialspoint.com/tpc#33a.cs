// tpc#33a.cs: Toplama ve �arpma fonksiyonlar�n� delegeli �a��rma �rne�i.

using System;
delegate int Hesaplat�c� (int tamsay�);
namespace Delegeler {
    class Toplama�arpma {
        static int say� = 10;
        public static int Toplama (int n) {say� += n; return say�;}
        public static int �arpma (int n) {say� *= n; return say�;}
        public static int say�Al() {return say�;}
        static void Main() {
            Console.Write ("Delege, fonksiyonlara i�aret�i gibi metod referans�n� tutar ve referanslar �al��ma zamanl� de�i�ebilir. Bilhassa olaylar ve geri-�a��ran fonksiyonlarda kullan�l�r. Delege arg�man� yerine yal�n metod ad� kullan�l�p, tiplenen delege de�eriyle fonksiyona i�lem yapt�r�p geri d�n��� yans�t�lacak.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Hesaplat�c� h1 = new Hesaplat�c� (Toplama); // Delege tiplemeleri
            Hesaplat�c� h2 = new Hesaplat�c� (�arpma);
            h1 (25); Console.WriteLine ("�lk toplama sonucu: {0}", say�Al()); // 10+25=35
            h1 (15); Console.WriteLine ("�kinci toplama sonucu: {0}", say�Al()); // 35+15=50
            h2 (5); Console.WriteLine ("�lk �arpma sonucu: {0}", say�Al()); // 50*5=250
            h2 (3); Console.WriteLine ("�kinci �arpma sonucu: {0}", say�Al()); // 250*3=750

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}