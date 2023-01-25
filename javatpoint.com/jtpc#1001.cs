// jtpc#1001.cs: Soyut s�n�f�n soyut metodunun miraslayan�n metoduyla esge�ilmesi �rne�i.

using System;
namespace Soyutlama {
    public abstract class �ekil {public abstract void �iz();}
    public class Daire: �ekil {public override void �iz() {Console.WriteLine ("DA�RE �iziyor...");} }
    public class Kare: �ekil {public override void �iz() {Console.WriteLine ("KARE �iziyor...");} }
    class Soyut {
        static void Main() {
            Console.Write ("'abstract' anahtarkelimeli s�n�f soyut ve soyut olmayan metodlar i�erebilir. Soyut metodlar kodlamas�z olup i�sel virtual/sanal oldu�undan miraslayan s�n�f metoduyla esge�ilebilir. Soyut metodlar sadece soyut s�n�f ve aray�z i�inde tan�mlanabilir. Soyut s�n�f tiplenemez, soyut olmayan miraslayan s�n�f tiplenir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            �ekil �k;
            //�k = new �ekil(); �k.�iz(); //Tiplenemez, derleme hatas�
            �k = new Daire(); �k.�iz();
            �k = new Kare(); �k.�iz();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}