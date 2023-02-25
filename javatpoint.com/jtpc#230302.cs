// jtpc#230302.cs: Adlý ve seçenekli argümanlarla metod çaðýrma örneði.

using System;
namespace YeniÖzellikler {
    class AdlýSeçenekliArgüman {
        static string TamÝsmiAl (string ad, string soyad) {return ad + " " + soyad;}
        static void topla (int a, int b = 12, int c = 3) {Console.WriteLine (a+b+c);} //Ýlk deðerin aktarýlmasý zorunlu, diðerleri seçenekli
        static void Main() {
            Console.Write ("Adlý argümanlara deðer aktarma adlarýn geliþigüzel sýralamasýyla yapýlabilir. Seçenekli argüman ilkdeðerli olup, deðer aktarýlmadýðýnda bu varsayýlan deðer alýnýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string isim1 = TamÝsmiAl ("M.Nihat", "Yavaþ"); //Adsýz argüman deðerleri geçirme
            string isim2 = TamÝsmiAl (ad: "M.Nihat", soyad: "Yavaþ"); //Adsýz argüman deðerleri geçirme
            string isim3 = TamÝsmiAl (soyad:"Yavaþ", ad:"M.Nihat"); //Adsýz argüman deðerlerini geliþigüzel sýrada geçirme
            Console.WriteLine ("Adsýz argüman aktarmalý isim: " + isim1);
            Console.WriteLine ("Normal sýralý adlý argüman aktarmalý isim: " + isim2);
            Console.WriteLine ("Geliþigüzel sýralý adlý argüman aktarmalý isim: {0}\n", isim3);

            //topla(); //Ýlk argüman zorunluðu derleme hatasý verdirir.
            topla (10); //Sadece ilk zorunlu deðer aktarýmý
            topla (10, 15); //Ýlk zorunlu ve ikinci seçenekli deðer aktarýmý
            topla (10, 15, 5); //Ýlk zorunlu ve ikinciyle üçüncü seçenekli deðerler aktarýmý

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}