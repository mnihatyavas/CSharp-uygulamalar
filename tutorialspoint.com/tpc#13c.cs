// tpc#13c.cs: Özyineli metodla faktöriyel hesabý örneði.

using System;
namespace Metodlar {
    class Faktöriyel {
        public long faktöriyel (int n) {
            long sonuç;
            if (n < 0 || n > 20) return 0; 
            if (n == 1 || n == 0) {return 1;
            }else {sonuç = faktöriyel (n - 1) * n; return sonuç;}
        }        
        static void Main (string[] args) {
            Console.Write ("Faktöriyel tamsayýsýný girin [Azami <= 20] Ent: "); int sayý = Convert.ToInt32 (Console.ReadLine());
            Faktöriyel F = new Faktöriyel();
            Console.Write ("{0} sayýsýnýn faktöriyeli: {1}\nTuþ...", sayý, F.faktöriyel (sayý));
            Console.ReadKey();            
        }
    }
}