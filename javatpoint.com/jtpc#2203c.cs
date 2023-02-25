// jtpc#2203c.cs: Verilen y�l�n ay g�nleri ve toplam y�l g�n� �rne�i.

using System;
namespace �e�itli {
    class TarihZamanC {
        static void Main() {
            Console.Write ("DateTime.DaysInMonth(2004,2) ile 28 gerid�n��� al�n�r. �stenen her y�l�n t�m ay g�nleri ve toplam y�l g�n� bulunabilir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            int y�l; Console.Write ("\nBir y�l gir [1,9999]: ");
            try {y�l = Convert.ToInt32 (Console.ReadLine());}catch (Exception hata) {Console.WriteLine ("HATA: [{0}]", hata); goto son;}
            int ayG�n�, toplamG�n = 0;
            for (int j = 1; j <= 12; j++) {
                //ayG�n� = DateTime.DaysInMonth (y�l, j);
                Console.WriteLine ("{0}.inci ay�n g�n say�s� = {1} g�n", j, (ayG�n� = DateTime.DaysInMonth (y�l, j)));
                toplamG�n +=ayG�n�;
            }
            Console.WriteLine ("\n{0} y�l�ndaki toplam g�n say�s� = {1} g�n", y�l, toplamG�n);

            son: Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}