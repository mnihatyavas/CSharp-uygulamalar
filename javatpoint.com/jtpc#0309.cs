// jtpc#0309.cs: Kodlama i�inde tek yada �ok sat�rl� yorum a��klamalar� yazma �rne�i.

using System;
namespace Control�fadeleri {
    class Yorumlar {
        static void Main () {
            Console.Write ("Yorum sat�rlar� i�letilmez, sadece kaynak kodlamayla u�ra�anlara yard�mc� olacak a��klamalar� i�erir yada baz� kodlamalar� ge�ici gizler. Tek sat�rl� // veya �ok sat�rl� /*...*/ olabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine();

            int ya�; // ya�, bir tamsay� de�i�kendir
            gir: Console.Write ("\nYa��n�z� girin [��k=999]: ");
            try {ya� = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            // Tamsay� harici verigiri�leri istisna hatas� �retip, tekrar ya� giri�ine y�nlendirir
            if (ya� == 999) goto son;
            if (ya� < 0 || ya� > 150) goto gir;
            Console.WriteLine ("Girdi�iniz {0} ya�a g�re do�um y�l�n�z: {1}", ya�, 2023-ya�);
            goto gir;
            /* Program, girilen ya�� g�ncel y�l'dan d��erek do�um y�l�n� hesaplar ve ekrana yans�t�r.
               Sonra yeni ya� giri�i i�in ak��� tekrar verigiri� sat�r�na atlat�r.
               Programdan ��kmak i�in ya� rakam� 999 olarak girilmelidir.

            */

            son: Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}