// j2sc#0209.cs: Parse() metotla girilen dizgenin tamsay�ya ayr��t�r�lmas� �rne�i.

using System;
namespace VeriTipleri {
    class Tamsay�yaAyr��t�r {
        static void Main() {
            Console.Write ("Int32.Parse(), int.Parse() ve int.TryParse() metotlar�yla Console.ReadLine() dizgesel giri�ler tamsay�ya �evrilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            int ts = Int32.Parse ("2023"); Console.WriteLine ("Ayr��t�r�lan de�er: {0}", ts);
            ts = int.Parse ("1881"); Console.WriteLine ("Ayr��t�r�lan de�er: {0}", ts);

            Console.Write ("\nBir tamsay� gir [Ent]: ");
            while (! int.TryParse (Console.ReadLine(), out ts)) {Console.Write ("HATA: Tekrar deneyin [Ent]: ");}
            Console.WriteLine ("Girdi�iniz tamsay�: " + ts.ToString());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}