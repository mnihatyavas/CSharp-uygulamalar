// j2sc#0405.cs: While(�art){ifade-ler} d�ng� �rne�i.

using System;
namespace �fadeler {
    class While {
        static void Main() {
            Console.Write ("While(�art){ifade-ler} ile �art true/do�ru kald��� s�rece d�ng� tekrarlar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("While d�ng�s�n�n ard���k [0, 100] say�lar�n� yans�tmas�:");
            int i = 0, j;
            while (i <= 100) Console.Write ("{0} ", i++);

            Console.WriteLine ("\n\nWhile d�ng�s�n�n rasgele int hane say�s�n� tespiti:");
            var r=new Random(); i=0; int ts1=r.Next (0, int.MaxValue);
            Console.WriteLine ("Rasgele int say� = " + ts1); 
            while (ts1 >= 1) {i++; ts1 /=10;};
            Console.WriteLine ("Hane adedi = " + i);

            long ls1; ts1=r.Next (0, 63);
            Console.WriteLine ("\n2^[0-->{0}] say�s�n�n i�i�e for-while d�ng�s�yle listelenmesi:", ts1); 
            for (i=0; i <= ts1; i++) {
                ls1 = 1;
                j = i;
                while (j-- > 0) ls1 *=2;
                Console.WriteLine ("2 ** " + i + " = " + ls1);
            }

            long ls2, ls3; i=r.Next (0, 92);
            Console.WriteLine ("\n[1, 1, 2, 3, 5,..-->{0} adet] fiboneki say�lar�n�n while d�ng�s�yle d�k�m�:", (i+1)); 
            ls1=ls2=1;
            Console.Write (ls2 + " ");
            while (i-- >= 1) {
                Console.Write (ls2 + " ");
                ls3 = ls2 + ls1;
                ls1 = ls2;
                ls2 = ls3;
            }

            Console.Write ("\n\nTu�..."); Console.ReadKey();
        }
    } 
}