// j2sc#0120.cs: �arta ba�l� olarak throw'la f�rlat�lan �zel a��klamal� istisna �rne�i.

using System;
namespace DilTemelleri {
    class Throw {
        public static int ThrowFonksiyonu (int b�len) {
            if (b�len == 0) throw new DivideByZeroException ("S�f�ra b�l�m hatas� f�rlat�ld�!");
            int x = 20 / b�len;
            return x;
        }
        static void Main() {
            Console.Write ("Bir alt fonksiyonda try-catch kullan�lmadan �arta ba�l� olarak f�rlat�lan ve istenilen �zelle�tirilmi� hata mesaj�n� i�eren 'throw' �a��ran program taraf�ndan (istenirse) y�netilebilmektedir. Throw istisna f�rlat�l�nca kalan kodlama i�letilmeden gerid�n�l�r; y�netilmezse ak�� devam etmez.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int b�l�m; var r=new Random();
            for (int i=0; i<20; i++) {try {b�l�m = ThrowFonksiyonu (r.Next(0, 10)); Console.WriteLine ("B�l�m sonucu = {0}", b�l�m);}catch (Exception h) {Console.WriteLine ("HATA: {0}", h.Message);} }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}