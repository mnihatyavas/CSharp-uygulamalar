// jtpc#230205.cs: "var" anahtarkelimeli ilkdeðerlemeyle tiplenen deðiþkenler tanýmlama örneði.

using System;
namespace YeniÖzellikler {
    class ÖrtükTipler {
        static void Main() {
            Console.Write ("'var' anahtarkelimesiyle, ilkdeðerle atanan verilere göre tiplenen deðiþkenler tanýmlanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var ts = 2023; var fs = 3.14f; var ds = (double)Math.PI; var krk = 'M'; var dizge = "M.Nihat Yavaþ"; var b = true;
            var dizi = new[]{2023, 1881, 1938, 1923};
            var tarih = DateTime.Now;
            Console.WriteLine ("var'la ilk atanana verilerle tiplenen deðiþkenler:\n{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}", ts, fs, ds, krk, dizge, b, dizi [3], tarih);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}