// tpc#22a.cs: Statik iþlemci aþýrýyükleniþiyle iki kutu ölçülerinin toplam hacmi örneði.

using System;
namespace StatikÝþlemciAþýrýyükleniþ {
    class Kutu {
        private double uzunluk;
        private double geniþlik;
        private double yükseklik;
 
        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void geniþlikKoy (double gen) {geniþlik = gen;}
        public void yükseklikKoy (double yük) {yükseklik = yük;}
        public double hacimAl() {return uzunluk * geniþlik * yükseklik;}

        // Ýki kutu nesnesinin ebatlarýný toplayan aþýrýyükleniþ iþlemci+
        public static Kutu operator+ (Kutu k1, Kutu k2) {
            Kutu kutu = new Kutu();
            kutu.uzunluk = k1.uzunluk + k2.uzunluk;
            kutu.geniþlik = k1.geniþlik + k2.geniþlik;
            kutu.yükseklik = k1.yükseklik + k2.yükseklik;
            return kutu;
        }
    }
    class ÝþlemciAþýrýyükleniþ {
        static void Main() {
            Console.Write ("Statik iþlemci aþýrýyüklenen fonksiyon nesnel tipli ve operator/iþlemci anahtarkelimeli olup, parametre listesi ve geridönüþ deðeri vardýr. Ýþlem esnasýnda sadece tanýmlanan iþlemcinin tanýmlý nesneyle iþlem yapmasý, özel tanýmlý iþlemci fonksiyonun aþýrýyükleniþ çaðrýlmasýna yeterlidir.\nTuþ..."); Console.ReadKey();

            Kutu kutu1 = new Kutu();
            Kutu kutu2 = new Kutu();
            Kutu kutu3 = new Kutu(); // kutu1 + kutu2

            double k1a=6.2, k1b=7, k1c=5.5; kutu1.uzunlukKoy (k1a); kutu1.geniþlikKoy (k1b); kutu1.yükseklikKoy (k1c); Console.WriteLine ("\n\n[{0}, {1} ve {2}] ölçekli kutu1'in hacmi: {3}", k1a, k1b, k1c, kutu1.hacimAl());
            double k2a=12, k2b=13.5, k2c=10.4; kutu2.uzunlukKoy (k2a); kutu2.geniþlikKoy (k2b); kutu2.yükseklikKoy (k2c); Console.WriteLine ("[{0}, {1} ve {2}] ölçekli kutu2'nin hacmi: {3}", k2a, k2b, k2c, kutu2.hacimAl());
            kutu3 = kutu1 + kutu2; // Aþýrýyüklenen operator+ fonksiyonu otomatikmen çaðrýlýr
            Console.WriteLine ("[{0}, {1} ve {2}] ölçekli kutu3'ün hacmi: {3}", k1a+k2a, k1b+k2b, k1c+k2c, kutu3.hacimAl());

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}