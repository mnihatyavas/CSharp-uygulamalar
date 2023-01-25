// jtpc#0802.cs: Bir sýnýfýn diðerine nesnel tip deðiþkeni olarak tanýmlanýp eklenmesi örneði.

using System;
namespace Kalýtsallýk {
    public class Adres {
        public string detay, ilçe, il; // genel alanlar
        public Adres (string detay, string ilçe, string il) {//Parametreli kurucu
            this.detay = detay;
            this.ilçe = ilçe;
            this.il = il;
        }
    }
    public class Ýþgören {
        public int no;  // genel alanlar
        public string isim;
        public Adres adres; //Ýþgören HAS-A Adres: Ekleme
        public Ýþgören (int no, string isim, Adres adres) {//Parametreli kurucu
            this.no = no;
            this.isim = isim;
            this.adres = adres;
       }
       public void göster() {Console.WriteLine ("{0} no'lu iþgören {1}'n adresi: [{2}, {3}, {4}]", no, isim, adres.detay, adres.ilçe, adres.il);}
    }
    class Ekleme {
        static void Main() {
            Console.Write ("Ekleme bir sýnýf içinde birbaþkasýný tip'li nesnel deðiþken olarak tanýmlayýp onun üyelerini kendi sýnýf üyelerine ilave etmesidir.\nTuþ..."); Console.ReadKey(); Console.WriteLine ("\n");

            Adres a = new Adres ("165 Cd, No: 19/B", "Toroslar", "MERSÝN");
            Ýþgören iþ = new Ýþgören (1001,"M.Nihat Yavaþ", a);
            iþ.göster();
            new Ýþgören (1002,"Hatice Yavaþ Kaçar", new Adres ("F.S.Mehmet Cd, No: 194/2-A", "Baðlarbaþý", "BURSA")).göster();
            new Ýþgören (1003,"Canan Candan", new Adres ("817 Cd, 163 Sk, No: 12/5-C", "Kale", "ANTALYA")).göster();

            Console.Write ("\nTuþ.."); Console.ReadKey();
        }
    }
}