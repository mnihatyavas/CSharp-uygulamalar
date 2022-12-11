// tpc#16b.cs: Dizgenin uzunluk ve tek krk özellikleri örneði.

using System;
namespace Dizgeler {
    class DizgeÖzellikleri {
        static void Main (string[] args) {
            string dizgem = "www.tutorialspoint.com'dan tüm herkese selamlar!";
            byte uz = Convert.ToByte (dizgem.Length);
            Console.WriteLine ("Mesaj: [{0}]\nUzunluðu: [{1}]\nÝlk krk: [{2}]\nOrtanca krk: [{3}]\nSon krk: [{4}]", dizgem, uz, dizgem [0], dizgem [Convert.ToByte (uz / 2)], dizgem [uz-1]);
            Console.Write ("Tuþ.."); Console.ReadKey();
        }
    }
}