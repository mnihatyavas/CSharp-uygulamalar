// tpc#16b.cs: Dizgenin uzunluk ve tek krk �zellikleri �rne�i.

using System;
namespace Dizgeler {
    class Dizge�zellikleri {
        static void Main (string[] args) {
            string dizgem = "www.tutorialspoint.com'dan t�m herkese selamlar!";
            byte uz = Convert.ToByte (dizgem.Length);
            Console.WriteLine ("Mesaj: [{0}]\nUzunlu�u: [{1}]\n�lk krk: [{2}]\nOrtanca krk: [{3}]\nSon krk: [{4}]", dizgem, uz, dizgem [0], dizgem [Convert.ToByte (uz / 2)], dizgem [uz-1]);
            Console.Write ("Tu�.."); Console.ReadKey();
        }
    }
}