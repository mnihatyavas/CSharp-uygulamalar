// j2sc#0505.cs: Concat metoduyla her t�r veriyi dizgesel ekleme �rne�i.

using System;
namespace Dizgeler {
    class DizgeselEkleme {
        static void Main() {
            Console.Write ("Concat i�i arg�manlar virg�ll� veya +'l� dizgesel veya say�sal eklenebilir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Concat i�i virg�llerle dizgeler ekleme:");
            string dizge1 = String.Concat ("Bu ", "bir ", "Concat ", "ekleme ","denemesi") + "dir." + " " + String.Concat ("Ard���k ", "eklemeler ", "m�mk�nd�r") + "."; 
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat i�i +'larla dizgeler ekleme:");
            dizge1 = String.Concat ("M." + "Nihat " + "Yavas, " + "Ya�: " + (2023 - 1957));
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat ile dizge, say�, bool ekleme:");
            dizge1 = String.Concat ("Merhaba ", 23, " Nisan ", 2023D, " ", false, " ",  20.00F, " ", 3.45M, " ", true); //M: decimal
            Console.WriteLine ("Concat'li dizge: " + dizge1);

            Console.WriteLine ("\nConcat ile say�y� ard���k dizgesel yada toplama say�sal ekleme:");
            int ts1 = 2023 - 2005;
            dizge1 = "Ya��n " + ts1 + " ha?";
            dizge1 += " M�thi�sin!..";
            Console.WriteLine ("Monolog: {0}", dizge1);
            dizge1  = 10 + 5 + " = 10 + 5\t2 + 3 = " + 2 + 3;
            Console.WriteLine ("Say�sal ve dizgesel toplama : {0}", dizge1);
            dizge1 = 10 + 5 + " = 10 + 5\t2 + 3 = " + (2 + 3);
            Console.WriteLine ("Say�sal ve say�sal toplama : {0}", dizge1);

            Console.WriteLine ("\nConcat ile dizgesel dizi elemanlar�n� do�rudan ekleme:");
            string[] dzgDizi = {"Merhaba ", "ve ", "ho�geldin ", "bu ", "t�mce ", "�rne�ine! "};
            Console.WriteLine ("Orijinal t�mce dizisi: \"{0}\"", string.Concat (dzgDizi));
            Array.Sort (dzgDizi);
            Console.WriteLine ("S�ral� t�mce dizisi: \"{0}\"", string.Concat (dzgDizi));

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}