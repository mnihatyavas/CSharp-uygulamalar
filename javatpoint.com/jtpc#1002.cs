// jtpc#1002.cs: Aray�z metodunun miraslayan�n metoduyla esge�ilmesi �rne�i.

using System;
namespace Soyutlama {
    public interface �ekil {void �iz();} //Aray�z metodu public olmaz
    public class Daire: �ekil {public void �iz() {Console.WriteLine ("DA�RE �iziyor...");} }
    public class Kare: �ekil {public void �iz() {Console.WriteLine ("KARE �iziyor...");} }
    class Aray�z {
        static void Main() {
            Console.Write ("Aray�z soyut s�n�f gibidir, ancak sadece kodsuz (i�sel soyut) metodlar i�erebilir. Kendisi tiplenemez. Aray�z� miraslayan s�n�f veya yap�, i�erdi�i t�m metodlar� y�r�tmelidir. �oklu s�n�f miraslanmas� olmazken, �oklu aray�z miraslanmas� m�mk�nd�r. Aray�zler genelde benzer metodlar� katagorilemekte kullan�l�r.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            �ekil �k;
            //�k = new �ekil(); �k.�iz(); //Tiplenemez, derleme hatas�
            �k = new Daire(); �k.�iz();
            �k = new Kare(); �k.�iz();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}