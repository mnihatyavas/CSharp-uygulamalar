// jtpc#0505.cs: 'params'lý fonksiyona deðiþken sayýda argüman aktarabilme örneði.

using System;
namespace Diziler {
    class ParamsDizi {
        public void Göster1 (params int[] dizi){// params'lý parametrik tamsayý dizi
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        public void Göster2 (params object[] dizi){// params'lý parametrik nesnel dizi
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        public void Göster3 (string ad, params object[] dizi){// Sona gelen params'lý parametrik nesnel dizi
            Console.WriteLine ("{0}'e dair bilgiler:", ad);
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        static void Main() {
            Console.Write ("Fonksiyon deðiþken sayýlý parametreleri, 'params' anahtarkelimeli dizi beyanlý yapýlabilir. Bu beyan sonrasý baþka parametre kullanýlamaz; ancak öncesinde kullanýlabilir. Nesnel tiplemeyle her tip veri gönderilebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            ParamsDizi p = new ParamsDizi();
            p.Göster1 (0, 2,4,6,8,10,12,14);
            p.Göster1 (1,3,5,7,9);
            p.Göster1 (2023-1923);

            p.Göster2 ("M.Nihat Yavaþ", "Malatya", 1.70, 60, "Haným", 'B', false);
            p.Göster2 ("Sevim Yavaþ", "Malatya", "Memet", true, 2023-1963);

            p.Göster3 ("Hilal Göktürk", "Gündüzbey", "Sefer", 2023-1985, 1.75, 55, "Fizik-Tedavi Doktoru");
            p.Göster3 ("Bekir Yavaþ", "Müteveffa", "Yeþilyurt", 2023-1973, 1973-1889);

            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}