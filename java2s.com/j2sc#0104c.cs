// j2sc#0104c.cs: Int tip gerid�n��l� Main metod �rne�i.

using System;
namespace DilTemelleri {
    class MainMetodu3 {
        public static int Main (string[] args) {
            Console.Write ("Main() metod void tipsiz yerine gerid�n�� yap�lacak int tipli de olabilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int i=0; foreach (string arg in args) Console.WriteLine ("Arg�man no.{0} = [{1}]", ++i, arg);
            return args.Length;
        }
    } 
}