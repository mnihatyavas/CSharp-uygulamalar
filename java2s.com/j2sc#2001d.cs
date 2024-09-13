// j2sc#2001d.cs: ThreadPriority, [vasýf], ThreadState örneði.

using System;
using System.Threading;
namespace ÇokluGörev {
    class SicimA {
        public int sayaç;
        public Thread ip;
        public SicimA (string ad) {//Kurucu
            sayaç = 0;
            ip = new Thread (this.koþ);
            ip.Name = ad;
        }
        void koþ() {
            Console.WriteLine ("["+ip.Name + " adlý sicim baþlýyor.]");
            do {sayaç++; Console.Write (ip.Name+" ");} while (sayaç < 100);
            Console.WriteLine ("\n["+ip.Name + " adlý sicim sonlanýyor.]");
        }
    }
    class SicimlerD {
        static void SicimMetodu() {
            Thread.CurrentThread.Name = "NihatSicimi";
            Thread ip = Thread.CurrentThread;
            Console.WriteLine ("Sicimin adý: {0}", ip.Name);
            Console.WriteLine ("Canlý mý? {0}", ip.IsAlive);
            Console.WriteLine ("Ýlk önceliði: {0}", ip.Priority);
            Console.WriteLine ("Durumu: {0}", ip.ThreadState);
            for (int i = 0; i < 100; i ++) {Console.Write (i+" "); Thread.Sleep (10);}
            Console.WriteLine ("\nSon önceliði: {0}", ip.Priority);
        }
        public static void GeriSayým() {
            Console.WriteLine ("Ýlk önceliði: {0}", Thread.CurrentThread.Priority);
            for (int i = 100; i > 0; i--) {Console.Write (i + " "); Thread.Sleep (10);}
        }
        public static void Yýllar() {for (int i = 1881; i <= 1938; i++) {Console.Write (i+" "); Thread.Sleep (10);} Console.Write("\r");}
        public static void SicimDurumu (Thread ip ) {
            Console.Write ("Aktüel durum: ");
            if ((ip.ThreadState & ThreadState.Aborted) == ThreadState.Aborted) Console.WriteLine ("Aborted=Kýrýldý");
            if ((ip.ThreadState & ThreadState.AbortRequested) == ThreadState.AbortRequested) Console.WriteLine ("AbortRequested=KýrýlmaTalepli");
            if ((ip.ThreadState & ThreadState.Background) == ThreadState.Background) Console.WriteLine ("Background=Arkaplanlý");
            if ((ip.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted | ThreadState.Aborted)) == 0) Console.WriteLine ("Running=Koþmakta");
            if ((ip.ThreadState & ThreadState.Stopped) == ThreadState.Stopped) Console.WriteLine ("Stopped: Sonlandý");
            if ((ip.ThreadState & ThreadState.StopRequested) == ThreadState.StopRequested) Console.WriteLine ("StopRequested=SonlanmaTalepli");
            if ((ip.ThreadState & ThreadState.Suspended) == ThreadState.Suspended) Console.WriteLine ("Suspended=Askýda");
            if ((ip.ThreadState & ThreadState.SuspendRequested) == ThreadState.SuspendRequested) Console.WriteLine ("SuspendRequested=AskýTalepli");
            if ((ip.ThreadState & ThreadState.Unstarted) == ThreadState.Unstarted) Console.WriteLine ("Unstarted=Baþlamadý");
            if ((ip.ThreadState & ThreadState.WaitSleepJoin) == ThreadState.WaitSleepJoin) Console.WriteLine ("WaitSleepJoin=UykuBlokBeklemede");
        }
        // [MTAThread]
        [STAThread] //Sicim vasýflarý
        static void Main() {
            Console.Write ("Sicim öncelikleri Lowest-->BelowNormal-->Normal-->AboveNormal-->Highest atanabilir.\nTuþ...");Console.ReadKey();Console.WriteLine ("\n");

            Console.WriteLine ("YüksekÖncelikli sicime daha önce ve çok görev zamaný tanýnýr:");
            SicimA snfA1 = new SicimA ("-DÖ-"); //DüþükÖncelik
            SicimA snfA2 = new SicimA ("*YÖ*"); //YüksekÖncelik
            snfA1.ip.Priority = ThreadPriority.BelowNormal;
            snfA2.ip.Priority = ThreadPriority.AboveNormal;
            snfA1.ip.Start(); snfA2.ip.Start();
            snfA1.ip.Join(); snfA2.ip.Join();
            Console.WriteLine (snfA1.ip.Name + " adlý sicim sayacý: " + snfA1.sayaç);
            Console.WriteLine (snfA2.ip.Name + " adlý sicim sayacý: " + snfA2.sayaç);

            Thread.Sleep (1000); Console.WriteLine ("\nGörev sýrasýnda önceliði Lowest-->Highest deðiþen sicim:");
            Thread ip = new Thread (new ThreadStart (SicimMetodu));
            ip.Priority = ThreadPriority.Lowest;
            ip.Start();
            Thread.Sleep (100); ip.Priority = ThreadPriority.Highest;

            Thread.Sleep (1000); Console.WriteLine ("\nGörev sýrasýnda önceliði Normal-->BelowNormal deðiþen sicim:");
            ip = new Thread (new ThreadStart (GeriSayým));
            ip.Priority = ThreadPriority.Normal;
            ip.Start();
            Thread.Sleep (500); Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine ("\nSon önceliði: {0}", Thread.CurrentThread.Priority);

            Thread.Sleep (1000); Console.WriteLine ("\nSicimin Start öncesi, sonrasý, görev icrasý ve kýrýlma durumlarý:");
            ip = new Thread (new ThreadStart (Yýllar)); SicimDurumu (ip);
            ip.Start(); SicimDurumu (ip);
            Yýllar(); SicimDurumu (ip);
            ip.Abort(); SicimDurumu (ip);

            Console.Write ("\nTuþ..."); Console.ReadKey();
        }
    } 
}