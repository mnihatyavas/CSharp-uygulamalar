// j2sc#0104a.cs: Program�n giri� noktas� olan Main() metod �rne�i.

using System;
namespace DilTemelleri {
    class MainMetodu1 {
        public static void Main (string[] arg�manlar) {
            Console.Write ("Main() metod program� ba�latand�r; bulunmazsa program �al��maz. Arg�mans�z: Main(), yada dizgesel dizili arg�manl�: Main (string[] arg�manlarDizisi) �eklinde olabilir. Komut sat�r� arg�manlar�n�n herbiri ya tek/�ift-t�rnaklar aras�nda yada bo�luk ayra�l� kabul edilir. Genelde ana metod gerid�n��s�z (void) iken tipli gerid�n��l� de (int) olabilir. Normalen statikdir (tiplemesiz do�rudan �al���r).\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Komut sat�r�ndan arg�manlar girmeyi deneyin!");
            foreach (string arg�man in arg�manlar) Console.WriteLine ("Arg�man: {0}", arg�man);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}