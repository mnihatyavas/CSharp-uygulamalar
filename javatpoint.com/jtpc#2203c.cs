// jtpc#2203c.cs: Verilen yýlýn ay günleri ve toplam yýl günü örneði.

using System;
namespace Çeþitli {
    class TarihZamanC {
        static void Main() {
            Console.Write ("DateTime.DaysInMonth(2004,2) ile 28 geridönüþü alýnýr. Ýstenen her yýlýn tüm ay günleri ve toplam yýl günü bulunabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int yýl; Console.Write ("\nBir yýl gir [1,9999]: ");
            try {yýl = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            int ayGünü, toplamGün = 0;
            for (int j = 1; j <= 12; j++) {
                //ayGünü = DateTime.DaysInMonth (yýl, j);
                Console.WriteLine ("{0}.inci ayýn gün sayýsý = {1} gün", j, (ayGünü = DateTime.DaysInMonth (yýl, j)));
                toplamGün +=ayGünü;
            }
            Console.WriteLine ("\n{0} yýlýndaki toplam gün sayýsý = {1} gün", yýl, toplamGün);

            son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}