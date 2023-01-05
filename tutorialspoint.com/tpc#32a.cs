// tpc#32a.cs: �sim listesini endeksleyicinin ebat konumlar�yla yazma ve okuma �rne�i.

using System;
namespace Endeksleyiciler {
    class SanalDizi {
        static public int ebat = 10;
        private string[] isimListesi = new string [ebat];
        public SanalDizi() {for (int i = 0; i < ebat; i++) isimListesi [i] = "NaMevcut";}
        public string this [int endeks] {
            get {
                string ge�ici;
                if (endeks >= 0 && endeks <= ebat-1) {ge�ici = isimListesi [endeks];
                }else {ge�ici = "";}
                return (ge�ici);
            }
            set {if (endeks >= 0 && endeks <= ebat-1) {isimListesi [endeks] = value;} }
        }
        static void Main() {
            Console.Write ("Endeksleyici bir nesneyi dizi gibi endeksleyip, sanal-dizi olmas�n� sa�lar. Eri�im i�in �zelliklerdeki gibi get-set kullan�l�rken �zellik bunu ad'la, endeksleyici ise nesne tiplemesini kasteden 'this' anahtarkelimesiyle yapar.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            SanalDizi isimler = new SanalDizi();
            isimler [0] = "M.Nihat Yava�";
            isimler [1] = "Hatice Yava� Ka�ar";
            isimler [2] = "S�heyla Y.�zbay";
            isimler [3] = "Zeliha Y.Candan";
            isimler [4] = "M.Nedim Yava�";
            isimler [5] = "Song�l Y.G�kt�rk";
            isimler [6] = "Sevim Yava�";
            for (int i = 0; i < SanalDizi.ebat; i++) {Console.WriteLine (isimler [i]);}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}