// jtpc#0501.cs: Tekboyutlu bir dizinin �e�itli tan�mlanma ve ilkde�er atanma �rne�i.

using System;
namespace Diziler {
    class Dizi {
        static void Main() {
            Console.Write ("Dizi sabit ebatl�, hepsi ayn� tipli elemanlardan olu�ur. �� �e�it dizi vard�r: Tekboyutlu, �okboyutlu, �entikli. Dizi tan�mlan�rken ilkde�er atamalar� ebatl�, ebats�z veya new-int'siz yap�labilir. foreach d�ng�s� dizi elemanlar�n�, ebat belirtmeden d�k�mleyebilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] dizi1 = new int [5]; Random r = new Random();
            for (int i=0; i < dizi1.Length; i++) dizi1 [i] = r.Next (0, 1000);
            for (int i=0; i < dizi1.Length; i++) Console.WriteLine ("{0}.inci rasgele [0,1000] say� = {1}", i+1, dizi1 [i]);

            Console.WriteLine();
            int[] dizi2a = new int [5] {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2b = new int[] {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2c = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            for (int i=0; i < dizi2c.Length; i++) Console.WriteLine ("1, 2 ve 3.�nc� dizilerin {0}.inci rasgele [0,1000] say�lar� = [{1}, {2}, {3}]", i+1, dizi2a [i], dizi2b [i], dizi2c [i]);

            Console.WriteLine(); int j=1;
            foreach (int eleman in dizi1) Console.WriteLine ("{0}.inci rasgele [0,1000] say� = {1}", j++, eleman);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}