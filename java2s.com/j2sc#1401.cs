// j2sc#1401.cs: Application'la Form'dan ��k�� ve sol-t�klama mesajlar� �rne�i.

using System;
using System.Windows.Forms; //Application i�in
using System.Threading; //ThreadExceptionEventArgs i�in
using System.Configuration; //AppSettingsReader i�in
namespace Geli�imler {
    public class SolT�klamaMesaj� : IMessageFilter {
        const int SOLTIKLAMA = 0x201;
        public bool PreFilterMessage (ref Message m) {
            if (m.Msg == SOLTIKLAMA) {
                Exception SolT�klama�stisnas�;
                SolT�klama�stisnas� = new Exception ("Form �zerinde sol fare t�kland�...");
                Application.OnThreadException (SolT�klama�stisnas�);
                return true;
            }
            return false;
        }
    }
    public class UygulamaOlayY�netimi {
        public void OnThreadException (object g�nderen, ThreadExceptionEventArgs olay) {
            Exception SolT�klama�stisnas�;
            SolT�klama�stisnas� = olay.Exception;
            Console.WriteLine (SolT�klama�stisnas�.Message);
        }
    }
    class Uygulama : Form {//Tiplemesi varsay�l� Form'u sunar
        public Uygulama() {//Kurucu
            Console.WriteLine ("�irket ad�: [{0}]", Application.CompanyName);
            Console.WriteLine ("�r�n ad�: [{0}]", Application.ProductName);
            Console.WriteLine ("Uygulama adresi: [{0}]", Application.StartupPath);
            Application.ApplicationExit += new EventHandler (Formdan��k��);
            Text = "Form ��k�� ve SolT�kla Testi";
        }
        private void Formdan��k�� (object g�nderen, EventArgs olayArg�manlar�) {Console.WriteLine ("Form'dan ��kt�m...");}
        static void Main() {
            Console.Write ("Application/Uygulama i�in 'using System.Windows.Forms' ve Form'un tezah�r� i�in Main() s�n�f� ebeveyni ':System.Windows.Forms.Form' veya k�saca ':Form' gerekmektedir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Uygulama bilgileri, Form ve ��k�� mesaj�:");
            Console.WriteLine ("Uygulama ba�lang�� yolu: " + Application.StartupPath);
            Application.Run (new Uygulama());

            Console.WriteLine ("\n2.Form'da sol fare t�klama istisna mesajl� sicimli olay y�netimi:");
            UygulamaOlayY�netimi t�klamaOlayY�netimi = new UygulamaOlayY�netimi();
            Uygulama formluUygulama = new Uygulama();
            SolT�klamaMesaj� t�klamaMesaj� = new SolT�klamaMesaj�();
            Application.AddMessageFilter (t�klamaMesaj�);
            Application.ThreadException += new ThreadExceptionEventHandler (t�klamaOlayY�netimi.OnThreadException);
            Application.Run (formluUygulama);

            Console.WriteLine ("\n:");

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}