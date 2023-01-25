// jtpc#0609.cs: 'enu' sayýlanabilenle mevsimlerin ve haftanýn günleri örneði.

using System;
namespace NesneSýnýfý {
    class Sayýlanabilen {
        public enum Mevsimler1 {KIÞ, ÝLKBAHAR, YAZ, SONBAHAR} //Varsayýlý ilkdeðer=0
        public enum Mevsimler2 {KIÞ=100, ÝLKBAHAR, YAZ, SONBAHAR} //Ýlkdeðer=100
        public enum Günler {Pazar=1, Pazartesi, Salý, Çarþamba, Perþembe, Cuma, Cumartesi};
        static void Main() {
            Console.Write ("'enum' anahtarkelimeli sayýlanabilenlere gün, ay, mevsim adlarý verilip deðerleri de dizi endeksi gibi 0'dan baþlasa da bu deðiþtirilebilir. Taranabilirler, sýnýf içinde tanýmlanabilirler. foreach taramada string tiple Enum.GetNames veya Günler tiple Enum.GetValues kullanýlabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("[KIÞ, ÝLKBAHAR, YAZ, SONBAHAR] = [{0}, {1}, {2}, {3}]", (int)Mevsimler1.KIÞ, (int)Mevsimler1.ÝLKBAHAR, (int)Mevsimler1.YAZ, (int)Mevsimler1.SONBAHAR);
            Console.WriteLine ("[KIÞ, ÝLKBAHAR, YAZ, SONBAHAR] = [{0}, {1}, {2}, {3}]", (int)Mevsimler2.KIÞ, (int)Mevsimler2.ÝLKBAHAR, (int)Mevsimler2.YAZ, (int)Mevsimler2.SONBAHAR);

            Console.WriteLine ("\n[Pazar, Pazartesi, Salý, Çarþamba, Perþembe, Cuma, Cumartesi] = [{0}, {1}, {2}, {3}, {4}, {5}, {6}]", (int)Günler.Pazar, (int)Günler.Pazartesi, (int)Günler.Salý, (int)Günler.Çarþamba, (int)Günler.Perþembe, (int)Günler.Cuma, (int)Günler.Cumartesi);
            foreach (string gün in Enum.GetNames (typeof (Günler))) {Console.Write (gün + " ");}
            Console.WriteLine(); int i=0;
            int[] günNo = {(int)Günler.Pazar, (int)Günler.Pazartesi, (int)Günler.Salý, (int)Günler.Çarþamba, (int)Günler.Perþembe, (int)Günler.Cuma, (int)Günler.Cumartesi};
            foreach (Günler gün in Enum.GetValues (typeof (Günler))) {Console.Write (günNo [i++] + "=" + gün + " ");}

            Console.Write ("\n\nTuþ.."); Console.ReadKey();
        }
    }
}