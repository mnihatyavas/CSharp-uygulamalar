// jtpc#0902.cs: Temel'deki ayn� adl� metodun t�rev'deki taraf�ndan esge�ilmesi �rne�i.

using System;
namespace �oklubi�im {
    public class Hayvanlar {
        public virtual void ye() {Console.WriteLine ("Yiyor...");}
        public void havla() {Console.WriteLine ("Havl�yor...");}
        public void g�l() {Console.WriteLine ("G�l�yor...");}
        public virtual void a�la() {Console.WriteLine ("A�l�yor...");}
    }
    public class YavruK�pek: Hayvanlar {
        public override void ye() {Console.WriteLine ("Pili� k�zartma yiyor...");}
        public override void a�la() {Console.WriteLine ("A�lay�p s�zlan�yor...");}
    }  
    class MetodEsge�me {
        static void Main() {
            Console.Write ("Ebeveyn 'virtual' metodla miraslayan yavru 'override' metod ayn� addaysa ebeveyniki ge�ersiz k�l�n�r. Bu yavruya miraslad��� metodu icab�nda �zelle�tirmesine imkan tan�r..\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            YavruK�pek yk = new YavruK�pek(); yk.ye(); yk.havla(); yk.g�l(); yk.a�la();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}