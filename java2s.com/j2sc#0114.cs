// j2sc#0114.cs: Metod argümanlarýnýn tek-yönlü deðer olarak dönderilmesi örneði.

using System;
namespace DilTemelleri {
    class Þahýs {
        public string isim;
        public int yaþ;
        public Þahýs (string i, int y) {isim = i; yaþ = y;}
        public void göster() {Console.WriteLine ("{0} {1} yaþýndadýr.", isim, yaþ);}
    }
    class Kontrol {
        public void ArgümanDeðiþmez (int i, int j) {i = i + j; j = -j;}
        public void ArgümanDeðiþir (ref int i, ref int j) {i = j - i; j = 2023 - j;}
    }
    class ParametreDeðeri {
        public static void þahýsNesnesi1 (Þahýs þ) {þ.yaþ = 99;}
        public static void þahýsNesnesi2 (Þahýs þ) {þ.isim = "Memet Yavaþ";}
        static void Main() {
            Console.Write ("Sýnýf tiplemesine deðiþken deðeri yanýsýra, tiplenen nesne deðeri de gönderilebilir. Parametre deðerleri ancak out/ref'lerde deðiþir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var kiþi = new Þahýs ("M.Nihat Yavaþ", 2023-1957); kiþi.göster();
            þahýsNesnesi1 (kiþi);  kiþi.göster();
            þahýsNesnesi2 (kiþi);  kiþi.göster();

            var kontrol = new Kontrol();
            int a = 1881, b = 1938;
            Console.WriteLine ("\nMetod çaðýrmadan önce (a, b) = ({0}, {1})", a, b);
            kontrol.ArgümanDeðiþmez (a, b); Console.WriteLine ("ArgümanDeðiþmez metodunu çaðýrdýktan sonra (a, b) = ({0}, {1})", a, b);
            kontrol.ArgümanDeðiþir (ref a, ref b); Console.WriteLine ("ArgümanDeðiþir metodunu çaðýrdýktan sonra (a, b) = ({0}, {1})", a, b);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}