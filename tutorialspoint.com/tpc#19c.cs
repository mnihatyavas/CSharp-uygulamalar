// tpc#19c.cs: Parametresiz s�n�f kurucu fonksiyonu �rne�i.

using System;
namespace S�n�flar {
    class �ember {
        private double yar��ap;

        public �ember() {Console.WriteLine ("\n\n�ember s�n�f nesnesi yarat�l�yor...");}
        public void yar��apKoy (double y�) {yar��ap = y�;}
        public double �evreyiAl() {return 2 * 3.141592653589793 * yar��ap;}
    }
    class �emberin�evresi1 {
        static void Main (string[] args) {
            Console.Write ("S�n�fla ayn� adl� kurucu fonksiyona yazaca��m�z a��klamalar, s�n�f tiplemesi yarat�l�rken beyan edilebilir.\nTu�..."); Console.ReadKey();

            �ember �ember = new �ember(); �ember.yar��apKoy (15.87);
            Console.WriteLine ("�emberin �evresi = [{0}] birim.", �ember.�evreyiAl());
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}