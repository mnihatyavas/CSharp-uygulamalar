// jtpc#0903.cs: Temel'deki ayn� adl� �yelerin t�rev'de base'le al�nt�lanmas� �rne�i.

using System;
namespace �oklubi�im {
    public class AnneK�pek {
        public string renk = "beyaz";
        public AnneK�pek(){Console.WriteLine ("Anne k�pek tiplemesi yarat�l�yor...");}
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public void havla() {Console.WriteLine ("Havl�yor...");}
        public void g�l() {Console.WriteLine ("G�l�yor...");}
        public virtual void a�la() {Console.WriteLine ("A�l�yor...");}
    }
    public class YavruK�pek: AnneK�pek {
        string renk = "sar�"; //Ebeveyn'le ayn� adl� de�i�ken ad� derleme ikaz� verir; ald�rma
        public YavruK�pek(){Console.WriteLine ("Yavru k�pek tiplemesi yarat�l�yor...");}
        public void rengi() {Console.WriteLine ("Ebeveyn rengi: " + base.renk); Console.WriteLine ("Yavru rengi: " + renk);}
        public override void ye() {base.ye(); Console.WriteLine ("Pili� k�zartma yiyor...");}
        public override void a�la() {base.a�la(); Console.WriteLine ("A�lay�p s�zlan�yor...");}
    }
    class Base {
        static void Main() {
            Console.Write ("Statik de�il, tiplemeyle yarat�lan metod, kurucu ve endeksli �zellik eri�imcisinin ayn� adl� esge�ilen �ye miraslanmas�nda, ayr�ca temelinki de isteniyorsa, onun �yesi �n�nde 'base' anahtarkelimesi kullan�lmal�d�r. Farkl� kuruculu miraslanmada ise ebevyninki i�sel yans�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            YavruK�pek yk = new YavruK�pek(); yk.rengi(); yk.ye(); yk.havla(); yk.g�l(); yk.a�la();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}