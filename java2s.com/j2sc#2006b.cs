// j2sc#2006b.cs: [ThreadStatic], Process, WaitHandle, Semaphore, Manual/AutoResetEvent örneði.

using System;
using System.Threading;
using System.Diagnostics; //Process, ProcessThreadCollection için
namespace ÝpTipleri {
    public class SýnýfA {
        public SýnýfA() {Console.WriteLine ("SýnýfA tiplemesi yaratýlýyor");} //Kurucu
    }
    public class StatikSicim {
        [ThreadStatic]
        public static SýnýfA snfA = new SýnýfA();
    }
    public class Görev {
        [ThreadStatic] 
        static int no = 2024;
        public string  ipAdý;
        public void Koþ (string ipAd) {
            ipAdý = ipAd;
            Thread ip = new Thread (new ThreadStart (süreç));
            ip.Start(); ip.Join();
        }
        public void süreç() {
            Console.WriteLine ("\t{0} koþuyor", ipAdý);
            for(int i = 0; i < 6; i++) Console.WriteLine ("{0} no = {1}", this.ipAdý, no++);
        }
    }
    class UyutucuSicim {
        AutoResetEvent otoYenileOlayý = new AutoResetEvent (false);
        public static WaitHandle BekletenYönetici() {
            UyutucuSicim us = new UyutucuSicim();
            Thread ip = new Thread (new ThreadStart (us.Uyut));
            ip.Start(); ip.Join();
            return (us.otoYenileOlayý);
        }
        public void Uyut() {
            Thread.Sleep (100);
            otoYenileOlayý.Set();
            Console.WriteLine ("\t-->AktüelSicim#: {0} 100mS uyuttu...", Thread.CurrentThread.ManagedThreadId);
        }
    }
    class SýnýfB {
        public Thread ip;
        static Semaphore izin = new Semaphore(1,1);
        public SýnýfB (string ad) {//Kurucu
            ip = new Thread (this.koþ);
            ip.Name = ad;
            ip.Start(); ip.Join();
        }  
        void koþ() {
            Console.WriteLine (ip.Name + " çalýþma izni bekliyor...");
            izin.WaitOne();
            Console.WriteLine (ip.Name + " çalýþma iznini aldý.");
            Console.WriteLine ("\t-->Ýþçi no: " + Thread.CurrentThread.GetHashCode());
            Thread.Sleep (50);
            Console.WriteLine (ip.Name + " çalýþma iznini býrakýyor.");
            izin.Release();
        }
    }
    class SýnýfC {
        public Thread ip;
        ManualResetEvent elleYenileOlayý;
        public SýnýfC (string ad, ManualResetEvent olay) {//Kurucu
            ip = new Thread (this.koþ);
            ip.Name = ad;  
            elleYenileOlayý = olay;
            ip.Start(); ip.Join();
        }
        void koþ() {
            Console.WriteLine ("\t{0} adlý sicim koþuyor...", ip.Name);
            for(int i=0; i<3; i++) {Console.WriteLine("\t-->Sicim no: " + Thread.CurrentThread.GetHashCode()); Thread.Sleep (50);}
            Console.WriteLine ("\t{0}/{1} koþusunu tamamladý.", ip.Name, ip.ManagedThreadId);
            elleYenileOlayý.Set();
        }
    }
    public class SýnýfD {
        public RegisteredWaitHandle kayýtlýBekleYönetimi = null;
        public string bilgi=null;
    } 
    class AktüelÝp {
        private static void ÝpFonk() {
            Console.WriteLine ("\tSicim#{0} baþlýyor...", Thread.CurrentThread.GetHashCode());
            Console.WriteLine ("StatikSicim.snfA: {0}", StatikSicim.snfA);
            Console.WriteLine ("Sicim#{0} sonlanýyor", Thread.CurrentThread.ManagedThreadId);
        }
        public static void ÝþlemSicimKoleksiyonu (int ÝþlemNo) {
            Process iþlem;
       mny: try {iþlem = Process.GetProcessById (ÝþlemNo);} catch {ÝþlemNo++; goto mny;}
            Console.WriteLine ("Ýþlem no: " + ÝþlemNo);
            Console.WriteLine ("Ýþlem adý: " + iþlem.ProcessName);
            ProcessThreadCollection ipler = iþlem.Threads;
            foreach (ProcessThread pt in ipler) Console.WriteLine ("-> Sicim No: {0}\tBaþlama zamaný: {1}\tÖncelik: {2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
        }
        public static AutoResetEvent otoYenileOlayý = new AutoResetEvent (false);
        public static int endeks = 0;
        public static void ZamanlayýcýYönetimi (object durum) {
            Console.Write ("ZamanlayýcýYönetimi: ");
            if (++endeks % 5 == 0) otoYenileOlayý.Set();
            Console.WriteLine (endeks);
        }
        private static void OlayYönetimi (object durum, bool zamanaþýmý) {
            Console.WriteLine ("-->{0}\tZamanaþýmý mý? {1}\tDurum: {2}\t{3}", endeks++, zamanaþýmý, durum, DateTime.Now.ToString ("HH:mm:ss.ffff"));
            if (endeks % 5 == 0) otoYenileOlayý.Set();
        }
        public static void BekletMetodu (object durum, bool zamanaþýmý) {
            SýnýfD snfD = (SýnýfD) durum;
            if (endeks==0 & zamanaþýmý) Console.WriteLine ("Mahmut " + snfD.bilgi + " Yavaþ");
            if (endeks == 10 && snfD.kayýtlýBekleYönetimi != null) snfD.kayýtlýBekleYönetimi.Unregister (null); //Döngü endeks=10'la sýnýrlý
            Console.WriteLine ("{0}/10-->BekletMetodu({1}) sicim#{2} ile {3} yürütülmekte..", endeks++, snfD.bilgi, Thread.CurrentThread.GetHashCode(), "OTOSÝNYALLÝ");
        }
        static void Main() {
            Console.Write ("[ThreadStatic]'in altýndaki statik sicim alanýdýr. Thread.CurrentThread.GetHashCode() veya Thread.CurrentThread.ManagedThreadId aynýdýr, aktüel sicim no'yu verir. Timer Dispose() ile, RegisteredWaitHandle ise Unregister(null) ile devredýþý býrakýlýr.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 join'li sicim statik sicim alanýyla SýnýfA tiplemesi yaratýyor:");
            int i; Thread ip;
            for(i=0;i<5;i++) {
                ip = new Thread (new ThreadStart (ÝpFonk));
                ip.Start(); ip.Join();
            }

            Thread.Sleep (1000); Console.WriteLine ("\n3 Koþ'lu sicimli görev ve 1 süreç'li sicimsiz görev:");
            Görev grv = new Görev(); grv.Koþ ("Sicim#1");
            grv = new Görev(); grv.Koþ ("Sicim#2");
            grv = new Görev(); grv.Koþ ("Sicim#3");
            grv = new Görev(); grv.ipAdý="Ustabaþý Main"; grv.süreç();

            Thread.Sleep (1000); Console.WriteLine ("\nBellekte aktif ilk süreç no, ad, ipleri, öncelikleri:");
            ÝþlemSicimKoleksiyonu (2000);

            Thread.Sleep (1000); Console.WriteLine ("\n5 BekletenYönetici'nin 5 sicimle 100mS'þer bekletmesi:");
            WaitHandle[] bekletenler = new WaitHandle [5];
            Console.WriteLine ("Sicimlerin tamamlanmasý bekleniyor...");
            for(i=0;i<5;i++) bekletenler [i] = UyutucuSicim.BekletenYönetici();
            WaitHandle.WaitAll (bekletenler);
            Console.WriteLine ("Bekleten sicimler tamamlandý");

            Thread.Sleep (1000); Console.WriteLine ("\n5 iþçi sicimi çalýþma izni bekliyor, alýyor ve býrakýyor:");
            SýnýfB snfB;
            for(i=0;i<5;i++) snfB = new SýnýfB ("Ýþçi#" + (i+1));

            Thread.Sleep (1000); Console.WriteLine ("\nElleYenileOlay'lý 5 sicim 3'er kerre koþmakta:");
            ManualResetEvent elleYenileOlayý = new ManualResetEvent (false);
            SýnýfC snfC;
            Console.WriteLine ("{0} no'lu ana sicim olaylý sicimleri bekliyor...", Thread.CurrentThread.ManagedThreadId);
            for(i=0;i<5;i++) {
                snfC = new SýnýfC ("OlaylýSicim#"+(i+1), elleYenileOlayý);
                elleYenileOlayý.WaitOne();
                Console.WriteLine ("Ana sicim {0}.olayý tamamladý.", i+1);
                elleYenileOlayý.Reset(); 
            }

            Thread.Sleep (1000); Console.WriteLine ("\n4 OtoYenileOlay'lý herbiri 5'er kez yenileyen zamanlayýcý:");
            Timer zamanlayýcý;
            for(i=0;i<4;i++) {
                zamanlayýcý = new Timer (new TimerCallback (ZamanlayýcýYönetimi), null, 50, 100);
                otoYenileOlayý.WaitOne();
                Console.WriteLine ("Zamanlayýcý {0}.nci sinyalini tamamladý.", i+1);
                zamanlayýcý.Dispose();
            }

            Thread.Sleep (1000); Console.WriteLine ("\nHer 1sn'de yinelenen RegisteredWaitHandle Thread.Sleep(18000)'le sýnýrlanýr:");
            otoYenileOlayý = new AutoResetEvent (false);
            endeks = 0;
            string durum = "Oto sinyalli.";
            RegisteredWaitHandle kayýtlýBekleYönetimi = null;
            kayýtlýBekleYönetimi = ThreadPool.RegisterWaitForSingleObject (otoYenileOlayý, OlayYönetimi, durum, 1000, false);
            Thread.Sleep (17500);
            Console.WriteLine ("Bekle iþlemi kayýt dýþý býrakýlýyor.");
            kayýtlýBekleYönetimi.Unregister (null);

            Thread.Sleep (1000); Console.WriteLine ("\nHer 10msn'de yinelenen RegisteredWaitHandle döngüsü endeks=10 ile sýnýrlanýr:");
            otoYenileOlayý = new AutoResetEvent (false);
            endeks = 0;
            SýnýfD snfD = new SýnýfD();
            snfD.bilgi = "Nihat";
            snfD.kayýtlýBekleYönetimi = ThreadPool.RegisterWaitForSingleObject (otoYenileOlayý, new WaitOrTimerCallback (BekletMetodu), snfD, 10, false);
            //otoYenileOlayý.Set();
            Thread.Sleep (1000);
            Console.WriteLine ("Bekle iþlemi [snfD.kayýtlýBekleYönetimi.Unregister(null)] ile kayýt dýþý býrakýldý.");

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}