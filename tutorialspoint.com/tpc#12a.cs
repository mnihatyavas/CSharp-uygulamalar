// tpc#12a.cs: Genel eriþim belirteçli kapsüllemeyle dikdörtgen alaný örneði.

using System;
namespace Kapsülleme {
    class Dikdörtgen {
        // Üye deðiþkenler:
        public double en;
        public double boy;

        // Üye fonksiyonlar:
        public double AlanýHesapla() {return en * boy;}
        public void Göster() {// void/boþ ise return/döndürülen-deðer yoktur
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Yükseklik: {0}", boy);
            Console.Write ("Dikdörtgenin alaný: {0}", AlanýHesapla());
        }
    }

    class GenelEriþim {
        static void Main (string[] args) {
            Console.WriteLine ("Soyutlama, sýnýf üyelerini görünür kýlarken, kapsülleme ise engeller; soyutlamalý kapsülleme, sýnýf üyelerine eriþim seviyesini belirler.");
            Console.WriteLine ("\nC# eriþim belirteçleri: Public/Genel, Private/Özel, Protected/Korumalý, Internal/Ýçsel ve ProtectedInternal/KorumalýÝçsel.");
            Console.WriteLine ("\nGenel eriþim belirteci, sýnýfýn üye deðiþken ve fonksiyonlarýna herkesin eriþimini mümkün kýlar.");
            Console.WriteLine ("\nKorumalý eriþim belirteci, sýnýfýn üye deðiþken ve fonksiyonlarýna sadece mirascý altsýnýf yavrularý eriþebilir.");
            Console.Write ("\nKorumalý içsel eriþim belirteci, sýnýfýn üye deðiþken ve fonksiyonlarýna sadece ayný uygulamanýn mirascý altsýnýf yavrularý eriþebilir.");
            Console.Write ("\nTuþ..."); Console.ReadKey();

            Dikdörtgen d = new Dikdörtgen();// Dikdörtgen tiplemesi
            Console.Write ("\n\nDikdörtgenin geniþliðini girin [10,5] Ent: "); d.en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikdörtgenin yüksekliðini girin [6,75] Ent: "); d.boy = Convert.ToDouble (Console.ReadLine());
            d.Göster();
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}