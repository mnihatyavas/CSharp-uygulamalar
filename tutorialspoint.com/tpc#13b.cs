// tpc#13b.cs: Ayr� s�n�f metoduyla iki tamsay�dan b�y���n�n tespiti �rne�i.

using System;
namespace Metodlar {
    class B�y���nTespiti {
        public int B�y���Bul (int n1, int n2) {
            int sonu�; // Lokal de�i�ken
            if (n1 > n2) sonu� = n1;
            else sonu� = n2;
            return sonu�;
        }
    }
    class AnaS�n�f {
        static void Main (string[] args) {
            Console.Write ("Bir metodun s�zdizimi:\n<Eri�im Belirteci/private> <D�nd�r�lenin Tipi/void> <Metod Ad�>(Parametre Listesi/) {Metod G�vdesi}\nMetod tan�mlan�r ve �a�r�l�r.");
            Console.Write ("\nTu�..."); Console.ReadKey();

            Console.Write ("\n\n�lk tamsay�y� girin [10] Ent: "); int ilk = Convert.ToInt32 (Console.ReadLine());
            Console.Write ("�kinci tamsay�y� girin [7] Ent: "); int ikinci = Convert.ToInt32 (Console.ReadLine());
            B�y���nTespiti b = new B�y���nTespiti();// Metodu i�eren s�n�f�n tiplemesi
            Console.Write ("�ki say�n�n b�y���: {0}\nTu�...", b.B�y���Bul (ilk, ikinci));
            Console.ReadKey();            
        }
    }
}