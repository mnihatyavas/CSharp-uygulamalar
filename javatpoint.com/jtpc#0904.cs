// jtpc#0904.cs: Miraslayan�n metod esge�mesi ve veri �yesi referans fark� �rne�i.

using System;
namespace �oklubi�im {
    public class AnneK�pek {
        public string renk = "beyaz";
        public virtual void rengi() {Console.WriteLine ("Rengi=" + renk);}
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public virtual void havla() {Console.WriteLine ("Uluyor...");}
        public virtual void g�l() {Console.WriteLine ("G�l�yor...");}
        public virtual void a�la() {Console.WriteLine ("A�l�yor...");}
    }
    public class YavruK�pek: AnneK�pek {
        string renk = "sar�";
        public override void rengi() {Console.WriteLine ("\nRengi=" + renk);}
        public override void ye() {Console.WriteLine ("Pili� k�zartma yiyor...");}
        public override void havla() {Console.WriteLine ("Havl�yor...");}
        public override void g�l() {Console.WriteLine ("K�k�rd�yor...");}
        public override void a�la() {Console.WriteLine ("A�lay�p s�zlan�yor...");}
    }
    public class �ekil {public virtual void �iz() {Console.WriteLine ("\n�EK�L �iziyor...");} }
    public class Daire: �ekil {public override void �iz() {Console.WriteLine ("DA�RE �iziyor...");} }
    public class Kare: �ekil {public override void �iz() {Console.WriteLine ("KARE �iziyor...");} }
    class �okluBi�im {
        static void Main() {
            Console.Write ("Nesneye-y�nelik programc�l���n 3 temel kavram�: miras, kaps�lleme ve �oklubi�im'dir.\n2 t�rl� �oklubi�im vard�r: derlemezamanl�, statik, erken ba�lamal� (metod ve i�lemci a��r�y�kleme); ve �al��mazamanl�, dinamik, ge� ba�lamal� (metod esge�me).\nAyn� adl� metodlarda virtual/override kullanarak tiplemeyi tamamen yavruyla veya ebeveyn referansl� ve yavru tiplemeyle yaparken miraslayan�n ebeveyn metod ge�erli esge�meli �al��mazamanl� �oklubi�im yaparken veri alanl� �yelerde �oklubi�im olmaz.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            AnneK�pek ak = new AnneK�pek(); ak.rengi(); ak.ye(); ak.havla(); ak.g�l(); ak.a�la();
            AnneK�pek yk1 = new YavruK�pek(); yk1.rengi(); yk1.ye(); yk1.havla(); yk1.g�l(); yk1.a�la(); //�oklubi�im metod esge�me
            Console.WriteLine ("AnneK�pek-->new YavruK�pek Renk={0}", yk1.renk); //Veri alanl� �yede �oklubi�im metod esge�me YOK
            YavruK�pek yk2 = new YavruK�pek(); yk2.rengi(); yk2.ye(); yk2.havla(); yk2.g�l(); yk2.a�la(); //�oklubi�im metod esge�me
            Console.WriteLine ("YavruK�pek-->new YavruK�pek Renk={0}", yk2.renk); //Veri alanl� �yede �oklubi�im metod esge�me YOK

            �ekil �k;
            �k = new �ekil(); �k.�iz();
            �k = new Daire(); �k.�iz(); //�oklubi�im metod esge�me
            �k = new Kare(); �k.�iz(); //�oklubi�im metod esge�me

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}