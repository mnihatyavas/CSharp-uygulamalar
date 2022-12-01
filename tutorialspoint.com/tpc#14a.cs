// tpc#14a.cs: Deðiþkene tipe uygun deðer veya null atanabilme örneði.

using System;
namespace Hiçlenebilenler {
    class NullAtama {
        static void Main (string[] args) {
            Console.Write ("Hiçlenebilen deðiþkene tipe uygun deðer yada null atanabilir.\nGenel sözdizim: '<veriTipi> ? <deðiþkenAdý> = deðer/null'.\nTuþ..."); Console.ReadKey();

            int? kilo = null;
            int? yaþ = 65;
            double? maaþ = new double?();
            double? giderler = 3580.57;
            bool? medeniDurum = new bool?();

            Console.WriteLine ("\nHiçlenebilen kilo, yaþ, maaþ ve giderler: [{0}, {1}, {2}, {3}]", kilo, yaþ, maaþ, giderler);
            Console.Write ("Hiçlenebilen medeni-durum: [{0}]\nTuþ...", medeniDurum); Console.ReadKey();
        }
    }
}