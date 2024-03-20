// j2sc#1401.cs: Application'la Form'dan çýkýþ ve sol-týklama mesajlarý örneði.

using System;
using System.Windows.Forms; //Application için
using System.Threading; //ThreadExceptionEventArgs için
using System.Configuration; //AppSettingsReader için
namespace Geliþimler {
    public class SolTýklamaMesajý : IMessageFilter {
        const int SOLTIKLAMA = 0x201;
        public bool PreFilterMessage (ref Message m) {
            if (m.Msg == SOLTIKLAMA) {
                Exception SolTýklamaÝstisnasý;
                SolTýklamaÝstisnasý = new Exception ("Form üzerinde sol fare týklandý...");
                Application.OnThreadException (SolTýklamaÝstisnasý);
                return true;
            }
            return false;
        }
    }
    public class UygulamaOlayYönetimi {
        public void OnThreadException (object gönderen, ThreadExceptionEventArgs olay) {
            Exception SolTýklamaÝstisnasý;
            SolTýklamaÝstisnasý = olay.Exception;
            Console.WriteLine (SolTýklamaÝstisnasý.Message);
        }
    }
    class Uygulama : Form {//Tiplemesi varsayýlý Form'u sunar
        public Uygulama() {//Kurucu
            Console.WriteLine ("Þirket adý: [{0}]", Application.CompanyName);
            Console.WriteLine ("Ürün adý: [{0}]", Application.ProductName);
            Console.WriteLine ("Uygulama adresi: [{0}]", Application.StartupPath);
            Application.ApplicationExit += new EventHandler (FormdanÇýkýþ);
            Text = "Form Çýkýþ ve SolTýkla Testi";
        }
        private void FormdanÇýkýþ (object gönderen, EventArgs olayArgümanlarý) {Console.WriteLine ("Form'dan çýktým...");}
        static void Main() {
            Console.Write ("Application/Uygulama için 'using System.Windows.Forms' ve Form'un tezahürü için Main() sýnýfý ebeveyni ':System.Windows.Forms.Form' veya kýsaca ':Form' gerekmektedir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Uygulama bilgileri, Form ve çýkýþ mesajý:");
            Console.WriteLine ("Uygulama baþlangýç yolu: " + Application.StartupPath);
            Application.Run (new Uygulama());

            Console.WriteLine ("\n2.Form'da sol fare týklama istisna mesajlý sicimli olay yönetimi:");
            UygulamaOlayYönetimi týklamaOlayYönetimi = new UygulamaOlayYönetimi();
            Uygulama formluUygulama = new Uygulama();
            SolTýklamaMesajý týklamaMesajý = new SolTýklamaMesajý();
            Application.AddMessageFilter (týklamaMesajý);
            Application.ThreadException += new ThreadExceptionEventHandler (týklamaOlayYönetimi.OnThreadException);
            Application.Run (formluUygulama);

            Console.WriteLine ("\n:");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}