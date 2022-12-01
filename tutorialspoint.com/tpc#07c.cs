// tpc#07c.cs: Konsoldan girilen dizgenin sayýya çevrilmesi örneði.

using System;
namespace Deðiþkenler {
    class KonsolVeriGiriþi {
        static void Main (string[] args) {
            int dyýl, ayýl, yaþ;
            Console.Write ("Doðum yýlýnýzý girin [yyyy] Ent: "); dyýl = Convert.ToInt32 (Console.ReadLine());
            Console.Write ("Aktüel yýlý girin [yyyy] Ent: "); ayýl = Convert.ToInt32 (Console.ReadLine());

            yaþ = ayýl - dyýl;
            Console.Write ("\n\nYaþýnýz: {0}\nTuþ...", yaþ);
            Console.ReadKey();
        }
    }
}