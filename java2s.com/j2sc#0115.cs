// j2sc#0115.cs: Metod parametre uzunlu�unu 'params object[]' ile de�i�ebilir k�lma �rne�i.

using System;
namespace DilTemelleri {
    class De�i�irUzunluktaParametreler {
        public static int i=0;
        // 2 arg�manl� Yaz, de�i�ir "params" arg�manl� Yaz ve tek dizge yazan DizgeyiYaz metotlar�
        public static void Yaz (string dizge, object nesne) {
            i=0;
            DizgeyiYaz (dizge);
            DizgeyiYaz (nesne.ToString());
        }
        public static void Yaz (string dizge, params object[] nesneler){
            i=0; Console.WriteLine();
            DizgeyiYaz (dizge);
            foreach (object nesne in nesneler) {DizgeyiYaz (nesne.ToString());}
        }
        public static void DizgeyiYaz (string dizge) {Console.WriteLine ("{0}.inci arg�man: {1}", ++i, dizge);}
        static int Topla (params int[] say�lar) {
            int toplam = 0; i=0;
            foreach (int say� in say�lar) {toplam += say�; ++i;}
            return toplam;
        }
        static void Main() {
            Console.Write ("Metod parametreleri 'params object[]' ile de�i�ken say�da g�nderilip, 'foreach' d�ng�s�yle tek tek i�lenebilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Yaz ("A", "B"); //2 arg�manl� Yaz
            Yaz ("A", "B", "C", 12, 14.2); //"params" arg�manl� Yaz
            object[] dizi1 = new object [4];
            dizi1 [0] = "A"; dizi1 [1] = "B"; dizi1 [2] = "C"; dizi1 [3] = 42;
            Yaz ("AAA", dizi1); //"params" arg�manl� Yaz
            object[] dizi2 = new object[] {"Nihat", "Nihal", 2023, Math.PI, Math.E, 1938-1881, true};
            Yaz ("Hatice", dizi2); //"params" arg�manl� Yaz

            Console.WriteLine ("\nToplam� [{0}] olan tamsay�l� arg�man say�s� [{1}] adettir.", Topla (1, 5, 2, 9, 8), i);
            var r=new Random(); Console.WriteLine ("Toplam� [{0}] olan tamsay�l� arg�man say�s� [{1}] adettir.", Topla (r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), r.Next (0,1000)), i);
            Console.WriteLine ("Toplam� [{0}] olan tamsay�l� arg�man say�s� [{1}] adettir.", Topla (2023-1951, r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), 1938-1881), i);
            int n=r.Next (2, 100);
            var dizi3=new int [n]; for (int j=0; j < n; j++) dizi3 [j]=r.Next (1, 200);
            Console.WriteLine ("Toplam� [{0}] olan tamsay�l� arg�man say�s� [{1}] adettir.", Topla (dizi3), i);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}