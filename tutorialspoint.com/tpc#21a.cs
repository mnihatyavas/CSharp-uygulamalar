// tpc#21a.cs: Aþýrýyüklenen fonksiyonlarýn argüman tipleriyle seçilmesi örneði.

using System;
namespace Çoklubiçim {
    class StatikFonksiyonAþýrýYüklenme {
        void yaz (int t) {Console.WriteLine ("\n\nTamsayý yazýlýyor: {0}", t );}
        void yaz (double k) {Console.WriteLine ("Kayannokta yazýlýyor: {0}", k );}
        void yaz (string d) {Console.WriteLine ("Dizge yazýlýyor: {0}", d );}
        static void Main() {
            Console.Write ("Çoklubiçimt tek arabaðlaç, çok fonksiyon demektir. Statik (erken-baðlama) çoklubiçimse derleme, dinamikse çalýþma sürecinde fonksiyon aþýrýyükleme irdelenir.\nFonksiyon aþýrý yükleme sadece döndürülenin tipiyle deðil, ayrýca argüman sayýsý ve tipleriyle de irdelenir.\nTuþ..."); Console.ReadKey();

            StatikFonksiyonAþýrýYüklenme y = new StatikFonksiyonAþýrýYüklenme();
            y.yaz (2022); // Argüman tamsayý
            y.yaz (3.141592653589793); // Argüman kayannokta
            y.yaz ("M.Nihat Yavaþ ile C#"); // Argüman dizge

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}