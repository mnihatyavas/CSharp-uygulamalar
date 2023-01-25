// jtpc#0903.cs: Temel'deki ayný adlý üyelerin türev'de base'le alýntýlanmasý örneði.

using System;
namespace Çoklubiçim {
    public class AnneKöpek {
        public string renk = "beyaz";
        public AnneKöpek(){Console.WriteLine ("Anne köpek tiplemesi yaratýlýyor...");}
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public void havla() {Console.WriteLine ("Havlýyor...");}
        public void gül() {Console.WriteLine ("Gülüyor...");}
        public virtual void aðla() {Console.WriteLine ("Aðlýyor...");}
    }
    public class YavruKöpek: AnneKöpek {
        string renk = "sarý"; //Ebeveyn'le ayný adlý deðiþken adý derleme ikazý verir; aldýrma
        public YavruKöpek(){Console.WriteLine ("Yavru köpek tiplemesi yaratýlýyor...");}
        public void rengi() {Console.WriteLine ("Ebeveyn rengi: " + base.renk); Console.WriteLine ("Yavru rengi: " + renk);}
        public override void ye() {base.ye(); Console.WriteLine ("Piliç kýzartma yiyor...");}
        public override void aðla() {base.aðla(); Console.WriteLine ("Aðlayýp sýzlanýyor...");}
    }
    class Base {
        static void Main() {
            Console.Write ("Statik deðil, tiplemeyle yaratýlan metod, kurucu ve endeksli özellik eriþimcisinin ayný adlý esgeçilen üye miraslanmasýnda, ayrýca temelinki de isteniyorsa, onun üyesi önünde 'base' anahtarkelimesi kullanýlmalýdýr. Farklý kuruculu miraslanmada ise ebevyninki içsel yansýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            YavruKöpek yk = new YavruKöpek(); yk.rengi(); yk.ye(); yk.havla(); yk.gül(); yk.aðla();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}