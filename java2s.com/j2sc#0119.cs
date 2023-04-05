// j2sc#0119.cs: �stisna olu�sun olu�mas�n nihai i�letilen finally blo�u �rne�i.

using System;
using System.IO;
namespace DilTemelleri {
    class DosyaOku {
        public void Dosyay�Tara() {
            var dsy = new FileStream ("j2sc#0119.css", FileMode.Open); //Hata i�in olmayan dosya-ad� da gir
            try {
                var oku = new StreamReader (dsy);
                string sat�r;
                while ((sat�r = oku.ReadLine()) != null) {Console.WriteLine (sat�r);}
            }finally {dsy.Close();}
        }
    }
    class Finally {
        static void Main() {
            Console.Write ("Finally blo�u, try-catch istisna yakalas�n yakalamas�n, terkedilirken nihai olarak mutlaka i�letilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int s�f�r = 0;
            Console.WriteLine ("Try-catch-finally blo�una giriliyor...");
            try {int i=1; i = i/s�f�r;
            }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizi endeks ta�mas�.");
            }catch (DivideByZeroException) {Console.WriteLine ("S�f�ra b�lemezsiniz!");
            }catch (Exception) {Console.WriteLine ("�nceki catch'lerin yakalamad��� istisnalar.");
            }finally {Console.WriteLine ("Try-catch...-finally'dan ��k�l�yor.");}
            Console.WriteLine ("Try-catch-finally blo�undan ��k�ld�...\n");

            var okuyucu = new DosyaOku();
            try {okuyucu.Dosyay�Tara();
            }catch (Exception h) {Console.WriteLine ("Dosya hatas�: [{0}]", h.Message);}

            var yaz�c� = new StreamWriter ("mny1.txt");
            try {
                yaz�c�.WriteLine ("Normalen her yaz�c� sat�r� an�nda dosyaya yaz�lmaktad�r.");
                yaz�c�.WriteLine ("Ancak bazen son veriler hen�z yaz�c� ak���nda beklemede kalabilmektedir.");
                yaz�c�.WriteLine ("Yaz�c� ak�m�n�n tamamen bo�alt�lmas� finally blo�unca yap�lacakt�r.");
            }finally {
                if (yaz�c� != null ) {((IDisposable)yaz�c�).Dispose();}
                Console.WriteLine ("\nYaz�c� ak��� tamamen bo�alt�ld�...");
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}