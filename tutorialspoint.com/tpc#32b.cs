// tpc#32b.cs: Ýsim listesini aþýrýyüklü endeksleyicinin konum ve adlarýyla yazma ve okuma örneði.

using System;
namespace Endeksleyiciler {
    class AþýrýyüklenenEndeksleyici {
        private string[] isimListesi = new string [ebat];
        static public int ebat = 10;
        public AþýrýyüklenenEndeksleyici() {for (int i = 0; i < ebat; i++) isimListesi [i] = "NaMevcut";}
        public string this [int endeks] {
            get {
                string geçici;
                if (endeks >= 0 && endeks <= ebat-1) {geçici = isimListesi [endeks];
                }else {geçici = "";}
                return (geçici);
            }
            set {if (endeks >= 0 && endeks <= ebat-1) {isimListesi [endeks] = value;} }
        }
        public int this [string ad] {// Aþýrýyüklenen this
            get {
                int endeks = 0;
                while (endeks < ebat) {if (isimListesi [endeks] == ad) {return endeks;} endeks++;}
                return 0; // Gereksiz
            }
        }
        static void Main() {
            Console.Write ("Endeksleyici aþýrýyüklenebilir. 'this' endeksleyicinin geridönüþü dizgesel isim olduðu gibi tamsayý endeksNo da olabilir. Ve tiplenenin eriþim endeksi ebat sayýlarý olduðu gibi isimler de olabilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            AþýrýyüklenenEndeksleyici isimler = new AþýrýyüklenenEndeksleyici();
            isimler [0] = "M.Nihat Yavaþ";
            isimler [1] = "Hatice Yavaþ Kaçar";
            isimler [2] = "Süheyla Y.Özbay";
            isimler [3] = "Zeliha Y.Candan";
            isimler [4] = "M.Nedim Yavaþ";
            isimler [5] = "Songül Y.Göktürk";
            isimler [6] = "Sevim Yavaþ";
            for (int i = 0; i < AþýrýyüklenenEndeksleyici.ebat; i++) {Console.WriteLine (isimler [i]);}
            Console.WriteLine (isimler ["Sevim Yavaþ"]);
            Console.WriteLine ("{0}'ýn endeks no'su: {1}", isimler [3], isimler ["Zeliha Y.Candan"]); // isimler[] endeksi hem tamsayý, hem de aþýrýyüklenen dizge olabilir

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}