// tpc#19e.cs: S�n�f�n kurucu yan�s�ra y�k�c� fonksiyonu �rne�i.

using System;
namespace S�n�flar {
    class �ember {
        private double yar��ap;

        public �ember() {Console.WriteLine ("\n\n�ember s�n�f nesnesi yarat�l�yor...");}
        ~�ember() {Console.WriteLine ("\n�ember s�n�f nesnesi y�k�l�yor/siliniyor...");}
        public void yar��apKoy (double y�) {yar��ap = y�;}
        public double �evreyiAl() {return 2 * 3.141592653589793 * yar��ap;}
    }
    class �emberin�evresi3 {
        static void Main (string[] args) {
            Console.Write ("S�n�f nesnesi ilk yarat�l�rken, ayn� adl� kurucu fonksiyon �a�r�ld��� gibi, program sonland���nda veya s�n�f nesnesi bellekten silindi�inde de, ~S�n�f ayn� adl� (parametresiz, d�nen de�ersiz, eri�im belirte�siz) y�k�c� fonksiyon otomatikmen �a�r�l�r.\nTu�..."); Console.ReadKey();

            �ember �ember = new �ember(); // Kurucu fonksiyon �a�r�l�r
            �ember.yar��apKoy (15.87); Console.WriteLine ("�lk �emberin �evresi = [{0}] birim.", �ember.�evreyiAl());
            �ember.yar��apKoy (7.17); Console.WriteLine ("�kinci �emberin �evresi = [{0}] birim.", �ember.�evreyiAl());
            Console.Write ("Tu�..."); Console.ReadKey(); // Y�k�c� fonksiyon �a�r�l�r

        }
    }
}