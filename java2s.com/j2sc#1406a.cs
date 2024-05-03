// j2sc#1406a.cs: System.Threading.Timer ve System.Timers.Timer zamanlay�c�lar �rne�i.

using System;
using System.Threading; //Thread ve System.Threading.Timer i�in
//using System.Timers; //System.Timers.Timer i�in
namespace Geli�im {
    public class Zamanlay�c�S�n�f {
        public event EventHandler Elapsed;
        private void HerSaniye (object nsn, EventArgs oly) {if (Elapsed != null) Elapsed (nsn, oly);}
        private System.Timers.Timer Zamanlay�c�m = new System.Timers.Timer();
        public Zamanlay�c�S�n�f() {//Kurucu
            Zamanlay�c�m.Elapsed += HerSaniye;
            Zamanlay�c�m.Interval = 1000;
            Zamanlay�c�m.Enabled = true;
        }
    }
    class Zamanlay�c�A {
        private static void Zamanlay�c��� (object durum) {
            Console.WriteLine ("Sicim-{0}'deki akt�el zaman: [{1}]", Thread.CurrentThread.GetHashCode(), DateTime.Now);
            //Thread.Sleep (300); //Gereksiz
        }
        static void Mesajl�Zaman (object mesaj) {Console.WriteLine ("{0}, Saniyelik akt�el zaman: [{1}]", mesaj.ToString(), DateTime.Now.ToLongTimeString());}
        public static void TarihZaman (Object bilgi) {Console.WriteLine (DateTime.Now);}
        private static void Zamanlay�c�Testi (object mesaj) {Console.WriteLine ("Zamanlay�c� olay�! {0}", mesaj);}
        public static void Zamanlay�cY�netimiA (object ns, EventArgs ol) {Console.WriteLine ("Class A y�neticisi �a�r�ld�");}
        public static void Zamanlay�cY�netimiB (object ns, EventArgs ol) {Console.WriteLine ("Class B y�neticisi �a�r�ld�");}
        public static void Zamanlay�cY�netimiC (object ns, EventArgs ol) {Console.WriteLine ("Class C y�neticisi �a�r�ld�");}
        static void Main() {
            Console.Write ("Timer zamanlay�c� tiplemesinin arg�manlar�: TimerCallback tiplemeli tekrarl� metot �a��rma, metoda aktar�lacak object bilgi, ilk gecikme ms, tekrarl� aral�k ms'dir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 sn uykuda sadece ba�ka sicimlerde Zamanlay�c���() her 1 sn'de �a�r�lacak:");
            Timer zamanlay�c� = new Timer (new TimerCallback (Zamanlay�c���), null, 0, 1000);
            Thread.Sleep (5000); //Uyu, alt kodlamalar 5sn beklesin
            zamanlay�c�.Dispose(); //�� bitti, ��pe at

            Console.Write ("\nMesajl� her 1 saniyelik zaman (SS:dd.ss) sunumu:");
            TimerCallback tekrarl��a�r� = new TimerCallback (Mesajl�Zaman);
            zamanlay�c� = new Timer (
                tekrarl��a�r�, //TimerCallback delege tipi
                "Merhaba", //Tekrarl� �a�r�lan metoda aktar�lan mesaj
                0, //�lk �a�r� i�in bekleme s�resi (mS)
                1000); //Her �a�r� aras� bekleme s�resi (ms)
            Console.Write ("\nMesajl� zamanlay�c�dan ��k [Tu�]...\n"); Console.ReadKey();
            zamanlay�c�.Dispose();

            Console.Write ("\nHer 500 milisaniyelik zaman sunumu:");
            tekrarl��a�r� = new TimerCallback (TarihZaman);
            zamanlay�c� = new Timer (tekrarl��a�r�, null, 1000, 500); //1sn gecikmeyle her yar�m sn'de tarihi g�sterir
            Console.Write ("\nMesajl� zamanlay�c�dan ��k [Tu�]...\n"); Console.ReadKey();
            zamanlay�c�.Dispose(); zamanlay�c� = null;

            Console.WriteLine ("\nAk��� durduran 500ms'lik uykuda her 50ms'de tekrarlanan test olay�:");
            using (Timer z = new Timer (Zamanlay�c�Testi, "Test ediyorum...", 0, 50)) {
                Thread.Sleep (500);
                Console.WriteLine ("500ms doldu. Ak��a devam!..");
            }
            TimeSpan bekle = new TimeSpan (5000); //5sn
            new Timer (
                delegate (object blg) {Console.WriteLine ("{0}: [{1}]\n[Tu�]...", "Zaman", DateTime.Now.ToString ("HH:mm:ss.ffff"));},
                null, bekle, new TimeSpan (-1)); //Hi� tekrars�z tek zaman bildirimi

            Console.WriteLine ("\nHerhangi tu�a bas�ncaya dek 3 A-B-C-dlg d�ng�s� her sn'de �a�r�l�r:");
            Zamanlay�c�S�n�f zy = new Zamanlay�c�S�n�f(); 
            zy.Elapsed += Zamanlay�cY�netimiA;
            zy.Elapsed += Zamanlay�cY�netimiB;
            zy.Elapsed += Zamanlay�cY�netimiC;
            zy.Elapsed += delegate (object ns, EventArgs ol) {Console.WriteLine ("Bu bir anonim metottur.");};
            Thread.Sleep (5000); //5sn sonra tu� zy'yi sonland�r�r

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}