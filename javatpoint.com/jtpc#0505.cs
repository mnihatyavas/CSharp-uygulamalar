// jtpc#0505.cs: 'params'l� fonksiyona de�i�ken say�da arg�man aktarabilme �rne�i.

using System;
namespace Diziler {
    class ParamsDizi {
        public void G�ster1 (params int[] dizi){// params'l� parametrik tamsay� dizi
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        public void G�ster2 (params object[] dizi){// params'l� parametrik nesnel dizi
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        public void G�ster3 (string ad, params object[] dizi){// Sona gelen params'l� parametrik nesnel dizi
            Console.WriteLine ("{0}'e dair bilgiler:", ad);
            for (int i=0; i < dizi.Length; i++) {Console.Write (dizi [i] + " ");}
            Console.WriteLine ("\n");
        }
        static void Main() {
            Console.Write ("Fonksiyon de�i�ken say�l� parametreleri, 'params' anahtarkelimeli dizi beyanl� yap�labilir. Bu beyan sonras� ba�ka parametre kullan�lamaz; ancak �ncesinde kullan�labilir. Nesnel tiplemeyle her tip veri g�nderilebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            ParamsDizi p = new ParamsDizi();
            p.G�ster1 (0, 2,4,6,8,10,12,14);
            p.G�ster1 (1,3,5,7,9);
            p.G�ster1 (2023-1923);

            p.G�ster2 ("M.Nihat Yava�", "Malatya", 1.70, 60, "Han�m", 'B', false);
            p.G�ster2 ("Sevim Yava�", "Malatya", "Memet", true, 2023-1963);

            p.G�ster3 ("Hilal G�kt�rk", "G�nd�zbey", "Sefer", 2023-1985, 1.75, 55, "Fizik-Tedavi Doktoru");
            p.G�ster3 ("Bekir Yava�", "M�teveffa", "Ye�ilyurt", 2023-1973, 1973-1889);

            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}