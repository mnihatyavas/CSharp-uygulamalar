// tpc#12b.cs: Özel eriþim belirteçli kapsüllemeyle dikdörtgen alaný örneði.

using System;
namespace Kapsülleme {
    class Dikdörtgen {
        // Özel üye deðiþkenlere dýþardan eriþilmez
        private double en;
        private double boy;

        // Genel üye fonksiyonlarýna dýþardan eriþilebilir
        public void VeriGiriþi() {
            Console.Write ("\n\nDikdörtgenin geniþliðini girin [10,5] Ent: "); en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikdörtgenin yüksekliðini girin [6,75] Ent: "); boy = Convert.ToDouble (Console.ReadLine());
        }
        private double AlanýHesapla() {return en * boy;}
        public void Göster() {
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Yükseklik: {0}", boy);
            Console.Write ("Dikdörtgenin alaný: {0}", AlanýHesapla());
        }
    }

    class ÖzelEriþim {
        static void Main (string[] args) {
            Console.Write ("\nÖzel eriþim belirteci, sýnýfýn üyelerine eriþimi yasaklar; ancak ayný sýnýf üyeleri birbirlerine eriþebilir.");
            Console.Write ("\nTuþ..."); Console.ReadKey();

            Dikdörtgen d = new Dikdörtgen();// Dikdörtgen tiplemesi
            d.VeriGiriþi();
            d.Göster();
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}