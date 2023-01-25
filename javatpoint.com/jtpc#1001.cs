// jtpc#1001.cs: Soyut sýnýfýn soyut metodunun miraslayanýn metoduyla esgeçilmesi örneði.

using System;
namespace Soyutlama {
    public abstract class Þekil {public abstract void çiz();}
    public class Daire: Þekil {public override void çiz() {Console.WriteLine ("DAÝRE çiziyor...");} }
    public class Kare: Þekil {public override void çiz() {Console.WriteLine ("KARE çiziyor...");} }
    class Soyut {
        static void Main() {
            Console.Write ("'abstract' anahtarkelimeli sýnýf soyut ve soyut olmayan metodlar içerebilir. Soyut metodlar kodlamasýz olup içsel virtual/sanal olduðundan miraslayan sýnýf metoduyla esgeçilebilir. Soyut metodlar sadece soyut sýnýf ve arayüz içinde tanýmlanabilir. Soyut sýnýf tiplenemez, soyut olmayan miraslayan sýnýf tiplenir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Þekil þk;
            //þk = new Þekil(); þk.çiz(); //Tiplenemez, derleme hatasý
            þk = new Daire(); þk.çiz();
            þk = new Kare(); þk.çiz();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}