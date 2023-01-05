// tpc#36a.cs: Soysal s�n�f tiplemesiyle tamsay�, krk ve dizge diziler i�leme �rne�i.

using System;
using System.Collections.Generic;
namespace Soysallar {
    public class SoysalDizi<Tip> {
        private Tip[] dizi;
        public SoysalDizi (int ebat) {dizi = new Tip [ebat + 1];}
        public Tip diziEleman�n�Al (int endeks) {return dizi [endeks];}
        public void diziEleman�n�Koy (int endeks, Tip de�er) {dizi [endeks] = de�er;}
    }
    class SoysalS�n�f {
        static void Main() {
            Console.Write ("Soysal<Tip>, s�n�f veya metod tipinin (ve diziyse ebat�n�n) program �al��mas� esnas�nda �oklu-farkl� tan�mlan�p, tan�mlanan tipine uygun verilerin i�lenmesine imkan tan�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            SoysalDizi<int> tamsay�Dizi = new SoysalDizi<int> (5); // Tamsay� dizi beyan�
            for (int i = 0; i < 5; i++) {tamsay�Dizi.diziEleman�n�Koy (i, i * 5);} // Tamsay� dizi elamanlar� koyma
            Console.Write ("Tamsay� dizi elemanlar�: ");
            for (int i = 0; i < 5; i++) {Console.Write (tamsay�Dizi.diziEleman�n�Al (i) + " ");} // Tamsay� dizi elamanlar� alma

            Console.Write ("\nKarakter dizi elemanlar�: ");
            SoysalDizi<char> krkDizi = new SoysalDizi<char> (10);
            for (int i = 0; i < 10; i++) {krkDizi.diziEleman�n�Koy (i, (char)(i+97));}
            for (int i = 0; i< 10; i++) {Console.Write (krkDizi.diziEleman�n�Al (i) + " ");}

            Console.Write ("\nDizge dizi elemanlar�: ");
            SoysalDizi<string> dizgeDizi = new SoysalDizi<string> (4);
            for (int i = 0; i < 4; i++) {dizgeDizi.diziEleman�n�Koy (i, "mny"+i);}
            for (int i = 0; i< 4; i++) {Console.Write (dizgeDizi.diziEleman�n�Al (i) + " ");}

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    }
}