// j2sc#0104a.cs: Programýn giriþ noktasý olan Main() metod örneði.

using System;
namespace DilTemelleri {
    class MainMetodu1 {
        public static void Main (string[] argümanlar) {
            Console.Write ("Main() metod programý baþlatandýr; bulunmazsa program çalýþmaz. Argümansýz: Main(), yada dizgesel dizili argümanlý: Main (string[] argümanlarDizisi) þeklinde olabilir. Komut satýrý argümanlarýnýn herbiri ya tek/çift-týrnaklar arasýnda yada boþluk ayraçlý kabul edilir. Genelde ana metod geridönüþsüz (void) iken tipli geridönüþlü de (int) olabilir. Normalen statikdir (tiplemesiz doðrudan çalýþýr).\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Komut satýrýndan argümanlar girmeyi deneyin!");
            foreach (string argüman in argümanlar) Console.WriteLine ("Argüman: {0}", argüman);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}