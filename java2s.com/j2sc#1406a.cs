// j2sc#1406a.cs: System.Threading.Timer ve System.Timers.Timer zamanlayýcýlar örneði.

using System;
using System.Threading; //Thread ve System.Threading.Timer için
//using System.Timers; //System.Timers.Timer için
namespace Geliþim {
    public class ZamanlayýcýSýnýf {
        public event EventHandler Elapsed;
        private void HerSaniye (object nsn, EventArgs oly) {if (Elapsed != null) Elapsed (nsn, oly);}
        private System.Timers.Timer Zamanlayýcým = new System.Timers.Timer();
        public ZamanlayýcýSýnýf() {//Kurucu
            Zamanlayýcým.Elapsed += HerSaniye;
            Zamanlayýcým.Interval = 1000;
            Zamanlayýcým.Enabled = true;
        }
    }
    class ZamanlayýcýA {
        private static void ZamanlayýcýÝþ (object durum) {
            Console.WriteLine ("Sicim-{0}'deki aktüel zaman: [{1}]", Thread.CurrentThread.GetHashCode(), DateTime.Now);
            //Thread.Sleep (300); //Gereksiz
        }
        static void MesajlýZaman (object mesaj) {Console.WriteLine ("{0}, Saniyelik aktüel zaman: [{1}]", mesaj.ToString(), DateTime.Now.ToLongTimeString());}
        public static void TarihZaman (Object bilgi) {Console.WriteLine (DateTime.Now);}
        private static void ZamanlayýcýTesti (object mesaj) {Console.WriteLine ("Zamanlayýcý olayý! {0}", mesaj);}
        public static void ZamanlayýcYönetimiA (object ns, EventArgs ol) {Console.WriteLine ("Class A yöneticisi çaðrýldý");}
        public static void ZamanlayýcYönetimiB (object ns, EventArgs ol) {Console.WriteLine ("Class B yöneticisi çaðrýldý");}
        public static void ZamanlayýcYönetimiC (object ns, EventArgs ol) {Console.WriteLine ("Class C yöneticisi çaðrýldý");}
        static void Main() {
            Console.Write ("Timer zamanlayýcý tiplemesinin argümanlarý: TimerCallback tiplemeli tekrarlý metot çaðýrma, metoda aktarýlacak object bilgi, ilk gecikme ms, tekrarlý aralýk ms'dir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 sn uykuda sadece baþka sicimlerde ZamanlayýcýÝþ() her 1 sn'de çaðrýlacak:");
            Timer zamanlayýcý = new Timer (new TimerCallback (ZamanlayýcýÝþ), null, 0, 1000);
            Thread.Sleep (5000); //Uyu, alt kodlamalar 5sn beklesin
            zamanlayýcý.Dispose(); //Ýþ bitti, çöpe at

            Console.Write ("\nMesajlý her 1 saniyelik zaman (SS:dd.ss) sunumu:");
            TimerCallback tekrarlýÇaðrý = new TimerCallback (MesajlýZaman);
            zamanlayýcý = new Timer (
                tekrarlýÇaðrý, //TimerCallback delege tipi
                "Merhaba", //Tekrarlý çaðrýlan metoda aktarýlan mesaj
                0, //Ýlk çaðrý için bekleme süresi (mS)
                1000); //Her çaðrý arasý bekleme süresi (ms)
            Console.Write ("\nMesajlý zamanlayýcýdan çýk [Tuþ]...\n"); Console.ReadKey();
            zamanlayýcý.Dispose();

            Console.Write ("\nHer 500 milisaniyelik zaman sunumu:");
            tekrarlýÇaðrý = new TimerCallback (TarihZaman);
            zamanlayýcý = new Timer (tekrarlýÇaðrý, null, 1000, 500); //1sn gecikmeyle her yarým sn'de tarihi gösterir
            Console.Write ("\nMesajlý zamanlayýcýdan çýk [Tuþ]...\n"); Console.ReadKey();
            zamanlayýcý.Dispose(); zamanlayýcý = null;

            Console.WriteLine ("\nAkýþý durduran 500ms'lik uykuda her 50ms'de tekrarlanan test olayý:");
            using (Timer z = new Timer (ZamanlayýcýTesti, "Test ediyorum...", 0, 50)) {
                Thread.Sleep (500);
                Console.WriteLine ("500ms doldu. Akýþa devam!..");
            }
            TimeSpan bekle = new TimeSpan (5000); //5sn
            new Timer (
                delegate (object blg) {Console.WriteLine ("{0}: [{1}]\n[Tuþ]...", "Zaman", DateTime.Now.ToString ("HH:mm:ss.ffff"));},
                null, bekle, new TimeSpan (-1)); //Hiç tekrarsýz tek zaman bildirimi

            Console.WriteLine ("\nHerhangi tuþa basýncaya dek 3 A-B-C-dlg döngüsü her sn'de çaðrýlýr:");
            ZamanlayýcýSýnýf zy = new ZamanlayýcýSýnýf(); 
            zy.Elapsed += ZamanlayýcYönetimiA;
            zy.Elapsed += ZamanlayýcYönetimiB;
            zy.Elapsed += ZamanlayýcYönetimiC;
            zy.Elapsed += delegate (object ns, EventArgs ol) {Console.WriteLine ("Bu bir anonim metottur.");};
            Thread.Sleep (5000); //5sn sonra tuþ zy'yi sonlandýrýr

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}