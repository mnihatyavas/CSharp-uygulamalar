// jtpc#0506.cs: Dizi kopyalama, sýralama, tersleme ve dökümleme örneði.

using System;
namespace Diziler {
    class DiziSýnýfý {
        static void DiziyiYaz (int[] dizi) {foreach (Object eleman in dizi) Console.Write (eleman + " ");}  
        static void Main() {
            Console.Write ("Array sýnýf özellikleri: IsFixedSize, IsReadOnly, IsSynchronized, Length, LongLength, Rank, SyncRoot.\nMetodlarý: AsReadOnly<T>(T[]), BinarySearch(Array,Int32,Int32,Object), BinarySearch(Array,Object), Clear(Array,Int32,Int32), Clone(), Copy(Array,Array,Int32), CopyTo(Array,Int32), CreateInstance(Type,Int32), Empty<T>(), Finalize(), Find<T>(T[],Predicate<T>), IndexOf(Array,Object), Initialize(), Reverse(Array), Sort(Array), ToString().\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] dizi1 = new int[6] {5, 8, 9, -25, 0, 7}; // Dizi yarat ve ilkdeðerle
            int[] dizi2 = new int[6]; // Boþ dizi yarat
            Console.WriteLine ("Ýlk dizinin ebatý: " + dizi1.Length);
            Console.Write ("Ýlk dizinin elemanlarý: "); DiziyiYaz (dizi1);
            Console.WriteLine ("\nEleman 9'un endeksi: " + Array.IndexOf (dizi1, 9));
            Array.Sort (dizi1); // Diziyi artan sýrala
            Console.Write ("Ýlk ARTAN sýralý dizinin elemanlarý: "); DiziyiYaz (dizi1);
            Array.Copy (dizi1, dizi2, dizi1.Length); // Tam ebatla diziyi kopyala
            Console.Write ("\nÝkinci (kopyalanan) dizinin elemanlarý: "); DiziyiYaz (dizi2);
            Array.Reverse (dizi1); // Ýlk (artan sýralý) diziyi tersle
            Console.Write ("\nÝlk AZALAN sýralý dizinin elemanlarý: ");  DiziyiYaz (dizi1);

            Console.Write ("\n\nTuþ.."); Console.ReadKey();
        }
    }
}