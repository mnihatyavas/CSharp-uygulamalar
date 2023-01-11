// jtpc#0308.cs: (Þartlý) goto ile program akýþýnýn belirtilen etikete atlamasý örneði.

using System;
namespace ControlÝfadeleri {
    class Goto {
        static void Main () {
            Console.Write ("Goto, program akýþýný doðrudan yada þarta baðlý olarak tanýmlý etiket satýrýna atlatýr. Yapýsal programcýlýða aykýrý olduðundan, kullanýlmasý pek tavsiye edilmez.\nTuþ..."); Console.ReadKey(); Console.WriteLine();

            int yaþ;
            YaþGir: Console.Write ("\nYaþýnýzý girin [999: çýk]: ");
            try {yaþ = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto YaþGir;}
            if (yaþ == 999) goto son;
            if (yaþ < 6 || yaþ > 100) goto YaþGir;
            if (yaþ < 18) Console.WriteLine ("Henüz reþit deðilsiniz, oy kullanamazsýnýz.");
            else Console.WriteLine ("Oyunuzu kullanmak için buyrun, kabine girin.");
            Console.Write ("\nTuþ.."); Console.ReadKey(); goto YaþGir;
            son:;
        }
    }
}