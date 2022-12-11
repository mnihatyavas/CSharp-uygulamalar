// tpc#19b.cs: Sýnýf özel deðiþkenleri ve genel fonksiyonlarý örneði.

using System;
namespace Sýnýflar {
    class Kutu {
        private double uzunluk;
        private double yükseklik;
        private double geniþlik;

        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void yükseklikKoy (double yük) {yükseklik = yük;}
        public void geniþlikKoy (double gen) {geniþlik = gen;}

        public double hacimAl() {return uzunluk * yükseklik * geniþlik;}
    }
    class KutuHacmiKoyAl {
        static void Main (string[] args) {
            Console.Write ("Sýnýf içi özel deðiþkenlere genel fonksiyonlarla deðerler aktarýlýp, hesap sonucu alýnabilir.\nTuþ..."); Console.ReadKey();

            Kutu Kutu1 = new Kutu(); Kutu1.uzunlukKoy (2); Kutu1.yükseklikKoy (1); Kutu1.geniþlikKoy (0.45);
            Kutu Kutu2 = new Kutu(); Kutu2.uzunlukKoy (5.5); Kutu2.yükseklikKoy (2.5); Kutu2.geniþlikKoy (1.65);
            Kutu Kutu3 = new Kutu(); Kutu3.uzunlukKoy (7.65); Kutu3.yükseklikKoy (3.45); Kutu3.geniþlikKoy (2.15);

            Console.WriteLine ("\n\nÝlk kutunun hacmi = [{0}] birim-küp.", Kutu1.hacimAl());
            Console.WriteLine ("Ýkinci kutunun hacmi = [{0}] birim-küp.", Kutu2.hacimAl());
            Console.WriteLine ("Üçüncü kutunun hacmi = [{0}] birim-küp.", Kutu3.hacimAl());
            Console.Write ("Tuþ..."); Console.ReadKey();

        }
    }
}