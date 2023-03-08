// jtpc#2305j.cs: S�zl�k koleksiyon anahtar-de�er kay�tlar�n� ilkde�erleme �rne�i.

using System;
using System.Collections.Generic;
namespace Yeni�zellikler {
    class ��renci {
        public int No {get; set;}
        public string Ad {get; set;}
        public string Eposta {get; set;}
    }
    class S�zl�k�lkde�erleme {
        static void Main() {
            Console.Write ("S�zl�k/Dictionary anahtar-de�er �iftli verili koleksiyondur. �lkde�erleme 'new Dictionary(){}' ile yap�l�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var s�zl�k = new Dictionary<int, string>();
            s�zl�k.Add (1001, "Hatice Yava�");
            s�zl�k.Add (2053, "Memet Yava�");
            s�zl�k.Add (3009, "Bekir Yava�");
            foreach (KeyValuePair<int, string> kay�t in s�zl�k) {Console.WriteLine ("{Anahtar=" + kay�t.Key + ", De�er=" + kay�t.Value + "}");}

            var ��r = new Dictionary<int, ��renci>() {
                {3, new ��renci() {No = 3010, Ad = "Fatma Yava�", Eposta = "fayavas@misal.com"} },
                {2, new ��renci() {No = 2055, Ad = "Han�m Yava�", Eposta = "hayavas@misal.com"} },
                {1, new ��renci() {No = 1007, Ad = "Sevim Yava�", Eposta = "seyavas@misal.com"} }
            }; Console.WriteLine();
            foreach (KeyValuePair<int, ��renci> k in ��r) {Console.WriteLine ("{Anahtar=" + k.Key + ", De�er={" + k.Value.No + ", " + k.Value.Ad + ", " + k.Value.Eposta + "} }");}

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}