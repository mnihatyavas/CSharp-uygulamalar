// tpc#12a.cs: Genel eri�im belirte�li kaps�llemeyle dikd�rtgen alan� �rne�i.

using System;
namespace Kaps�lleme {
    class Dikd�rtgen {
        // �ye de�i�kenler:
        public double en;
        public double boy;

        // �ye fonksiyonlar:
        public double Alan�Hesapla() {return en * boy;}
        public void G�ster() {// void/bo� ise return/d�nd�r�len-de�er yoktur
            Console.WriteLine ("\nUzunluk: {0}", en);
            Console.WriteLine ("Y�kseklik: {0}", boy);
            Console.Write ("Dikd�rtgenin alan�: {0}", Alan�Hesapla());
        }
    }

    class GenelEri�im {
        static void Main (string[] args) {
            Console.WriteLine ("Soyutlama, s�n�f �yelerini g�r�n�r k�larken, kaps�lleme ise engeller; soyutlamal� kaps�lleme, s�n�f �yelerine eri�im seviyesini belirler.");
            Console.WriteLine ("\nC# eri�im belirte�leri: Public/Genel, Private/�zel, Protected/Korumal�, Internal/��sel ve ProtectedInternal/Korumal���sel.");
            Console.WriteLine ("\nGenel eri�im belirteci, s�n�f�n �ye de�i�ken ve fonksiyonlar�na herkesin eri�imini m�mk�n k�lar.");
            Console.WriteLine ("\nKorumal� eri�im belirteci, s�n�f�n �ye de�i�ken ve fonksiyonlar�na sadece mirasc� alts�n�f yavrular� eri�ebilir.");
            Console.Write ("\nKorumal� i�sel eri�im belirteci, s�n�f�n �ye de�i�ken ve fonksiyonlar�na sadece ayn� uygulaman�n mirasc� alts�n�f yavrular� eri�ebilir.");
            Console.Write ("\nTu�..."); Console.ReadKey();

            Dikd�rtgen d = new Dikd�rtgen();// Dikd�rtgen tiplemesi
            Console.Write ("\n\nDikd�rtgenin geni�li�ini girin [10,5] Ent: "); d.en = Convert.ToDouble (Console.ReadLine());
            Console.Write ("Dikd�rtgenin y�ksekli�ini girin [6,75] Ent: "); d.boy = Convert.ToDouble (Console.ReadLine());
            d.G�ster();
            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    }
}