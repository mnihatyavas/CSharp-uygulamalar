// tpc#14a.cs: De�i�kene tipe uygun de�er veya null atanabilme �rne�i.

using System;
namespace Hi�lenebilenler {
    class NullAtama {
        static void Main (string[] args) {
            Console.Write ("Hi�lenebilen de�i�kene tipe uygun de�er yada null atanabilir.\nGenel s�zdizim: '<veriTipi> ? <de�i�kenAd�> = de�er/null'.\nTu�..."); Console.ReadKey();

            int? kilo = null;
            int? ya� = 65;
            double? maa� = new double?();
            double? giderler = 3580.57;
            bool? medeniDurum = new bool?();

            Console.WriteLine ("\nHi�lenebilen kilo, ya�, maa� ve giderler: [{0}, {1}, {2}, {3}]", kilo, ya�, maa�, giderler);
            Console.Write ("Hi�lenebilen medeni-durum: [{0}]\nTu�...", medeniDurum); Console.ReadKey();
        }
    }
}