// j2sc#1406b.cs: örneði.

using System;
using System.Threading; //Thread, System.Threading.Timer ve TimerCallback için
//using System.Timers; //ElapsedEventArgs ve ElapsedEventHandler için
namespace Geliþimler {
    public delegate void MesajYönetimi (string mesajMetni);
    public class Baðlantý {
        public event MesajYönetimi MesajGeldi;
        public System.Timers.Timer zamanlayýcý;
        public Baðlantý() {//Kurucu
            zamanlayýcý = new System.Timers.Timer (1000);
            zamanlayýcý.Elapsed += new System.Timers.ElapsedEventHandler (MesajKontrolu);
            zamanlayýcý.Start();
        }
        private void MesajKontrolu (object bilgi, System.Timers.ElapsedEventArgs oly) {MesajGeldi ("Hey sesimi duyan yok mu?");}
    }
    class ZamanlayýcýB {
        private static void SinyalVakti (object gönderen, System.Timers.ElapsedEventArgs oly) {Console.WriteLine ("System.Timers.Timer'la 1sn'lik SinyalVakti: [{0}]", oly.SignalTime);}
        public static void VakitKontrolu (Object bilgi) {Console.WriteLine ("System.Threading.Timer'la 0.5sn'lik VakitKontrolu: [{0}]", DateTime.Now);}
        public static void MesajýGöster (string mesaj) {Console.WriteLine ("{0} zamanlý mesaj: [{1}]", DateTime.Now.ToString ("HH:mm:ss.ffff"), mesaj);}
        static void VaktiGöster (object bilgi) {Console.WriteLine ("\t{0}: [{1}]", bilgi.ToString(), DateTime.Now);}
        static int _Sayaç=0;
        static AutoResetEvent _YeniOlay = new AutoResetEvent (false);
        static int _AlarmÝpNo;
        static void Alarm (object gönderen, System.Timers.ElapsedEventArgs olay) {
            Console.WriteLine ("{0}: {1}", olay.SignalTime.ToString ("T"), ++_Sayaç);
            if (_Sayaç >= 10) {
                _AlarmÝpNo = Thread.CurrentThread.ManagedThreadId;
                _YeniOlay.Set();
            }
        }
        static void Alarm2 (object bilgi) {
            Console.WriteLine ("{0} = {1}", DateTime.Now.ToString ("T"), ++_Sayaç);
            if (_Sayaç >= 5) {
                _AlarmÝpNo = Thread.CurrentThread.ManagedThreadId;
                _YeniOlay.Set();
            }
        }
        static int sayaç = 1881;
        static void SayaçYaz (object bilgi, System.Timers.ElapsedEventArgs olay) {Console.Write (sayaç++ + " ");}
        static void Main() {
            Console.Write ("Ýçiçe kullanýlan System.Threading ve System.Timers tiplemeleri, ayrýca Dispose() zamanlarý ReadKey(), Read() ve ReadLine()'la birbirlerinden dikkatlice yalýtýlmalýdýr. Varsayýlý 'using System.Threading' önceliði ve using'siz 'System.Timers.Timer' uzun yazýlým yöntemi tercih edilmelidir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("System.Timers.Timer ve System.Threading.Timer'la zamanlayýcýlar:");
            System.Timers.Timer zamanlayýcý1 = new System.Timers.Timer();
            double araSüre = 1000; //1sn
            zamanlayýcý1.Interval = araSüre;
            zamanlayýcý1.AutoReset = true;
            zamanlayýcý1.Elapsed += new System.Timers.ElapsedEventHandler (SinyalVakti);
            zamanlayýcý1.Start(); //Start sonrasý herhanagi tuþ, kýrar
            Console.WriteLine ("Enter..."); Console.ReadLine();
            zamanlayýcý1.Dispose(); zamanlayýcý1 = null; //Çerçöp temizliði
            TimerCallback tekrarlýÇaðrý = new TimerCallback (VakitKontrolu);
            Timer zamanlayýcý2 = new Timer (tekrarlýÇaðrý, null, 1000, 500); //1 sn gecikmeyle 0.5 sn'lik zaman beyaný
            Console.WriteLine ("Enter..."); Console.ReadLine();
            zamanlayýcý2.Dispose(); zamanlayýcý2 = null; //Çerçöp temizliði

            Console.WriteLine ("Çift zamanlayýcýyla her saniye gelen vakitli mesaj ve tarihin karma sunulmasý:");
            Baðlantý baðlantým = new Baðlantý();
            baðlantým.MesajGeldi += new MesajYönetimi (MesajýGöster);
            TimerCallback tcb = new TimerCallback (VaktiGöster);
            Timer t = new Timer (tcb, "Tarih ve zaman", 0, 1000);
            Console.WriteLine ("Enter..."); Console.ReadLine();
            baðlantým.zamanlayýcý.Dispose(); baðlantým.zamanlayýcý=null;
            t.Dispose(); t=null;

            Console.WriteLine ("Sicim olaylý sayaç, özel istisna ve son deðerleri:");
            Console.WriteLine ("\tSystem.Timers.Timer() ile sayaç[1,10]:");
            using (zamanlayýcý1 = new System.Timers.Timer()) {
                zamanlayýcý1.AutoReset = true;
                zamanlayýcý1.Interval = 1000;
                zamanlayýcý1.Elapsed += new System.Timers.ElapsedEventHandler (Alarm);
                zamanlayýcý1.Start();
                _YeniOlay.WaitOne();
            }
            if (_AlarmÝpNo == Thread.CurrentThread.ManagedThreadId) throw new ApplicationException ("Sicim No'lar ayný.");
            try {throw new ApplicationException ("Yeni Uygulama Ýstisnasý");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("Alarm sicim no: {0}", _AlarmÝpNo);
            Console.WriteLine ("Yönetilen aktüel sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("Son sayaç no: {0}", _Sayaç);
            Console.WriteLine ("\tSystem.Threading.Timer() ile sayaç[1,5]:"); _Sayaç=0;
            using (t = new Timer (Alarm2, null, 0, 1000)) {_YeniOlay.WaitOne();}
            if (_AlarmÝpNo == Thread.CurrentThread.ManagedThreadId) throw new ApplicationException ("Sicim No'lar ayný.");
            try {throw new ApplicationException ("_Sayaç <= 5");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("Alarm sicim no: {0}", _AlarmÝpNo);
            Console.WriteLine ("Yönetilen aktüel sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("Son sayaç no: {0}", _Sayaç);

            Console.WriteLine ("\nEnter'a deðin sayaç [1881, oo]:");
            zamanlayýcý1 = new System.Timers.Timer (100); //Her 100 ms'de artan yýllar
            zamanlayýcý1.Elapsed += new System.Timers.ElapsedEventHandler (SayaçYaz);
            zamanlayýcý1.Start();
            Console.Write ("Enter...\n"); Console.ReadLine();
            zamanlayýcý1.Dispose(); zamanlayýcý1=null;

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}