// jtpc#0605.cs: 'static' anahtarkelimeli alan�n tiplenmeden eri�ilebilirli�i �rne�i.

using System;
namespace NesneS�n�f� {
    public class FacebookHesab� {
        public int hesapNo;
        public String isim;
        public static float ilgiOran� = 8.8f; //�lkde�erli
        public static int saya� = 0; //�lkde�erli
        public FacebookHesab� (int hesapNo, String isim) {//Parametreli kurucu
            this.hesapNo = hesapNo;
            this.isim = isim;
            saya�++;
        }
        public void g�ster() {Console.WriteLine ("{0} Facebook hesap no'lu {1}'�n ilgi oran�: %{2}", hesapNo, isim, ilgiOran�);}
    }
    class Statik {
        static void Main() {
            Console.Write ("'static' anahtarkelimesi, tiplenmeden do�rudan eri�ilebilecek �yelerde (alan, kurucu, --y�k�c� veya endeksleyici de�il--, metod, s�n�f, �zellik, i�lemci, olay) kullan�labildi�inden bellek yemez. Her tiplemedeyse di�er �yeler gibi ekstra bellek gerektirmez ve ortak bellek de�eri ayn� kal�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            FacebookHesab� h1 = new FacebookHesab� (1001, "M.Nihat Yava�");
            FacebookHesab� h2 = new FacebookHesab� (1002, "Hatice Y.Ka�ar");
            FacebookHesab� h3 = new FacebookHesab� (1003, "Z.Nihal Candan");
            h1.g�ster(); h2.g�ster(); h3.g�ster();

            FacebookHesab�.ilgiOran� = 23.87f; //Statik �yeye "new"la tiplemeden do�rudan eri�im
            Console.WriteLine(); h1.g�ster(); h2.g�ster(); h3.g�ster();

            Console.WriteLine ("\nYarat�lan toplam Facebook hesap say�s�: " + FacebookHesab�.saya�); //Her tipleme ayn� statik belle�i g�r�r

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}