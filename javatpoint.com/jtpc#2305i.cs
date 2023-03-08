// jtpc#2305i.cs: 'nameof' iþlemciyle deðiþken, metod ve sýnýf adlarýný alma örneði.

using System;
namespace YeniÖzellikler {
    class NameofÝþlemci {
        int[] dizi = new int[5];
        int Göster (int[] d) {try {d [6] = 2023;}catch (Exception){}  return 0; }
        static void göster(){/* Kodlama */}
        static void Main() {
            Console.Write ("'nameof' iþlemcisi program çýktýsýna deðiþken, metod ve sýnýf adlarýný yansýtýr; kýsmen 'typeof' gibidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            string site = "www.javatpoint.com"; Console.WriteLine (site);
            //Console.WriteLine ("{0} adlý deðiþkenin tipi: {1}", nameof (site), typeof (site));
            //Console.WriteLine ("Metodun adý:" + nameof (göster));

            var nesne = new NameofÝþlemci();
            try {nesne.Göster (nesne.dizi);
            }catch (Exception h) {
                Console.WriteLine ("HATA: " + h.Message);
                Console.WriteLine ("Hata fýrlatan metodun adý: " + nesne.Göster (nesne.dizi));
            }

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    }
}