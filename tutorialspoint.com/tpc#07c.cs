// tpc#07c.cs: Konsoldan girilen dizgenin say�ya �evrilmesi �rne�i.

using System;
namespace De�i�kenler {
    class KonsolVeriGiri�i {
        static void Main (string[] args) {
            int dy�l, ay�l, ya�;
            Console.Write ("Do�um y�l�n�z� girin [yyyy] Ent: "); dy�l = Convert.ToInt32 (Console.ReadLine());
            Console.Write ("Akt�el y�l� girin [yyyy] Ent: "); ay�l = Convert.ToInt32 (Console.ReadLine());

            ya� = ay�l - dy�l;
            Console.Write ("\n\nYa��n�z: {0}\nTu�...", ya�);
            Console.ReadKey();
        }
    }
}