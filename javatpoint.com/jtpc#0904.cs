// jtpc#0904.cs: Miraslayanýn metod esgeçmesi ve veri üyesi referans farký örneði.

using System;
namespace Çoklubiçim {
    public class AnneKöpek {
        public string renk = "beyaz";
        public virtual void rengi() {Console.WriteLine ("Rengi=" + renk);}
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public virtual void havla() {Console.WriteLine ("Uluyor...");}
        public virtual void gül() {Console.WriteLine ("Gülüyor...");}
        public virtual void aðla() {Console.WriteLine ("Aðlýyor...");}
    }
    public class YavruKöpek: AnneKöpek {
        string renk = "sarý";
        public override void rengi() {Console.WriteLine ("\nRengi=" + renk);}
        public override void ye() {Console.WriteLine ("Piliç kýzartma yiyor...");}
        public override void havla() {Console.WriteLine ("Havlýyor...");}
        public override void gül() {Console.WriteLine ("Kýkýrdýyor...");}
        public override void aðla() {Console.WriteLine ("Aðlayýp sýzlanýyor...");}
    }
    public class Þekil {public virtual void çiz() {Console.WriteLine ("\nÞEKÝL çiziyor...");} }
    public class Daire: Þekil {public override void çiz() {Console.WriteLine ("DAÝRE çiziyor...");} }
    public class Kare: Þekil {public override void çiz() {Console.WriteLine ("KARE çiziyor...");} }
    class ÇokluBiçim {
        static void Main() {
            Console.Write ("Nesneye-yönelik programcýlýðýn 3 temel kavramý: miras, kapsülleme ve çoklubiçim'dir.\n2 türlü çoklubiçim vardýr: derlemezamanlý, statik, erken baðlamalý (metod ve iþlemci aþýrýyükleme); ve çalýþmazamanlý, dinamik, geç baðlamalý (metod esgeçme).\nAyný adlý metodlarda virtual/override kullanarak tiplemeyi tamamen yavruyla veya ebeveyn referanslý ve yavru tiplemeyle yaparken miraslayanýn ebeveyn metod geçerli esgeçmeli çalýþmazamanlý çoklubiçim yaparken veri alanlý üyelerde çoklubiçim olmaz.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            AnneKöpek ak = new AnneKöpek(); ak.rengi(); ak.ye(); ak.havla(); ak.gül(); ak.aðla();
            AnneKöpek yk1 = new YavruKöpek(); yk1.rengi(); yk1.ye(); yk1.havla(); yk1.gül(); yk1.aðla(); //Çoklubiçim metod esgeçme
            Console.WriteLine ("AnneKöpek-->new YavruKöpek Renk={0}", yk1.renk); //Veri alanlý üyede çoklubiçim metod esgeçme YOK
            YavruKöpek yk2 = new YavruKöpek(); yk2.rengi(); yk2.ye(); yk2.havla(); yk2.gül(); yk2.aðla(); //Çoklubiçim metod esgeçme
            Console.WriteLine ("YavruKöpek-->new YavruKöpek Renk={0}", yk2.renk); //Veri alanlý üyede çoklubiçim metod esgeçme YOK

            Þekil þk;
            þk = new Þekil(); þk.çiz();
            þk = new Daire(); þk.çiz(); //Çoklubiçim metod esgeçme
            þk = new Kare(); þk.çiz(); //Çoklubiçim metod esgeçme

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}