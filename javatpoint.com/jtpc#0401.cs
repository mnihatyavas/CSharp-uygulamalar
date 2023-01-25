// jtpc#0401.cs: Statik ve genel, parametresiz ve tek parametreli, gerid�n��s�z ve d�n��l� fonksiyonlar �rne�i.

using System;
namespace Fonksiyonlar {
    class Fonksiyon {
        static void G�ster1() {Console.WriteLine ("Bu bir parametresiz statik eri�imli fonksiyondur.");}
        public void G�ster2() {Console.WriteLine ("Bu bir parametresiz genel eri�imli fonksiyondur.");}
        public void G�ster3 (string mesaj) {Console.WriteLine ("Bu bir tek parametreli genel eri�imli fonksiyondur.\nMerhaba {0}!..", mesaj);}
        public string G�ster4 (string mesaj) {Console.WriteLine ("Bu bir tek parametreli genel eri�imli ve dizgesel tip gerid�n��l� fonksiyondur."); return mesaj + "; nas�ls�n?..";}

        static void Main () {
            Console.Write ("Fonksiyon, s�kl�kla �a�r�labilecek bir kodlama blo�u olup, yegane ad�, tercihli gerid�n�� tipi, eri�im belirteci ve de�er nakledilecek parametreleri vard�r. Statik fonksiyon s�n�fla nesneli tipleme gerekmeden �a�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            G�ster1();
            Fonksiyon f1 = new Fonksiyon(); f1.G�ster2(); // f1 tiplemeli
            new Fonksiyon().G�ster2(); // Do�rudan tiplemeli
            new Fonksiyon().G�ster3 ("Nihat");
            Console.WriteLine ("Merhaba {0}", new Fonksiyon().G�ster4 ("Nihat"));

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}