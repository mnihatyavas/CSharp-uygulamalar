// jtpc#2205.cs: Read ile sat�r, karakter ve tu� giri�i �rne�i.

using System;
namespace �e�itli {
    class Oku {
        static void Main() {
            Console.Write ("System.ReadLine() metodu dizgesel sat�r giri�inin bitiminde Enter'la girileni okur.\nSystem.Read() sadece tek karakter giri�ini okur.\nSystem.ReadKey() ise program ak���n�n devam� i�in herhangibir tu�a (veya Ent) bas�lmas�n� bekler ve bas�lan tu� karakteri ekranda yans�r.\nF�rlat�lan istisnalar: IOException, OutOfMemoryException, ArgumentOutOfRangeException\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            string sat�r, ad, soyad;
            Console.WriteLine ("L�tfen tam adresini yaz�p Enter bas:");  
            sat�r = Console.ReadLine();
            Console.WriteLine ("Buyur, yazd�klar�n�n do�rulu�unu kontrol et: [{0}]", sat�r);

            Console.Write ("\nL�tfen ad�n�z� yaz�p Enter bas: "); ad = Console.ReadLine();
            Console.Write ("L�tfen soyad�n�z� yaz�p Enter bas: "); soyad = Console.ReadLine();
            Console.WriteLine ("Girdi�iniz soyad ve ad: [{0}, {1}]", soyad, ad);

            char krk1, krk2, krk3, krk4;  
            Console.Write ("\nL�tfen 4 karakterli �ifrenizi girip Ent bas: "); krk1 = Convert.ToChar (Console.Read()); krk2 = Convert.ToChar (Console.Read());  krk3 = Convert.ToChar (Console.Read()); krk4 = Convert.ToChar (Console.Read());
            Console.WriteLine ("Girdi�iniz harfler (tersten): [{0}, {1}, {2} ve {3}]", krk4, krk3, krk2, krk1);

            var tarih = DateTime.Now;
            Console.WriteLine ("\nAkt�el tarih ve zaman: [{0}]", tarih);
            Console.Write ("Program ak��� i�in herhangibir tu�a bas�n: ["); Console.ReadKey();
            Console.Write ("] <== tu�una bast�n�z");

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    }
}