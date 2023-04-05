// j2sc#0104b.cs: Main metod �e�itlemeleri �rne�i.

using System;
namespace DilTemelleri {
    class MainMetodu2 {
        public static void Main (string[] argDizi) {
            Console.Write ("Main() metod sat�r�nda kullan�lan anahtarkelimeler: public, static, void, int. Ayr�ca arg�mans�z yada arg�man alg�lamal� olabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");
/*
static void Main() {...}
static int Main() {...}
static void Main (string[] arg�manlarDizisi){...}
static int Main (string[] args){...}
public static int Main() {return (0);}
*/
            switch (argDizi.Length) {
                case (0): Console.WriteLine ("Komut sat�r�ndan arg�man girilmemi�"); break;
                case (1): if (argDizi [0][0] == '-') Console.WriteLine ("�lk arg�man '-' ile ba�l�yor."); break;
                case (2): if (argDizi [1][0] == '-') Console.WriteLine ("�kinci arg�man '-' ile ba�l�yor."); break;
                default: Console.WriteLine ("Komut sat�r�ndan 2'den fazla arg�man girilmi�"); break;
            }
            int i=0; foreach (string a in argDizi) Console.WriteLine ("{0}.nci arg�man = {1}", ++i, a);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}