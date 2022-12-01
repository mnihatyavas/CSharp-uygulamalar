// tpc#04b.cs: Dairenin �evre, alan ve hacim hesab� �rne�i.

using System;
namespace TemelS�zdizim {
    class Daire {
        double y; // yar��ap
        double pi;

        public void De�erleriAl() {y = 23.785; pi = 3.1418;}
        public double Daire�evresi() {return 2 * pi * y;}
        public double DaireAlan�() {return pi * y * y;}
        public double DaireHacmi() {return 4 / 3 * pi * y * y * y;}
        public void G�ster() {
            Console.WriteLine ("Yar��ap: {0}", y);
            Console.WriteLine ("Dairenin �evresi: {0} m", Daire�evresi());
            Console.WriteLine ("Dairenin alan�: {0} m2", DaireAlan�());
            Console.Write ("Dairenin hacmi: {0} m3\n\nTu�..", DaireHacmi());
        }
    }

    class Daire�l��mleri {
        static void Main (string[] args) {
            Daire d = new Daire();
            d.De�erleriAl();
            d.G�ster();
            Console.ReadKey(); // Herhangibir tu�a bas
        }
    }
}