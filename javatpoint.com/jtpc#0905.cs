// jtpc#0905.cs: M�h�rl� 'sealed' s�n�f miraslanmaz, metod esge�ilmez, de�i�ken g�r�nt�lenmez �rne�i.

using System;
namespace �oklubi�im {
    /*sealed*/ public class AnneK�pek {
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public virtual void havla() {Console.WriteLine ("Uluyor...");}
        public virtual void g�l() {Console.WriteLine ("G�l�yor...");}
        public virtual void a�la() {Console.WriteLine ("A�l�yor...");}
    }
    public class YavruK�pek : AnneK�pek {
        public override void ye() {Console.WriteLine ("\nPili� k�zartma yiyor...");}
        public override void havla() {Console.WriteLine ("Havl�yor...");}
        //public sealed override void g�l() {Console.WriteLine ("K�k�rd�yor...");}
        //public sealed override void a�la() {Console.WriteLine ("A�lay�p s�zlan�yor...");}
    }
    class M�h�rl� {
        static void Main() {
            Console.Write ("'sealed' anahtarkelimeli s�n�f miraslanamaz. M�h�rl� metod esge�ilemez. 'struct' yap� i�sel m�h�rl� oldu�undan miraslanmaz. Ayr�ca m�h�rl� de�i�ken g�r�nt�lenmez. Derleme hatas� verir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            AnneK�pek ak = new AnneK�pek(); ak.ye(); ak.havla(); ak.g�l(); ak.a�la();
            AnneK�pek yk1 = new YavruK�pek(); yk1.ye(); yk1.havla(); yk1.g�l(); yk1.a�la();
            YavruK�pek yk2 = new YavruK�pek(); yk2.ye(); yk2.havla(); yk2.g�l(); yk2.a�la();

            /*sealed*/ int x = 10;
            x = x++ * 3;
            Console.WriteLine ("\nx="+x);

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}