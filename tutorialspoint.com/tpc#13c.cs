// tpc#13c.cs: �zyineli metodla fakt�riyel hesab� �rne�i.

using System;
namespace Metodlar {
    class Fakt�riyel {
        public long fakt�riyel (int n) {
            long sonu�;
            if (n < 0 || n > 20) return 0; 
            if (n == 1 || n == 0) {return 1;
            }else {sonu� = fakt�riyel (n - 1) * n; return sonu�;}
        }        
        static void Main (string[] args) {
            Console.Write ("Fakt�riyel tamsay�s�n� girin [Azami <= 20] Ent: "); int say� = Convert.ToInt32 (Console.ReadLine());
            Fakt�riyel F = new Fakt�riyel();
            Console.Write ("{0} say�s�n�n fakt�riyeli: {1}\nTu�...", say�, F.fakt�riyel (say�));
            Console.ReadKey();            
        }
    }
}