// j2sc#0104c.cs: Int tip geridönüþlü Main metod örneði.

using System;
namespace DilTemelleri {
    class MainMetodu3 {
        public static int Main (string[] args) {
            Console.Write ("Main() metod void tipsiz yerine geridönüþ yapýlacak int tipli de olabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            int i=0; foreach (string arg in args) Console.WriteLine ("Argüman no.{0} = [{1}]", ++i, arg);
            return args.Length;
        }
    } 
}