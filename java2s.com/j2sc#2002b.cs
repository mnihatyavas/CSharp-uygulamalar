// j2sc#2002b.cs: ThreadPool.QueueUserWorkItem(new WaitCallback(SicimMtodu), mesaj) örneði.

using System;
using System.Threading;
namespace SicimHavuzu {
    public class Yazýcý {
        private object kilitArmasý = new object();
        public void SayýlarýYaz() {
            lock (kilitArmasý) {//Join gibi herbir görevin tam bloklu icrasýný saðlar
                Console.WriteLine ("\n-> {0} nolu sicim SayýlarýYaz()'ý iþletiyor", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 10; i++) {Console.Write (i+" "); Thread.Sleep (10);}
            }
        }
    }
    public class SýnýfA {
        public RegisteredWaitHandle yönet = null;
        public string dizge = null;
    }
    public class SýnýfB {
        public string dizge;
        public double ds;
        public SýnýfB (string a, double b) {dizge = a; ds = b;} //Kurucu
    }
    class HavuzB {
        static void SayýlarýYaz (object durum) {//Yazýcý.SayýlarýYaz'la ayný ad karýþmaz
            Yazýcý iþ = (Yazýcý)durum; //WaitCallback iþ'le ayný ad karýþmaz
            iþ.SayýlarýYaz();
        }
        public const int Tekrar = 100;
        public static void ÝþiniYap (object nokta) {Console.WriteLine ("\n->{0} nolu sicim: ", Thread.CurrentThread.ManagedThreadId);for (int i = 0; i < Tekrar; i++) {Console.Write (nokta); Thread.Sleep (10);}}
        public static void BekleSüreci (object drm, bool bittiMi) {
            SýnýfA snfA = (SýnýfA) drm;
            if (bittiMi) {Console.WriteLine ("BekleSüreci({0}) {1} nolu sicimde çalýþmakta; durumu = {2}.", snfA.dizge, Thread.CurrentThread.GetHashCode(), "ÇALIÞMAYA DEVAM"); return;}
            if (snfA.yönet != null) {snfA.yönet.Unregister (null);}
            Console.WriteLine ("BekleSüreci({0}) {1} nolu sicimde çalýþmakta; durumu = {2}.", snfA.dizge, Thread.CurrentThread.GetHashCode(), "ÇALIÞMA BÝTTÝ");
        }
        static void SicimSüreci1 (Object drm) {SýnýfB snfB = (SýnýfB) drm; Console.WriteLine (snfB.dizge+snfB.ds);}
        static void SicimSüreci2 (Object drm) {SýnýfB snfB = (SýnýfB) drm; Console.WriteLine (snfB.dizge, snfB.ds);}
        static void Main() {
            Console.Write ("Lock da Join gibi herbir görevin tam bloklu bütün olarak icrasýný saðlar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("Herbiri 0-->9 yazan 5 sicimli görev icrasý:");
            int i;
            Console.WriteLine ("Main() sicim no = {0}", Thread.CurrentThread.ManagedThreadId);
            Yazýcý yzc = new Yazýcý();
            WaitCallback iþ = new WaitCallback (SayýlarýYaz);
            for (i = 0; i < 5; i++) ThreadPool.QueueUserWorkItem (iþ, yzc);

            Thread.Sleep (2000); Console.WriteLine ("\nJoin/lock'suz, herbiri 100 '.' koyan 5 sicim:");
            for(i=0;i<5;i++) ThreadPool.QueueUserWorkItem (ÝþiniYap, '.');
            for(i=0;i<Tekrar;i++) {Console.Write ('-'); Thread.Sleep (30);} //Noktayla çizgiler karýþýr

            Thread.Sleep (1000); Console.WriteLine ("\nVerili sürede çalýþmasýný sürdürdüðünü ve bitirdiðini bildiren sicim:");
            AutoResetEvent olay = new AutoResetEvent (false);
            SýnýfA snfA = new SýnýfA();
            snfA.dizge = "M.Nihat Yavaþ";
            snfA.yönet = ThreadPool.RegisterWaitForSingleObject (olay, new WaitOrTimerCallback (BekleSüreci), snfA, 50, false); //50 sn süre artýrýlýrsa sadece "ÇALIÞMA BÝTTÝ" okunur
            Thread.Sleep (300); olay.Set(); Thread.Sleep (100);

            Thread.Sleep (1000); Console.WriteLine ("\nSicimHavuz metodu SýnýfB'nin dizge ve sayýsýný yazmakta:");
            SýnýfB snfB = new SýnýfB ("M.NihatYavaþ--> ", 20240907);
            if (ThreadPool.QueueUserWorkItem (new WaitCallback (SicimSüreci1), snfB)) {    
                Thread.Sleep (1000);
                Console.WriteLine ("SicimSüreci() tamamlandý.");
            }else Console.WriteLine ("SicimHavuzu talebi icraen kuyruklanamadý."); 
            snfB = new SýnýfB ("Tarih(YYYYAAGG.SSDDss): {0:0.000000}", 20240907.203652);
            if (ThreadPool.QueueUserWorkItem (new WaitCallback (SicimSüreci2), snfB)) {    
                Thread.Sleep (1000);
                Console.WriteLine ("SicimSüreci() tamamlandý.");
            }else Console.WriteLine ("SicimHavuzu talebi icraen kuyruklanamadý."); 

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}