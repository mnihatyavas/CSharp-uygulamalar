// j2sc#0119.cs: Ýstisna oluþsun oluþmasýn nihai iþletilen finally bloðu örneði.

using System;
using System.IO;
namespace DilTemelleri {
    class DosyaOku {
        public void DosyayýTara() {
            var dsy = new FileStream ("j2sc#0119.css", FileMode.Open); //Hata için olmayan dosya-adý da gir
            try {
                var oku = new StreamReader (dsy);
                string satýr;
                while ((satýr = oku.ReadLine()) != null) {Console.WriteLine (satýr);}
            }finally {dsy.Close();}
        }
    }
    class Finally {
        static void Main() {
            Console.Write ("Finally bloðu, try-catch istisna yakalasýn yakalamasýn, terkedilirken nihai olarak mutlaka iþletilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int sýfýr = 0;
            Console.WriteLine ("Try-catch-finally bloðuna giriliyor...");
            try {int i=1; i = i/sýfýr;
            }catch (IndexOutOfRangeException) {Console.WriteLine ("Dizi endeks taþmasý.");
            }catch (DivideByZeroException) {Console.WriteLine ("Sýfýra bölemezsiniz!");
            }catch (Exception) {Console.WriteLine ("Önceki catch'lerin yakalamadýðý istisnalar.");
            }finally {Console.WriteLine ("Try-catch...-finally'dan çýkýlýyor.");}
            Console.WriteLine ("Try-catch-finally bloðundan çýkýldý...\n");

            var okuyucu = new DosyaOku();
            try {okuyucu.DosyayýTara();
            }catch (Exception h) {Console.WriteLine ("Dosya hatasý: [{0}]", h.Message);}

            var yazýcý = new StreamWriter ("mny1.txt");
            try {
                yazýcý.WriteLine ("Normalen her yazýcý satýrý anýnda dosyaya yazýlmaktadýr.");
                yazýcý.WriteLine ("Ancak bazen son veriler henüz yazýcý akýþýnda beklemede kalabilmektedir.");
                yazýcý.WriteLine ("Yazýcý akýmýnýn tamamen boþaltýlmasý finally bloðunca yapýlacaktýr.");
            }finally {
                if (yazýcý != null ) {((IDisposable)yazýcý).Dispose();}
                Console.WriteLine ("\nYazýcý akýþý tamamen boþaltýldý...");
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}