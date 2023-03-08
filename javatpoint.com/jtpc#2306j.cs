// jtpc#2306j.cs: Metodun 'out' öncüllü argüman ve parametreleriyle çoklu deðer aktarýmý örneði.

using System;
namespace YeniÖzellikler {
    class OutParametre {
        public void Göster(int n, out float a, out int b, out int c) {a = (float)Math.Sqrt (n); b = n*n; c = n*n*n;}
        static void Main() {
            Console.Write ("Metodun çaðýran ve çaðrýlan argüman-parametreleri önüne 'out' anahtarkelimesiyle return'süz çoklu deðer aktarýmý yapýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n2, n3; float n1;
            Gir: Console.Write ("Bir +tamsayý girin [-1: Son]: ");
            try {ts = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            new OutParametre().Göster(ts, out n1, out n2, out n3);
            Console.WriteLine ("Girdiðiniz {0} tamsayýsýnýn karekökü={1}, karesi={2} ve küpü={3}\n", ts, n1, n2, n3); goto Gir;

            Son: Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}