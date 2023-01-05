// tpc#21b.cs: Soyut sýnýfýn soyut metodunu türev sýnýf aþýrýyüklemeli metoduyla dinamik kullanma örneði.

using System;
namespace Çoklubiçim {
    abstract class Þekil {public abstract int alan();} //Soyut sýnýfýn içeriksiz soyut metodu.
    class Dikdörtgen: Þekil {
        private int uzunluk;
        private int yükseklik;
        public Dikdörtgen (int a = 0, int b = 0) {uzunluk = a; yükseklik = b;}
        public override int alan() {// Miraslanan aþýrýyüklü dinamik türev sýnýf fonksiyonu
            Console.WriteLine ("\n\nDikdörtgen sýnýfýnýn alan() metodu.");
            return (uzunluk * yükseklik);
        }
    }
    class DinamikSoyutMetod {
        static void Main() {
            Console.Write ("Arabaðlaç benzeri soyut sýnýf ve içi boþ soyut metodu, miraslanan türev sýnýfýnda aþýrýyükleme fonksiyonunda daha etkili ve dinamik kullanýlýr. Soyut sýnýf tiplenmez, soyut metodu haricen tanýmlanamaz, seal/mühürlü sýnýf miraslanmaz ve soyut olamaz.\nTuþ..."); Console.ReadKey();

            Dikdörtgen d = new Dikdörtgen (15, 7); // Soyutu miraslayan somut sýnýf tiplemesi
            Console.WriteLine ("Alan: {0}",d.alan());

            Console.Write ("Tuþ..."); Console.ReadKey();
        }
    }
}