// jtpc#0609.cs: 'enu' say�lanabilenle mevsimlerin ve haftan�n g�nleri �rne�i.

using System;
namespace NesneS�n�f� {
    class Say�lanabilen {
        public enum Mevsimler1 {KI�, �LKBAHAR, YAZ, SONBAHAR} //Varsay�l� ilkde�er=0
        public enum Mevsimler2 {KI�=100, �LKBAHAR, YAZ, SONBAHAR} //�lkde�er=100
        public enum G�nler {Pazar=1, Pazartesi, Sal�, �ar�amba, Per�embe, Cuma, Cumartesi};
        static void Main() {
            Console.Write ("'enum' anahtarkelimeli say�lanabilenlere g�n, ay, mevsim adlar� verilip de�erleri de dizi endeksi gibi 0'dan ba�lasa da bu de�i�tirilebilir. Taranabilirler, s�n�f i�inde tan�mlanabilirler. foreach taramada string tiple Enum.GetNames veya G�nler tiple Enum.GetValues kullan�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Console.WriteLine ("[KI�, �LKBAHAR, YAZ, SONBAHAR] = [{0}, {1}, {2}, {3}]", (int)Mevsimler1.KI�, (int)Mevsimler1.�LKBAHAR, (int)Mevsimler1.YAZ, (int)Mevsimler1.SONBAHAR);
            Console.WriteLine ("[KI�, �LKBAHAR, YAZ, SONBAHAR] = [{0}, {1}, {2}, {3}]", (int)Mevsimler2.KI�, (int)Mevsimler2.�LKBAHAR, (int)Mevsimler2.YAZ, (int)Mevsimler2.SONBAHAR);

            Console.WriteLine ("\n[Pazar, Pazartesi, Sal�, �ar�amba, Per�embe, Cuma, Cumartesi] = [{0}, {1}, {2}, {3}, {4}, {5}, {6}]", (int)G�nler.Pazar, (int)G�nler.Pazartesi, (int)G�nler.Sal�, (int)G�nler.�ar�amba, (int)G�nler.Per�embe, (int)G�nler.Cuma, (int)G�nler.Cumartesi);
            foreach (string g�n in Enum.GetNames (typeof (G�nler))) {Console.Write (g�n + " ");}
            Console.WriteLine(); int i=0;
            int[] g�nNo = {(int)G�nler.Pazar, (int)G�nler.Pazartesi, (int)G�nler.Sal�, (int)G�nler.�ar�amba, (int)G�nler.Per�embe, (int)G�nler.Cuma, (int)G�nler.Cumartesi};
            foreach (G�nler g�n in Enum.GetValues (typeof (G�nler))) {Console.Write (g�nNo [i++] + "=" + g�n + " ");}

            Console.Write ("\n\nTu�.."); Console.ReadKey();
        }
    }
}