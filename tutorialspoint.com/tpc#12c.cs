// tpc#12c.cs: ��sel eri�im belirte�li kaps�llemeyle dikd�rtgen alan� �rne�i.

using System;
namespace Kaps�lleme {
    class Dikd�rtgen {
        // ��sel �ye de�i�kenlere d��sal uygulamalardan eri�ilmez
        internal double en;
        internal double boy;

        double Alan�Hesapla() {return en * boy;}// Belirtilmezse varsay�l� "private"dir
        internal void G�ster() {
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Y�kseklik: {0}", boy);
            Console.Write ("Dikd�rtgenin alan�: {0}", Alan�Hesapla());
        }
    }

    class ��selEri�im {
        static void Main (string[] args) {
            Console.Write ("\n��sel eri�im belirteci, s�n�f�n �yelerine eri�imi harici uygulamalara yasaklar; ancak ayn� uygulaman�n i�sel/dahili t�m s�n�f �yeleri birbirlerine eri�ebilir.");
            Console.Write ("\nTu�..."); Console.ReadKey();

            Dikd�rtgen d = new Dikd�rtgen();// Dikd�rtgen tiplemesi
            Console.Write ("\n\nDikd�rtgenin geni�li�ini girin [10,5] Ent: "); d.en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikd�rtgenin y�ksekli�ini girin [6,75] Ent: "); d.boy = Convert.ToDouble (Console.ReadLine());
            d.G�ster();
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}