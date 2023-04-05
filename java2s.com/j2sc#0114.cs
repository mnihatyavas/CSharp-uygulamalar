// j2sc#0114.cs: Metod arg�manlar�n�n tek-y�nl� de�er olarak d�nderilmesi �rne�i.

using System;
namespace DilTemelleri {
    class �ah�s {
        public string isim;
        public int ya�;
        public �ah�s (string i, int y) {isim = i; ya� = y;}
        public void g�ster() {Console.WriteLine ("{0} {1} ya��ndad�r.", isim, ya�);}
    }
    class Kontrol {
        public void Arg�manDe�i�mez (int i, int j) {i = i + j; j = -j;}
        public void Arg�manDe�i�ir (ref int i, ref int j) {i = j - i; j = 2023 - j;}
    }
    class ParametreDe�eri {
        public static void �ah�sNesnesi1 (�ah�s �) {�.ya� = 99;}
        public static void �ah�sNesnesi2 (�ah�s �) {�.isim = "Memet Yava�";}
        static void Main() {
            Console.Write ("S�n�f tiplemesine de�i�ken de�eri yan�s�ra, tiplenen nesne de�eri de g�nderilebilir. Parametre de�erleri ancak out/ref'lerde de�i�ir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ki�i = new �ah�s ("M.Nihat Yava�", 2023-1957); ki�i.g�ster();
            �ah�sNesnesi1 (ki�i);  ki�i.g�ster();
            �ah�sNesnesi2 (ki�i);  ki�i.g�ster();

            var kontrol = new Kontrol();
            int a = 1881, b = 1938;
            Console.WriteLine ("\nMetod �a��rmadan �nce (a, b) = ({0}, {1})", a, b);
            kontrol.Arg�manDe�i�mez (a, b); Console.WriteLine ("Arg�manDe�i�mez metodunu �a��rd�ktan sonra (a, b) = ({0}, {1})", a, b);
            kontrol.Arg�manDe�i�ir (ref a, ref b); Console.WriteLine ("Arg�manDe�i�ir metodunu �a��rd�ktan sonra (a, b) = ({0}, {1})", a, b);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}