// jtpc#1002.cs: Arayüz metodunun miraslayanýn metoduyla esgeçilmesi örneði.

using System;
namespace Soyutlama {
    public interface Þekil {void çiz();} //Arayüz metodu public olmaz
    public class Daire: Þekil {public void çiz() {Console.WriteLine ("DAÝRE çiziyor...");} }
    public class Kare: Þekil {public void çiz() {Console.WriteLine ("KARE çiziyor...");} }
    class Arayüz {
        static void Main() {
            Console.Write ("Arayüz soyut sýnýf gibidir, ancak sadece kodsuz (içsel soyut) metodlar içerebilir. Kendisi tiplenemez. Arayüzü miraslayan sýnýf veya yapý, içerdiði tüm metodlarý yürütmelidir. Çoklu sýnýf miraslanmasý olmazken, çoklu arayüz miraslanmasý mümkündür. Arayüzler genelde benzer metodlarý katagorilemekte kullanýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Þekil þk;
            //þk = new Þekil(); þk.çiz(); //Tiplenemez, derleme hatasý
            þk = new Daire(); þk.çiz();
            þk = new Kare(); þk.çiz();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}