// tpc#29b.cs: Eski yerine yeni metodun kullan�lmas�n� ikazlayan demode vasf� �rne�i.

using System;
namespace Vas�flar {
    class DemodeVas�f {
        [Obsolete ("�KAZ: EskiMetod() demode oldu, art�k yerine YeniMetod() kullan�lmal�", false)]
        static void EskiMetod() {Console.WriteLine ("EskiMetod() kullan�l�yor.");}
        static void YeniMetod() {Console.WriteLine ("YeniMetod() kullan�l�yor.");}
        static void Main() {
            Console.Write ("Obsolete vasf� 'true' olsayd�, EskiMetod() ikazl� �al��mak yerine, derleme hatas�yla exe yarat�lmayacakt�.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");
            /* tpc#29b.cs(14,13): error CS0619: 'Vas�flar.DemodeVas�f.EskiMetod()' is obsolete:
               '�KAZ: EskiMetod() demode oldu, art�k yerine YeniMetod() kullan�lmal�' */

            EskiMetod();

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}