// jtpc#0604.cs: 'this' anahtarkelimesinin sýnýfiçi metodda parametrelerle kullanýlmasý örneði.

using System;
namespace NesneSýnýfý {
    public class Emekli {
        public int no;
        public String isim;
        public float maaþ;
        public Emekli (int no, String ad, float maaþ) {//Parametreli kurucu metodu
            this.no = no;
            isim = ad;
            this.maaþ = maaþ;
        }
        public void Göster() {Console.WriteLine ("{0} no'lu {1} adlý emeklinin aylýk brüt maaþý: {2}", no, isim, maaþ);}
    }
    class Bu {
        static void Main() {
            Console.Write ("'this' anahtarkelimesinin kullanýldýðý yerler: Ayný sýnýf deðiþken üyesi sýnýf içi metodlarda kullanýlýrken parametreyle aynýysa, ayýrtetmek için; aktüel nesne baþka metod parametresiyle aktarýlýrken; endeksleyicilerin beyanýnda.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Emekli e1 = new Emekli (1001, "M.Nihat Yavaþ", 4850f);  
            Emekli e2 = new Emekli (1002, "M.Nedim Yavaþ", 4985f);
            Emekli e3 = new Emekli (1003, "Hatice Y.Kaçar", 4750f);
            e1.Göster();
            e2.Göster();
            e3.Göster();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}