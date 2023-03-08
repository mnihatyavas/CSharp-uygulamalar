// jtpc#2306i.cs: Tek '=>' ifadeli alýcý-koyucu deðer atamlarý örneði.

using System;
namespace YeniÖzellikler {
    class Öðrenci {
        private int no;
        private string ad;
        private string eposta;
        public Öðrenci (int a, string b, string c) /*=>*/ {no=a; ad = b; eposta=c;}
        public int No() {/*get => No; set => No=value;*/ return no;}
        public string Ad() {/*get => Ad; set => Ad=value;*/ return ad;}
        public string Eposta() {/*get => Eposta; set => Eposta=value;*/ return eposta;}
    }
    class AlýcýKoyucu {
        static void Main() {
            Console.Write ("Tek satýrlýk '=>' ifadeler özellik, metod ve kurucularda tek ifadeli get-set/alýcý-koyucularla atama iþlemleri için kullanýlabilmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðr = new Öðrenci (1001, "Zafer", "zafer@gmail.com"); Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", öðr.No(), öðr.Ad(), öðr.Eposta());
            öðr = new Öðrenci (1002, "Canan", "canan@gmail.com"); Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðr.No(), öðr.Ad(), öðr.Eposta());
            öðr = new Öðrenci (1003, "Belkýs", "belkis@gmail.com"); Console.WriteLine ("{0} no'lu öðrenci {1}'ýn epostasý: {2}", öðr.No(), öðr.Ad(), öðr.Eposta());

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}