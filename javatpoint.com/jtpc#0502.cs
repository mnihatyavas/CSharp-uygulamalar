// jtpc#0502.cs: Diziyi fonksiyonlara g�nderip d�k�mleme ve en-k���k/b�y�k eleman�n� bulma �rne�i.

using System;
namespace Diziler {
    class DizidenFonksiyona {
        static void diziyiD�k�mle (int[] d) {
            Console.WriteLine ("Dizi elemanlar� d�k�mleniyor:");
            for (int i = 0; i < d.Length; i++) Console.WriteLine (d [i]);  
        }
        static void enk�����Bul (int[] d) {
            int enk���k = d [0], endeks = 0;  
            for (int i = 1; i < d.Length; i++) {if (enk���k > d [i]) {enk���k = d [i]; endeks = i;} }  
            Console.WriteLine ("Dizinin enk���k eleman� ve endeksi =  [{0}, {1}]", enk���k, endeks);
        }
        static void enb�y���Bul (int[] d) {
            int enb�y�k = d [0], endeks = 0;  
            for (int i = 1; i < d.Length; i++) {if (enb�y�k < d [i]) {enb�y�k = d [i]; endeks = i;} }  
            Console.WriteLine ("Dizinin enb�y�k eleman� ve endeksi =  [{0}, {1}]", enb�y�k, endeks);
        }
        static void Main() {
            Console.Write ("Fonksiyona dizi ge�irirken arg�man olarak yal�n diziad� kullan�lmal�d�r. Statik fonksiyon s�n�f�yla tiplenmeden do�rudan �a�r�labilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Random r = new Random();
            int[] dizi1 = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2 = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            diziyiD�k�mle (dizi1); enk�����Bul (dizi1); enb�y���Bul (dizi1);
            Console.WriteLine(); diziyiD�k�mle (dizi2); enk�����Bul (dizi2); enb�y���Bul (dizi2);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}