// tpc#33c.cs: Ekrana ve diskdosyasýna yazan metodlarýn delegelendirilmesi örneði.

using System;
using System.IO;
namespace Delegeler {
    class EkranaDiske {
        static FileStream da; //DosyaAkýþý
        static StreamWriter ay; // AkýþYazýcý
        public delegate void dizgeyiYaz (string d); // Delege beyaný
        public static void ekranaYaz (string d) {Console.WriteLine ("Mesaj: [{0}]", d);}
        public static void diskeYaz (string d) {
            da = new FileStream (
                "mny1.txt",
                FileMode.Append, FileAccess.Write);
                ay = new StreamWriter (da);
                ay.WriteLine (d);
                ay.Flush(); // akýþ tamponu boþaltýlýr
                ay.Close(); // Akýþlar kapatýlýr
                da.Close();
        }
        public static void dizgeyiGönder(dizgeyiYaz yaz) { // Parametrik delegeye dizge argümaný gönderir
            yaz ("Merhaba C# dünyasý!");
            yaz ("Parametrik delegeyle argümansal dizge yazdýrýlmaktadýr.");
            yaz ("Tüm çok-satýrlý mesajlar bu yöntemle yazdýrýlabilir...");
        }
        static void Main() {
            Console.Write ("Ekrana ve disk dosyasýna yazan metodlarý, geridönüþ tipsiz (void) delege tiplemeleriyle kullanma.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            dizgeyiYaz dy1 = new dizgeyiYaz (ekranaYaz);
            dizgeyiYaz dy2 = new dizgeyiYaz (diskeYaz);
            dizgeyiGönder (dy1);
            dizgeyiGönder (dy2);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}