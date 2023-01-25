// jtpc#0501.cs: Tekboyutlu bir dizinin çeþitli tanýmlanma ve ilkdeðer atanma örneði.

using System;
namespace Diziler {
    class Dizi {
        static void Main() {
            Console.Write ("Dizi sabit ebatlý, hepsi ayný tipli elemanlardan oluþur. Üç çeþit dizi vardýr: Tekboyutlu, çokboyutlu, çentikli. Dizi tanýmlanýrken ilkdeðer atamalarý ebatlý, ebatsýz veya new-int'siz yapýlabilir. foreach döngüsü dizi elemanlarýný, ebat belirtmeden dökümleyebilir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] dizi1 = new int [5]; Random r = new Random();
            for (int i=0; i < dizi1.Length; i++) dizi1 [i] = r.Next (0, 1000);
            for (int i=0; i < dizi1.Length; i++) Console.WriteLine ("{0}.inci rasgele [0,1000] sayý = {1}", i+1, dizi1 [i]);

            Console.WriteLine();
            int[] dizi2a = new int [5] {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2b = new int[] {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            int[] dizi2c = {r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000), r.Next (0, 1000)};
            for (int i=0; i < dizi2c.Length; i++) Console.WriteLine ("1, 2 ve 3.üncü dizilerin {0}.inci rasgele [0,1000] sayýlarý = [{1}, {2}, {3}]", i+1, dizi2a [i], dizi2b [i], dizi2c [i]);

            Console.WriteLine(); int j=1;
            foreach (int eleman in dizi1) Console.WriteLine ("{0}.inci rasgele [0,1000] sayý = {1}", j++, eleman);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}