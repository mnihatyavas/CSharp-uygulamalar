// jtpc#0309.cs: Kodlama içinde tek yada çok satýrlý yorum açýklamalarý yazma örneði.

using System;
namespace ControlÝfadeleri {
    class Yorumlar {
        static void Main () {
            Console.Write ("Yorum satýrlarý iþletilmez, sadece kaynak kodlamayla uðraþanlara yardýmcý olacak açýklamalarý içerir yada bazý kodlamalarý geçici gizler. Tek satýrlý // veya çok satýrlý /*...*/ olabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine();

            int yaþ; // yaþ, bir tamsayý deðiþkendir
            gir: Console.Write ("\nYaþýnýzý girin [Çýk=999]: ");
            try {yaþ = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto gir;}
            // Tamsayý harici verigiriþleri istisna hatasý üretip, tekrar yaþ giriþine yönlendirir
            if (yaþ == 999) goto son;
            if (yaþ < 0 || yaþ > 150) goto gir;
            Console.WriteLine ("Girdiðiniz {0} yaþa göre doðum yýlýnýz: {1}", yaþ, 2023-yaþ);
            goto gir;
            /* Program, girilen yaþý güncel yýl'dan düþerek doðum yýlýný hesaplar ve ekrana yansýtýr.
               Sonra yeni yaþ giriþi için akýþý tekrar verigiriþ satýrýna atlatýr.
               Programdan çýkmak için yaþ rakamý 999 olarak girilmelidir.

            */

            son: Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}