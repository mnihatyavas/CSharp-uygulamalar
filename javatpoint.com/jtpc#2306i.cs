// jtpc#2306i.cs: Tek '=>' ifadeli al�c�-koyucu de�er atamlar� �rne�i.

using System;
namespace Yeni�zellikler {
    class ��renci {
        private int no;
        private string ad;
        private string eposta;
        public ��renci (int a, string b, string c) /*=>*/ {no=a; ad = b; eposta=c;}
        public int No() {/*get => No; set => No=value;*/ return no;}
        public string Ad() {/*get => Ad; set => Ad=value;*/ return ad;}
        public string Eposta() {/*get => Eposta; set => Eposta=value;*/ return eposta;}
    }
    class Al�c�Koyucu {
        static void Main() {
            Console.Write ("Tek sat�rl�k '=>' ifadeler �zellik, metod ve kurucularda tek ifadeli get-set/al�c�-koyucularla atama i�lemleri i�in kullan�labilmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��r = new ��renci (1001, "Zafer", "zafer@gmail.com"); Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", ��r.No(), ��r.Ad(), ��r.Eposta());
            ��r = new ��renci (1002, "Canan", "canan@gmail.com"); Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��r.No(), ��r.Ad(), ��r.Eposta());
            ��r = new ��renci (1003, "Belk�s", "belkis@gmail.com"); Console.WriteLine ("{0} no'lu ��renci {1}'�n epostas�: {2}", ��r.No(), ��r.Ad(), ��r.Eposta());

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}