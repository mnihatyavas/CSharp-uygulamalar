// tpc#21b.cs: Soyut s�n�f�n soyut metodunu t�rev s�n�f a��r�y�klemeli metoduyla dinamik kullanma �rne�i.

using System;
namespace �oklubi�im {
    abstract class �ekil {public abstract int alan();} //Soyut s�n�f�n i�eriksiz soyut metodu.
    class Dikd�rtgen: �ekil {
        private int uzunluk;
        private int y�kseklik;
        public Dikd�rtgen (int a = 0, int b = 0) {uzunluk = a; y�kseklik = b;}
        public override int alan() {// Miraslanan a��r�y�kl� dinamik t�rev s�n�f fonksiyonu
            Console.WriteLine ("\n\nDikd�rtgen s�n�f�n�n alan() metodu.");
            return (uzunluk * y�kseklik);
        }
    }
    class DinamikSoyutMetod {
        static void Main() {
            Console.Write ("Araba�la� benzeri soyut s�n�f ve i�i bo� soyut metodu, miraslanan t�rev s�n�f�nda a��r�y�kleme fonksiyonunda daha etkili ve dinamik kullan�l�r. Soyut s�n�f tiplenmez, soyut metodu haricen tan�mlanamaz, seal/m�h�rl� s�n�f miraslanmaz ve soyut olamaz.\nTu�..."); Console.ReadKey();

            Dikd�rtgen d = new Dikd�rtgen (15, 7); // Soyutu miraslayan somut s�n�f tiplemesi
            Console.WriteLine ("Alan: {0}",d.alan());

            Console.Write ("Tu�..."); Console.ReadKey();
        }
    }
}