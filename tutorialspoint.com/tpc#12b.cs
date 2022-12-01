// tpc#12b.cs: �zel eri�im belirte�li kaps�llemeyle dikd�rtgen alan� �rne�i.

using System;
namespace Kaps�lleme {
    class Dikd�rtgen {
        // �zel �ye de�i�kenlere d��ardan eri�ilmez
        private double en;
        private double boy;

        // Genel �ye fonksiyonlar�na d��ardan eri�ilebilir
        public void VeriGiri�i() {
            Console.Write ("\n\nDikd�rtgenin geni�li�ini girin [10,5] Ent: "); en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikd�rtgenin y�ksekli�ini girin [6,75] Ent: "); boy = Convert.ToDouble (Console.ReadLine());
        }
        private double Alan�Hesapla() {return en * boy;}
        public void G�ster() {
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Y�kseklik: {0}", boy);
            Console.Write ("Dikd�rtgenin alan�: {0}", Alan�Hesapla());
        }
    }

    class �zelEri�im {
        static void Main (string[] args) {
            Console.Write ("\n�zel eri�im belirteci, s�n�f�n �yelerine eri�imi yasaklar; ancak ayn� s�n�f �yeleri birbirlerine eri�ebilir.");
            Console.Write ("\nTu�..."); Console.ReadKey();

            Dikd�rtgen d = new Dikd�rtgen();// Dikd�rtgen tiplemesi
            d.VeriGiri�i();
            d.G�ster();
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}