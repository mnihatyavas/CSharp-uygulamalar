// tpc#12c.cs: Ýçsel eriþim belirteçli kapsüllemeyle dikdörtgen alaný örneði.

using System;
namespace Kapsülleme {
    class Dikdörtgen {
        // Ýçsel üye deðiþkenlere dýþsal uygulamalardan eriþilmez
        internal double en;
        internal double boy;

        double AlanýHesapla() {return en * boy;}// Belirtilmezse varsayýlý "private"dir
        internal void Göster() {
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Yükseklik: {0}", boy);
            Console.Write ("Dikdörtgenin alaný: {0}", AlanýHesapla());
        }
    }

    class ÝçselEriþim {
        static void Main (string[] args) {
            Console.Write ("\nÝçsel eriþim belirteci, sýnýfýn üyelerine eriþimi harici uygulamalara yasaklar; ancak ayný uygulamanýn içsel/dahili tüm sýnýf üyeleri birbirlerine eriþebilir.");
            Console.Write ("\nTuþ..."); Console.ReadKey();

            Dikdörtgen d = new Dikdörtgen();// Dikdörtgen tiplemesi
            Console.Write ("\n\nDikdörtgenin geniþliðini girin [10,5] Ent: "); d.en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikdörtgenin yüksekliðini girin [6,75] Ent: "); d.boy = Convert.ToDouble (Console.ReadLine());
            d.Göster();
            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}