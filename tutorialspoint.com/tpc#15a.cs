// tpc#15a.cs: For d�ng�s�yle i�lenen tamsay� dizi �rne�i.

using System;
namespace Diziler {
    class ForD�ng�l�Dizi {
        static void Main (string[] args) {
            Console.Write ("Dizi beyan�: 'veriTipi[] diziAd�'.\n\n�rnek beyanlar:\ndouble[] bakiye;\ndouble[] bakiye = new double[10];\nbakiye[0] = 4500.50;\ndouble[] bakiye = {2340.0, 4523.69, 3421.0};\nint [] notlar = new int[5] {99, 98, 92, 97, 95};\nint [] notlar = new int[] {99, 98, 92, 97, 95}; int[] skor = notlar;==>Ayn� belle�i g�r�rler\ndouble netMaa� = bakiye[9];\nEnter..."); Console.ReadLine();

            int[] n = new int[10]; // n, 10 tamsay�l� bir dizidir
            int i,j;
            for (i = 0; i < 10; i++) {n [i] = i + 100;} // �lk de�er atama
            for (j = 0; j < 10; j++ ) {Console.WriteLine ("Eleman [{0}] = {1}", j, n [j]);} // ��kt�

            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}