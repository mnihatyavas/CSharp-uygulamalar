// tpc#04b.cs: Dairenin çevre, alan ve hacim hesabý örneði.

using System;
namespace TemelSözdizim {
    class Daire {
        double y; // yarýçap
        double pi;

        public void DeðerleriAl() {y = 23.785; pi = 3.1418;}
        public double DaireÇevresi() {return 2 * pi * y;}
        public double DaireAlaný() {return pi * y * y;}
        public double DaireHacmi() {return 4 / 3 * pi * y * y * y;}
        public void Göster() {
            Console.WriteLine ("Yarýçap: {0}", y);
            Console.WriteLine ("Dairenin çevresi: {0} m", DaireÇevresi());
            Console.WriteLine ("Dairenin alaný: {0} m2", DaireAlaný());
            Console.Write ("Dairenin hacmi: {0} m3\n\nTuþ..", DaireHacmi());
        }
    }

    class DaireÖlçümleri {
        static void Main (string[] args) {
            Daire d = new Daire();
            d.DeðerleriAl();
            d.Göster();
            Console.ReadKey(); // Herhangibir tuþa bas
        }
    }
}