// j2sc#2002b.cs: ThreadPool.QueueUserWorkItem(new WaitCallback(SicimMtodu), mesaj) �rne�i.

using System;
using System.Threading;
namespace SicimHavuzu {
    public class Yaz�c� {
        private object kilitArmas� = new object();
        public void Say�lar�Yaz() {
            lock (kilitArmas�) {//Join gibi herbir g�revin tam bloklu icras�n� sa�lar
                Console.WriteLine ("\n-> {0} nolu sicim Say�lar�Yaz()'� i�letiyor", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10; i++) {Console.Write (i+" "); Thread.Sleep (10);}
            }
        }
    }
    public class S�n�fA {
        public RegisteredWaitHandle y�net = null;
        public string dizge = null;
    }
    public class S�n�fB {
        public string dizge;
        public double ds;
        public S�n�fB (string a, double b) {dizge = a; ds = b;} //Kurucu
    }
    class HavuzB {
        static void Say�lar�Yaz (object durum) {//Yaz�c�.Say�lar�Yaz'la ayn� ad kar��maz
            Yaz�c� i� = (Yaz�c�)durum; //WaitCallback i�'le ayn� ad kar��maz
            i�.Say�lar�Yaz();
        }
        public const int Tekrar = 100;
        public static void ��iniYap (object nokta) {Console.WriteLine ("\n->{0} nolu sicim: ", Thread.CurrentThread.ManagedThreadId);for (int i = 0; i < Tekrar; i++) {Console.Write (nokta); Thread.Sleep (10);}}
        public static void BekleS�reci (object drm, bool bittiMi) {
            S�n�fA snfA = (S�n�fA) drm;
            if (bittiMi) {Console.WriteLine ("BekleS�reci({0}) {1} nolu sicimde �al��makta; durumu = {2}.", snfA.dizge, Thread.CurrentThread.GetHashCode(), "�ALI�MAYA DEVAM"); return;}
            if (snfA.y�net != null) {snfA.y�net.Unregister (null);}
            Console.WriteLine ("BekleS�reci({0}) {1} nolu sicimde �al��makta; durumu = {2}.", snfA.dizge, Thread.CurrentThread.GetHashCode(), "�ALI�MA B�TT�");
        }
        static void SicimS�reci1 (Object drm) {S�n�fB snfB = (S�n�fB) drm; Console.WriteLine (snfB.dizge+snfB.ds);}
        static void SicimS�reci2 (Object drm) {S�n�fB snfB = (S�n�fB) drm; Console.WriteLine (snfB.dizge, snfB.ds);}
        static void Main() {
            Console.Write ("Lock da Join gibi herbir g�revin tam bloklu b�t�n olarak icras�n� sa�lar.\nTu�...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Herbiri 0-->9 yazan 5 sicimli g�rev icras�:");
            int i;
            Console.WriteLine ("Main() sicim no = {0}", Thread.CurrentThread.ManagedThreadId);
            Yaz�c� yzc = new Yaz�c�();
            WaitCallback i� = new WaitCallback (Say�lar�Yaz);
            for (i = 0; i < 5; i++) ThreadPool.QueueUserWorkItem (i�, yzc);

            Thread.Sleep (2000); Console.WriteLine ("\nJoin/lock'suz, herbiri 100 '.' koyan 5 sicim:");
            for(i=0;i<5;i++) ThreadPool.QueueUserWorkItem (��iniYap, '.');
            for(i=0;i<Tekrar;i++) {Console.Write ('-'); Thread.Sleep (30);} //Noktayla �izgiler kar���r

            Thread.Sleep (1000); Console.WriteLine ("\nVerili s�rede �al��mas�n� s�rd�rd���n� ve bitirdi�ini bildiren sicim:");
            AutoResetEvent olay = new AutoResetEvent (false);
            S�n�fA snfA = new S�n�fA();
            snfA.dizge = "M.Nihat Yava�";
            snfA.y�net = ThreadPool.RegisterWaitForSingleObject (olay, new WaitOrTimerCallback (BekleS�reci), snfA, 50, false); //50 sn s�re art�r�l�rsa sadece "�ALI�MA B�TT�" okunur
            Thread.Sleep (300); olay.Set(); Thread.Sleep (100);

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuz metodu S�n�fB'nin dizge ve say�s�n� yazmakta:");
            S�n�fB snfB = new S�n�fB ("M.NihatYava�--> ", 20240907);
            if (ThreadPool.QueueUserWorkItem (new WaitCallback (SicimS�reci1), snfB)) {    
                Thread.Sleep (1000);
                Console.WriteLine ("SicimS�reci() tamamland�.");
            }else Console.WriteLine ("SicimHavuzu talebi icraen kuyruklanamad�."); 
            snfB = new S�n�fB ("Tarih(YYYYAAGG.SSDDss): {0:0.000000}", 20240907.203652);
            if (ThreadPool.QueueUserWorkItem (new WaitCallback (SicimS�reci2), snfB)) {    
                Thread.Sleep (1000);
                Console.WriteLine ("SicimS�reci() tamamland�.");
            }else Console.WriteLine ("SicimHavuzu talebi icraen kuyruklanamad�."); 

            Console.Write ("\nTu�..."); Console.ReadKey();
        }
    } 
}