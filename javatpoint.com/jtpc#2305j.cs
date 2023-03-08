// jtpc#2305j.cs: Sözlük koleksiyon anahtar-deðer kayýtlarýný ilkdeðerleme örneði.

using System;
using System.Collections.Generic;
namespace YeniÖzellikler {
    class Öðrenci {
        public int No {get; set;}
        public string Ad {get; set;}
        public string Eposta {get; set;}
    }
    class SözlükÝlkdeðerleme {
        static void Main() {
            Console.Write ("Sözlük/Dictionary anahtar-deðer çiftli verili koleksiyondur. Ýlkdeðerleme 'new Dictionary(){}' ile yapýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var sözlük = new Dictionary<int, string>();
            sözlük.Add (1001, "Hatice Yavaþ");
            sözlük.Add (2053, "Memet Yavaþ");
            sözlük.Add (3009, "Bekir Yavaþ");
            foreach (KeyValuePair<int, string> kayýt in sözlük) {Console.WriteLine ("{Anahtar=" + kayýt.Key + ", Deðer=" + kayýt.Value + "}");}

            var öðr = new Dictionary<int, Öðrenci>() {
                {3, new Öðrenci() {No = 3010, Ad = "Fatma Yavaþ", Eposta = "fayavas@misal.com"} },
                {2, new Öðrenci() {No = 2055, Ad = "Haným Yavaþ", Eposta = "hayavas@misal.com"} },
                {1, new Öðrenci() {No = 1007, Ad = "Sevim Yavaþ", Eposta = "seyavas@misal.com"} }
            }; Console.WriteLine();
            foreach (KeyValuePair<int, Öðrenci> k in öðr) {Console.WriteLine ("{Anahtar=" + k.Key + ", Deðer={" + k.Value.No + ", " + k.Value.Ad + ", " + k.Value.Eposta + "} }");}

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}