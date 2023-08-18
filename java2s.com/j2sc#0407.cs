// j2sc#0407.cs: Break ile d�ng�lerin kapsam �ncesi �zel �art'la k�r�lmas� �rne�i.

using System;
namespace �fadeler {
    class Break {
        static void Main() {
            Console.Write ("Mevcut d�ng� d���na k�rmak i�in (�artl�) break kullan�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i, j, k;
            Console.WriteLine ("Break ile for d�ng�s�n�n yar�s�nda k�r�lmas�:");
            for (i=-20; i <= 20; i++) {
                if (i > 0) break; // i >= 1 ise k�rmak
                Console.Write (i + " ");
            } Console.WriteLine ("Tamam!");

            Console.WriteLine ("\nBreak ile for d�ng�s�n�n rasgele [0,10000] ilk enk���kb�len'inde k�r�lmas�:");
            var r=new Random(); j=r.Next (1, 10000);
            k = 1;
            for (i=2; i < j/2; i++) {// 7831%41=0
                if ((j%i) == 0) {k = i; break;}
            } Console.WriteLine ("{0} say�s�n�n enk���kb�len'i = {1}", j, k);

            Console.WriteLine ("\nBreak ile i�i�e-for_while'�n i� while'de erken k�r�lmas�:");
            for (i=0; i<3; i++) {
                Console.WriteLine ("D�� for d�ng� sayac�: " + i);
                Console.Write ("\t�� while d�ng� sayac�: ");
                k = 0;
                while (k < 10000) {
                    if (k == 10) break;
                    Console.Write (k + " ");
                    k++;
                } Console.WriteLine();
            }
            Console.WriteLine ("For-while d�ng�leri tamamland�.");

            Console.WriteLine ("\nBreak ile foreach d�ng�s�n�n tesad�fi erken k�r�lmas�:");
            k = 0;
            int[] tsDizi = new int [100];
            j=r.Next (1, 100);
            for (i = 0; i < 100; i++) tsDizi [i] = r.Next (0, 1000);
            i=0;
            Console.Write ("Toplanacak say�lar: ");
            foreach (int x in tsDizi) {
                Console.Write (x + " ");
                k +=x; i++;
                if (i == j) break;
            } Console.WriteLine ("\n{0}/100 adet rasgele say�n�n toplam� = {1}", j, k);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}