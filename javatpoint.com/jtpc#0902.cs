// jtpc#0902.cs: Temel'deki ayný adlý metodun türev'deki tarafýndan esgeçilmesi örneði.

using System;
namespace Çoklubiçim {
    public class Hayvanlar {
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public void havla() {Console.WriteLine ("Havlýyor...");}
        public void gül() {Console.WriteLine ("Gülüyor...");}
        public virtual void aðla() {Console.WriteLine ("Aðlýyor...");}
    }
    public class YavruKöpek: Hayvanlar {
        public override void ye() {Console.WriteLine ("Piliç kýzartma yiyor...");}
        public override void aðla() {Console.WriteLine ("Aðlayýp sýzlanýyor...");}
    }  
    class MetodEsgeçme {
        static void Main() {
            Console.Write ("Ebeveyn 'virtual' metodla miraslayan yavru 'override' metod ayný addaysa ebeveyniki geçersiz kýlýnýr. Bu yavruya mirasladýðý metodu icabýnda özelleþtirmesine imkan tanýr..\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            YavruKöpek yk = new YavruKöpek(); yk.ye(); yk.havla(); yk.gül(); yk.aðla();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}