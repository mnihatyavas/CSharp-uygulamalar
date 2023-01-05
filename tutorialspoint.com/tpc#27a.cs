// tpc#27a.cs: Try-catch blo�uyla s�f�ra b�l�m hatas�n�n yakalanmas� �rne�i.

using System;
namespace �stisnaY�netimi {
    class S�f�raB�l�m {
        int sonu�;
        S�f�raB�l�m() {sonu� = 0;}
        public void b�l (int pay, int payda) {
            try {sonu� = pay / payda;
            } catch (DivideByZeroException hata) {Console.WriteLine ("Yakalanan hata: {0}", hata);
            } finally {Console.WriteLine ("[{0}/{1}] b�l�m sonucu: {2}\n", pay, payda, sonu�);}
        }
        static void Main() {
            Console.Write ("Try/Dene blo�undaki kodlaman�n �al��ma zamanl� olas� hatas�n� yada throw/f�rlatt���n� tek-�oklu catch/yakala ile, program� k�rmadan y�neten, sonu�ta/finally ��k�� kodlamas�n� i�leten y�ntemdir.\nSystem.SystemExeption'dan t�reyen baz� istisna s�n�flar�: System.IO.IOException, System.IndexOutOfRangeException, System.ArrayTypeMismatchException, System.NullReferenceException, System.DivideByZeroException, System.InvalidCastException, System.OutOfMemoryException, System.StackOverflowException\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            new S�f�raB�l�m().b�l (25, 0);
            new S�f�raB�l�m().b�l (25, 5);
            new S�f�raB�l�m().b�l (0, 0);

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}