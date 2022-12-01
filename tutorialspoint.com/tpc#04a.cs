// tpc#04a.cs: Verili en ve boy deðerleriyle dikdörtgen alanýnýn hesaplanmasý örneði.

using System;
namespace TemelSözdizim {
    class Dikdörtgen {
        // Sýnýf altý "üye deðiþkenler"
        double en;
        double boy;
        // Sýnýf altý "üye fonksiyonlar"
        public void DeðerleriAl() {
            en = 4.5;
            boy = 3.5;
        }
        public double AlanýHesapla() {return en * boy;}
        public void Göster() {
            Console.WriteLine ("En: {0}", en);
            Console.WriteLine ("Boy: {0}", boy);
            Console.Write ("Dikdörtgenin Alaný: {0}\nEnt..", AlanýHesapla());
        }
    }

    class DikdörtgenAlaný {
        static void Main (string[] args) {
            Dikdörtgen d = new Dikdörtgen();
            d.DeðerleriAl();
            d.Göster();
            Console.ReadLine(); // Enter bas
        }
    }
}