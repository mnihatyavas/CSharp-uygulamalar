// jtpc#2305i.cs: 'nameof' i�lemciyle de�i�ken, metod ve s�n�f adlar�n� alma �rne�i.

using System;
namespace Yeni�zellikler {
    class Nameof��lemci {
        int[] dizi = new int[5];
        int G�ster (int[] d) {try {d [6] = 2023;}catch (Exception){}  return 0; }
        static void g�ster(){/* Kodlama */}
        static void Main() {
            Console.Write ("'nameof' i�lemcisi program ��kt�s�na de�i�ken, metod ve s�n�f adlar�n� yans�t�r; k�smen 'typeof' gibidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            string site = "www.javatpoint.com"; Console.WriteLine (site);
            //Console.WriteLine ("{0} adl� de�i�kenin tipi: {1}", nameof (site), typeof (site));
            //Console.WriteLine ("Metodun ad�:" + nameof (g�ster));

            var nesne = new Nameof��lemci();
            try {nesne.G�ster (nesne.dizi);
            }catch (Exception h) {
                Console.WriteLine ("HATA: " + h.Message);
                Console.WriteLine ("Hata f�rlatan metodun ad�: " + nesne.G�ster (nesne.dizi));
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}