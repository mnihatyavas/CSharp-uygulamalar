// j2sc#0117.cs: 'try-catch' ile �al��mazamanl� istisnalar�n idaresi �rne�i.

using System;
namespace DilTemelleri {
    class �stisna {
        public static void Ge�ersizDiziEleman�naEri�im() {
            int[] tsDizi = new int [20]; //[0-->19]
            try {// �stisna �a�r�lan metotda y�netiliyor.
                Console.WriteLine ("Ge�ersiz dizi elemana eri�im deneniyor.");
                tsDizi [20] = 2020;
            }catch (IndexOutOfRangeException h) {
                Console.WriteLine ("IndexOutOfRangeException istisnas� y�netiliyor.");
                Console.WriteLine ("Hata mesaj� = [{0}]", h.Message);
                Console.WriteLine ("Y���n izi = [{0}]", h.StackTrace);
            }
        }
        public static void S�f�raB�l�m() {
            int s�f�r = 0;
            Console.WriteLine ("S�f�ra b�l�m deneniyor.");
            int sonu� = 1 / s�f�r;
        }
        public static int �stisnaF�rlatanMetot (int n) {
            if (n == 0) throw new DivideByZeroException ("0 ile b�l�m �zel istisnas� f�rlat�ld�!");
            int x = 2020 / n;
            return x;
        }
        static void Main() {
            Console.Write ("T�m �al��mazamanl� istisnalar System.Exception'dan t�retilir. �stisna y�netimi try-catch i�in genel Exception, yada di�er odakl� istisnalar (ArrayTypeMismatchException, DivideByZeroException, IndexOutOfRangeException, InvalidCastException, OutOfMemoryException, OverflowException, NullReferenceException, StackOverflowException) veya kendi �zel tan�ml� istisnan�z� f�rlatabilirsiniz. �stisna �zellikleri: Message, StackTrace, TargetSite, TargetSite.DeclaringType, TargetSite.MemberType, Source, HelpLink; metodu: ToString().\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int S�f�r = 0;
            try {int j = 1 / S�f�r;
            }catch (DivideByZeroException hata) {Console.WriteLine ("DivideByZero/S�f�raB�l�m hatas�: [{0}]", hata);
            }catch (Exception hata) {Console.WriteLine ("Exception/�stisna hatas�: [{0}]", hata);}

            try {
                var tsDizi = new int [4];
                Console.WriteLine ("\nEndeks ta�ma istisnas� �ncesi...");
                for (int i=0; i < 10; i++) {tsDizi [i] = i;}
            }catch (IndexOutOfRangeException hata) {
                Console.WriteLine ("Standart hata mesaj�: [{0}]", hata);
                Console.WriteLine ("Y���n izi: [{0}]", hata.StackTrace);
                Console.WriteLine ("Mesaj: [{0}]", hata.Message);
                Console.WriteLine ("Hedef site: [{0}]", hata.TargetSite);
                Console.WriteLine ("�stisnan�n tan�ml� s�n�f�: [{0}]", hata.TargetSite.DeclaringType);
                Console.WriteLine ("�stisna s�n�f �ye tipi: [{0}]", hata.TargetSite.MemberType);
                Console.WriteLine ("Kaynak: [{0}.cs]", hata.Source);
                Console.WriteLine ("Yard�m ba�lant�s�: [{0}]", hata.HelpLink);
            }  
            Console.WriteLine ("Try-catch istisna y�netimi sonras�...");

            Console.WriteLine ("\nGe�ersizDiziEleman�naEri�im() metodu �a�r�l�yor...");
            Ge�ersizDiziEleman�naEri�im();
            try {// �a�r�lan metotda f�rlat�lan istisna �a��ran metotda y�netiliyor.
                Console.WriteLine ("\nS�f�raB�l�m() metodu �a�r�l�yor...");
                S�f�raB�l�m();
            }catch (DivideByZeroException h) {
                Console.WriteLine ("DivideByZeroException istisnas� y�netiliyor.");
                Console.WriteLine ("Hata mesaj� = [{0}]", h.Message);
                Console.WriteLine ("Y���n izi = [{0}]", h.StackTrace);
            }

            try {
                Console.WriteLine ("\nB�l�m sonucu = {0}", �stisnaF�rlatanMetot (10)); //Sorunsuz
                Console.WriteLine ("B�l�m sonucu = {0}", �stisnaF�rlatanMetot (20)); //Sorunsuz
                Console.WriteLine ("B�l�m sonucu = {0}", �stisnaF�rlatanMetot (0)); //�stisna f�rlatt�
            }catch (Exception h) {Console.WriteLine ("F�rlat�lan bir istisna yakaland�: [{0}]\nProgram ak��� devam ediyor", h);}
            Console.WriteLine ("Try-catch tamamland�...");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}