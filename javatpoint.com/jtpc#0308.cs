// jtpc#0308.cs: (�artl�) goto ile program ak���n�n belirtilen etikete atlamas� �rne�i.

using System;
namespace Control�fadeleri {
    class Goto {
        static void Main () {
            Console.Write ("Goto, program ak���n� do�rudan yada �arta ba�l� olarak tan�ml� etiket sat�r�na atlat�r. Yap�sal programc�l��a ayk�r� oldu�undan, kullan�lmas� pek tavsiye edilmez.\nTu�..."); Console.ReadKey(); Console.WriteLine();

            int ya�;
            Ya�Gir: Console.Write ("\nYa��n�z� girin [999: ��k]: ");
            try {ya� = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto Ya�Gir;}
            if (ya� == 999) goto son;
            if (ya� < 6 || ya� > 100) goto Ya�Gir;
            if (ya� < 18) Console.WriteLine ("Hen�z re�it de�ilsiniz, oy kullanamazs�n�z.");
            else Console.WriteLine ("Oyunuzu kullanmak i�in buyrun, kabine girin.");
            Console.Write ("\nTu�.."); Console.ReadKey(); goto Ya�Gir;
            son:;
        }
    }
}