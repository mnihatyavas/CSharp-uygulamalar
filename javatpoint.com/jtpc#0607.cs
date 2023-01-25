// jtpc#0607.cs: 'static' ve belirteçsiz kurucunun tekkerelik kullanýlabilmesi örneði.

using System;
namespace NesneSýnýfý {
    public class FacebookHesabý {
        public int hesapNo;
        public String isim;
        public static float ilgiOraný = 8.8f; //Ýlkdeðerli ve üzerine toplanacak
        public static int sayaç=1000; //Ýlkdeðerli ve geçersizlenecek
        public FacebookHesabý (int hesapNo, String isim) {//Parametreli kurucu
            this.hesapNo = hesapNo;
            this.isim = isim;
            sayaç++;
        }
        static FacebookHesabý() {ilgiOraný += 10.5f; sayaç = 10; Console.WriteLine ("Statik kurucu içsel ve tekkerelik iþletilir.\n");}
        public void göster() {Console.WriteLine ("{0} Facebook hesap no'lu {1}'ýn ilgi oraný: %{2}", hesapNo, isim, ilgiOraný);}
    }
    class StatikKurucu {
        static void Main() {
            Console.Write ("'static' kurucu parametresiz ve belirteçsiz olup, normal kurucudan farklý olarak sadece ilk tipleme yada statik üye referanslanmasýnda iþletilir; baþkaca, yada doðrudan çaðrýlamaz. Sadece statik üyelerin (diðer alanlarýn deðil) ilkdeðerlemeleri, yada tekkerelik iþlemlerde kullanýlýr.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            FacebookHesabý h1 = new FacebookHesabý (1001, "M.Nihat Yavaþ");
            FacebookHesabý h2 = new FacebookHesabý (1002, "Hatice Y.Kaçar");
            FacebookHesabý h3 = new FacebookHesabý (1003, "Z.Nihal Candan");
            h1.göster(); h2.göster(); h3.göster();

            FacebookHesabý.ilgiOraný = 23.87f; //Statik üyeye "new"la tiplemeden doðrudan eriþim
            Console.WriteLine(); h1.göster(); h2.göster(); h3.göster();

            Console.WriteLine ("\nYaratýlan toplam Facebook hesap sayýsý: " + FacebookHesabý.sayaç); //Hatalý 10+3=13

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}