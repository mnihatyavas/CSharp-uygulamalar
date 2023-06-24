// j2sc#0205.cs: 'int[] tsDizi' deðerlerine endeksle eriþim örneði.

using System;
namespace VeriTipleri {
    class TamsayýDizi {
        static int EnbüyükDeðer (int[] tsDizi) {
            int enbüyük = tsDizi [0];
            for (int i = 1; i < tsDizi.Length; i++) {if (tsDizi [i] > enbüyük) enbüyük = tsDizi [i];}
            return enbüyük;
        }
        static int EnküçükDeðer (int[] tsDizi) {
            int enküçük = tsDizi [0];
            for (int i = 1; i < tsDizi.Length; i++) {if (tsDizi [i] < enküçük) enküçük = tsDizi [i];}
            return enküçük;
        }
        static void Main() {
            Console.Write ("Tamsayý dizi elemanlarý, endeks [0, Length-1] taranarak eriþilir. Dizi uzunluðu ayný adla 'new int[]' ile yeni dizi yaratýmlarýnda deðiþebilir. Diziyi doðrudan {} ile ilkdeðerli yaratabilmek için dizi adýnda öncelikle 'int[]' kullanýlmalýdýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int[] tsDizi = new int [10];
            int diziUzunluk = tsDizi.Length;
            Console.WriteLine ("Tamsayý dizi uzunluðu = " + diziUzunluk);
            for (int endeks = 0; endeks < diziUzunluk; endeks++) {
                tsDizi [endeks] = endeks * 2;
                Console.WriteLine ("tsDizi [{0}] = {1}", endeks, tsDizi [endeks]);
            }

            var r=new Random();
            tsDizi = new int [5] {r.Next (0, 100), r.Next (0, 100), r.Next (0, 100), r.Next (0, 100), r.Next (0, 100)};
            Console.WriteLine ("\nTamsayý dizi uzunluðu = " + (diziUzunluk=tsDizi.Length));
            for (int i = 0; i < diziUzunluk; i++) {Console.WriteLine ("tsDizi [{0}] = {1}", i, tsDizi [i]);}

            int[] tsDizi2 = {r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000), r.Next (-1000, 1000)};
            Console.WriteLine ("\nforeach (int ts in tsDizi2):");
            foreach (int ts in tsDizi2) {Console.WriteLine ("ts in tsDizi2 = " + ts);}

            Console.WriteLine ("\ntsDizi2 (enküçük, enbüyük) = ({0}, {1})", EnküçükDeðer (tsDizi2), EnbüyükDeðer (tsDizi2));

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}