// tpc#22a.cs: Statik i�lemci a��r�y�kleni�iyle iki kutu �l��lerinin toplam hacmi �rne�i.

using System;
namespace Statik��lemciA��r�y�kleni� {
    class Kutu {
        private double uzunluk;
        private double geni�lik;
        private double y�kseklik;
 
        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void geni�likKoy (double gen) {geni�lik = gen;}
        public void y�kseklikKoy (double y�k) {y�kseklik = y�k;}
        public double hacimAl() {return uzunluk * geni�lik * y�kseklik;}

        // �ki kutu nesnesinin ebatlar�n� toplayan a��r�y�kleni� i�lemci+
        public static Kutu operator+ (Kutu k1, Kutu k2) {
            Kutu kutu = new Kutu();
            kutu.uzunluk = k1.uzunluk + k2.uzunluk;
            kutu.geni�lik = k1.geni�lik + k2.geni�lik;
            kutu.y�kseklik = k1.y�kseklik + k2.y�kseklik;
            return kutu;
        }
    }
    class ��lemciA��r�y�kleni� {
        static void Main() {
            Console.Write ("Statik i�lemci a��r�y�klenen fonksiyon nesnel tipli ve operator/i�lemci anahtarkelimeli olup, parametre listesi ve gerid�n�� de�eri vard�r. ��lem esnas�nda sadece tan�mlanan i�lemcinin tan�ml� nesneyle i�lem yapmas�, �zel tan�ml� i�lemci fonksiyonun a��r�y�kleni� �a�r�lmas�na yeterlidir.\nTu�..."); Console.ReadKey();

            Kutu kutu1 = new Kutu();
            Kutu kutu2 = new Kutu();
            Kutu kutu3 = new Kutu(); // kutu1 + kutu2

            double k1a=6.2, k1b=7, k1c=5.5; kutu1.uzunlukKoy (k1a); kutu1.geni�likKoy (k1b); kutu1.y�kseklikKoy (k1c); Console.WriteLine ("\n\n[{0}, {1} ve {2}] �l�ekli kutu1'in hacmi: {3}", k1a, k1b, k1c, kutu1.hacimAl());
            double k2a=12, k2b=13.5, k2c=10.4; kutu2.uzunlukKoy (k2a); kutu2.geni�likKoy (k2b); kutu2.y�kseklikKoy (k2c); Console.WriteLine ("[{0}, {1} ve {2}] �l�ekli kutu2'nin hacmi: {3}", k2a, k2b, k2c, kutu2.hacimAl());
            kutu3 = kutu1 + kutu2; // A��r�y�klenen operator+ fonksiyonu otomatikmen �a�r�l�r
            Console.WriteLine ("[{0}, {1} ve {2}] �l�ekli kutu3'�n hacmi: {3}", k1a+k2a, k1b+k2b, k1c+k2c, kutu3.hacimAl());

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}