// tpc#29b.cs: Eski yerine yeni metodun kullanýlmasýný ikazlayan demode vasfý örneði.

using System;
namespace Vasýflar {
    class DemodeVasýf {
        [Obsolete ("ÝKAZ: EskiMetod() demode oldu, artýk yerine YeniMetod() kullanýlmalý", false)]
        static void EskiMetod() {Console.WriteLine ("EskiMetod() kullanýlýyor.");}
        static void YeniMetod() {Console.WriteLine ("YeniMetod() kullanýlýyor.");}
        static void Main() {
            Console.Write ("Obsolete vasfý 'true' olsaydý, EskiMetod() ikazlý çalýþmak yerine, derleme hatasýyla exe yaratýlmayacaktý.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");
            /* tpc#29b.cs(14,13): error CS0619: 'Vasýflar.DemodeVasýf.EskiMetod()' is obsolete:
               'ÝKAZ: EskiMetod() demode oldu, artýk yerine YeniMetod() kullanýlmalý' */

            EskiMetod();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}