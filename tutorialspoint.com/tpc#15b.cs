// tpc#15b.cs: ForEach d�ng�s�yle i�lenen tamsay� dizi �rne�i.

using System;
namespace Diziler {
    class ForEachD�ng�l�Dizi {
        static void Main (string[] args) {
            int[] n = new int[10]; // n, 10 tamsay�l� bir dizidir
            for (int i = 0; i < 10; i++) {n [i] = i + 100;} // �lk de�er atama
            foreach (int j in n ) {int i = j - 100; Console.WriteLine ("Eleman [{0}] = {1}", i, j);} // ��kt�

            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}