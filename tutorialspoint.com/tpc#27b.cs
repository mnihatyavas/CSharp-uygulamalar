// tpc#27b.cs: Try-catch blo�uyla �zel throw f�rlatarak s�f�ra b�l�m hatas�n�n yakalanmas� �rne�i.

using System;
namespace �stisnaY�netimi {
    class F�rlat�lanHata {
        public void g�ster (int a, int b) {
            try {new B�l�m().b�l (a, b);
            } catch (S�f�raB�l�m�stisnas� hata) {Console.WriteLine ("S�f�raB�l�m�stisnas� ({0}/{1}): {2}", a, b, hata.Message);}
        }
        static void Main() {
            Console.Write ("Exeption/�stisna temel s�n�f�yla kendi �zel hata f�rlatma/throw t�rev-s�n�f�m�z� yarabiliriz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            new F�rlat�lanHata().g�ster (25, 0);
            new F�rlat�lanHata().g�ster (25, 5);
            new F�rlat�lanHata().g�ster (0, 0);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
    public class S�f�raB�l�m�stisnas�: Exception {public S�f�raB�l�m�stisnas� (string mesaj): base (mesaj){} }
    public class B�l�m {
        public void b�l (int pay, int payda) {
            if (payda == 0) {throw (new S�f�raB�l�m�stisnas� ("S�f�ra b�l�m hatas� bulundu!.."));
            } else {Console.WriteLine ("[{0}/{1}] b�l�m sonucu: {2}", pay, payda, pay/payda);}
        }
    }
}