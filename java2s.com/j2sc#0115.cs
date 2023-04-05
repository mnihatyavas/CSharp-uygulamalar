// j2sc#0115.cs: Metod parametre uzunluðunu 'params object[]' ile deðiþebilir kýlma örneði.

using System;
namespace DilTemelleri {
    class DeðiþirUzunluktaParametreler {
        public static int i=0;
        // 2 argümanlý Yaz, deðiþir "params" argümanlý Yaz ve tek dizge yazan DizgeyiYaz metotlarý
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
        public static void DizgeyiYaz (string dizge) {Console.WriteLine ("{0}.inci argüman: {1}", ++i, dizge);}
        static int Topla (params int[] sayýlar) {
            int toplam = 0; i=0;
            foreach (int sayý in sayýlar) {toplam += sayý; ++i;}
            return toplam;
        }
        static void Main() {
            Console.Write ("Metod parametreleri 'params object[]' ile deðiþken sayýda gönderilip, 'foreach' döngüsüyle tek tek iþlenebilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Yaz ("A", "B"); //2 argümanlý Yaz
            Yaz ("A", "B", "C", 12, 14.2); //"params" argümanlý Yaz
            object[] dizi1 = new object [4];
            dizi1 [0] = "A"; dizi1 [1] = "B"; dizi1 [2] = "C"; dizi1 [3] = 42;
            Yaz ("AAA", dizi1); //"params" argümanlý Yaz
            object[] dizi2 = new object[] {"Nihat", "Nihal", 2023, Math.PI, Math.E, 1938-1881, true};
            Yaz ("Hatice", dizi2); //"params" argümanlý Yaz

            Console.WriteLine ("\nToplamý [{0}] olan tamsayýlý argüman sayýsý [{1}] adettir.", Topla (1, 5, 2, 9, 8), i);
            var r=new Random(); Console.WriteLine ("Toplamý [{0}] olan tamsayýlý argüman sayýsý [{1}] adettir.", Topla (r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), r.Next (0,1000)), i);
            Console.WriteLine ("Toplamý [{0}] olan tamsayýlý argüman sayýsý [{1}] adettir.", Topla (2023-1951, r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), r.Next (0,1000), 1938-1881), i);
            int n=r.Next (2, 100);
            var dizi3=new int [n]; for (int j=0; j < n; j++) dizi3 [j]=r.Next (1, 200);
            Console.WriteLine ("Toplamý [{0}] olan tamsayýlý argüman sayýsý [{1}] adettir.", Topla (dizi3), i);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}