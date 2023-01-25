// jtpc#0607.cs: 'static' ve belirte�siz kurucunun tekkerelik kullan�labilmesi �rne�i.

using System;
namespace NesneS�n�f� {
    public class FacebookHesab� {
        public int hesapNo;
        public String isim;
        public static float ilgiOran� = 8.8f; //�lkde�erli ve �zerine toplanacak
        public static int saya�=1000; //�lkde�erli ve ge�ersizlenecek
        public FacebookHesab� (int hesapNo, String isim) {//Parametreli kurucu
            this.hesapNo = hesapNo;
            this.isim = isim;
            saya�++;
        }
        static FacebookHesab�() {ilgiOran� += 10.5f; saya� = 10; Console.WriteLine ("Statik kurucu i�sel ve tekkerelik i�letilir.\n");}
        public void g�ster() {Console.WriteLine ("{0} Facebook hesap no'lu {1}'�n ilgi oran�: %{2}", hesapNo, isim, ilgiOran�);}
    }
    class StatikKurucu {
        static void Main() {
            Console.Write ("'static' kurucu parametresiz ve belirte�siz olup, normal kurucudan farkl� olarak sadece ilk tipleme yada statik �ye referanslanmas�nda i�letilir; ba�kaca, yada do�rudan �a�r�lamaz. Sadece statik �yelerin (di�er alanlar�n de�il) ilkde�erlemeleri, yada tekkerelik i�lemlerde kullan�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            FacebookHesab� h1 = new FacebookHesab� (1001, "M.Nihat Yava�");
            FacebookHesab� h2 = new FacebookHesab� (1002, "Hatice Y.Ka�ar");
            FacebookHesab� h3 = new FacebookHesab� (1003, "Z.Nihal Candan");
            h1.g�ster(); h2.g�ster(); h3.g�ster();

            FacebookHesab�.ilgiOran� = 23.87f; //Statik �yeye "new"la tiplemeden do�rudan eri�im
            Console.WriteLine(); h1.g�ster(); h2.g�ster(); h3.g�ster();

            Console.WriteLine ("\nYarat�lan toplam Facebook hesap say�s�: " + FacebookHesab�.saya�); //Hatal� 10+3=13

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}