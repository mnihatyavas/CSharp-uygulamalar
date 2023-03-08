// jtpc#2306c.cs: Deconstruct-out ile yaratýlan nesnenin çoklu alan deðerlerini okuma örneði.

using System;
namespace YeniÖzellikler {
    public class Öðrenci{
        private int No;
        private string Ad;
        private string Eposta;
        public Öðrenci (int n, string a, string e) {
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
            Console.Write ("Karþýlýklý 'out' parametreli void Deconstruct/Al metodla çoklu ve karma tipli deðerleri okumak mümkündür.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            var öðrenci = new Öðrenci (1001, "Nur Küçükbay", "nrkucukbay@gmail.com");
            int no; string ad; string eposta;
            öðrenci.Al (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", no, ad, eposta);
            öðrenci = new Öðrenci (1002, "Yücel Küçükbay", "yckucukbay@gmail.com");
            öðrenci.Deconstruct (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", no, ad, eposta);
            öðrenci = new Öðrenci (1003, "Serap Küçükbay", "srkucukbay@gmail.com");
            öðrenci.Deconstruct (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", no, ad, eposta);
            öðrenci = new Öðrenci (1004, "Necat Küçükbay", "nckucukbay@gmail.com");
            öðrenci.Al (out no, out ad, out eposta);
            Console.WriteLine ("{0} no'lu öðrenci {1}'in epostasý: {2}", no, ad, eposta);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }

    }
}