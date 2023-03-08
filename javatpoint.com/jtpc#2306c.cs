// jtpc#2306c.cs: Deconstruct-out ile yarat�lan nesnenin �oklu alan de�erlerini okuma �rne�i.

using System;
namespace Yeni�zellikler {
    public class ��renci{
        private int No;
        private string Ad;
        private string Eposta;
        public ��renci (int n, string a, string e) {
            this.No = n;
            this.Ad = a;
            this.Eposta = e;
        }
        public void Deconstruct (out int a, out string b, out string c) {
            a  = this.No;
            b  = this.Ad;
            c = this.Eposta;
        }
        public void Al (out int a, out string b, out string c) {
            a  = this.No;
            b  = this.Ad;
            c = this.Eposta;
        }
    }
    class OutAl {
        static void Main() {
            Console.Write ("Kar��l�kl� 'out' parametreli void Deconstruct/Al metodla �oklu ve karma tipli de�erleri okumak m�mk�nd�r.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            var ��renci = new ��renci (1001, "Nur K���kbay", "nrkucukbay@gmail.com");
            int no; string ad; string eposta;
            ��renci.Al (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", no, ad, eposta);
            ��renci = new ��renci (1002, "Y�cel K���kbay", "yckucukbay@gmail.com");
            ��renci.Deconstruct (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", no, ad, eposta);
            ��renci = new ��renci (1003, "Serap K���kbay", "srkucukbay@gmail.com");
            ��renci.Deconstruct (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", no, ad, eposta);
            ��renci = new ��renci (1004, "Necat K���kbay", "nckucukbay@gmail.com");
            ��renci.Al (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu ��renci {1}'in epostas�: {2}", no, ad, eposta);

            Console.Write ("\nTu�..."); Console.ReadKey();
        }

    }
}