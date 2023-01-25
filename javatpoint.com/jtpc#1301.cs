// jtpc#1301.cs: F�rlat�lan s�f�ra b�l�m istisnas�n�n yakalan�p y�netilmesi �rne�i.

using System;
namespace �stisnaY�netimi {
    class TryCatch {
        static void Main() {
            Console.Write ("�al��mazamanl� hatalar, ilgili  System.Exception s�n�f hata nesnesini f�rlat�p program� k�rar. �stisna y�netimi bu istisnay� y�netip, normal program ak���n� s�rd�r�r.\nSystem.Exception'�n birka� t�rev s�n�f�: System.DivideByZeroException, System.NullReferenceException, System.InvalidCastException, System.IO.IOException, System.FieldAccessException\n�stisna y�netiminin 4 anahtarkelimesi: try, catch, finally, throw\nAyr�ca kullan�c�-tan�ml� �zel istisnalar da yarat�labilir.\nTry blo�u f�rlat�labilecek istisna kodlamas�n�, catch blo�uysa f�rlat�lan istisnay� yakalay�p y�neten kodlamay� i�erir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            try {
                int a = 10;
                int b = 0;
                Console.Write ("a/b={0}/{1}=", a, b);
                Console.Write (a/b);
            }catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata);}
            Console.WriteLine ("\nNormal program ak���na devam"); 

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}