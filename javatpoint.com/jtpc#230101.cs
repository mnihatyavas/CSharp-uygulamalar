// jtpc#230101.cs: Ýki ayrý kýsmi altprogramýn anaprogramla çalýþtýrýlmasý örneði.

using System;
namespace YeniÖzellikler {
    class KýsmiTipler {
        static void Main() {
            Console.Write ("Sýnýf, arayüz, yapý ve metodlar 'partial'/kýsmi anahtarkelimeyle ayrý .cs kaynak programlarý olarak yazýlýp, sonra birlikte derlenip birtek .exe koþturulabilir program elde edilebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var müþteri = new Müþteri();
            müþteri.Tutar = 25280;
            Console.WriteLine ("Aktüel bakiye: {0}.00 TL", müþteri.Tutar);
            müþteri.yatýr (3875); müþteri.çek (1562); müþteri.yatýr (5898); müþteri.çek (4589); müþteri.çek (1265);

            Console.Write ("\nTuþ...");Console.ReadKey();
            //>csc jtpc#230101a.cs jtpc#230101b.cs jtpc#230101.cs
            //>jtpc#230101
        }
    }
}