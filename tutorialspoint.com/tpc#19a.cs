// tpc#19a.cs: S�n�f tan�m�yla kutular�n hacimleri hesab� �rne�i.

using System;
namespace S�n�flar {
    class Kutu {
        public double uzunluk;
        public double y�kseklik;
        public double geni�lik;
    }
    class KutuHacmi {
        static void Main (string[] args) {
            Console.Write ("S�n�f tiplemeleri nesnedir. De�i�ken ve metodlar s�n�f �yeleridir.\nVarsay�l� �ye eri�im belirteci private/�zel, s�n�f�nki ise internal/i�sel'dir.\nMetod veri tipi d�nd�r�lecek veriye dairdir.\n�yelere eri�im 's�n�fAd�.�yeAd�' nokta i�lemcisiyledir.\nTu�..."); Console.ReadKey();

            Kutu Kutu1 = new Kutu(); Kutu1.uzunluk = 2; Kutu1.y�kseklik = 1; Kutu1.geni�lik = 0.45;
            Kutu Kutu2 = new Kutu(); Kutu2.uzunluk = 5.5; Kutu2.y�kseklik = 2.5; Kutu2.geni�lik = 1.65;
            Kutu Kutu3 = new Kutu(); Kutu3.uzunluk = 7.65; Kutu3.y�kseklik = 3.45; Kutu3.geni�lik = 2.15;
            double hacim = 0;

            hacim = Kutu1.uzunluk * Kutu1.y�kseklik * Kutu1.geni�lik; Console.WriteLine ("\n\n�lk kutunun hacmi = [{0}] birim-k�p.", hacim);
            hacim = Kutu2.uzunluk * Kutu2.y�kseklik * Kutu2.geni�lik; Console.WriteLine ("�kinci kutunun hacmi = [{0}] birim-k�p.", hacim);
            hacim = Kutu3.uzunluk * Kutu3.y�kseklik * Kutu3.geni�lik; Console.WriteLine ("���nc� kutunun hacmi = [{0}] birim-k�p.", hacim);
            Console.Write ("Tu�..."); Console.ReadKey();

        }
    }
}