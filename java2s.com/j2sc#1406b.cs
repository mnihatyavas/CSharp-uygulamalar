// j2sc#1406b.cs: �rne�i.

using System;
using System.Threading; //Thread, System.Threading.Timer ve TimerCallback i�in
//using System.Timers; //ElapsedEventArgs ve ElapsedEventHandler i�in
namespace Geli�imler {
    public delegate void MesajY�netimi (string mesajMetni);
    public class Ba�lant� {
        public event MesajY�netimi MesajGeldi;
        public System.Timers.Timer zamanlay�c�;
        public Ba�lant�() {//Kurucu
            zamanlay�c� = new System.Timers.Timer (1000);
            zamanlay�c�.Elapsed += new System.Timers.ElapsedEventHandler (MesajKontrolu);
            zamanlay�c�.Start();
        }
        private void MesajKontrolu (object bilgi, System.Timers.ElapsedEventArgs oly) {MesajGeldi ("Hey sesimi duyan yok mu?");}
    }
    class Zamanlay�c�B {
        private static void SinyalVakti (object g�nderen, System.Timers.ElapsedEventArgs oly) {Console.WriteLine ("System.Timers.Timer'la 1sn'lik SinyalVakti: [{0}]", oly.SignalTime);}
        public static void VakitKontrolu (Object bilgi) {Console.WriteLine ("System.Threading.Timer'la 0.5sn'lik VakitKontrolu: [{0}]", DateTime.Now);}
        public static void Mesaj�G�ster (string mesaj) {Console.WriteLine ("{0} zamanl� mesaj: [{1}]", DateTime.Now.ToString ("HH:mm:ss.ffff"), mesaj);}
        static void VaktiG�ster (object bilgi) {Console.WriteLine ("\t{0}: [{1}]", bilgi.ToString(), DateTime.Now);}
        static int _Saya�=0;
        static AutoResetEvent _YeniOlay = new AutoResetEvent (false);
        static int _Alarm�pNo;
        static void Alarm (object g�nderen, System.Timers.ElapsedEventArgs olay) {
            Console.WriteLine ("{0}: {1}", olay.SignalTime.ToString ("T"), ++_Saya�);
            if (_Saya� >= 10) {
                _Alarm�pNo = Thread.CurrentThread.ManagedThreadId;
                _YeniOlay.Set();
            }
        }
        static void Alarm2 (object bilgi) {
            Console.WriteLine ("{0} = {1}", DateTime.Now.ToString ("T"), ++_Saya�);
            if (_Saya� >= 5) {
                _Alarm�pNo = Thread.CurrentThread.ManagedThreadId;
                _YeniOlay.Set();
            }
        }
        static int saya� = 1881;
        static void Saya�Yaz (object bilgi, System.Timers.ElapsedEventArgs olay) {Console.Write (saya�++ + " ");}
        static void Main() {
            Console.Write ("��i�e kullan�lan System.Threading ve System.Timers tiplemeleri, ayr�ca Dispose() zamanlar� ReadKey(), Read() ve ReadLine()'la birbirlerinden dikkatlice yal�t�lmal�d�r. Varsay�l� 'using System.Threading' �nceli�i ve using'siz 'System.Timers.Timer' uzun yaz�l�m y�ntemi tercih edilmelidir.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("System.Timers.Timer ve System.Threading.Timer'la zamanlay�c�lar:");
            System.Timers.Timer zamanlay�c�1 = new System.Timers.Timer();
            double araS�re = 1000; //1sn
            zamanlay�c�1.Interval = araS�re;
            zamanlay�c�1.AutoReset = true;
            zamanlay�c�1.Elapsed += new System.Timers.ElapsedEventHandler (SinyalVakti);
            zamanlay�c�1.Start(); //Start sonras� herhanagi tu�, k�rar
            Console.WriteLine ("Enter..."); Console.ReadLine();
            zamanlay�c�1.Dispose(); zamanlay�c�1 = null; //�er��p temizli�i
            TimerCallback tekrarl��a�r� = new TimerCallback (VakitKontrolu);
            Timer zamanlay�c�2 = new Timer (tekrarl��a�r�, null, 1000, 500); //1 sn gecikmeyle 0.5 sn'lik zaman beyan�
            Console.WriteLine ("Enter..."); Console.ReadLine();
            zamanlay�c�2.Dispose(); zamanlay�c�2 = null; //�er��p temizli�i

            Console.WriteLine ("�ift zamanlay�c�yla her saniye gelen vakitli mesaj ve tarihin karma sunulmas�:");
            Ba�lant� ba�lant�m = new Ba�lant�();
            ba�lant�m.MesajGeldi += new MesajY�netimi (Mesaj�G�ster);
            TimerCallback tcb = new TimerCallback (VaktiG�ster);
            Timer t = new Timer (tcb, "Tarih ve zaman", 0, 1000);
            Console.WriteLine ("Enter..."); Console.ReadLine();
            ba�lant�m.zamanlay�c�.Dispose(); ba�lant�m.zamanlay�c�=null;
            t.Dispose(); t=null;

            Console.WriteLine ("Sicim olayl� saya�, �zel istisna ve son de�erleri:");
            Console.WriteLine ("\tSystem.Timers.Timer() ile saya�[1,10]:");
            using (zamanlay�c�1 = new System.Timers.Timer()) {
                zamanlay�c�1.AutoReset = true;
                zamanlay�c�1.Interval = 1000;
                zamanlay�c�1.Elapsed += new System.Timers.ElapsedEventHandler (Alarm);
                zamanlay�c�1.Start();
                _YeniOlay.WaitOne();
            }
            if (_Alarm�pNo == Thread.CurrentThread.ManagedThreadId) throw new ApplicationException ("Sicim No'lar ayn�.");
            try {throw new ApplicationException ("Yeni Uygulama �stisnas�");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("Alarm sicim no: {0}", _Alarm�pNo);
            Console.WriteLine ("Y�netilen akt�el sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("Son saya� no: {0}", _Saya�);
            Console.WriteLine ("\tSystem.Threading.Timer() ile saya�[1,5]:"); _Saya�=0;
            using (t = new Timer (Alarm2, null, 0, 1000)) {_YeniOlay.WaitOne();}
            if (_Alarm�pNo == Thread.CurrentThread.ManagedThreadId) throw new ApplicationException ("Sicim No'lar ayn�.");
            try {throw new ApplicationException ("_Saya� <= 5");}catch (Exception ht) {Console.WriteLine ("HATA: [{0}]", ht.Message);}
            Console.WriteLine ("Alarm sicim no: {0}", _Alarm�pNo);
            Console.WriteLine ("Y�netilen akt�el sicim no: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine ("Son saya� no: {0}", _Saya�);

            Console.WriteLine ("\nEnter'a de�in saya� [1881, oo]:");
            zamanlay�c�1 = new System.Timers.Timer (100); //Her 100 ms'de artan y�llar
            zamanlay�c�1.Elapsed += new System.Timers.ElapsedEventHandler (Saya�Yaz);
            zamanlay�c�1.Start();
            Console.Write ("Enter...\n"); Console.ReadLine();
            zamanlay�c�1.Dispose(); zamanlay�c�1=null;

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}