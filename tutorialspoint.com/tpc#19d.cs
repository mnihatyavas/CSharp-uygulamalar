// tpc#19d.cs: Parametreli s�n�f kurucu fonksiyonu �rne�i.

using System;
namespace S�n�flar {
    class �ember {
        private double yar��ap;

        public �ember (double y�) {yar��ap = y�; Console.WriteLine ("\n\n�ember s�n�f nesnesi yarat�l�yor...\n1.�emberin �evresi = [{0}] birim.", �evreyiAl());}
        public void yar��apKoy (double y�) {yar��ap = y�;}
        public double �evreyiAl() {return 2 * 3.141592653589793 * yar��ap;}
    }
    class �emberin�evresi2 {
        static void Main (string[] args) {
            Console.Write ("S�n�fla ayn� adl� kurucu fonksiyona g�nderece�imis arg�man, s�n�f tiplemesi yarat�l�rken ayn� anda da �ember �evre sonucunu sunabilir.\nTu�..."); Console.ReadKey();

            �ember �ember = new �ember (12.61);
            �ember.yar��apKoy (15.87); Console.WriteLine ("2.�emberin �evresi = [{0}] birim.", �ember.�evreyiAl());
            �ember.yar��apKoy (7.17); Console.WriteLine ("3.�emberin �evresi = [{0}] birim.", �ember.�evreyiAl());
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}