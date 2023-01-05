// tpc#32a.cs: Ýsim listesini endeksleyicinin ebat konumlarýyla yazma ve okuma örneði.

using System;
namespace Endeksleyiciler {
    class SanalDizi {
        static public int ebat = 10;
        private string[] isimListesi = new string [ebat];
        public SanalDizi() {for (int i = 0; i < ebat; i++) isimListesi [i] = "NaMevcut";}
        public string this [int endeks] {
            get {
                string geçici;
                if (endeks >= 0 && endeks <= ebat-1) {geçici = isimListesi [endeks];
                }else {geçici = "";}
                return (geçici);
            }
            set {if (endeks >= 0 && endeks <= ebat-1) {isimListesi [endeks] = value;} }
        }
        static void Main() {
            Console.Write ("Endeksleyici bir nesneyi dizi gibi endeksleyip, sanal-dizi olmasýný saðlar. Eriþim için özelliklerdeki gibi get-set kullanýlýrken özellik bunu ad'la, endeksleyici ise nesne tiplemesini kasteden 'this' anahtarkelimesiyle yapar.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            SanalDizi isimler = new SanalDizi();
            isimler [0] = "M.Nihat Yavaþ";
            isimler [1] = "Hatice Yavaþ Kaçar";
            isimler [2] = "Süheyla Y.Özbay";
            isimler [3] = "Zeliha Y.Candan";
            isimler [4] = "M.Nedim Yavaþ";
            isimler [5] = "Songül Y.Göktürk";
            isimler [6] = "Sevim Yavaþ";
            for (int i = 0; i < SanalDizi.ebat; i++) {Console.WriteLine (isimler [i]);}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}