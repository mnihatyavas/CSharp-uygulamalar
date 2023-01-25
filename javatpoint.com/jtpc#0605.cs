// jtpc#0605.cs: 'static' anahtarkelimeli alanýn tiplenmeden eriþilebilirliði örneði.

using System;
namespace NesneSýnýfý {
    public class FacebookHesabý {
        public int hesapNo;
        public String isim;
        public static float ilgiOraný = 8.8f; //Ýlkdeðerli
        public static int sayaç = 0; //Ýlkdeðerli
        public FacebookHesabý (int hesapNo, String isim) {//Parametreli kurucu
            this.hesapNo = hesapNo;
            this.isim = isim;
            sayaç++;
        }
        public void göster() {Console.WriteLine ("{0} Facebook hesap no'lu {1}'ýn ilgi oraný: %{2}", hesapNo, isim, ilgiOraný);}
    }
    class Statik {
        static void Main() {
            Console.Write ("'static' anahtarkelimesi, tiplenmeden doðrudan eriþilebilecek üyelerde (alan, kurucu, --yýkýcý veya endeksleyici deðil--, metod, sýnýf, özellik, iþlemci, olay) kullanýlabildiðinden bellek yemez. Her tiplemedeyse diðer üyeler gibi ekstra bellek gerektirmez ve ortak bellek deðeri ayný kalýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            FacebookHesabý h1 = new FacebookHesabý (1001, "M.Nihat Yavaþ");
            FacebookHesabý h2 = new FacebookHesabý (1002, "Hatice Y.Kaçar");
            FacebookHesabý h3 = new FacebookHesabý (1003, "Z.Nihal Candan");
            h1.göster(); h2.göster(); h3.göster();

            FacebookHesabý.ilgiOraný = 23.87f; //Statik üyeye "new"la tiplemeden doðrudan eriþim
            Console.WriteLine(); h1.göster(); h2.göster(); h3.göster();

            Console.WriteLine ("\nYaratýlan toplam Facebook hesap sayýsý: " + FacebookHesabý.sayaç); //Her tipleme ayný statik belleði görür

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}