// jtpc#2306j.cs: Metodun 'out' �nc�ll� arg�man ve parametreleriyle �oklu de�er aktar�m� �rne�i.

using System;
namespace Yeni�zellikler {
    class OutParametre {
        public void G�ster(int n, out float a, out int b, out int c) {a = (float)Math.Sqrt (n); b = n*n; c = n*n*n;}
        static void Main() {
            Console.Write ("Metodun �a��ran ve �a�r�lan arg�man-parametreleri �n�ne 'out' anahtarkelimesiyle return's�z �oklu de�er aktar�m� yap�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts, n2, n3; float n1;
            Gir: Console.Write ("Bir +tamsay� girin [-1: Son]: ");
            try {ts = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata.Message); goto Gir;}
            if (ts == -1 ) goto Son; if (ts < 0 ) goto Gir;
            new OutParametre().G�ster(ts, out n1, out n2, out n3);
            Console.WriteLine ("Girdi�iniz {0} tamsay�s�n�n karek�k�={1}, karesi={2} ve k�p�={3}\n", ts, n1, n2, n3); goto Gir;

            Son: Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}