// jtpc#0506.cs: Dizi kopyalama, s�ralama, tersleme ve d�k�mleme �rne�i.

using System;
namespace Diziler {
    class DiziS�n�f� {
        static void DiziyiYaz (int[] dizi) {foreach (Object eleman in dizi) Console.Write (eleman + " ");}  
        static void Main() {
            Console.Write ("Array s�n�f �zellikleri: IsFixedSize, IsReadOnly, IsSynchronized, Length, LongLength, Rank, SyncRoot.\nMetodlar�: AsReadOnly<T>(T[]), BinarySearch(Array,Int32,Int32,Object), BinarySearch(Array,Object), Clear(Array,Int32,Int32), Clone(), Copy(Array,Array,Int32), CopyTo(Array,Int32), CreateInstance(Type,Int32), Empty<T>(), Finalize(), Find<T>(T[],Predicate<T>), IndexOf(Array,Object), Initialize(), Reverse(Array), Sort(Array), ToString().\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int[] dizi1 = new int[6] {5, 8, 9, -25, 0, 7}; // Dizi yarat ve ilkde�erle
            int[] dizi2 = new int[6]; // Bo� dizi yarat
            Console.WriteLine ("�lk dizinin ebat�: " + dizi1.Length);
            Console.Write ("�lk dizinin elemanlar�: "); DiziyiYaz (dizi1);
            Console.WriteLine ("\nEleman 9'un endeksi: " + Array.IndexOf (dizi1, 9));
            Array.Sort (dizi1); // Diziyi artan s�rala
            Console.Write ("�lk ARTAN s�ral� dizinin elemanlar�: "); DiziyiYaz (dizi1);
            Array.Copy (dizi1, dizi2, dizi1.Length); // Tam ebatla diziyi kopyala
            Console.Write ("\n�kinci (kopyalanan) dizinin elemanlar�: "); DiziyiYaz (dizi2);
            Array.Reverse (dizi1); // �lk (artan s�ral�) diziyi tersle
            Console.Write ("\n�lk AZALAN s�ral� dizinin elemanlar�: ");  DiziyiYaz (dizi1);

            Console.Write ("\n\nTu�.."); Console.ReadKey();
        }
    }
}