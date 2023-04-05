// j2sc#0118.cs: Try-catch-finally anahtarkelimelerle istisnalar�n y�netilmesi �rne�i.

using System;
namespace DilTemelleri {
    class TryCatch {
        public static int S�f�r = 0;
        static void Fonksiyon1() {
            try {int j = 22 / S�f�r;
            }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("ArgumentOutOfRangeException hatas�: [{0}]", h.Message);} //Bu hata olu�maz
            Console.WriteLine ("Fonksiyon1() i�indeyim."); //Buraya ula�maz
        }
        static void Fonksiyon2() {
            var tsDizi = new int [4];
            Console.WriteLine ("�stisna �retilmeden �ncesi...");
            for (int i=0; i < 10; i++) {//Y�netilmeyen IndexOutOfRangeException istisnas�
               tsDizi [i] = i*i*i;
               Console.WriteLine ("tsDizi [{0}]: {1}", i, tsDizi [i]);
            } 
        }
        static void Fonksiyon3() {
            int x = 1, y = 0;
            try {x = x/y;
            }catch (IndexOutOfRangeException) {Console.WriteLine ("Catch blo�u"); //�stisnay� yakalamaz
            }finally {Console.WriteLine ("Finally blo�u");}
        }
        static void Main() {
            Console.Write ("�al��mazamanl� istisnalar, program ak���n�n k�r�lmamas� i�in: try-catch-finally anahtarkelimeleriyle y�netilir. Bunlarla y�netilmeyen istisna hatay� yans�tarak program� sonland�r�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Try-catch �NCES�...");
            try {int j = 22 / S�f�r; //Hata yakalar
                Console.WriteLine ("Buraya ULA�MAZ...");
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message);}
            Console.WriteLine ("Try-catch SONRASI...");

            try {int i = 1/S�f�r;
                Console.WriteLine ("Buraya ULA�MAZ...");
            }catch (DivideByZeroException) {Console.WriteLine ("\nHATA: [{0}]", "S�f�ra b�l�m hatas�!");}

            var tsDizi1 = new int[]{4, 8, 16}; Console.WriteLine();
            for (int i=0; i < 5; i++) {
                try {Console.WriteLine (tsDizi1 [i]/S�f�r);
                }catch (DivideByZeroException) {Console.WriteLine ("S�f�ra b�l�m hatas�!");
                }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizide endeks ta�ma hatas�!");}
            }

            int[] tsDizi2 = {4, 8}; Console.WriteLine();
            for (int i=0; i < 4; i++) {
                try {Console.WriteLine (tsDizi2 [i]/S�f�r);
                }catch {Console.WriteLine ("Bir hata olu�tu!");}
            }

            try {Console.WriteLine(); //D�� try
                for(int i=0; i < 5; i++) {
                    try {//�� try
                        Console.WriteLine (tsDizi1 [i]/S�f�r);
                    }catch (DivideByZeroException) {Console.WriteLine ("S�f�ra b�l�m hatas�!");
                    }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizide endeks ta�ma hatas�!");}
                }
            }finally {Console.WriteLine ("Vahim hatalar olu�tu!");}

            try {Fonksiyon1();
            }catch (ArgumentException h) {Console.WriteLine ("ArgumentException hatas�: [{0}]", h.Message); //Bu hata olu�maz
            }catch (Exception h){Console.WriteLine ("\nException hatas�: [{0}]", h.Message);} //Bu hata olu�ur

            try {Console.WriteLine ("\nTry blo�unda, s�f�ra b�l�m arifesindeyim");
                int j = 1 / S�f�r;
                Console.WriteLine ("Hata olu�tu�undan, buraya ula��lmaz, catch'e atlar");
            }catch {Console.WriteLine ("Catch blo�unday�m, bir istisna f�rlat�ld�");
            }finally {Console.WriteLine ("Finally blo�unday�m, son bellek temizli�i yap�labilir");}

            try {Console.WriteLine ("\nTry blo�unda, s�f�ra b�l�m arifesindeyim");
                int j = 1 / S�f�r;
            }catch (DivideByZeroException h) {
                Console.WriteLine ("Hata mesaj�: [{0}]", h.Message);
                Console.WriteLine ("Y���n izi: [{0}]", h.StackTrace);
            }

            while (true) {
                Gir: Console.Write ("\nSe� [1, 2, 9=Son]: ");
                try {S�f�r = Convert.ToInt32 (Console.ReadLine());}catch (Exception h) {Console.WriteLine ("HATA: [{0}]", h.Message); goto Gir;}
                if (S�f�r == 9) break;
                if (S�f�r < 1 || S�f�r > 2) goto Gir;
                if (S�f�r == 1) Fonksiyon2(); else Fonksiyon3();
            }

            try {string dizge = null; dizge.ToUpper();
            }catch (NullReferenceException) {Console.WriteLine ("\nCatch blo�unda NullReferenceException istisnas�.");
            }finally {Console.WriteLine ("Finally blo�unda son try-catch-finally i�lemleri.");}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}