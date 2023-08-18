// j2sc#0407.cs: Break ile döngülerin kapsam öncesi özel þart'la kýrýlmasý örneði.

using System;
namespace Ýfadeler {
    class Break {
        static void Main() {
            Console.Write ("Mevcut döngü dýþýna kýrmak için (þartlý) break kullanýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k;
            Console.WriteLine ("Break ile for döngüsünün yarýsýnda kýrýlmasý:");
            for (i=-20; i <= 20; i++) {
                if (i > 0) break; // i >= 1 ise kýrmak
                Console.Write (i + " ");
            } Console.WriteLine ("Tamam!");

            Console.WriteLine ("\nBreak ile for döngüsünün rasgele [0,10000] ilk enküçükbölen'inde kýrýlmasý:");
            var r=new Random(); j=r.Next (1, 10000);
            k = 1;
            for (i=2; i < j/2; i++) {// 7831%41=0
                if ((j%i) == 0) {k = i; break;}
            } Console.WriteLine ("{0} sayýsýnýn enküçükbölen'i = {1}", j, k);

            Console.WriteLine ("\nBreak ile içiçe-for_while'ýn iç while'de erken kýrýlmasý:");
            for (i=0; i<3; i++) {
                Console.WriteLine ("Dýþ for döngü sayacý: " + i);
                Console.Write ("\tÝç while döngü sayacý: ");
                k = 0;
                while (k < 10000) {
                    if (k == 10) break;
                    Console.Write (k + " ");
                    k++;
                } Console.WriteLine();
            }
            Console.WriteLine ("For-while döngüleri tamamlandý.");

            Console.WriteLine ("\nBreak ile foreach döngüsünün tesadüfi erken kýrýlmasý:");
            k = 0;
            int[] tsDizi = new int [100];
            j=r.Next (1, 100);
            for (i = 0; i < 100; i++) tsDizi [i] = r.Next (0, 1000);
            i=0;
            Console.Write ("Toplanacak sayýlar: ");
            foreach (int x in tsDizi) {
                Console.Write (x + " ");
                k +=x; i++;
                if (i == j) break;
            } Console.WriteLine ("\n{0}/100 adet rasgele sayýnýn toplamý = {1}", j, k);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}