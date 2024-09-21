// j2sc#2004b.cs: Ortak lock(kilit)'li Monitor.Enter/TryEnter/Exit/Wait/Pulse örneði.

using System;
using System.Threading;
namespace Sicimler {
    class VeriTabaný {
        public void VeriKaydet (string veri) {
            Console.WriteLine ("[VeriKaydet-{0}] baþladý", veri);
            Monitor.Enter (this);
            Console.WriteLine("[VeriKaydet-{0}] çalýþýyor...", veri);
            //throw new Exception ("HATA!");
            for(int i = 0; i < 50; i++) {
                Thread.Sleep (10);
                Console.Write (veri);
            }
            Monitor.Exit (this);
            Console.WriteLine ("\n[VeriKaydet-{0}] bitti", veri);
        }
    }
    public class Üretici {
        private Veri veri;
        public Üretici (Veri veri) {this.veri = veri;} //Kurucu
        public void koþ() {for(int i=0;i<20;i++) {veri.üret(); Thread.Sleep (100);}} //for(int i=0;i<20;i++) {
    }
    public class Tüketici {
        private Veri veri;
        public Tüketici (Veri veri) {this.veri = veri;}
        public void koþ() {for(int i=0;i<20;i++) {veri.tüket(); Thread.Sleep (100);}}
    }
    public class Veri {
        int sayaç=0;
        bool hazýrMý = false;
        public void üret() {
            lock (this) {
                if (hazýrMý) Monitor.Wait (this);
                sayaç++;
                Console.Write ("Üretilen: "+sayaç+"==>\t");
                hazýrMý = true;
                Monitor.Pulse (this);
            }
        }
        public void tüket() {
            lock (this) {
                if (!hazýrMý) Monitor.Wait (this);
                Console.WriteLine ("Tüketilen: "+sayaç); 
                hazýrMý = false;
                Monitor.Pulse (this);
            }
        }
    }
    class MonitorB {
        private static Object kitleyici = new Object();
        private static int sayaç = 0;
        public int SayacýArtýr() {
            int syç;
            lock (kitleyici) {syç = ++sayaç;}
            return syç;
        }
        public void Say() {
            for(int i = 0; i < 4; i++) {
                Console.WriteLine ("Sicim({0}): sayaç = {1}", Thread.CurrentThread.Name, SayacýArtýr());
                Thread.Sleep (10);
            }
        }
        private const int limit2 = 6;
        private const int toplamiþ = 30;
        private static Object kitleyici2 = new Object();
        static void Ýþçi() {
            while (true) {
                lock (kitleyici2) {Monitor.Wait (kitleyici2);} //== Monitor.Wait (ortakKilit, Timeout.Infinite)
                Console.WriteLine ("{0} çalýþýyor...", Thread.CurrentThread.Name);
                Thread.Sleep (100);
            }
        }
        public static VeriTabaný vt = new VeriTabaný();
        public static void SicimMetodu1() {
            Console.WriteLine ("[SicimMetodu1] baþladý");
            Console.WriteLine ("[SicimMetodu1] " + "VeriTabaný.VeriKaydet()'i çaðýrýyor");
            try {vt.VeriKaydet ("X");} catch{}
            Console.WriteLine ("[SicimMetodu1] bitti");
        }
        public static void SicimMetodu2() {
            Console.WriteLine ("[SicimMetodu2] baþladý");
            Console.WriteLine ("[SicimMetodu2] " + "VeriTabaný.VeriKaydet()'i çaðýrýyor");
            try {vt.VeriKaydet ("W");} catch{}
            Console.WriteLine ("[SicimMetodu2] bitti");
        }
        static long sayaç2;
        static void Azaltýcý() {
            sayaç2 = 10;
            try {Monitor.Enter (sayaç2);
                if (sayaç2 < 11) {
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (sayaç2);
                    //Monitor.Wait (sayaç2);
                }
                while (sayaç2 > 0) {
                    long aracý = sayaç2; //Ýþgüzarlýk
                    aracý--;
                    Thread.Sleep (1);
                    sayaç2 = aracý;
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (sayaç2);
                }

            }finally {try {Monitor.Exit(sayaç2);}catch (Exception ht) {Console.WriteLine(ht.Message);}}
        }
        static void Artýrýcý() {
            sayaç2 = -1;
            try {Monitor.Enter (sayaç2);
                while (sayaç2 < 10) {
                    long aracý = sayaç2; //Ýþgüzarlýk
                    aracý++;
                    Thread.Sleep (1);
                    sayaç2 = aracý;
                    Console.Write (Thread.CurrentThread.Name+": ");
                    Console.WriteLine (sayaç2);
                }
                try {Monitor.Pulse(sayaç2);}catch (Exception ht) {Console.WriteLine(ht.Message);}

            }finally {try {Monitor.Exit(sayaç2);}catch (Exception ht) {Console.WriteLine(ht.Message);}}
        }
        static void Main() {
            Console.Write ("Monitor.Pulse(kilit) ortak kilitli sicimler arasýnda ardýþýk ve almaþýk tek-tek sýçramalar yapar.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("5 lock&join sicimin herbiri sayacý [1-->20] birer artýrmakta:");
            int limit = 5, i;
            Thread[] ipler = new Thread [limit];
            for(i=0;i<limit;i++) {
                MonitorB mB = new MonitorB();
                ipler [i] = new Thread (new ThreadStart (mB.Say));
                ipler [i].Name = "Ýp#" + i;
            }
            for(i=0;i<limit;i++) ipler [i].Start();
            for(i=0;i<limit;i++) ipler [i].Join();
            Console.WriteLine ("Tüm {0} adet ipler tamamlandý.", limit);

            Thread.Sleep (1000); Console.WriteLine ("\n6 lock&Pulse [1-->6].sicim birer sýçramalý 30 toplamiþ yapmakta:");
            Thread[] ipler2 = new Thread [limit2];
            for(i=0;i<limit2;i++) {
                ipler2 [i] = new Thread (Ýþçi);
                ipler2 [i].Name = (i+1) + ".sicim";
                ipler2 [i].IsBackground = true;
                ipler2 [i].Start();
            }
            for(i=0;i<toplamiþ;i++) {
                Thread.Sleep (200);
                lock (kitleyici2) {Monitor.Pulse (kitleyici2);}
            }

            Thread.Sleep (1000); Console.WriteLine ("\nAsenkron 2 sicim lock&join'siz zamanpaylaþýmlý 50'þer (X-W) veri kaydetmekte:");
            ThreadStart iþçi1 = new ThreadStart (SicimMetodu1);
            ThreadStart iþçi2 = new ThreadStart (SicimMetodu2);
            Thread ip1 = new Thread (iþçi1);
            Thread ip2 = new Thread (iþçi2);
            ip1.Start(); ip2.Start();

            Thread.Sleep (1000); Console.WriteLine ("\n2 join'li sicimin azaltan [10--0] ve artýran [0-->10] icraatlarý:");
            Thread[] ipler3 = {new Thread (new ThreadStart (Azaltýcý)), new Thread (new ThreadStart (Artýrýcý))};
            i = 1;
            foreach (Thread ip in ipler3) {
                ip.IsBackground = true;
                ip.Start();
                ip.Name = "Sayaç-" + i.ToString();
                Console.WriteLine ("{0} baþladý", ip.Name);
                Thread.Sleep (50);
                i++;
            }
            foreach (Thread ip in ipler3) ip.Join();

            Thread.Sleep (1000); Console.WriteLine ("\nMonitor.Pulse ile toplam 20 adet almaþýk üretim-->tüketim döngüsü:");
            Veri vr = new Veri();
            Üretici üret = new Üretici (vr);
            Tüketici tüket = new Tüketici (vr);
            ip1 = new Thread (new ThreadStart (üret.koþ));
            ip2 = new Thread (new ThreadStart (tüket.koþ));
            ip1.Start(); ip2.Start();

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}