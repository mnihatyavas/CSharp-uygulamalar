// tpc#19b.cs: S�n�f �zel de�i�kenleri ve genel fonksiyonlar� �rne�i.

using System;
namespace S�n�flar {
    class Kutu {
        private double uzunluk;
        private double y�kseklik;
        private double geni�lik;

        public void uzunlukKoy (double uz) {uzunluk = uz;}
        public void y�kseklikKoy (double y�k) {y�kseklik = y�k;}
        public void geni�likKoy (double gen) {geni�lik = gen;}

        public double hacimAl() {return uzunluk * y�kseklik * geni�lik;}
    }
    class KutuHacmiKoyAl {
        static void Main (string[] args) {
            Console.Write ("S�n�f i�i �zel de�i�kenlere genel fonksiyonlarla de�erler aktar�l�p, hesap sonucu al�nabilir.\nTu�..."); Console.ReadKey();

            Kutu Kutu1 = new Kutu(); Kutu1.uzunlukKoy (2); Kutu1.y�kseklikKoy (1); Kutu1.geni�likKoy (0.45);
            Kutu Kutu2 = new Kutu(); Kutu2.uzunlukKoy (5.5); Kutu2.y�kseklikKoy (2.5); Kutu2.geni�likKoy (1.65);
            Kutu Kutu3 = new Kutu(); Kutu3.uzunlukKoy (7.65); Kutu3.y�kseklikKoy (3.45); Kutu3.geni�likKoy (2.15);

            Console.WriteLine ("\n\n�lk kutunun hacmi = [{0}] birim-k�p.", Kutu1.hacimAl());
            Console.WriteLine ("�kinci kutunun hacmi = [{0}] birim-k�p.", Kutu2.hacimAl());
            Console.WriteLine ("���nc� kutunun hacmi = [{0}] birim-k�p.", Kutu3.hacimAl());
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}