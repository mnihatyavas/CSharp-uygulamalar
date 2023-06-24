// j2sc#0205.cs: 'int[] tsDizi' de�erlerine endeksle eri�im �rne�i.

using System;
namespace VeriTipleri {
    class Tamsay�Dizi {
        static int Enb�y�kDe�er (int[] tsDizi) {
            int enb�y�k = tsDizi [0];
            for (int i = 1; i < tsDizi.Length; i++) {if (tsDizi [i] > enb�y�k) enb�y�k = tsDizi [i];}
            return enb�y�k;
        }
        static int Enk���kDe�er (int[] tsDizi) {
            int enk���k = tsDizi [0];
            for (int i = 1; i < tsDizi.Length; i++) {if (tsDizi [i] < enk���k) enk���k = tsDizi [i];}
            return enk���k;
        }
        static void Main() {
            Console.Write ("Tamsay� dizi elemanlar�, endeks [0, Length-1] taranarak eri�ilir. Dizi uzunlu�u ayn� adla 'new int[]' ile yeni dizi yarat�mlar�nda de�i�ebilir. Diziyi do�rudan {} ile ilkde�erli yaratabilmek i�in dizi ad�nda �ncelikle 'int[]' kullan�lmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int[] tsDizi = new int [10];
            int diziUzunluk = tsDizi.Length;
            Console.WriteLine ("Tamsay� dizi uzunlu�u = " + diziUzunluk);
            for (int endeks = 0; endeks < diziUzunluk; endeks++) {
                tsDizi [endeks] = endeks * 2;
                Console.WriteLine ("tsDizi [{0}] = {1}", endeks, tsDizi [endeks]);
            }

            var r=new Random();
            tsDizi = new int [5] {r.Next (0, 100), r.Next (0, 100), r.Next (0, 100), r.Next (0, 100), r.Next (0, 100)};
            Console.WriteLine ("\nTamsay� dizi uzunlu�u = " + (diziUzunluk=tsDizi.Length));
            for (int i = 0; i < diziUzunluk; i++) {Console.WriteLine ("tsDizi [{0}] = {1}", i, tsDizi [i]);}

            int[] tsDizi2 = {r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000)};
            Console.WriteLine ("\nforeach (int ts in tsDizi2):");
            foreach (int ts in tsDizi2) {Console.WriteLine ("ts in tsDizi2 = " + ts);}

            Console.WriteLine ("\ntsDizi2 (enk���k, enb�y�k) = ({0}, {1})", Enk���kDe�er (tsDizi2), Enb�y�kDe�er (tsDizi2));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}