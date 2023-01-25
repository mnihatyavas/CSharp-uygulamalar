// jtpc#0802.cs: Bir s�n�f�n di�erine nesnel tip de�i�keni olarak tan�mlan�p eklenmesi �rne�i.

using System;
namespace Kal�tsall�k {
    public class Adres {
        public string detay, il�e, il; // genel alanlar
        public Adres (string detay, string il�e, string il) {//Parametreli kurucu
            this.detay = detay;
            this.il�e = il�e;
            this.il = il;
        }
    }
    public class ��g�ren {
        public int no;  // genel alanlar
        public string isim;
        public Adres adres; //��g�ren HAS-A Adres: Ekleme
        public ��g�ren (int no, string isim, Adres adres) {//Parametreli kurucu
            this.no = no;
            this.isim = isim;
            this.adres = adres;
       }
       public void g�ster() {Console.WriteLine ("{0} no'lu i�g�ren {1}'n adresi: [{2}, {3}, {4}]", no, isim, adres.detay, adres.il�e, adres.il);}
    }
    class Ekleme {
        static void Main() {
            Console.Write ("Ekleme bir s�n�f i�inde birba�kas�n� tip'li nesnel de�i�ken olarak tan�mlay�p onun �yelerini kendi s�n�f �yelerine ilave etmesidir.\nTu�..."); Console.ReadKey(); Console.WriteLine ("\n");

            Adres a = new Adres ("165 Cd, No: 19/B", "Toroslar", "MERS�N");
            ��g�ren i� = new ��g�ren (1001,"M.Nihat Yava�", a);
            i�.g�ster();
            new ��g�ren (1002,"Hatice Yava� Ka�ar", new Adres ("F.S.Mehmet Cd, No: 194/2-A", "Ba�larba��", "BURSA")).g�ster();
            new ��g�ren (1003,"Canan Candan", new Adres ("817 Cd, 163 Sk, No: 12/5-C", "Kale", "ANTALYA")).g�ster();

            Console.Write ("\nTu�.."); Console.ReadKey();
        }
    }
}