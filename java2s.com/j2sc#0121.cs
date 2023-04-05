// j2sc#0121.cs: �a�r�lan metotta olu�an bir istisnan�n y�netilmesi �rne�i.

using System;
namespace DilTemelleri {
    class Metottaki�stisna {
        public static void istisnal�Metot1() {
            var tsDizi = new int [4];
            for (int i=0; i < 10; i++) {
                tsDizi [i] = i*i;
                Console.WriteLine ("tsDizi[{0}]: {1}", i, tsDizi [i]);
            } 
            Console.WriteLine ("Bu a��klamaya ula��lmaz.");
        }
        public static void istisnal�Metot2() {
            var tsDizi = new int [4];
            Console.WriteLine ("\nTry-catch'den �nce...");
            try {
                for (int i=0; i < 10; i++) {
                    tsDizi [i] = i*i;
                    Console.WriteLine ("tsDizi[{0}]: {1}", i, tsDizi [i]);
                }
            }catch (IndexOutOfRangeException) {Console.WriteLine ("(Alt metotta f�rlat�lan) dizi endeks ta�ma istisnas� (alt metotta) yakaland�!");}
            Console.WriteLine ("Try-catch'den sonra...");
            Console.WriteLine ("Bu a��klamaya ula��l�r.\n");
        }
        static void Main() {
            Console.Write ("�a�r�lan metotta olu�an bir istisna ya yine ayn� yerdeki try-catch ile yada �a��ran metottaki try-catch taraf�ndan y�netilebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Try-catch'den �nce...");
            try {istisnal�Metot1();
            }catch (IndexOutOfRangeException) {Console.WriteLine ("(�a�r�lan metotta f�rlat�lan) dizi endeks ta�ma istisnas� (�a��ran metotta) yakaland�!");}
            Console.WriteLine ("Try-catch'den sonra...");

            istisnal�Metot2();

            try {int x = 1, y = 0;
                x /= y; //�stisna olu�ur
            }catch (Exception h) {
                if (h is SystemException) {Console.WriteLine ("�stisna �al��mazamanl� f�rlat�lm��t�r.\nSebebi: [{0}]", h.Message);
                }else {Console.WriteLine ("�stisna uygulamaca f�rlat�lm��t�r.");}
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}