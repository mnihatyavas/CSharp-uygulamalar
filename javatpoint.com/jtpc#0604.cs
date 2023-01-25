// jtpc#0604.cs: 'this' anahtarkelimesinin s�n�fi�i metodda parametrelerle kullan�lmas� �rne�i.

using System;
namespace NesneS�n�f� {
    public class Emekli {
        public int no;
        public String isim;
        public float maa�;
        public Emekli (int no, String ad, float maa�) {//Parametreli kurucu metodu
            this.no = no;
            isim = ad;
            this.maa� = maa�;
        }
        public void G�ster() {Console.WriteLine ("{0} no'lu {1} adl� emeklinin ayl�k br�t maa��: {2}", no, isim, maa�);}
    }
    class Bu {
        static void Main() {
            Console.Write ("'this' anahtarkelimesinin kullan�ld��� yerler: Ayn� s�n�f de�i�ken �yesi s�n�f i�i metodlarda kullan�l�rken parametreyle ayn�ysa, ay�rtetmek i�in; akt�el nesne ba�ka metod parametresiyle aktar�l�rken; endeksleyicilerin beyan�nda.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Emekli e1 = new Emekli (1001, "M.Nihat Yava�", 4850f);  
            Emekli e2 = new Emekli (1002, "M.Nedim Yava�", 4985f);
            Emekli e3 = new Emekli (1003, "Hatice Y.Ka�ar", 4750f);
            e1.G�ster();
            e2.G�ster();
            e3.G�ster();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}