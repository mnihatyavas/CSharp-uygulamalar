// j2sc#0122.cs: Throw ile f�rlat�lan Exception ve t�revleri �rne�i.

using System;
using System.Collections;
namespace DilTemelleri {
    public class Ortalama {
        public void Ortalamay�Hesapla() {
            try {
                int adet = 0;
                int ortalama = (10+20+60) / adet;
            }catch (DivideByZeroException h) {throw (new DivideByZeroException ("ortalama paydas�ndaki adet=3 olmal�yd�", h));}
        }
    }
    class �stisnaF�rlat�� {
        public static void YenidenF�rlat�lan�stisna() {
            int[] tsDizi = {4, 8};
            int d = 0;
            for (int i=0; i < 1000; i++) {
                try {Console.WriteLine (tsDizi [i] /d); d=2; //Buna ula��lmaz
                }catch (DivideByZeroException) {Console.WriteLine ("S�f�ra b�l�m hatas� yakaland� (for d�ng�ye devam)!");
                }catch (IndexOutOfRangeException) {
                    Console.WriteLine ("Dizi endeksi ta�ma hatas� yakaland� (for d�ng�s� k�r�l�r)!");
                    throw; //Bu istisna tekrar f�rlat�ld�
                } 
            }
        }
        public static void Topla (int x,int y, out int toplam) {toplam = x + y;}
        static void Main() {
            Console.Write ("'throw new istisna' ile f�rlat�lan s�n�f nesnesi 'Exception' veya ondan t�retilen mevcut istisnalardan biri olmal�d�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            try {Console.WriteLine ("Throw �ncesi...");
                throw new DivideByZeroException ("S�f�ra b�l�m istisnas� f�rlat�ld�.");
                Console.WriteLine ("Throw sonras�..."); //Buraya ula��lmaz
            }catch (DivideByZeroException hata) {Console.WriteLine ("Throw'la f�rlat�lan istisna yakaland�: [{0}]", hata.Message);}
            Console.WriteLine ("Try-catch blo�u sonras�...\n");

            try {YenidenF�rlat�lan�stisna();
            }catch (IndexOutOfRangeException h) {Console.WriteLine ("***Tekrar f�rlat�p yakalanan (k�r�c�) hata: [{0}]", h.Message);}

            var ort = new Ortalama();
            try {ort.Ortalamay�Hesapla();
            }catch (Exception h) {Console.WriteLine ("\nYakalan�p yeniden f�rlat�lan hata: [{0}]\n", h);}

            try {
                try {var liste = new ArrayList();
                    liste.Add (1881); liste.Add (1938); liste.Add (2023);
                    Console.WriteLine ("Listenin 1, 2 ve 3.nc� birimleri = ({0}, {1}, {2})", liste [0], liste [1], liste [2]);
                    Console.WriteLine ("Listenin 10.ncu birimi = {0}", liste [9]);
                }catch (ArgumentOutOfRangeException h) {Console.WriteLine ("�stisna: [{0}]", h);
                }finally {Console.WriteLine ("Bellek temizli�i yap�l�yor..." );
                    throw new Exception ("Finally blokta istisna f�rlatmay� seviyorum!");
                }
            }catch (Exception h) {Console.WriteLine ("�� finally blokta f�rlat�lan istisna: [{0}]", h.Message);}

            try {var istisnam = new Exception ("Benim �zel istisnams�n!");
                istisnam.HelpLink = "Readme.txt dosyas�na bak�n�z";
                istisnam.Source = "j2sc#0122.cs program�";
                throw istisnam;
            }catch (Exception h) {
                Console.WriteLine ("\nYard�m ba�lant�s� = " + h.HelpLink);
                Console.WriteLine ("Mesaj = " + h.Message);
                Console.WriteLine ("Kaynak = " + h.Source);
                Console.WriteLine ("Y���n izi = " + h.StackTrace);
                Console.WriteLine ("Hedef site = " + h.TargetSite);
            }

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}