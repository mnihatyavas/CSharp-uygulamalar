// jtpc#0401.cs: Statik ve genel, parametresiz ve tek parametreli, geridönüþsüz ve dönüþlü fonksiyonlar örneði.

using System;
namespace Fonksiyonlar {
    class Fonksiyon {
        static void Göster1() {Console.WriteLine ("Bu bir parametresiz statik eriþimli fonksiyondur.");}
        public void Göster2() {Console.WriteLine ("Bu bir parametresiz genel eriþimli fonksiyondur.");}
        public void Göster3 (string mesaj) {Console.WriteLine ("Bu bir tek parametreli genel eriþimli fonksiyondur.\nMerhaba {0}!..", mesaj);}
        public string Göster4 (string mesaj) {Console.WriteLine ("Bu bir tek parametreli genel eriþimli ve dizgesel tip geridönüþlü fonksiyondur."); return mesaj + "; nasýlsýn?..";}

        static void Main () {
            Console.Write ("Fonksiyon, sýklýkla çaðrýlabilecek bir kodlama bloðu olup, yegane adý, tercihli geridönüþ tipi, eriþim belirteci ve deðer nakledilecek parametreleri vardýr. Statik fonksiyon sýnýfla nesneli tipleme gerekmeden çaðrýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Göster1();
            Fonksiyon f1 = new Fonksiyon(); f1.Göster2(); // f1 tiplemeli
            new Fonksiyon().Göster2(); // Doðrudan tiplemeli
            new Fonksiyon().Göster3 ("Nihat");
            Console.WriteLine ("Merhaba {0}", new Fonksiyon().Göster4 ("Nihat"));

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}