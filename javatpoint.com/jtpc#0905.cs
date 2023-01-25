// jtpc#0905.cs: Mühürlü 'sealed' sýnýf miraslanmaz, metod esgeçilmez, deðiþken görüntülenmez örneði.

using System;
namespace Çoklubiçim {
    /*sealed*/ public class AnneKöpek {
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public virtual void havla() {Console.WriteLine ("Uluyor...");}
        public virtual void gül() {Console.WriteLine ("Gülüyor...");}
        public virtual void aðla() {Console.WriteLine ("Aðlýyor...");}
    }
    public class YavruKöpek : AnneKöpek {
        public override void ye() {Console.WriteLine ("\nPiliç kýzartma yiyor...");}
        public override void havla() {Console.WriteLine ("Havlýyor...");}
        //public sealed override void gül() {Console.WriteLine ("Kýkýrdýyor...");}
        //public sealed override void aðla() {Console.WriteLine ("Aðlayýp sýzlanýyor...");}
    }
    class Mühürlü {
        static void Main() {
            Console.Write ("'sealed' anahtarkelimeli sýnýf miraslanamaz. Mühürlü metod esgeçilemez. 'struct' yapý içsel mühürlü olduðundan miraslanmaz. Ayrýca mühürlü deðiþken görüntülenmez. Derleme hatasý verir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            AnneKöpek ak = new AnneKöpek(); ak.ye(); ak.havla(); ak.gül(); ak.aðla();
            AnneKöpek yk1 = new YavruKöpek(); yk1.ye(); yk1.havla(); yk1.gül(); yk1.aðla();
            YavruKöpek yk2 = new YavruKöpek(); yk2.ye(); yk2.havla(); yk2.gül(); yk2.aðla();

            /*sealed*/ int x = 10;
            x = x++ * 3;
            Console.WriteLine ("\nx="+x);

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}